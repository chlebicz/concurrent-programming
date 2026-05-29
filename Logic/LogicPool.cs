using Data;
using System.Diagnostics;

namespace Logic
{
    public class LogicPool : ILogicPool
    {
        public IDataPool Pool { get; }
        private List<ILogicBall> _balls;
        public IReadOnlyCollection<ILogicBall> Balls => _balls.AsReadOnly();
        private readonly IBallFactory _ballFactory;
        public int BallRadius { get; } = 15;

        private List<Timer> _timers = new();

        public LogicPool(IDataPool pool, IBallFactory ballFactory)
        {
            Pool = pool;
            _balls = new();
            _ballFactory = ballFactory;
        }

        private bool _collidesWithAny(ILogicBall ball)
        {
            bool result = false;
            foreach (var otherBall in _balls)
            {
                if (ball != otherBall && ball.CollidesWith(otherBall))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public void Prepare(int balls)
        {
            for (int i = 0; i < balls; i++)
            {
                var dataBall = _ballFactory.CreateBall(i, 0, 0, BallRadius);
                LogicBall logicBall = new(dataBall);

                Stopwatch stopwatch = Stopwatch.StartNew();
                while (true)
                {
                    logicBall.Ball.X = Random.Shared.Next(BallRadius, Pool.XDim - BallRadius);
                    logicBall.Ball.Y = Random.Shared.Next(BallRadius, Pool.YDim - BallRadius);

                    if (!_collidesWithAny(logicBall))
                    {
                        break;
                    }

                    if (stopwatch.ElapsedMilliseconds >= 2000)
                    {
                        throw new Exception(
                            $"Couldn't create {balls} balls that don't intersect - probably not enough space"
                        );
                    }
                }

                Pool.AddBall(dataBall);
                _balls.Add(logicBall);
            }
        }

        public void StartMovement()
        {
            StopMovement();

            foreach (var ball in _balls)
            {
                Timer ballTimer = new Timer(MoveBallCallback, ball, 0, 16);
                _timers.Add(ballTimer);
            }
        }

        public void CheckWallCollision(ILogicBall ball)
        {
            if (ball.Ball.X <= BallRadius && ball.Ball.DirectionX < 0)
            {
                ball.Ball.X = BallRadius;
                ball.Ball.DirectionX *= -1;
            }
            if (ball.Ball.X >= Pool.XDim - BallRadius && ball.Ball.DirectionX > 0)
            {
                ball.Ball.X = Pool.XDim - BallRadius;
                ball.Ball.DirectionX *= -1;
            }
            if (ball.Ball.Y <= BallRadius && ball.Ball.DirectionY < 0)
            {
                ball.Ball.Y = BallRadius;
                ball.Ball.DirectionY *= -1;
            }
            if (ball.Ball.Y >= Pool.YDim - BallRadius && ball.Ball.DirectionY > 0)
            {
                ball.Ball.Y = Pool.YDim - BallRadius;
                ball.Ball.DirectionY *= -1;
            }
        }

        private void _handleCollision(ILogicBall ball, ILogicBall otherBall)
        {

            IDataBall b1 = ball.Ball;
            IDataBall b2 = otherBall.Ball;

            float dx = b1.X - b2.X;
            float dy = b1.Y - b2.Y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            if (distance == 0)
            {
                return;
            }

            float nx = dx / distance;
            float ny = dy / distance;

            float v1x = b1.DirectionX * b1.Velocity;
            float v1y = b1.DirectionY * b1.Velocity;
            float v2x = b2.DirectionX * b2.Velocity;
            float v2y = b2.DirectionY * b2.Velocity;

            float rvx = v1x - v2x;
            float rvy = v1y - v2y;

            float velAlongNormal = rvx * nx + rvy * ny;

            if (velAlongNormal > 0)
            {
                return;
            }

            float j = -2 * velAlongNormal;
            j /= (1f / b1.Mass) + (1f / b2.Mass);

            float impulseX = j * nx;
            float impulseY = j * ny;

            float newV1x = v1x + (impulseX / b1.Mass);
            float newV1y = v1y + (impulseY / b1.Mass);
            float newV2x = v2x - (impulseX / b2.Mass);
            float newV2y = v2y - (impulseY / b2.Mass);

            b1.Velocity = (float)Math.Sqrt(newV1x * newV1x + newV1y * newV1y);
            if (b1.Velocity > 0)
            {
                b1.DirectionX = newV1x / b1.Velocity;
                b1.DirectionY = newV1y / b1.Velocity;
            }

            b2.Velocity = (float)Math.Sqrt(newV2x * newV2x + newV2y * newV2y);
            if (b2.Velocity > 0)
            {
                b2.DirectionX = newV2x / b2.Velocity;
                b2.DirectionY = newV2y / b2.Velocity;
            }
        }

        public void CheckBallCollision(ILogicBall ball)
        {
            foreach (ILogicBall otherBall in _balls)
            {
                if (otherBall == ball)
                {
                    continue;
                }

                if (!otherBall.CollidesWith(ball))
                {
                    continue;
                }

                bool firstLockBall = ball.Ball.Number < otherBall.Ball.Number;
                object firstLock = firstLockBall ? ball : otherBall;
                object secondLock = firstLockBall ? otherBall : ball;

                lock (firstLock)
                {
                    lock (secondLock)
                    {
                        if (!otherBall.CollidesWith(ball))
                        {
                            continue;
                        }

                        _handleCollision(ball, otherBall);
                    }
                }
            }
        }

        private void MoveBallCallback(object? state)
        {
            if (state is not ILogicBall ball) return;

            lock (ball)
            {
                ball.Update();
                CheckWallCollision(ball);
            }
            CheckBallCollision(ball);
        }

        public void ClearBalls()
        {
            StopMovement();
            _balls.Clear();
        }

        public void StopMovement()
        {
            foreach (var timer in _timers)
            {
                timer.Dispose();
            }
            _timers.Clear();
        }

        public void Dispose()
        {
            StopMovement();
        }
    }
}
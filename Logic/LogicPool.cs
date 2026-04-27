using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class LogicPool : ILogicPool
    {
        public IDataPool Pool { get; }
        private List<ILogicBall> _balls;
        public IReadOnlyCollection<ILogicBall> Balls => _balls.AsReadOnly();
        private readonly IBallFactory _ballFactory;
        public int BallRadius { get; } = 10;

        public LogicPool(IDataPool pool, IBallFactory ballFactory)
        {
            Pool = pool;
            _balls = new();
            _ballFactory = ballFactory;
        }

        public void Prepare(int balls)
        {
            for (int i = 0; i < balls; i++)
            {
                var dataBall = _ballFactory.CreateBall(
                    i,
                    Random.Shared.Next(BallRadius, Pool.XDim - BallRadius),
                    Random.Shared.Next(BallRadius, Pool.YDim - BallRadius),
                    BallRadius
                );

                Pool.AddBall(dataBall);

                LogicBall logicBall = new LogicBall(dataBall);

                while (logicBall.DirectionX == 0 && logicBall.DirectionY == 0)
                {
                    logicBall.DirectionX = Random.Shared.Next(-1, 2);
                    logicBall.DirectionY = Random.Shared.Next(-1, 2);
                }

                _balls.Add(logicBall);
            }
        }

        public void Update()
        {
            foreach (var ball in _balls)
            {
                ball.Update();
                if (ball.Ball.X <= BallRadius)
                {
                    ball.Ball.X = BallRadius;
                    ball.DirectionX *= -1;
                }
                if (ball.Ball.X >= Pool.XDim - BallRadius)
                {
                    ball.Ball.X = Pool.XDim - BallRadius;
                    ball.DirectionX *= -1;
                }
                if (ball.Ball.Y <= BallRadius)
                {
                    ball.Ball.Y = BallRadius;
                    ball.DirectionY *= -1;
                }
                if (ball.Ball.Y >= Pool.YDim - BallRadius)
                {
                    ball.Ball.Y = Pool.YDim - BallRadius;
                    ball.DirectionY *= -1;
                }
            }
        }

        public void ClearBalls()
        {
            _balls.Clear();
        }
    }
}

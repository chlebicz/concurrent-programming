using Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public class LogicPool : ILogicPool, IDisposable
    {
        public IDataPool Pool { get; }
        private List<ILogicBall> _balls;
        public IReadOnlyCollection<ILogicBall> Balls => _balls.AsReadOnly();
        private readonly IBallFactory _ballFactory;
        public int BallRadius { get; } = 10;

        private CancellationTokenSource _cts;

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
                _balls.Add(logicBall);
            }
        }

        public void StartMovement()
        {
            _cts = new CancellationTokenSource();

            foreach (var ball in _balls)
            {
                Task.Run(() => MoveBallLoop(ball, _cts.Token));
            }
        }

        private async Task MoveBallLoop(ILogicBall ball, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                ball.Update();

                if (ball.Ball.X <= BallRadius)
                {
                    ball.Ball.X = BallRadius;
                    ball.Ball.DirectionX *= -1;
                }
                if (ball.Ball.X >= Pool.XDim - BallRadius)
                {
                    ball.Ball.X = Pool.XDim - BallRadius;
                    ball.Ball.DirectionX *= -1;
                }
                if (ball.Ball.Y <= BallRadius)
                {
                    ball.Ball.Y = BallRadius;
                    ball.Ball.DirectionY *= -1;
                }
                if (ball.Ball.Y >= Pool.YDim - BallRadius)
                {
                    ball.Ball.Y = Pool.YDim - BallRadius;
                    ball.Ball.DirectionY *= -1;
                }

                await Task.Delay(16, token);
            }
        }

        public void ClearBalls()
        {
            StopMovement();
            _balls.Clear();
        }

        public void StopMovement()
        {
            _cts?.Cancel();
        }

        public void Dispose()
        {
            _cts?.Cancel();
            _cts?.Dispose();
        }
    }
}
using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class LogicPool
    {
        public DataPool Pool { get; }

        private List<LogicBall> logicBalls;

        public LogicPool(int xDim, int yDim, int balls)
        {
            Pool = new DataPool(xDim, yDim);
            logicBalls = new List<LogicBall>();
            Prepare(balls);
        }

        public void Prepare(int balls)
        {
            for (int i = 0; i < balls; i++)
            {
                DataBall dataBall = new DataBall(
                    i, 
                    Random.Shared.Next(DataBall.Radius, Pool.XDim-DataBall.Radius), 
                    Random.Shared.Next(DataBall.Radius, Pool.YDim-DataBall.Radius)
                );

                Pool.AddBall(dataBall);

                LogicBall logicBall = new LogicBall(dataBall);

                logicBall.DirectionX = Random.Shared.Next(-1, 2);
                logicBall.DirectionY = Random.Shared.Next(-1, 2);

                logicBalls.Add(logicBall);
            }
        }

        public void Update()
        {
            foreach (var ball in logicBalls)
            {
                ball.Update();
                if (ball.Ball.X <= DataBall.Radius)
                {
                    ball.Ball.X = DataBall.Radius;
                    ball.DirectionX *= -1;
                }
                if (ball.Ball.X >= Pool.XDim - DataBall.Radius)
                {
                    ball.Ball.X = Pool.XDim - DataBall.Radius;
                    ball.DirectionX *= -1;
                }
                if (ball.Ball.Y <= DataBall.Radius)
                {
                    ball.Ball.Y = DataBall.Radius;
                    ball.DirectionY *= -1;
                }
                if (ball.Ball.Y >= Pool.YDim - DataBall.Radius)
                {
                    ball.Ball.Y = Pool.YDim - DataBall.Radius;
                    ball.DirectionY *= -1;
                }
            }
        }
    }
}

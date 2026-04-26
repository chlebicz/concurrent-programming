using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DataPool
    {
        public int XDim {  get; }
        public int YDim { get; }
        public List<Ball> balls;


        public DataPool(int xDim, int yDim)
        {
            XDim = xDim;
            YDim = yDim;
            balls = new List<Ball>();
        }

        public void AddBall(Ball ball)
        {
            this.balls.Add(ball);
        }

        public void RemoveBall(Ball ball)
        {
            this.balls.Remove(ball);
        }
    }
}

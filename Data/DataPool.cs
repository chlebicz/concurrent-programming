using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DataPool
    {
        public int XDim {  get; }
        public int YDim { get; }
        private List<DataBall> balls;


        public DataPool(int xDim, int yDim)
        {
            XDim = xDim;
            YDim = yDim;
            balls = new List<DataBall>();
        }

        public void AddBall(DataBall ball)
        {
            this.balls.Add(ball);
        }

        public void RemoveBall(DataBall ball)
        {
            this.balls.Remove(ball);
        }
    }
}

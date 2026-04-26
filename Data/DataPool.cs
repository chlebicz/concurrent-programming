using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DataPool : IDataPool
    {
        public int XDim { get; }
        public int YDim { get; }
        private List<IDataBall> balls;
        public IReadOnlyCollection<IDataBall> Balls => balls.AsReadOnly();

        public DataPool(int xDim, int yDim)
        {
            XDim = xDim;
            YDim = yDim;
            balls = new List<IDataBall>();
        }

        public void AddBall(IDataBall ball)
        {
            this.balls.Add(ball);
        }

        public void RemoveBall(IDataBall ball)
        {
            this.balls.Remove(ball);
        }
    }
}

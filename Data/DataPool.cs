using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DataPool : IDataPool
    {
        public int XDim { get; }
        public int YDim { get; }
        private List<IDataBall> _balls;
        public IReadOnlyCollection<IDataBall> Balls => _balls.AsReadOnly();

        public DataPool(int xDim, int yDim)
        {
            XDim = xDim;
            YDim = yDim;
            _balls = new List<IDataBall>();
        }

        public void AddBall(IDataBall ball)
        {
            _balls.Add(ball);
        }

        public void RemoveBall(IDataBall ball)
        {
            _balls.Remove(ball);
        }
    }
}

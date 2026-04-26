using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicTest
{
    internal class FakeDataPool : IDataPool
    {
        public int XDim { get; }
        public int YDim { get; }

        private List<IDataBall> balls;
        public IReadOnlyCollection<IDataBall> Balls => balls.AsReadOnly();

        public FakeDataPool(int xDim, int yDim)
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

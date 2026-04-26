using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace DataTest
{
    public class DataPoolTest
    {
        [Fact]
        public void CreatePoolTest()
        {
            DataPool pool = new DataPool(100, 120);
            Assert.Equal(100, pool.XDim);
            Assert.Equal(120, pool.YDim);
        }

        [Fact]
        public void AddRemoveBallTest()
        {
            DataPool pool = new DataPool(100, 120);
            IBallFactory ballFactory = new FakeBallFactory();
            Assert.Empty(pool.Balls);
            IDataBall ball = ballFactory.CreateBall(5, 5, 5, 5);
            pool.AddBall(ball);
            Assert.Single(pool.Balls);
            pool.RemoveBall(ball);
            Assert.Empty(pool.Balls);
        }
    }
}

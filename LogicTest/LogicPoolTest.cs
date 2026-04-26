using Data;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicTest
{
    public class LogicPoolTest
    {
        [Fact]
        public void CreateLogicPoolTest()
        {
            IBallFactory factory = new FakeBallFactory();
            IDataPool pool = new FakeDataPool(100, 100);
            ILogicPool logicPool = new LogicPool(pool, factory);
            Assert.Equal(pool, logicPool.Pool);
        }

        [Fact]

        public void PrepareTest()
        {
            IBallFactory factory = new FakeBallFactory();
            IDataPool pool = new FakeDataPool(100, 100);
            ILogicPool logicPool = new LogicPool(pool, factory);
            logicPool.Prepare(5);
            Assert.Equal(5, logicPool.Balls.Count);
            Assert.All(logicPool.Balls, ball =>
            {
                Assert.InRange(ball.Ball.X, ball.Ball.Radius, logicPool.Pool.XDim - ball.Ball.Radius);
                Assert.InRange(ball.Ball.Y, ball.Ball.Radius, logicPool.Pool.YDim - ball.Ball.Radius);
            });
        }
    }
}

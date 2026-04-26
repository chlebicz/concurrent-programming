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
    }
}

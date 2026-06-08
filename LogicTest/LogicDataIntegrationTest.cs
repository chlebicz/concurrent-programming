using Data;
using Logic;
using Xunit;

namespace LogicTest
{
    public class LogicDataIntegrationTest
    {
        [Fact]
        public void LogicPool_Prepare_ShouldPopulateRealDataPool()
        {
            IBallFactory realFactory = new BallFactory();
            IDataPool realDataPool = new DataPool(500, 500);
            ILogicPool logicPool = new LogicPool(realDataPool, realFactory);
            int ballCount = 10;

            logicPool.Prepare(ballCount);

            Assert.Equal(ballCount, logicPool.Balls.Count);
            Assert.Equal(ballCount, realDataPool.Balls.Count);
            
            foreach (var logicBall in logicPool.Balls)
            {
                var dataBall = logicBall.Ball;
                
                Assert.Contains(dataBall, realDataPool.Balls);

                Assert.InRange(dataBall.X, dataBall.Radius, realDataPool.XDim - dataBall.Radius);
                Assert.InRange(dataBall.Y, dataBall.Radius, realDataPool.YDim - dataBall.Radius);
            }
        }
    }
}

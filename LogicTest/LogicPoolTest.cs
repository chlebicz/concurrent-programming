using Data;
using Logic;

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

        [Fact]
        public void CheckWallCollisionTest_ShouldReverseDirection()
        {
            IBallFactory factory = new FakeBallFactory();
            IDataPool pool = new FakeDataPool(500, 500);
            LogicPool logicPool = new LogicPool(pool, factory);

            logicPool.Prepare(1);
            var logicBall = logicPool.Balls.First();

            logicBall.Ball.X = 5;
            logicBall.Ball.DirectionX = -1f;

            logicPool.CheckWallCollision(logicBall);

            Assert.Equal(logicPool.BallRadius, logicBall.Ball.X);
            Assert.Equal(1f, logicBall.Ball.DirectionX);
        }

        [Fact]
        public void CheckBallCollisionTest_ShouldBounceOffEachOther()
        {
            IBallFactory factory = new FakeBallFactory();
            IDataPool pool = new FakeDataPool(500, 500);
            LogicPool logicPool = new LogicPool(pool, factory);

            logicPool.Prepare(2);
            var ball1 = logicPool.Balls.ElementAt(0);
            var ball2 = logicPool.Balls.ElementAt(1);

            ball1.Ball.X = 50; ball1.Ball.Y = 50;
            ball1.Ball.DirectionX = 1f; 
            ball1.Ball.DirectionY = 0f;
            ball1.Ball.Velocity = 5f;

            ball2.Ball.X = 70; ball2.Ball.Y = 50;
            ball2.Ball.DirectionX = -1f;
            ball2.Ball.DirectionY = 0f;
            ball2.Ball.Velocity = 5f;

            logicPool.CheckBallCollision(ball1);

            Assert.True(ball1.Ball.DirectionX < 0);
            Assert.True(ball2.Ball.DirectionX > 0);
        }

        [Fact]
        public void CheckBallCollisionTest_ShouldIgnoreIfMovingApart()
        {
            IBallFactory factory = new FakeBallFactory();
            IDataPool pool = new FakeDataPool(500, 500);
            LogicPool logicPool = new LogicPool(pool, factory);

            logicPool.Prepare(2);
            var ball1 = logicPool.Balls.ElementAt(0);
            var ball2 = logicPool.Balls.ElementAt(1);

            ball1.Ball.X = 50; ball1.Ball.Y = 50;
            ball1.Ball.DirectionX = -1f;
            ball1.Ball.DirectionY = 0f;
            ball1.Ball.Velocity = 5f;

            ball2.Ball.X = 70; ball2.Ball.Y = 50;
            ball2.Ball.DirectionX = 1f;
            ball2.Ball.DirectionY = 0f;
            ball2.Ball.Velocity = 5f;

            logicPool.CheckBallCollision(ball1);

            Assert.Equal(-1f, ball1.Ball.DirectionX);
            Assert.Equal(1f, ball2.Ball.DirectionX);
        }
    }
}
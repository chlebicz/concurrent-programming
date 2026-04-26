using Data;

namespace UnitTests
{
    public class BallTest
    {
        [Fact]
        public void CreateBallTest()
        {
            Ball ball = new Ball(8, 5, 7, 0);
            Assert.Equal(8, ball.Number);
            Assert.Equal(5, ball.X);
            Assert.Equal(7, ball.Y);
            Assert.Equal(0, ball.Direction);
        }
    }
}

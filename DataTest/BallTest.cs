using Data;

namespace UnitTests
{
    public class BallTest
    {
        [Fact]
        public void CreateBallTest()
        {
            DataBall ball = new DataBall(8, 5, 7);
            Assert.Equal(8, ball.Number);
            Assert.Equal(5, ball.X);
            Assert.Equal(7, ball.Y);
        }
    }
}

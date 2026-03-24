using Data;

namespace UnitTests
{
    public class BallTest
    {
        [Fact]
        public void CreateBallTest()
        {
            Ball ball = new Ball(8, 5, 7);
            Assert.Equal(8, ball.GetNumber());
            Assert.Equal(5, ball.GetXPos());
            Assert.Equal(7, ball.GetYPos());
        }
    }
}

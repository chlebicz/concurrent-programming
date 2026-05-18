using Data;

namespace DataTest
{
    public class DataBallTest
    {
        [Fact]
        public void CreateBallTest()
        {
            DataBall ball = new DataBall(8, 5, 7, 10);
            Assert.Equal(8, ball.Number);
            Assert.Equal(5, ball.X);
            Assert.Equal(7, ball.Y);
            Assert.Equal(10, ball.Radius);
            Assert.Equal(1, ball.DirectionX);
            Assert.Equal(0, ball.DirectionY);
            Assert.Equal(2, ball.Velocity);
        }
    }
}

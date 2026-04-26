using Data;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicTest
{
    public class LogicBallTest
    {
        [Fact]
        public void CreateBallTest()
        {
            IBallFactory factory = new FakeBallFactory();
            IDataBall dataBall = factory.CreateBall(5, 5, 5, 5);
            LogicBall ball = new LogicBall(dataBall);
            Assert.Equal(dataBall, ball.Ball);
        }

        [Fact]
        public void UpdateBallTest()
        {
            IBallFactory factory = new FakeBallFactory();
            IDataBall dataBall = factory.CreateBall(5, 5, 5, 5);
            LogicBall ball = new LogicBall(dataBall);
            ball.DirectionX = 1;
            ball.DirectionY = -1;
            ball.Update();
            Assert.Equal(10, ball.Ball.X);
            Assert.Equal(-10, ball.Ball.Y);
        }
    }
}

using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicTest
{
    internal class FakeBallFactory : IBallFactory
    {
        public IDataBall CreateBall(int number, int xPos, int yPos, int radius)
        {
            return new FakeDataBall(number, xPos, yPos, radius);
        }
    }
}

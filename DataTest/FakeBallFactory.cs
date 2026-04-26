using Data;
using System;
using System.Collections.Generic;
using System.Text;
using DataTest;

namespace DataTest
{
    internal class FakeBallFactory : IBallFactory
    {
        public IDataBall CreateBall(int number, int xPos, int yPos, int radius)
        {
            return new FakeDataBall();
        }
    }
}

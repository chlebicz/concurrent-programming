using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicTest
{
    internal class FakeDataBall : IDataBall
    {
        public int Number { get; set; } = 0;
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int Radius { get; set; } = 0;
    }
}

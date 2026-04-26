using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTest
{
    internal class FakeDataBall : IDataBall
    {
        public int Number { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }
    }
}

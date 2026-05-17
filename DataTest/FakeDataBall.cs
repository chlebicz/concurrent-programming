using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTest
{
    internal class FakeDataBall : IDataBall
    {
        public int Number { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public int Radius { get; set; }
        public float DirectionX { get; set; } = 1;
        public float DirectionY { get; set; } = 0;
        public int Mass { get; } = 1;
        public float Velocity { get; set; } = 10;
    }
}

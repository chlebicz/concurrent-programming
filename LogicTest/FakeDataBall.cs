using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicTest
{
    internal class FakeDataBall : IDataBall
    {
        public int Number { get; set; } = 0;
        public float X { get; set; } = 0;
        public float Y { get; set; } = 0;
        public int Radius { get; set; } = 0;
        public float DirectionX { get; set; } = 0;
        public float DirectionY { get; set; } = 0;
        public int Mass { get; } = 0;
        public float Velocity { get; set; } = 10;
    }
}

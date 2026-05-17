using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IDataBall
    {
        public int Number { get; }
        public int Radius { get; }
        public int Mass { get; }

        public float X { get; set; }
        public float Y { get; set; }
        public float DirectionX { get; set; }
        public float DirectionY { get; set; }
        public float Velocity { get; set; }
    }
}

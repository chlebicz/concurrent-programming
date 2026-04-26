using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IDataBall
    {
        public int Number { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Logic
{
    public class LogicBall
    {
        public DataBall dataBall {  get; }
        public int DirectionX { get; set; } = 0;
        public int DirectionY { get; set; } = 0;

        public LogicBall(DataBall dataBall)
        {
            this.dataBall = dataBall;
        }

        public void Update()
        {
            dataBall.X += 10 * DirectionX;
            dataBall.Y += 10 * DirectionY;
        }
    }
}

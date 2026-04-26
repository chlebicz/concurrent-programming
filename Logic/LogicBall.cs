using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Logic
{
    public class LogicBall
    {
        public DataBall Ball {  get; }
        public int DirectionX { get; set; } = 0;
        public int DirectionY { get; set; } = 0;

        public LogicBall(DataBall dataBall)
        {
            this.Ball = dataBall;
        }

        public void Update()
        {
            Ball.X += 10 * DirectionX;
            Ball.Y += 10 * DirectionY;
        }
    }
}

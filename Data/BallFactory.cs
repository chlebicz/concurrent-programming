using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class BallFactory : IBallFactory
    {
        public IDataBall CreateBall(int number, int xPos, int yPos, int radius)
        {
            return new DataBall(number, xPos, yPos, radius);
        }
    }
}

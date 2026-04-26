using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IBallFactory
    {
        IDataBall CreateBall(int number, int xPos, int yPos, int radius);
    }
}

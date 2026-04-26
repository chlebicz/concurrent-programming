using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Pool
    {
        private List<DataBall> balls;

        public Pool()
        {
            balls = new List<DataBall>();

            int ballNumber = 0;
            for (int i = 5; i >= 0; --i) // level
            {
                int yPos = i * DataBall.Diameter;
                int spacing = (5 - i) * DataBall.Diameter;

                for (int j = 1; j <= i; ++j)
                {
                    int previousBalls = (j - 1) * DataBall.Diameter;
                    ++ballNumber;
                    balls.Add(new DataBall(ballNumber, spacing + previousBalls, yPos));
                }
            }
        }

        public List<DataBall> GetBalls()
        {
            return balls;
        }
    }
}

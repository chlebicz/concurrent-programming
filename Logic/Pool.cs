using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Pool
    {
        private List<Ball> balls;

        public Pool()
        {
            balls = new List<Ball>();

            int ballNumber = 0;
            for (int i = 5; i >= 0; --i) // level
            {
                int yPos = i * Ball.GetSize();
                int spacing = (5 - i) * Ball.GetSize();

                for (int j = 1; j <= i; ++j)
                {
                    int previousBalls = (j - 1) * Ball.GetSize();
                    ++ballNumber;
                    balls.Add(new Ball(ballNumber, spacing + previousBalls, yPos));
                }
            }
        }

        public List<Ball> GetBalls()
        {
            return balls;
        }
    }
}

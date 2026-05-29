using Data;

namespace Logic
{
    public class LogicBall : ILogicBall
    {
        public IDataBall Ball { get; }

        public LogicBall(IDataBall dataBall)
        {
            Ball = dataBall;
            RandomiseDirection();
        }

        public void RandomiseDirection()
        {
            // generate random vector of length 1
            Ball.DirectionX = 2 * Random.Shared.NextSingle() - 1;
            Ball.DirectionY = (float) Math.Sqrt(1 - Ball.DirectionX * Ball.DirectionX);
            if (Random.Shared.NextSingle() >= 0.5)
            {
                Ball.DirectionY *= -1;
            }
        }

        public void Update(float deltaTime)
        {
            // We multiply by a constant to maintain reasonable speed on screen
            // Assuming deltaTime is in seconds
            Ball.X += Ball.Velocity * Ball.DirectionX * deltaTime * 100;
            Ball.Y += Ball.Velocity * Ball.DirectionY * deltaTime * 100;
        }

        public bool CollidesWith(ILogicBall other)
        {
            float xDiff = other.Ball.X - Ball.X;
            float yDiff = other.Ball.Y - Ball.Y;
            float distance = (float) Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
            return distance <= Ball.Radius + other.Ball.Radius;
        }
    }
}

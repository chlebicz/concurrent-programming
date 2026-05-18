using Data;

namespace LogicTest
{
    internal class FakeDataBall : IDataBall
    {
        public int Number { get; set; } = 0;
        public float X { get; set; } = 0;
        public float Y { get; set; } = 0;
        public int Radius { get; set; } = 10;
        public int Mass { get; } = 1;
        public float DirectionX { get; set; } = 1;
        public float DirectionY { get; set; } = 0;
        public float Velocity { get; set; } = 1;

        public FakeDataBall(int number, int xPos, int yPos, int radius)
        {
            Number = number;
            X = xPos;
            Y = yPos;
            Radius = radius;
        }
    }
}

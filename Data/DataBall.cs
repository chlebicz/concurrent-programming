namespace Data
{
    public class DataBall : IDataBall
    {
        public int Number { get; }
        public float X { get; set; }
        public float Y { get; set; }
        public int Radius { get; } = 10;
        public int Mass { get; } = 1;

        public float DirectionX { get; set; } = 1;
        public float DirectionY { get; set; } = 0;

        public float Velocity { get; set; } = 10;

        public DataBall(int number, int xPos, int yPos, int radius)
        {
            Number = number;
            X = xPos;
            Y = yPos;
            Radius = radius;
        }
    }
}

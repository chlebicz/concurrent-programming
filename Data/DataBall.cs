namespace Data
{
    public class DataBall : IDataBall
    {
        public int Number { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; } = 10;
        
        public DataBall(int number, int xPos, int yPos, int radius)
        {
            Number = number;
            X = xPos;
            Y = yPos;
            Radius = radius;
        }
    }
}

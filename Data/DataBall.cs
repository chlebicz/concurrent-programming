namespace Data
{
    public class DataBall
    {
        public int Number { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public static int Diameter { get; } = 10;
        
        public DataBall(int number, int xPos, int yPos)
        {
            Number = number;
            X = xPos;
            Y = yPos;
        }
    }
}

namespace Data
{
    public class Ball
    {
        public int Number { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public static int Diameter { get; } = 10;
        public int Direction { get; set; }
        
        public Ball(int number, int xPos, int yPos, int direction)
        {
            Number = number;
            X = xPos;
            Y = yPos;
            Direction = direction;
        }
    }
}

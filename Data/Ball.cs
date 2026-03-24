namespace Data
{
    public class Ball
    {
        private int number;
        private int xPos;
        private int yPos;
        private static int size = 10;
        
        public Ball(int number, int xPos, int yPos)
        {
            this.number = number;
            this.xPos = xPos;
            this.yPos = yPos;
        }

        public int GetNumber()
        {
            return number;
        }

        public int GetXPos()
        {
            return xPos;
        }

        public int GetYPos()
        {  
            return yPos;
        }

        public static int GetSize()
        {
            return size;
        }

        public void SetXPos(int xPos)
        {
            this.xPos = xPos;
        }

        public void SetYPos(int yPos)
        {
            this.yPos = yPos;
        }

    }
}

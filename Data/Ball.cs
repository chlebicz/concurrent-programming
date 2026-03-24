namespace Data
{
    public class Ball
    {
        private int number;
        private int xPos;
        private int yPos;
        
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

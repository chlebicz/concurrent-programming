namespace Data
{
    public class DataBallStateDto
    {
        public DateTime Timestamp { get; set; }
        public int Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Vx { get; set; }
        public float Vy { get; set; }

        public DataBallStateDto(IDataBall ball)
        {
            Timestamp = DateTime.Now;
            Id = ball.Number;
            X = ball.X;
            Y = ball.Y;
            Vx = ball.DirectionX * ball.Velocity;
            Vy = ball.DirectionY * ball.Velocity;
        }
    }
}
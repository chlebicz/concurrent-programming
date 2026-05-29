namespace Logic
{
    public class BallStateDto
    {
        public DateTime Timestamp { get; set; }
        public int Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Vx { get; set; }
        public float Vy { get; set; }

        public BallStateDto(ILogicBall ball)
        {
            Timestamp = DateTime.Now;
            Id = ball.Ball.Number;
            X = ball.Ball.X;
            Y = ball.Ball.Y;
            Vx = ball.Ball.DirectionX * ball.Ball.Velocity;
            Vy = ball.Ball.DirectionY * ball.Ball.Velocity;
        }
    }
}
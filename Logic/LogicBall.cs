using Data;
using System.Diagnostics;

namespace Logic
{
    public class LogicBall : ILogicBall
    {
        public IDataBall Ball { get; }
        private Timer? _timer;
        private Stopwatch _stopwatch;
        private readonly Action<ILogicBall>? _onMove;

        public LogicBall(IDataBall dataBall, Action<ILogicBall>? onMove = null)
        {
            Ball = dataBall;
            _onMove = onMove;
            _stopwatch = new Stopwatch();
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

        public event EventHandler<BallEventArgs>? PositionChanged;

        public void Start()
        {
            Stop();
            _stopwatch.Restart();
            _timer = new Timer(MoveCallback, null, 0, 16);
        }

        public void Stop()
        {
            _timer?.Dispose();
            _timer = null;
            _stopwatch.Stop();
        }

        private void MoveCallback(object? state)
        {
            float deltaTime = (float)_stopwatch.Elapsed.TotalSeconds;
            _stopwatch.Restart();

            lock (this)
            {
                Ball.X += Ball.Velocity * Ball.DirectionX * deltaTime;
                Ball.Y += Ball.Velocity * Ball.DirectionY * deltaTime;
            }

            _onMove?.Invoke(this);
            PositionChanged?.Invoke(this, new BallEventArgs(this));
        }

        public bool CollidesWith(ILogicBall other)
        {
            float xDiff = other.Ball.X - Ball.X;
            float yDiff = other.Ball.Y - Ball.Y;
            float distance = (float) Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
            return distance <= Ball.Radius + other.Ball.Radius;
        }

        public void Dispose()
        {
            Stop();
        }
    }
}

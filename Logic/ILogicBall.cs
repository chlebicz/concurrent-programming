using Data;

namespace Logic
{
    public class BallEventArgs : EventArgs
    {
        public ILogicBall Ball { get; }
        public BallEventArgs(ILogicBall ball)
        {
            Ball = ball;
        }
    }

    public interface ILogicBall : IDisposable
    {
        public IDataBall Ball { get; }
        public bool CollidesWith(ILogicBall other);
        public event EventHandler<BallEventArgs>? PositionChanged;
        void Start();
        void Stop();
    }
}

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

    public interface ILogicBall
    {
        public IDataBall Ball { get; }
        public void Update(float deltaTime);
        public bool CollidesWith(ILogicBall other);
        public event EventHandler<BallEventArgs>? PositionChanged;
    }
}

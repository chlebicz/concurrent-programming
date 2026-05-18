using Data;

namespace Logic
{
    public interface ILogicPool : IDisposable
    {
        public IDataPool Pool { get; }
        public void Prepare(int balls);
        public void ClearBalls();
        public IReadOnlyCollection<ILogicBall> Balls { get; }

        public void StartMovement();
        public void StopMovement();
    }
}

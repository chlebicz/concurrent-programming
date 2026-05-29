using Data;

namespace Logic
{
    public interface ILogicBall
    {
        public IDataBall Ball { get; }
        public void Update(float deltaTime);
        public bool CollidesWith(ILogicBall other);
    }
}

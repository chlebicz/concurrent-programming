namespace Data
{
    public interface IDataPool
    {
        int XDim { get; }
        int YDim { get; }
        public IReadOnlyCollection<IDataBall> Balls { get; }
        void AddBall(IDataBall ball);
        void RemoveBall(IDataBall ball);
    }
}

namespace Data
{
    public interface IDataPool
    {
        int XDim { get; }
        int YDim { get; }
        IReadOnlyCollection<IDataBall> Balls { get; }
        void AddBall(IDataBall ball);
        void RemoveBall(IDataBall ball);
    }
}

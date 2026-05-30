using Logic;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace PresentationModel
{
    public class ModelPool : IModelPool
    {
        private readonly ILogicPool _logicPool;
        private ObservableCollection<ModelBall> _balls;
        private readonly Dispatcher _dispatcher;

        private void _updateBalls()
        {
            for (int i = 0; i < _logicPool.Balls.Count; i++)
            {
                var lBall = _logicPool.Balls.ElementAt(i);
                var mBall = _balls[i];
                mBall.RadiusX = _mapX(lBall.Ball.Radius);
                mBall.RadiusY = _mapY(lBall.Ball.Radius);
                mBall.X = _mapX(lBall.Ball.X);
                mBall.Y = _mapY(lBall.Ball.Y);
            }
        }

        private int _canvasWidth;
        public int CanvasWidth
        {
            get => _canvasWidth;
            set
            {
                _canvasWidth = value;
                _updateBalls();
            }
        }

        private int _canvasHeight;
        public int CanvasHeight {
            get => _canvasHeight;
            set
            {
                _canvasHeight = value;
                _updateBalls();
            }
        }

        public ModelPool(ILogicPool logicPool)
        {
            _logicPool = logicPool;
            _balls = new ObservableCollection<ModelBall>();
            _dispatcher = Dispatcher.CurrentDispatcher;
        }

        public void Start(int ballCount)
        {
            if (_balls.Count != 0)
            {
                _logicPool.ClearBalls();
            }
            _logicPool.Prepare(ballCount);

            _balls.Clear();
            foreach (var lBall in _logicPool.Balls)
            {
                var mBall = new ModelBall
                {
                    RadiusX = _mapX(lBall.Ball.Radius),
                    RadiusY = _mapY(lBall.Ball.Radius),
                    X = _mapX(lBall.Ball.X),
                    Y = _mapY(lBall.Ball.Y)
                };
                _balls.Add(mBall);

                lBall.PositionChanged += (s, e) =>
                {
                    _dispatcher.BeginInvoke(() =>
                    {
                        mBall.X = _mapX(e.Ball.Ball.X);
                        mBall.Y = _mapY(e.Ball.Ball.Y);
                    });
                };
            }

            _logicPool.StartMovement();
        }

        public void Stop()
        {
            _logicPool.StopMovement();
        }

        public ObservableCollection<ModelBall> GetBalls() => _balls;

        private int _mapX(float x)
        {
            return (int)(x * CanvasWidth / _logicPool.Pool.XDim);
        }

        private int _mapY(float y)
        {
            return (int)(y * CanvasHeight / _logicPool.Pool.YDim);
        }

        public void Dispose()
        {
            _logicPool.Dispose();
        }
    }
}

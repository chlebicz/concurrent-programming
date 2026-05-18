using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Text;

namespace PresentationModel
{
    internal class ModelPool : IModelPool
    {
        private readonly ILogicPool _logicPool;
        private readonly DispatcherTimer _timer;
        private ObservableCollection<ModelBall> _balls;

        private void _updateBallRadii()
        {
            for (int i = 0; i < _logicPool.Balls.Count; i++)
            {
                _balls[i].RadiusX = _mapX(_logicPool.Balls.ElementAt(i).Ball.Radius);
                _balls[i].RadiusY = _mapY(_logicPool.Balls.ElementAt(i).Ball.Radius);
            }
        }

        private int _canvasWidth;
        public int CanvasWidth
        {
            get => _canvasWidth;
            set
            {
                _canvasWidth = value;
                _updateBallRadii();
            }
        }

        private int _canvasHeight;
        public int CanvasHeight {
            get => _canvasHeight;
            set
            {
                _canvasHeight = value;
                _updateBallRadii();
            }
        }

        public ModelPool(ILogicPool logicPool)
        {
            _logicPool = logicPool;
            _balls = new ObservableCollection<ModelBall>();

            _timer = new DispatcherTimer();
            _timer.Interval = System.TimeSpan.FromMilliseconds(16);
            _timer.Tick += (s, e) => UpdateModel();
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
            }

            _logicPool.StartMovement();

            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
            _logicPool.StopMovement();
        }

        public ObservableCollection<ModelBall> GetBalls() => _balls;

        private void UpdateModel()
        {
            for (int i = 0; i < _logicPool.Balls.Count; i++)
            {
                var ball = _logicPool.Balls.ElementAt(i);
                _balls[i].X = _mapX(ball.Ball.X);
                _balls[i].Y = _mapY(ball.Ball.Y);
            }
        }

        private int _mapX(float x)
        {
            return (int)(x * CanvasWidth / _logicPool.Pool.XDim);
        }

        private int _mapY(float y)
        {
            return (int)(y * CanvasHeight / _logicPool.Pool.YDim);
        }
    }
}

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

        public int CanvasWidth { get; set; }
        public int CanvasHeight { get; set; }

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
                    Radius = lBall.Ball.Radius,
                    X = MapX(lBall.Ball.X),
                    Y = MapY(lBall.Ball.Y)
                };
                _balls.Add(mBall);
            }

            _timer.Start();
        }

        public void Stop() => _timer.Stop();

        public ObservableCollection<ModelBall> GetBalls() => _balls;

        private void UpdateModel()
        {
            _logicPool.Update();

            for (int i = 0; i < _logicPool.Balls.Count; i++)
            {
                var ball = _logicPool.Balls.ElementAt(i);
                _balls[i].X = MapX(ball.Ball.X);
                _balls[i].Y = MapY(ball.Ball.Y);
            }
        }

        private int MapX(float x)
        {
            return (int)(x * CanvasWidth / _logicPool.Pool.XDim);
        }

        private int MapY(float y)
        {
            return (int)(y * CanvasHeight / _logicPool.Pool.YDim);
        }
    }
}

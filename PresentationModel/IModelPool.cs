using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PresentationModel
{
    public interface IModelPool
    {
        public int CanvasWidth { get; set; }
        public int CanvasHeight { get; set; }

        public ObservableCollection<ModelBall> GetBalls();
        public void Start(int ballCount);
        public void Stop();
    }
}
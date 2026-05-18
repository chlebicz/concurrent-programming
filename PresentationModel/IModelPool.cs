using System.Collections.ObjectModel;

namespace PresentationModel
{
    public interface IModelPool : IDisposable
    {
        public int CanvasWidth { get; set; }
        public int CanvasHeight { get; set; }

        public ObservableCollection<ModelBall> GetBalls();
        public void Start(int ballCount);
        public void Stop();
    }
}
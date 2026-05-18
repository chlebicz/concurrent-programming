using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PresentationModel
{
    public class ModelBall : INotifyPropertyChanged
    {
        private int _x;
        private int _y;
        private int _radiusX;
        private int _radiusY;

        public int X
        {
            get => _x;
            set {
                _x = value;
                OnPropertyChanged();
                OnPropertyChanged("Left");
            }
        }
        public int Y
        {
            get => _y;
            set {
                _y = value;
                OnPropertyChanged();
                OnPropertyChanged("Top");
            }
        }
        public int RadiusX
        {
            get => _radiusX;
            set {
                _radiusX = value;
                OnPropertyChanged();
                OnPropertyChanged("DiameterX");
            }
        }
        public int RadiusY
        {
            get => _radiusY;
            set {
                _radiusY = value;
                OnPropertyChanged();
                OnPropertyChanged("DiameterY");
            }
        }

        public int Left
        {
            get => _x - RadiusX;
        }
        public int Top
        {
            get => _y - RadiusY;
        }
        public int DiameterX
        {
            get => _radiusX * 2;
        }
        public int DiameterY
        {
            get => _radiusY * 2;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PresentationModel
{
    public class ModelBall : INotifyPropertyChanged
    {
        private int _x;
        private int _y;
        private int _radius;

        public int X
        {
            get => _x;
            set { _x = value; OnPropertyChanged(); }
        }
        public int Y
        {
            get => _y;
            set { _y = value; OnPropertyChanged(); }
        }
        public int Radius
        {
            get => _radius;
            set { _radius = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

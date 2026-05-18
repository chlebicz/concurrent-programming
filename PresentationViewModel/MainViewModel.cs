using PresentationModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace PresentationViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IModelPool _modelPool;

        private int _ballCount;
        private ObservableCollection<ModelBall> _balls;

        public double CanvasWidth { get; private set; }
        public double CanvasHeight { get; private set; }
        public ICommand UpdateSizeCommand { get; }
        public ICommand CanvasLoadedCommand { get; }

        public string BallCount
        {
            get {
                if (_ballCount == 0)
                {
                    return "";
                }
                else
                {
                    return _ballCount.ToString();
                }
            }
            set
            {
                if (BallCount != value)
                {
                    int newBallCount;
                    if (int.TryParse(value, out newBallCount))
                    {
                        _ballCount = newBallCount;
                    }

                    if (value == "" || newBallCount == 0)
                    {
                        _ballCount = 0;
                        BallCount = "";
                    }
                    else
                    {
                        BallCount = _ballCount.ToString();
                    }
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<ModelBall> Balls
        {
            get => _balls;
            set
            {
                _balls = value;
                OnPropertyChanged();
            }
        }

        public ICommand StartCommand { get; }

        public ICommand StopCommand { get; }

        public MainViewModel(IModelPool modelPool)
        {
            _modelPool = modelPool;
            Balls = _modelPool.GetBalls();
            StartCommand = new RelayCommand(StartSimulation);
            StopCommand = new RelayCommand(StopSimulation);
            UpdateSizeCommand = new RelayCommand<SizeChangedEventArgs>(OnCanvasSizeChanged);
            CanvasLoadedCommand = new RelayCommand<RoutedEventArgs>(OnCanvasLoaded);
        }

        private void OnCanvasLoaded(RoutedEventArgs e)
        {
            if (e.Source is FrameworkElement element)
            {
                UpdateCanvasSize(element.ActualWidth, element.ActualHeight);
            }
        }

        private void OnCanvasSizeChanged(SizeChangedEventArgs e)
        {
            UpdateCanvasSize(e.NewSize.Width, e.NewSize.Height);
        }

        private void UpdateCanvasSize(double width, double height)
        {
            CanvasWidth = width;
            CanvasHeight = height;

            _modelPool.CanvasWidth = (int)Math.Floor(CanvasWidth);
            _modelPool.CanvasHeight = (int)Math.Floor(CanvasHeight);
        }

        private void StartSimulation()
        {
            _modelPool.Start(_ballCount);
        }

        private void StopSimulation()
        {
            _modelPool.Stop();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

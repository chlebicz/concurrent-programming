using Data;
using Logic;
using PresentationModel;
using PresentationViewModel;
using System.Windows;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IBallFactory ballFactory = new BallFactory();
            IDataPool pool = new DataPool(500, 300);
            ILogicPool logicPool = new LogicPool(pool, ballFactory);
            IModelPool modelPool = new ModelPool(logicPool);
            MainViewModel viewModel = new MainViewModel(modelPool);

            MainWindow window = new MainWindow();
            window.DataContext = viewModel;

            window.Show();
        }
    }

}

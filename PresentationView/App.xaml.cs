using Data;
using Logic;
using PresentationModel;
using PresentationViewModel;
using System.Configuration;
using System.Data;
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
            IDataPool pool = new DataPool(756, 340);
            ILogicPool logicPool = new LogicPool(pool, ballFactory);
            IModelPoolFactory modelPoolFactory = new ModelPoolFactory();
            IModelPool modelPool = modelPoolFactory.CreatePool(logicPool);
            MainViewModel viewModel = new MainViewModel(modelPool);

            MainWindow window = new MainWindow();
            window.DataContext = viewModel;

            window.Show();
        }
    }

}

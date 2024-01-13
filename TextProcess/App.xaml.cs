using System.Windows;
using TextProcess.Services;
using Unity;

namespace TextProcess
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            TestProcessService testProcessService = new TestProcessService();
            MainWindowViewModel viewModel = new MainWindowViewModel(testProcessService);
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = viewModel;
            mainWindow.Show();
        }
    }
}

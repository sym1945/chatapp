using chatapp.core;
using System;
using System.Windows;

namespace chatapp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ApplicationSetup();

            IoC.Logger.Log("Application starting...", LogLevel.Debug);

            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        private void ApplicationSetup()
        {
            IoC.Setup();

            IoC.Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory(new[]
            { 
                new FileLogger("log.txt"),
            }));

            IoC.Kernel.Bind<ITaskManager>().ToConstant(new TaskManager());

            IoC.Kernel.Bind<IFileManager>().ToConstant(new FileManager());

            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());
        }
    }
}

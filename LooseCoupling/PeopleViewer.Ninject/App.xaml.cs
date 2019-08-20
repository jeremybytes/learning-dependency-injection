using Common;
using Ninject;
using PersonRepository.Caching;
using PersonRepository.CSV;
using PersonRepository.Service;
using System.Windows;

namespace PeopleViewer.Ninject
{
    public partial class App : Application
    {
        IKernel Container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Application.Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            Container = new StandardKernel();
            Container.Bind<IPersonRepository>().To<CachingRepository>()
                .InSingletonScope()
                .WithConstructorArgument<IPersonRepository>(
                    Container.Get<ServiceRepository>());
        }

        private void ComposeObjects()
        {
            Application.Current.MainWindow = Container.Get<MainWindow>();
        }
    }
}

using Autofac;
using Autofac.Features.ResolveAnything;
using Common;
using PeopleViewer.Presentation;
using PersonRepository.Caching;
using PersonRepository.Service;
using PersonRepository.CSV;
using System.Windows;

namespace PeopleViewer.Autofac
{
    public partial class App : Application
    {
        IContainer Container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Application.Current.MainWindow.Title = "With Dependency Injection - Autofac";
            Application.Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // DATA READER TYPE OPTION #1 - No Decorator
            //builder.RegisterType<CSVRepository>().As<IPersonRepository>()
            //    .SingleInstance();

            // DATA READER TYPE OPTION #2 - With Decorator
            builder.RegisterType<ServiceRepository>().Named<IPersonRepository>("repository")
                .SingleInstance();
            builder.RegisterDecorator<IPersonRepository>(
                (c, inner) => new CachingRepository(inner), fromKey: "repository");

            // OTHER TYPES OPTION #1 - Automatic Registration
            //builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            // OTHER TYPES OPTION #2 - Explicit Registration
            builder.RegisterType<MainWindow>().InstancePerDependency();
            builder.RegisterType<PeopleViewModel>().InstancePerDependency();

            Container = builder.Build();
        }

        private void ComposeObjects()
        {
            Application.Current.MainWindow = Container.Resolve<MainWindow>();
        }
    }
}

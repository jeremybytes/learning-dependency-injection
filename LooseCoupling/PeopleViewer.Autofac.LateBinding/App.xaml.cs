using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using PeopleViewer.Presentation;
using System.Windows;

namespace PeopleViewer.Autofac.LateBinding
{
    public partial class App : Application
    {
        IContainer Container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Application.Current.MainWindow.Title = "With Dependency Injection - Autofac Late Binding";
            Application.Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            var config = new ConfigurationBuilder();
            config.AddJsonFile("autofac.json");

            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);

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

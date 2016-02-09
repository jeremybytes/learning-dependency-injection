using PeopleViewer.Presentation;
using PersonRepository.Caching;
using PersonRepository.CSV;
using PersonRepository.Service;
using System.Windows;
using Ninject;
using Common;

namespace PeopleViewer
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

        }

        private void ComposeObjects()
        {

        }
    }
}

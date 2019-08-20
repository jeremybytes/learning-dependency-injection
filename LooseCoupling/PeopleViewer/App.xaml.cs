using PeopleViewer.Presentation;
using PersonRepository.Caching;
using PersonRepository.CSV;
using PersonRepository.Service;
using System.Windows;

namespace PeopleViewer
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ComposeObjects();
            Application.Current.MainWindow.Show();
        }

        private static void ComposeObjects()
        {
            var wrappeRepo = new ServiceRepository();
            var repository = new CachingRepository(wrappeRepo);
            var viewModel = new PeopleViewModel(repository);
            Application.Current.MainWindow = new MainWindow(viewModel);
        }
    }
}

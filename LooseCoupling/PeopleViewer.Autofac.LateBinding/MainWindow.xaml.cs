using PeopleViewer.Presentation;
using System.Windows;

namespace PeopleViewer.Autofac.LateBinding
{
    public partial class MainWindow : Window
    {
        PeopleViewModel ViewModel { get; set; }

        public MainWindow(PeopleViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RefreshPeople();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ClearPeople();
        }
    }
}

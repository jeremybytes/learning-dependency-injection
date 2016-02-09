using PeopleViewer.Presentation;
using System.Windows;

namespace PeopleViewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}

using System.Windows;

namespace PeopleViewer
{
    public partial class MainWindow : Window
    {
        MainWindowViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainWindowViewModel();
            DataContext = viewModel;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.RefreshData();
        }
    }
}

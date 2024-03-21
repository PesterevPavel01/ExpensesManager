using ExpensesManager.Models;
using System.Windows;

namespace ExpensesManager.Views
{
    /// <summary>
    /// Логика взаимодействия для messageWindow.xaml
    /// </summary>
    public partial class messageWindow : Window
    {
        public messageWindow()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (MessageWindowViewModel)this.DataContext;
            viewModel.clickOk();
            this.Close();
        }

        private void Error_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (MessageWindowViewModel)this.DataContext;
            viewModel.clickError();
            this.Close();
        }
    }
}

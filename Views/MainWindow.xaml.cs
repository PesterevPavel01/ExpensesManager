using ExpensesManager.Models;
using ExpensesManager.ViewModels;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ExpensesManager.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Icons icons;
        public MainWindow()
        {
            InitializeComponent();

            var viewModel = (MainWindowViewModel)this.DataContext;
            icons = viewModel.Icons;

            search.Source = icons.searchBlue;
            load.Source = icons.download;
            settings.Source = icons.settings;
            navbarClose.Source= icons.navbarClose;
        }

        

        private void navbarOpen_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mainContainer.ColumnDefinitions[1].Width = new GridLength(160);
            navbarClose.Width = 30;
            navbarOpen.Width = 0;
        }

        private void navbarClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mainContainer.ColumnDefinitions[1].Width = new GridLength(0);
            navbarOpen.Width = 50;
            navbarClose.Width = 0;
        }

        private void navbarOpen_MouseEnter(object sender, MouseEventArgs e)
        {
            logoLineFirst.Background = (Brush)new BrushConverter().ConvertFromString("#FFFFFF");
            logoLineSecond.Background = (Brush)new BrushConverter().ConvertFromString("#FFFFFF");
            logoLineThird.Background = (Brush)new BrushConverter().ConvertFromString("#FFFFFF");
        }

        private void navbarOpen_MouseLeave(object sender, MouseEventArgs e)
        {
            logoLineFirst.Background = (Brush)new BrushConverter().ConvertFromString("#EFE1B0");
            logoLineSecond.Background = (Brush)new BrushConverter().ConvertFromString("#EFE1B0");
            logoLineThird.Background = (Brush)new BrushConverter().ConvertFromString("#EFE1B0");
        }

        private void navbarClose_MouseEnter(object sender, MouseEventArgs e)
        {
            navbarClose.Source = icons.navbarCloseSelected;
        }

        private void navbarClose_MouseLeave(object sender, MouseEventArgs e)
        {
            navbarClose.Source = icons.navbarClose;
        }

        private void search_MouseEnter(object sender, MouseEventArgs e)
        {
            search.Source = icons.searchRed;
        }

        private void search_MouseLeave(object sender, MouseEventArgs e)
        {
            search.Source = icons.searchBlue;
        }

        private void load_MouseEnter(object sender, MouseEventArgs e)
        {
            load.Source = icons.downloadSelected;
        }

        private void load_MouseLeave(object sender, MouseEventArgs e)
        {
            load.Source = icons.download;
        }

        private void settings_MouseEnter(object sender, MouseEventArgs e)
        {
            settings.Source = icons.settingsSelected;
        }

        private void settings_MouseLeave(object sender, MouseEventArgs e)
        {
            settings.Source = icons.settings;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}

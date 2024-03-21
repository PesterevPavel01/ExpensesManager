using ExpensesManager.Models;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExpensesManager.Views.MainWindowParts.DocumentPage
{
    /// <summary>
    /// Логика взаимодействия для DocumentFieldRedactorPage.xaml
    /// </summary>
    public partial class DocumentFieldRedactorPage : Page
    {
        private readonly Icons icons;
        public DocumentFieldRedactorPage(Icons icons)
        {
            this.icons = icons;
            InitializeComponent();
            addNewItemButton.Source = icons.ok;
        }

        private void addNewItemButton_MouseEnter(object sender, MouseEventArgs e)
        {
            addNewItemButton.Source = icons.okSelected;
        }

        private void addNewItemButton_MouseLeave(object sender, MouseEventArgs e)
        {
            addNewItemButton.Source = icons.ok;
        }

        private void addNewItemButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var viewModel = (ExpensesManager.DocumentFieldRedactorPageViewModel)this.DataContext;
            Items.Focus();
            viewModel.addNewItem();
            NameNewItem.Focus();
        }

        private void Items_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Delete || Items.SelectedItems.Count < 1) return;
            var viewModel = (ExpensesManager.DocumentFieldRedactorPageViewModel)this.DataContext;
            ICommonItem<short> currentItem = Items.SelectedItems[0] as ICommonItem<short>;
            viewModel.deleteItem(currentItem);
        }
    }
}

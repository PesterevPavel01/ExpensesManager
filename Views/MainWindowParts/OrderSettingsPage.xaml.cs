using ExpensesManager.Models;
using System.Windows.Controls;

namespace ExpensesManager.Views.MainWindowParts
{
    /// <summary>
    /// Логика взаимодействия для ParamsPage.xaml
    /// </summary>
    public partial class OrderSettingsPage : Page
    {
        Icons icons;
        public OrderSettingsPage(Icons icons)
        {
            this.icons = icons;
            InitializeComponent();
        }
        
    }
}

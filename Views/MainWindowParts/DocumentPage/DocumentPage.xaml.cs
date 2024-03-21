using ExpensesManager.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExpensesManager.Views.MainWindowParts.DocumentPage
{
    /// <summary>
    /// Логика взаимодействия для DocumentPage.xaml
    /// </summary>
    public partial class DocumentPage : Page
    {
        Icons icons;
        public DocumentPage(Icons icons)
        {
            this.icons = icons;
            InitializeComponent();
            newOrganization.Source = icons.update;
            newDepartment.Source = icons.update;
            newExpenditure.Source = icons.update;
            this.Value.PreviewTextInput += new TextCompositionEventHandler(Value_PreviewTextInput);
        }
        public string item;
        void Value_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string s=e.Text;
            if ((!Char.IsDigit(e.Text, 0)) && (e.Text!= ".") && (e.Text != ",") && (e.Text != "-")) e.Handled = true;
        }

        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key != Key.Enter) return;
            //Document newDocument = new Document()
            //{
            //    date = DateFild.SelectedDate.Value.ToShortDateString(),
            //    item = Item.Text,
            //    value = Convert.ToString(Value.Text),
            //    organization = Organization.Text,
            //    department = Department.Text,
            //    comment = Comment.Text,
            //};

            //if (newDocument.item.Trim() == "" || newDocument.department.Trim() == "" || newDocument.organization.Trim() == "" || newDocument.value.Trim() == "0")
            //{
            //    MessageBox.Show("Некорректные данные");
            //    return;
            //}
            //var page = (DocumentPageViewModel)this.DataContext;
            //page._mySqlConnector.sendToDB(page._queryString.addDocument(newDocument));
        }

        private void newExpenditure_MouseEnter(object sender, MouseEventArgs e)
        {
            newExpenditure.Source = icons.updateSelected;
        }

        private void newExpenditure_MouseLeave(object sender, MouseEventArgs e)
        {
            newExpenditure.Source = icons.update;
        }

        private void newOrganization_MouseEnter(object sender, MouseEventArgs e)
        {
            newOrganization.Source = icons.updateSelected;
        }

        private void newOrganization_MouseLeave(object sender, MouseEventArgs e)
        {
            newOrganization.Source = icons.update;
        }

        private void newDepartment_MouseEnter(object sender, MouseEventArgs e)
        {
            newDepartment.Source = icons.updateSelected;
        }

        private void newDepartment_MouseLeave(object sender, MouseEventArgs e)
        {
            newDepartment.Source = icons.update;
        }

        private void Page_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}

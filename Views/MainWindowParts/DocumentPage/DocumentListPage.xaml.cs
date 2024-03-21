using ExpensesManager.Models;
using ExpensesManager.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExpensesManager.Views.MainWindowParts.DocumentPage
{
    /// <summary>
    /// Логика взаимодействия для DocumentListPage.xaml
    /// </summary>
    public partial class DocumentListPage : Page
    {
        private readonly Icons icons;

        public DocumentListPage(Icons icons)
        {
            this.icons = icons;
            InitializeComponent();
            docSetts.Source = icons.documentSetts;
            closeButton.Source = icons.closeBlue;
            filtrButton.Source = icons.filtrButton;
            previewButton.Source = icons.document;
            listSettingsButton.Source = icons.settings;
            updateButton.Source = icons.update;
        }

        private void docSetts_MouseEnter(object sender, MouseEventArgs e)
        {
            docSetts.Source = icons.documentSettsSelected;
        }

        private void docSetts_MouseLeave(object sender, MouseEventArgs e)
        {
            docSetts.Source = icons.documentSetts;
        }

        private void filtrButton_MouseEnter(object sender, MouseEventArgs e)
        {
            filtrButton.Source = icons.filtrButtonSelected;
        }

        private void filtrButton_MouseLeave(object sender, MouseEventArgs e)
        {
            filtrButton.Source = icons.filtrButton;
        }

        private void previewButton_MouseEnter(object sender, MouseEventArgs e)
        {
            previewButton.Source = icons.documentSelected;
        }

        private void previewButton_MouseLeave(object sender, MouseEventArgs e)
        {
            previewButton.Source = icons.document;
        }
        private void updateButton_MouseEnter(object sender, MouseEventArgs e)
        {
            updateButton.Source = icons.updateSelected;
        }

        private void updateButton_MouseLeave(object sender, MouseEventArgs e)
        {
            updateButton.Source = icons.update;
        }
        private void closeButton_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void closeButton_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void Frame_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key != Key.Enter && e.Key != Key.Escape) return;
            var viewModel = (DocumentListPageViewModel)this.DataContext;
            var documentPage = this.DocumentPageFrame.Content as DocumentPage;
            switch (e.Key)
            {
                case Key.Enter:
                    resultList.Focus();
                    viewModel.addNewDocumentAsync();
                    documentPage.Value.Focus();
                    break;

                case Key.Escape:
                    viewModel.RedactorModeOff();
                    var documentFieldRedactorPage = this.ListSettingsPageFrame.Content as DocumentFieldRedactorPage;
                    var listSettsPageVM = (ExpensesManager.DocumentFieldRedactorPageViewModel)documentFieldRedactorPage.DataContext;
                    listSettsPageVM.RedactorModeOff();
                    break;
            }
        }

        private void resultList_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Delete || resultList.SelectedItems.Count < 1) return;
            var viewModel = (DocumentListPageViewModel)this.DataContext;
            Document currentDocument = resultList.SelectedItems[0] as Document;
            viewModel.deleteDocument(currentDocument);
        }

        private void listSettingsButton_MouseEnter(object sender, MouseEventArgs e)
        {
            listSettingsButton.Source = icons.settingsSelected;
        }

        private void listSettingsButton_MouseLeave(object sender, MouseEventArgs e)
        {
            listSettingsButton.Source = icons.settings;
        }
    }
}

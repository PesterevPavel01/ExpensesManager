using ExpensesManager.Models;
using ExpensesManager.Views;
using ExpensesManager.Views.MainWindowParts.DocumentPage;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ExpensesManager.ViewModels
{

    internal class DocumentListPageViewModel : BindableBase
    {

        public DocumentListPageViewModel(Icons icons)
        {
            _icons = icons;

            DocumentList = new List<Document>();

            addNewDocumentCommand = new DelegateCommand(addNewDocumentAsync);
            documentListDoubleClickCommand = new DelegateCommand<object>(documentListDoubleClick);
            loadDocumentListCommand = new DelegateCommand<object>(LoadDocumentList);
            docSettsVisibleChangeCommand = new DelegateCommand(docSettsVisibleChange);
            docSettsModeChangeCommand = new DelegateCommand<object>(docSettsModeChange);

            DocParamsWidht = "0";
            ListSettingsWidht = "0";
            docSettsVisible = "0";
            ButtonAddVisibility = "Visible";
            ButtonSaveChangesVisibility = "Hidden";
            TranzitColor = "#EFE1B0";
            widhtTable = _docSettsContainerWidht;
            PreviewWidht = _docSettsContainerWidht;
            

            _paramsPageViewModel = new ParamsPageViewModel();
            _parameters = new(_icons);
            _parameters.DataContext = _paramsPageViewModel;
            ParamsPage = _parameters;

            _fieldRedactorPage = new(_icons);
            _fieldRedactorPageViewModel = new DocumentFieldRedactorPageViewModel();
            _fieldRedactorPage.DataContext = _fieldRedactorPageViewModel;
            ListPage = _fieldRedactorPage;

            _newDocument = new DocumentPage(_icons);
            _newDocumentPageViewModel = new DocumentPageViewModel(_paramsPageViewModel.SearchSettingsItems);
            _newDocument.DataContext = _newDocumentPageViewModel;
            DocumentPage = _newDocument;

            _DateStart = DateTime.Now.AddMonths(-1);
            _DateEnd = DateTime.Now;

            LoadDocumentList(null);

        }

        #region PROPERTIES

        private readonly Icons _icons;
        private List<Document> _documentList { get; set; }
        public List<Document> DocumentList
        {
            get => _documentList;
            set
            {
                _documentList = value;
                RaisePropertyChanged(nameof(DocumentList));
            }
        }
        public DelegateCommand addNewDocumentCommand { get; set; }
        public DelegateCommand<object> documentListDoubleClickCommand { get; set; }
        public DelegateCommand<object> loadDocumentListCommand { get; set; }
        public DelegateCommand docSettsVisibleChangeCommand { get; set; }
        public DelegateCommand<object> docSettsModeChangeCommand { get; set; }

        private messageWindow _messageWindow;

        public MessageWindowViewModel messageWindowViewModel = new();

        ExpenseDocumentService _documentService = new();

        public DocumentPageViewModel _newDocumentPageViewModel;
        private DocumentPage _newDocument;
        public Page _NewDocumentPage;

        public Page DocumentPage
        {
            get => _NewDocumentPage;
            set
            {
                _NewDocumentPage = value;
                RaisePropertyChanged(nameof(DocumentPage));
            }
        }

        private ParamsPageViewModel _paramsPageViewModel;
        private OrderSettingsPage _parameters;
        private Page _paramsPage;

        public Page ParamsPage
        {
            get => _paramsPage;
            set
            {
                _paramsPage = value;
                RaisePropertyChanged(nameof(ParamsPage));
            }
        }

        private DocumentFieldRedactorPageViewModel _fieldRedactorPageViewModel;
        private DocumentFieldRedactorPage _fieldRedactorPage;
        private Page _listPage;

        public Page ListPage
        {
            get => _listPage;
            set
            {
                _listPage = value;
                RaisePropertyChanged(nameof(ListPage));
            }
        }

        private Document _currentDocument;
        private DateTime _DateStart { get; set; }
        public DateTime DateStart
        {
            get => _DateStart;
            set
            {
                _DateStart = value;
                RaisePropertyChanged(nameof(DateStart));
            }
        }
        private DateTime _DateEnd { get; set; }
        public DateTime DateEnd
        {
            get => _DateEnd;
            set
            {
                _DateEnd = value;
                RaisePropertyChanged(nameof(DateEnd));
            }
        }

        public bool flagRedactorMode = false;

        private string _widhtTable { get; set; }
        private string _docSettsVisible { get; set; }
        private string _previewWidht { get; set; }
        public string PreviewWidht
        {
            get => _previewWidht;
            set
            {
                _previewWidht = value;
                RaisePropertyChanged(nameof(PreviewWidht));
            }
        }
        private string _docParamsWidht { get; set; }
        public string DocParamsWidht
        {
            get => _docParamsWidht;
            set
            {
                _docParamsWidht = value;
                RaisePropertyChanged(nameof(DocParamsWidht));
            }
        }
        private string _listSettingsWidht { get; set; }
        public string ListSettingsWidht
        {
            get => _listSettingsWidht;
            set
            {
                _listSettingsWidht = value;
                RaisePropertyChanged(nameof(ListSettingsWidht));
            }
        }
        private string _tranzitColor { get; set; }
        public string TranzitColor
        {
            get => _tranzitColor;
            set
            {
                _tranzitColor = value;
                RaisePropertyChanged(nameof(TranzitColor));
            }
        }

        private const string _docSettsContainerWidht = "450";
        private string _docPreviewContent { get; set; }
        public string DocPreviewContent
        {
            get => _docPreviewContent;
            set
            {
                _docPreviewContent = value;
                RaisePropertyChanged(nameof(DocPreviewContent));
            }
        }
        private string _buttonAddVisibility { get; set; }
        public string ButtonAddVisibility
        {
            get => _buttonAddVisibility;
            set
            {
                _buttonAddVisibility = value;
                RaisePropertyChanged(nameof(ButtonAddVisibility));
            }
        }
        private string _buttonSaveChangesVisibility { get; set; }
        public string ButtonSaveChangesVisibility
        {
            get => _buttonSaveChangesVisibility;
            set
            {
                _buttonSaveChangesVisibility = value;
                RaisePropertyChanged(nameof(ButtonSaveChangesVisibility));
            }
        }
        private string saveContent = "";

        public string docSettsVisible
        {
            get => _docSettsVisible;
            set
            {
                _docSettsVisible = value;
                RaisePropertyChanged(nameof(docSettsVisible));
            }
        }

        public string widhtTable
        {
            get => _widhtTable;
            set
            {
                _widhtTable = value;
                RaisePropertyChanged(nameof(widhtTable));
            }
        }

        #endregion


        #region METHODS

        private void docSettsVisibleChange()
        {
            docSettsVisible = _docSettsVisible == "0" ? _docSettsContainerWidht : "0";
            if (docSettsVisible == "0")
            {
                DocPreviewContent = "";
                saveContent = "";
            }
        }
        private void docSettsModeChange(object param)
        {
            var currentImage = param as System.Windows.Controls.Image;
            String name = currentImage.Name;
            if (name == "filtrButton")
            {
                saveContent = DocPreviewContent;
                DocPreviewContent = "";
            }
            else
            {
                DocPreviewContent = saveContent;
            }
            DocParamsWidht = (name == "filtrButton") ? "*" : "0";
            PreviewWidht = (name == "previewButton") ? "*" : "0";
            ListSettingsWidht = (name == "listSettingsButton") ? "*" : "0";
        }

        private async void LoadDocumentList(object param)
        {
            if (param != null)
            {
                var control = param as Control;
                control.Focus();
            }

            if (DocumentList != null) DocumentList.Clear();

            var Documents = await _documentService.GetDocumentsAsync(_DateStart, _DateEnd, _icons.Ok);

            if (Documents.IsSuccess) 
                DocumentList = Documents.Data.Select(x =>
                    new Document(
                        Convert.ToString(x.Id),
                        x.Expenditure,
                        x.Date.ToShortDateString(),
                        Convert.ToString(x.Value),
                        x.Organization,
                        x.Department,
                        x.Comment,
                        _icons.Ok)).ToList();

            if (flagRedactorMode)
                DocumentList.FirstOrDefault(x => x.Id == _currentDocument.Id).StatusIcon = _icons.Edit;

            DocumentList = DocumentList.OrderByDescending(el => el.Date).ToList();
        }

        private void documentListDoubleClick(object param)
        {
            if (_currentDocument != null) _currentDocument.StatusIcon = _icons.Ok;
            var dataGrid = param as System.Windows.Controls.DataGrid;
            _currentDocument = dataGrid.SelectedItems[0] as Document;
            _currentDocument.StatusIcon = _icons.Edit;
            flagRedactorMode = true;
            updateDocumentPageViewModel();
            ButtonAddVisibility = "Hidden";
            ButtonSaveChangesVisibility = "Visible";
            TranzitColor = "#97B761";
        }

        public async void addNewDocumentAsync()
        {

            double number;
            try
            {
                number = Convert.ToDouble(_newDocumentPageViewModel.Value.Replace(".", ","));
            }
            catch
            {
                MessageBox.Show("Некорректно введена сумма документа", "ошибка");
                return;
            }

            if (_newDocumentPageViewModel.Item.Trim() == "" || _newDocumentPageViewModel.Department.Trim() == "" || _newDocumentPageViewModel.Organization.Trim() == "")
            {
                MessageBox.Show("Некорректные данные", "ошибка");
                return;
            }

            DocumentDto newDocument = 
                new(number, _newDocumentPageViewModel.Date,
                _newDocumentPageViewModel.Comment, _newDocumentPageViewModel.Item,
                _newDocumentPageViewModel.Organization, _newDocumentPageViewModel.Department);

            BaseResult<DocumentDto> result;

            if (!flagRedactorMode)
            {

                result = await _documentService.CreateDocumentAsync(newDocument);

                if (result.IsSuccess)
                {
                    DocumentList.Add(
                        new Document(Convert.ToString(result.Data.Id),
                        newDocument.Expenditure,
                        result.Data.Date.ToShortDateString(),
                        newDocument.Value.ToString(),
                        newDocument.Organization,
                        newDocument.Department,
                        newDocument.Comment,
                        _icons.Ok
                        ));
                }
                _newDocumentPageViewModel.Value = "";
            }
            else
            {
                newDocument.Id = Convert.ToInt64(_currentDocument.Id);

                result = await _documentService.UpdateDocumentAsync(newDocument);

                if (result.IsSuccess)
                {
                    _currentDocument.Item = newDocument.Expenditure;
                    _currentDocument.Date = newDocument.Date.ToShortDateString();
                    _currentDocument.Value = newDocument.Value.ToString();
                    _currentDocument.Organization = newDocument.Organization;
                    _currentDocument.Comment = newDocument.Comment;
                    _currentDocument.Department = newDocument.Department;
                }
            }

            DocumentList = DocumentList.OrderByDescending(el => el.Date).ToList();
        }

        public async void deleteDocument(Document selectedDocument)
        {
            BaseResult<DocumentDto> result;

            _messageWindow = new messageWindow();
            _messageWindow.DataContext = messageWindowViewModel;
            messageWindowViewModel.Content = "Вы уверены, что хотите удалить запись?";
            _messageWindow.ShowDialog();

            if (!messageWindowViewModel.result) return;

            result = await _documentService.DeleteDocumentAsync(Convert.ToInt64(selectedDocument.Id));

            if (result.IsSuccess)
            {
                var item = DocumentList.Where(item => item.Id == selectedDocument.Id).FirstOrDefault();
                DocumentList.Remove(item);
                DocumentList = DocumentList.OrderByDescending(el => el.Date).ToList();
            }
        }

        private void updateDocumentPageViewModel()
        {

            _newDocumentPageViewModel.Date = Convert.ToDateTime(_currentDocument.Date);
            _newDocumentPageViewModel.Item = _currentDocument.Item;
            _newDocumentPageViewModel.Value = _currentDocument.Value;
            _newDocumentPageViewModel.Organization = _currentDocument.Organization;
            _newDocumentPageViewModel.Department = _currentDocument.Department;
            _newDocumentPageViewModel.Comment = _currentDocument.Comment;

        }

        public void RedactorModeOff()
        {
            if (_currentDocument == null) return;

            flagRedactorMode = false;
            _newDocumentPageViewModel.Value = "";
            ButtonAddVisibility = "Visible";
            ButtonSaveChangesVisibility = "Hidden";
            _currentDocument.StatusIcon = _icons.Ok;
            TranzitColor = "#EFE1B0";
        }

        #endregion
    }

}

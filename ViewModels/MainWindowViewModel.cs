using ExpensesManager.Models;
using ExpensesManager.Views;
using ExpensesManager.Views.MainWindowParts.DocumentPage;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace ExpensesManager.ViewModels
{
    public class MainWindowViewModel:BindableBase
    {
        #region COMMANDS
        public DelegateCommand openSearchCommand { get; set; }
        public DelegateCommand openLoadFormCommand { get; set; }
        public DelegateCommand openSettingsCommand { get; set; }

        #endregion

        public MainWindowViewModel()
        {
            
            openSearchCommand = new DelegateCommand(openDocumentListPage);
            NavButtons.Add(_searchBtnName, openSearchCommand);

            openLoadFormCommand = new DelegateCommand(openLoadForm);
            NavButtons.Add(_loadBtnName, openLoadFormCommand);

            openSettingsCommand = new DelegateCommand(openSettings);
            NavButtons.Add(_settingsBtnName, openSettingsCommand);

            Icons = new Icons();

            //settingsPage.DataContext = new SettingsPageViewModel(mySqlConnector);
            documentPage = new DocumentListPage(Icons);
            documentPage.DataContext = new DocumentListPageViewModel(Icons);
            //importModel = new ImportDocumentPageViewModel(readerIniSettings.settings.resourceFolder);
            //importPage.DataContext = importModel;

            openDocumentListPage();
        }

        #region PROPERTIES

        public readonly Icons Icons;

        private DocumentListPage documentPage;

        private readonly string _searchBtnName = "Найти/Добавить";
        private readonly string _loadBtnName = "Загрузить";
        private readonly string _settingsBtnName = "Настройки";


        private Dictionary<string, DelegateCommand> _navButtons = new Dictionary<string, DelegateCommand>();

        public Dictionary<string, DelegateCommand> NavButtons
        {
            get => _navButtons;
            set
            {
                _navButtons = value;
                RaisePropertyChanged(nameof(NavButtons));
            }
        }


        private Page _selectedPage;

        public Page SelectedPage
        {
            get => _selectedPage;
            set
            {
                _selectedPage = value;
                RaisePropertyChanged(nameof(SelectedPage));
            }
        }

#endregion

#region METHODS

        private void openDocumentListPage()
        {
            openPage(documentPage, "DocumentListPage");
        }

        private void openLoadForm()
        {
        }

        private async void openSettings()
        {
        }

#endregion

        private void openPage(Page page, string pageName)
        {
            SelectedPage = page;
        }
    }
}

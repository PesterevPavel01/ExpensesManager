using ExpensesManager.Models;
using ExpensesManager.Models.Controls;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace ExpensesManager
{
    class ParamsPageViewModel : BindableBase
    {
        public ParamsPageViewModel() {
            _checkBoxItemControl = new CheckBoxItemControl();
            loadSearchSettingsItems();
            loadSearchSettingsTypes();
            searchSettingsTypesChangeCommand = new DelegateCommand<object> (searchSettingsTypesChange);
            searchSettsSelectedItemsGhangeCommand = new DelegateCommand<object>(searchSettsSelectedItemsGhange);
        }

        #region PROPERTIES

        private CheckBoxItemControl _checkBoxItemControl;

        private List<Param> _ReportFormat;
        public List<Param> ReportFormat
        {
            get => _ReportFormat;
            set
            {
                _ReportFormat = value;
                RaisePropertyChanged(nameof(ReportFormat));
            }
        }

        private List<Param> _SearchSettingsItems = new List<Param>();
        public List<Param> SearchSettingsItems
        {
            get => _SearchSettingsItems;
            set
            {
                _SearchSettingsItems = value;
                RaisePropertyChanged(nameof(SearchSettingsItems));
            }
        }
        public DelegateCommand<object> searchSettsSelectedItemsGhangeCommand { get; set; }
        public DelegateCommand<object> searchSettingsTypesChangeCommand { get; set; }
        public DelegateCommand<object> checkAllCommand { get; set; }

        #endregion

        #region METHODS

        private async void loadSearchSettingsItems()
        {
            ExpenditureService _expenditureService = new ExpenditureService();

            var response = await _expenditureService.GetAllAsync();

            if (response != null)
            {
                SearchSettingsItems = new List<Param>();

                foreach (ExpenditureDto model in response)
                {
                    SearchSettingsItems.Add(
                        new Param 
                        {
                            id=Convert.ToString(model.Id),
                            name=model.Name,
                            value=true
                        });
                }
            }
        }

        private void loadSearchSettingsTypes()
        {
            _ReportFormat = new List<Param>() {
                new Param { id = "0", name = "Список", value = true
                },
                new Param { id = "1", name = "Отчет", value = false } 
            };
        }

        private void checkAll(object currentItem)
        {

            var currentParam = currentItem as Param;

            if (currentParam.name == "Выделить все")
            {
                foreach (Param item in _ReportFormat)
                {
                    if (item.id == currentParam.id) continue;
                    item.value = !currentParam.value;
                }
            }
            else 
            {
            }

        }

        private void searchSettingsTypesChange(object currentItem)
        {
            _checkBoxItemControl.activateOne(currentItem, _ReportFormat);
            

        }

        private void searchSettsSelectedItemsGhange(object currentItem) 
        {
            _checkBoxItemControl.activateAll(currentItem, _SearchSettingsItems);
        }

        #endregion

    }
}

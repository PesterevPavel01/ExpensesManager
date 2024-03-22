using ExpensesManager.Models;
using ExpensesManager.Models.Controls;
using ExpensesManager.Services.Api;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace ExpensesManager
{
    class OrderSettingsPageViewModel : BindableBase
    {
        public OrderSettingsPageViewModel() {
            _checkBoxItemControl = new CheckBoxItemControl();
            loadSearchSettingsItems();
            loadSearchSettingsTypes();
            searchSettingsTypesChangeCommand = new DelegateCommand<object> (searchSettingsTypesChange);
            searchSettsSelectedItemsGhangeCommand = new DelegateCommand<object>(searchSettsSelectedItemsGhange);
        }

        #region PROPERTIES

        private CheckBoxItemControl _checkBoxItemControl;

        private List<OrderParameter> _ReportFormat;
        public List<OrderParameter> ReportFormat
        {
            get => _ReportFormat;
            set
            {
                _ReportFormat = value;
                RaisePropertyChanged(nameof(ReportFormat));
            }
        }

        private List<OrderParameter> _SearchSettingsItems = new List<OrderParameter>();
        public List<OrderParameter> SearchSettingsItems
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
            ExpenditureService _expenditureService = new ExpenditureService("Expenditure");

            var response = await _expenditureService.GetAllAsync();

            if (response != null)
            {
                SearchSettingsItems = new List<OrderParameter>();

                foreach (ExpenditureDto model in response)
                {
                    SearchSettingsItems.Add(
                        new OrderParameter 
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
            _ReportFormat = new List<OrderParameter>() {
                new OrderParameter { id = "0", name = "Список", value = true
                },
                new OrderParameter { id = "1", name = "Отчет", value = false } 
            };
        }

        private void checkAll(object currentItem)
        {

            var currentParam = currentItem as OrderParameter;

            if (currentParam.name == "Выделить все")
            {
                foreach (OrderParameter item in _ReportFormat)
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

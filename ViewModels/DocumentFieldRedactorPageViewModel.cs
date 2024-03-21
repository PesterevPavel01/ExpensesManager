using ExpensesManager.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpensesManager
{
    class DocumentFieldRedactorPageViewModel : BindableBase
    {
        public DocumentFieldRedactorPageViewModel() 
        {
            _currentField = "Статьи";
            getExpenditures();
            fieldsSelectionChangeCommand = new DelegateCommand<object>(fieldsSelectionChange);
            addNewItemCommand = new DelegateCommand(addNewItem);
            itemsDoubleClickCommand = new DelegateCommand<object>(itemsDoubleClick);
        }
        private readonly Icons _icons = new Icons();
        private readonly ExpenditureService _expenditureService = new();
        private readonly DepartnentService _departnentService = new();
        private readonly OrganizationService _organizationService = new();
        public DelegateCommand<object> fieldsSelectionChangeCommand { get; set; }
        public DelegateCommand addNewItemCommand { get; set; }

        public DelegateCommand<object> itemsDoubleClickCommand { get; set; }
        private string _currentField { get; set; }

        private CommonItemDto _currentItem;

        private bool flagRedactorMode;
        private string _nameNewItem { get; set; }
        public string CurrentField
        {
            get => _currentField;
            set
            {
                _currentField = value;
                RaisePropertyChanged(nameof(CurrentField));
            }
        }
        public string NameNewItem
        {
            get => _nameNewItem;
            set
            {
                _nameNewItem = value;
                RaisePropertyChanged(nameof(NameNewItem));
            }
        }

        private List<CommonItemDto> _items;
        public List<CommonItemDto> Items
        {
            get => _items;
            set
            {
                _items = value;
                RaisePropertyChanged(nameof(Items));
            }
        }

        private List<String> _fields=new() {"Статьи","Организации", "Департаменты" };

        public List<String> Fields
        {
            get => _fields;
            set
            {
                _fields = value;
                RaisePropertyChanged(nameof(Fields));
            }
        }
        private async void fieldsSelectionChange(object param)
        {
            RedactorModeOff();
            var comboBox = param as System.Windows.Controls.ComboBox;
            switch (comboBox.SelectedValue)
            {
                case "Статьи":
                    getExpenditures();
                    break;
                case "Департаменты":
                    var departments = await _departnentService.GetAllAsync();
                    Items = departments.Select(item => new CommonItemDto(item, _icons.Ok)).ToList();
                    break;
                case "Организации":
                    var organizations = await _organizationService.GetAllAsync();
                    Items = organizations.Select(item => new CommonItemDto(item, _icons.Ok)).ToList();
                    break;
            }            
        }

        private async void getExpenditures() 
        {
            var expenditures = await _expenditureService.GetAllAsync();
            Items = expenditures.Select(item => new CommonItemDto(item, _icons.Ok)).ToList();
        }
        public async void addNewItem()
        {
            ICommonItem<short> newItem;
            if (String.IsNullOrEmpty(_currentField) || String.IsNullOrEmpty(NameNewItem)) return;

            if (flagRedactorMode)
            {
                updateItem();
                return;
            }

            switch (_currentField)
            {
                case "Статьи":
                    newItem = new ExpenditureDto() { Id = 0, Name = NameNewItem };
                    var resultExp = await _expenditureService.CreateAsync(newItem as ExpenditureDto) ;
                    if (resultExp.IsSuccess) 
                        Items.Add(new CommonItemDto(newItem, _icons.Ok));
                    break;
                case "Департаменты":
                    newItem = new DepartmentDto() { Id = 0, Name = NameNewItem };
                    var resultDept = await _departnentService.CreateAsync(newItem as DepartmentDto);
                    if (resultDept.IsSuccess)
                        Items.Add(new CommonItemDto(newItem, _icons.Ok));
                    break;
                case "Организации":
                    newItem = new OrganizationDto() { Id = 0, Name = NameNewItem };
                    var resultOrg = await _organizationService.CreateAsync(newItem as OrganizationDto);
                    if (resultOrg.IsSuccess)
                        Items.Add(new CommonItemDto(newItem, _icons.Ok));
                    break;
            }
            Items = Items.OrderBy(item => item.Name).ToList();
        }
        public async void updateItem()
        {
            if (String.IsNullOrEmpty(_currentField)) return;
            switch (_currentField)
            {
                case "Статьи":
                    var resultExp = await _expenditureService.UpdateAsync(new ExpenditureDto(_currentItem.Id, NameNewItem));
                    if (resultExp.IsSuccess)
                        Items.FirstOrDefault(item => item.Id == _currentItem.Id).Name = NameNewItem;
                    break;
                case "Департаменты":
                    var resultDept = await _departnentService.UpdateAsync(new DepartmentDto(_currentItem.Id, NameNewItem));
                    if (resultDept.IsSuccess)
                        Items.FirstOrDefault(item => item.Id == _currentItem.Id).Name = NameNewItem;
                    break;
                case "Организации":
                    var resultOrg = await _organizationService.UpdateAsync(new OrganizationDto(_currentItem.Id, NameNewItem));
                    if (resultOrg.IsSuccess)
                        Items.FirstOrDefault(item => item.Id == _currentItem.Id).Name = NameNewItem;
                    break;
            }
            Items = Items.OrderBy(item => item.Name).ToList();
        }
        public async void deleteItem(ICommonItem<short> currentItem)
        {
            if (String.IsNullOrEmpty(_currentField)) return;
            switch (_currentField)
            {
                case "Статьи":
                    var resultExp = await _expenditureService.DeleteAsync((short)currentItem.Id);
                    if (resultExp.IsSuccess)
                        Items=Items.Where(item=>item.Id!=currentItem.Id).ToList();
                    break;
                case "Департаменты":
                    var resultDept = await _departnentService.DeleteAsync((short)currentItem.Id);
                    if (resultDept.IsSuccess)
                        Items = Items.Where(item => item.Id != currentItem.Id).ToList();
                    break;
                case "Организации":
                    var resultOrg = await _organizationService.DeleteAsync((short)currentItem.Id);
                    if (resultOrg.IsSuccess)
                        Items = Items.Where(item => item.Id != currentItem.Id).ToList();
                    break;
            }
            Items = Items.OrderBy(item => item.Name).ToList();
        }

        public async void itemsDoubleClick(object param) 
        {
            if (_currentItem != null) _currentItem.StatusIcon = _icons.Ok;
            var dataGrid = param as System.Windows.Controls.DataGrid;
            _currentItem = dataGrid.SelectedItems[0] as CommonItemDto;
            _currentItem.StatusIcon = _icons.Edit;
            flagRedactorMode = true;
            NameNewItem = _currentItem.Name;
        }
        public void RedactorModeOff()
        {
            flagRedactorMode = false;
            if (_currentItem == null) return;
            NameNewItem = "";
            _currentItem.StatusIcon = _icons.Ok;
        }
    }
}

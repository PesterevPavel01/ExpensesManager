using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace ExpensesManager.ViewModels
{
    class DocumentPageViewModel : BindableBase
    {
        public DocumentPageViewModel(List<Param> items)
        {
            getItems(items);
            loadItemsAsync();
            loadOrganizationsAsync();
            loadDepartmentsAsync();
            Date = DateTime.Now;
            updateListItemsCommand = new DelegateCommand(loadItemsAsync);
            updateOrganizationsItemCommand = new DelegateCommand(loadOrganizationsAsync);
            updateListDepartmentsCommand = new DelegateCommand(loadDepartmentsAsync);
        }

        OrganizationService _organizationService = new();
        DepartnentService _departnentService = new();
        ExpenditureService _expenditureService = new();

        public TextBox valueTextBox;
        public DelegateCommand updateListItemsCommand { get; set; }
        public DelegateCommand updateOrganizationsItemCommand { get; set; }
        public DelegateCommand updateListDepartmentsCommand { get; set; }

        private List<String> _items;
        private List<String> _departmens;
        private List<String> _organizations;
        private string _item { get; set; } = "";
        private DateTime _date { get; set; }
        private string _value { get; set; } = "";
        private string _department { get; set; } = "";
        public string _organization { get; set; } = "";
        public string _comment { get; set; } = "";

        public List<String> Organizations
        {
            get => _organizations;
            set
            {
                _organizations = value;
                RaisePropertyChanged(nameof(Organizations));
            }
        }

        public List<String> Departments
        {
            get => _departmens;
            set
            {
                _departmens = value;
                RaisePropertyChanged(nameof(Departments));
            }
        }

        public List<String> Items
        {
            get => _items;
            set
            {
                _items = value;
                RaisePropertyChanged(nameof(Items));
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                RaisePropertyChanged(nameof(Date));
            }
        }

        public string Department
        {
            get => _department;
            set
            {
                _department = value;
                RaisePropertyChanged(nameof(Department));
            }
        }

        public string Organization
        {
            get => _organization;
            set
            {
                _organization = value;
                RaisePropertyChanged(nameof(Organization));
            }
        }

        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                RaisePropertyChanged(nameof(Comment));
            }
        }

        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                RaisePropertyChanged(nameof(Value));
            }
        }

        public string Item
        {
            get => _item;
            set
            {
                _item = value;
                RaisePropertyChanged(nameof(Item));
            }
        }
        private void getItems(List<Param> items)
        {
            _items = new List<String>();
            foreach (var item in items)
            {
                _items.Add(item.name);
            }
        }

        private async void loadItemsAsync()
        {
            var response = await _expenditureService.GetAllAsync();

            if (response != null)
            {
                Items = response.OrderBy(x => x.Name).Select(x => x.Name).ToList();
            }
        }

        private async void loadOrganizationsAsync()
        {
            var response = await _organizationService.GetAllAsync();

            if (response != null)
            {
                Organizations = response.OrderBy(x => x.Name).Select(x => x.Name).ToList();
            }
        }

        private async void loadDepartmentsAsync()
        {
            var response = await _departnentService.GetAllAsync();

            if (response != null)
            {
                Departments = response.OrderBy(x => x.Name).Select(x => x.Name).ToList();
            }
        }
    }

}

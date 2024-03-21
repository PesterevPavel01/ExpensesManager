using Prism.Mvvm;
using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ExpensesManager
{
    public class Document : BindableBase
    {
        public Document() { }

        private CultureInfo culture = new CultureInfo("ru-RU");

        public Document(string id, string item, string date, string value, string organization, string department, string comment, BitmapImage icon)
        {

            this.Id = id;
            this.Date = date;
            this.Value = _formattingNumber(value);
            this.Organization = organization;
            this.Item = item;
            this.Department = department;
            this.Comment = comment;
            _statusIcon= icon;
        }

        public string Id { get; set; }
        private string? _item { get; set; }
        public string _date { get; set; }
        public string _value { get; set; }
        public string? _department { get; set; }
        public string? _organization { get; set; }
        public string? _comment { get; set; }

        private BitmapImage _statusIcon { get; set; }
        private bool _checked { get; set; } = true;

        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                RaisePropertyChanged(nameof(Comment));
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

        public string Value
        {
            get => _value;
            set
            {
                _value = _formattingNumber(value);
                RaisePropertyChanged(nameof(Value));
            }
        }

        public string Date
        {
            get => _date;
            set
            {
                _date = value;
                RaisePropertyChanged(nameof(Date));
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

        public bool Checked
        {
            get => _checked;
            set
            {
                _checked = value;
                RaisePropertyChanged(nameof(Checked));
            }
        }

        public BitmapImage StatusIcon
        {
            get => _statusIcon;
            set
            {
                _statusIcon = value;
                RaisePropertyChanged(nameof(StatusIcon));
            }
        }

        private string _formattingNumber (string number)
        {
            return Convert.ToDouble(number).ToString("N1", culture);
        }

        //public static implicit operator Document(ListViewItem v)
        //{
        //    throw new NotImplementedException();
        //}

    }
}

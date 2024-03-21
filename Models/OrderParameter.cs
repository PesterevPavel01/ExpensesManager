using Prism.Commands;
using Prism.Mvvm;

namespace ExpensesManager
{
    public class OrderParameter:BindableBase
    {
        private string _id { get; set; }
        private string _name { get; set; }
        private bool _value { get; set; }

        public string id
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged(nameof(id));
            }
        }

        public string name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(name));
            }
        }

        public bool value
        {
            get => _value;
            set
            {
                _value = value;
                RaisePropertyChanged(nameof(value));
            }
        }
    }


}

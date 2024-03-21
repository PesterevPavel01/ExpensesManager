using Prism.Mvvm;

namespace ExpensesManager.Models
{
    internal class MessageWindowViewModel : BindableBase
    {
        public MessageWindowViewModel() {
            result = false;
        }


        private string _content { get; set; }

        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                RaisePropertyChanged(nameof(Content));
            }
        }

        public bool result=false;

        public void clickOk() {
            result = true;
        }

        public void clickError()
        {
            result = false;
        }

        public void update() {
            result = false;
        }
    }
}

using Prism.Mvvm;
using System.Windows.Media.Imaging;

namespace ExpensesManager.Models
{
    public class CommonItemDto : BindableBase,ICommonItem<short>
    {
        public short? Id { get ; set; }
        public string Name { get ; set ; }
        private BitmapImage _statusIcon { get; set; }
        private bool _checked { get; set; } = true;

        public CommonItemDto(ICommonItem<short> item, BitmapImage statusIcon) 
        { 
            StatusIcon = statusIcon;
            Checked = true;
            Id= item.Id;
            Name = item.Name;
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
    }
}

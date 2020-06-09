using System.ComponentModel;

namespace PracticeWPF.Core
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public string title { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

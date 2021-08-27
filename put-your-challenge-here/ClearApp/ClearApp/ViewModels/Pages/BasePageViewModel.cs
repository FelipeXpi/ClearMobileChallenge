using System.ComponentModel;

namespace ClearApp.ViewModels.Pages
{
    public abstract class BasePageViewModel : INotifyPropertyChanged
    {
        #region Fields

        private bool isBusy;

        #endregion

        #region Properties

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        #endregion

        #region Virtual Methods

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}

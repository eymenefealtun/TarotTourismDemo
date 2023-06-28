using Tourism.MainPage.Core;
using Tourism.MainPage.Services;

namespace Tourism.MainPage.MVVM.ViewModel
{
    public class SettingsViewModel : Core.ViewModel
    {
        private INavigationService _navigation;
        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand MainWindowComand { get; set; }


        public SettingsViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            MainWindowComand = new RelayCommand(o => { Navigation.NavigateTo<MainViewModel>(); }, canExecute: o => true);
        }

       // public GlobalViewModel Global { get; } = GlobalViewModel.Instance;





    }
}

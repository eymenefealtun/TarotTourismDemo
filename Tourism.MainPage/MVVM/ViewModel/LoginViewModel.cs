using Tourism.MainPage.Core;
using Tourism.MainPage.Services;

namespace Tourism.MainPage.MVVM.ViewModel
{
    public class LoginViewModel : Core.ViewModel
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
        public RelayCommand MainWindowCommand { get; set; }
        public LoginViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            MainWindowCommand = new RelayCommand(o => { Navigation.NavigateTo<MainWindowViewModel>(); }, canExecute: o => true);

        }

    }
}

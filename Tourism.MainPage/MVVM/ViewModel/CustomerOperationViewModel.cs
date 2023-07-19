using Tourism.Core.Exceptions;
using Tourism.MainPage.Core;
using Tourism.MainPage.Services;
using Tourism.MainPage.Services.Authentications;

namespace Tourism.MainPage.MVVM.ViewModel
{
    class CustomerOperationViewModel : Core.ViewModel
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
        public RelayCommand OperationViewCommand { get; set; }
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ReservationDetailViewCommand { get; set; }
        public CustomerOperationViewModel(INavigationService navigation)                
        {           
            Navigation = navigation;
            OperationViewCommand = new RelayCommand(o => { Navigation.NavigateTo<OperationViewModel>(); }, canExecute: o => true);
            HomeViewCommand = new RelayCommand(o => { Navigation.NavigateTo<HomeViewModel>(); }, canExecute: o => true);
            ReservationDetailViewCommand = new RelayCommand(o =>
            {
            if (User.IsOperatorUserAuthorized(new string[] {"admin"}))                         
                    Navigation.NavigateTo<ReservationDetailViewModel>();                
                else
                    throw new UserNotAuthorizedException("Hello");
            }, canExecute: o => true);
        }


    }
}

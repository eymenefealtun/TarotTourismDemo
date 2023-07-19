using Tourism.MainPage.Core;
using Tourism.MainPage.Services;

namespace Tourism.MainPage.MVVM.ViewModel
{
    public class OperationViewModel : Core.ViewModel
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
        public RelayCommand CustomerViewCommand { get; set; }   
        public RelayCommand CustomerOperationViewCommand { get; set; }
        public RelayCommand ReservationDetailViewCommand { get; set; }

        public OperationViewModel(INavigationService navigation)                    
        {                           
            Navigation = navigation;
            CustomerViewCommand = new RelayCommand(o => { Navigation.NavigateTo<CustomerViewModel>(); }, canExecute: o => true);
            CustomerOperationViewCommand = new RelayCommand(o => { Navigation.NavigateTo<CustomerOperationViewModel>(); }, canExecute: o => true);
            ReservationDetailViewCommand = new RelayCommand(o => { Navigation.NavigateTo<ReservationDetailViewModel>(); }, canExecute: o => true);
        }


    }
}   

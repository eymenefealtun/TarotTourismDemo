using Tourism.MainPage.Core;
using Tourism.MainPage.Services;

namespace Tourism.MainPage.MVVM.ViewModel
{
    public class MainViewModel : Core.ViewModel
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand OperationViewCommand { get; set; }
        public RelayCommand CustomerViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        public RelayCommand CustomerOperationViewCommand { get; set; }
        public RelayCommand AddOperationViewCommand { get; set; }
        public RelayCommand UpdateOperationViewCommand { get; set; }
        public RelayCommand ReservationDetailViewCommand { get; set; }
        public RelayCommand OperatorUserViewCommand { get; set; }
        public RelayCommand CurrencyViewCommand { get; set; }
        public RelayCommand MainCategoryViewCommand { get; set; }
        public RelayCommand SubCategoryViewCommand { get; set; }

        //public HomeViewModel HomeVm { get; set; }
        //public OperationViewModel OperationVm { get; set; }
        //public CustomerViewModel CustomerVm { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
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

        public MainViewModel(INavigationService navService)
        {
            Navigation = navService;
            Navigation.NavigateTo<HomeViewModel>();

            HomeViewCommand = new RelayCommand(o => { Navigation.NavigateTo<HomeViewModel>(); }, canExecute: o => true);
            OperationViewCommand = new RelayCommand(o => { Navigation.NavigateTo<OperationViewModel>(); }, canExecute: o => true);
            CustomerViewCommand = new RelayCommand(o => { Navigation.NavigateTo<CustomerViewModel>(); }, canExecute: o => true);
            SettingsViewCommand = new RelayCommand(o => { Navigation.NavigateTo<SettingsViewModel>(); }, canExecute: o => true);
            CustomerOperationViewCommand = new RelayCommand(o => { Navigation.NavigateTo<CustomerOperationViewModel>(); }, canExecute: o => true);
            AddOperationViewCommand = new RelayCommand(o => { Navigation.NavigateTo<AddOperationViewModel>(); }, canExecute: o => true);
            UpdateOperationViewCommand = new RelayCommand(o => { Navigation.NavigateTo<UpdateOperationViewModel>(); }, canExecute: o => true);
            ReservationDetailViewCommand = new RelayCommand(o => { Navigation.NavigateTo<ReservationDetailViewModel>(); }, canExecute: o => true);
            OperatorUserViewCommand = new RelayCommand(o => { Navigation.NavigateTo<OperatorUserViewModel>(); }, canExecute: o => true);
            CurrencyViewCommand = new RelayCommand(o => { Navigation.NavigateTo<CurrencyViewModel>(); }, canExecute: o => true);
            MainCategoryViewCommand = new RelayCommand(o => { Navigation.NavigateTo<MainCategoryViewModel>(); }, canExecute: o => true);
            SubCategoryViewCommand = new RelayCommand(o => { Navigation.NavigateTo<SubCategoryViewModel>(); }, canExecute: o => true);



            #region Old
            //HomeVm = new HomeViewModel();             
            //OperationVm = new OperationViewModel();   
            //CustomerVm = new CustomerViewModel();

            //CurrentView = HomeVm; 

            //HomeViewCommand = new RelayCommand(o =>
            //{
            //    CurrentView = HomeVm;
            //});
            //OpeartionViewCommand = new RelayCommand(o =>
            //{
            //    CurrentView = OperationVm;
            //});
            //CustomerViewCommand = new RelayCommand(o =>
            //{
            //    CurrentView = CustomerVm;
            //}); 
            #endregion
        }



    }

}

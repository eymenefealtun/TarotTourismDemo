using System.Windows;
using System.Windows.Media;
using Tourism.Core.Exceptions;
using Tourism.MainPage.Core;
using Tourism.MainPage.Services;
using Tourism.MainPage.Services.Authentications;

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
        public RelayCommand GeneralIncomeOutgoingCommand { get; set; }
        public RelayCommand EmptyPageViewCommand { get; set; }
        public RelayCommand MainWindowViewCommand { get; set; }
        public RelayCommand DuplicateOperationViewCommand { get; set; }
        public RelayCommand LoginViewCommand { get; set; }
        public RelayCommand MainWindowCommand { get; set; }




        public RelayCommand MoveViewCommand { get; set; }
        public RelayCommand PinkCommand { get; set; }

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
        public GlobalViewModel Global { get; } = GlobalViewModel.Instance;


        public MainViewModel(INavigationService navService)
        {
            Navigation = navService;
            // Navigation.NavigateTo<MainWindowViewModel>();
            Navigation.NavigateTo<HomeViewModel>();
            //Navigation.NavigateTo<LoginViewModel>();




            OperationViewCommand = new RelayCommand(o =>
            {
                if (User.IsOperatorUserAuthorized(new string[] { "Manager", "Outgoing Operations Assistant Manager", "Outgoing Operations Supervisor", "Accounting" }))
                    Navigation.NavigateTo<OperationViewModel>();
                else
                    throw new UserNotAuthorizedException();
            }, canExecute: o => true);


            CustomerViewCommand = new RelayCommand(o =>
            {
                if (User.IsOperatorUserAuthorized(new string[] { "Manager", "Outgoing Operations Assistant Manager", "Outgoing Operations Supervisor", "Accounting" }))
                    Navigation.NavigateTo<CustomerViewModel>();
                else
                    throw new UserNotAuthorizedException();
            }, canExecute: o => true);


            AddOperationViewCommand = new RelayCommand(o =>
            {
                if (User.IsOperatorUserAuthorized(new string[] { "Manager", "Outgoing Operations Assistant Manager", "Outgoing Operations Supervisor", "Accounting" }))
                    Navigation.NavigateTo<AddOperationViewModel>();
                else
                    throw new UserNotAuthorizedException();
            }, canExecute: o => true);


            OperatorUserViewCommand = new RelayCommand(o =>
            {
                if (User.IsOperatorUserAuthorized(new string[] { "Admin" }))
                    Navigation.NavigateTo<OperatorUserViewModel>();
                else
                    throw new UserNotAuthorizedException();
            }, canExecute: o => true);

            CurrencyViewCommand = new RelayCommand(o =>
            {
                if (User.IsOperatorUserAuthorized(new string[] { "Manager", "Outgoing Operations Assistant Manager", "Outgoing Operations Supervisor", "Accounting" }))
                    Navigation.NavigateTo<CurrencyViewModel>();
                else
                    throw new UserNotAuthorizedException();
            }, canExecute: o => true);

            MainCategoryViewCommand = new RelayCommand(o =>
            {
                if (User.IsOperatorUserAuthorized(new string[] { "Manager", "Outgoing Operations Assistant Manager", "Outgoing Operations Supervisor", "Accounting" }))
                    Navigation.NavigateTo<MainCategoryViewModel>();
                else
                    throw new UserNotAuthorizedException();
            }, canExecute: o => true);


            SubCategoryViewCommand = new RelayCommand(o =>
            {
                if (User.IsOperatorUserAuthorized(new string[] { "Manager", "Outgoing Operations Assistant Manager", "Outgoing Operations Supervisor", "Accounting" }))
                    Navigation.NavigateTo<SubCategoryViewModel>();
                else
                    throw new UserNotAuthorizedException();
            }, canExecute: o => true);


            GeneralIncomeOutgoingCommand = new RelayCommand(o =>
            {
                if (User.IsOperatorUserAuthorized(new string[] { "Accounting" }))
                    Navigation.NavigateTo<GeneralIncomeOutgoingViewModel>();
                else
                    throw new UserNotAuthorizedException();
            }, canExecute: o => true);


            DuplicateOperationViewCommand = new RelayCommand(o =>
            {
                if (User.IsOperatorUserAuthorized(new string[] { "Manager", "Outgoing Operations Assistant Manager", "Outgoing Operations Supervisor", "Accounting" }))
                    Navigation.NavigateTo<DuplicateOperationViewModel>();
                else
                    throw new UserNotAuthorizedException();
            }, canExecute: o => true);



            #region The Pages NavigatingFromAnotherPage
            ReservationDetailViewCommand = new RelayCommand(o => { Navigation.NavigateTo<ReservationDetailViewModel>(); }, canExecute: o => true);
            UpdateOperationViewCommand = new RelayCommand(o => { Navigation.NavigateTo<UpdateOperationViewModel>(); }, canExecute: o => true);
            CustomerOperationViewCommand = new RelayCommand(o => { Navigation.NavigateTo<CustomerOperationViewModel>(); }, canExecute: o => true);

            #endregion

            HomeViewCommand = new RelayCommand(o => { Navigation.NavigateTo<HomeViewModel>(); }, canExecute: o => true);
            EmptyPageViewCommand = new RelayCommand(o => { Navigation.NavigateTo<EmptyPageViewModel>(); }, canExecute: o => true);
            LoginViewCommand = new RelayCommand(o => { Navigation.NavigateTo<LoginViewModel>(); }, canExecute: o => true);
            MainWindowCommand = new RelayCommand(o => { Navigation.NavigateTo<MainWindowViewModel>(); }, canExecute: o => true);
            SettingsViewCommand = new RelayCommand(o => { Navigation.NavigateTo<SettingsViewModel>(); }, canExecute: o => true);







            MoveViewCommand = new RelayCommand(o => { Application.Current.MainWindow.DragMove(); }, canExecute: o => false);
            MainWindowViewCommand = new RelayCommand(o => { Navigation.NavigateTo<MainWindowViewModel>(); }, canExecute: o => true);
            PinkCommand = new RelayCommand(o => { Application.Current.MainWindow.Background = new SolidColorBrush(Colors.Pink); }, canExecute: o => true);



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

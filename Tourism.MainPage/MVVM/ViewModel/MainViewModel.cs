﻿using System.Windows;
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

        public enum Statusses
        {
            Worker,
        }

        int _homeViewCommandAuthLevel = 1;
        int _operationViewCommandAuthLevel = 1;
        int _customerViewCommandAuthLevel = 1;
        int _settingsViewCommandAuthLevel = 1;
        int _customerOperationViewCommandAuthLevel = 1;
        int _addOperationViewCommandAuthLevel = 1;
        int _operatorUserViewAuthLevel = 1;
        int _updateOperationViewCommandAuthLevel = 1;
        int _reservationDetailViewCommand = 1;
        int _operatorUserViewCommandAuthLevel = 1;

        int _currencyViewCommand = 1;
        int _mainCategoryViewCommand = 1;
        int _subCategoryViewCommand = 1;
        int _generalIncomeOutgoingCommand = 1;
        int _emptyPageViewCommand = 1;
        int _loginViewCommand = 1;
        int _mainWindowCommand;


        public MainViewModel(INavigationService navService)
        {
            Navigation = navService;
            // Navigation.NavigateTo<MainWindowViewModel>();
            Navigation.NavigateTo<HomeViewModel>();
            //Navigation.NavigateTo<LoginViewModel>();

            HomeViewCommand = new RelayCommand(o => { Navigation.NavigateTo<HomeViewModel>(); }, canExecute: o => true);
            OperationViewCommand = new RelayCommand(o => { Navigation.NavigateTo<OperationViewModel>(); }, canExecute: o => true);
            CustomerViewCommand = new RelayCommand(o => { Navigation.NavigateTo<CustomerViewModel>(); }, canExecute: o => true);
            SettingsViewCommand = new RelayCommand(o => { Navigation.NavigateTo<SettingsViewModel>(); }, canExecute: o => true);
            CustomerOperationViewCommand = new RelayCommand(o => { Navigation.NavigateTo<CustomerOperationViewModel>(); }, canExecute: o => true);
            AddOperationViewCommand = new RelayCommand(o => { Navigation.NavigateTo<AddOperationViewModel>(); }, canExecute: o => true);
            UpdateOperationViewCommand = new RelayCommand(o => { Navigation.NavigateTo<UpdateOperationViewModel>(); }, canExecute: o => true);
            ReservationDetailViewCommand = new RelayCommand(o => { Navigation.NavigateTo<ReservationDetailViewModel>(); }, canExecute: o => true);

            OperatorUserViewCommand = new RelayCommand(o =>
            {
                //if (User.CurrentUser().UserLevelId <= _operatorUserViewCommandAuthLevel)
                    Navigation.NavigateTo<OperatorUserViewModel>();                 
                //else
                //    throw new UserNotAuthorizedException();
            }, canExecute: o => true);



            CurrencyViewCommand = new RelayCommand(o => { Navigation.NavigateTo<CurrencyViewModel>(); }, canExecute: o => true);
            MainCategoryViewCommand = new RelayCommand(o => { Navigation.NavigateTo<MainCategoryViewModel>(); }, canExecute: o => true);
            SubCategoryViewCommand = new RelayCommand(o => { Navigation.NavigateTo<SubCategoryViewModel>(); }, canExecute: o => true);
            GeneralIncomeOutgoingCommand = new RelayCommand(o => { Navigation.NavigateTo<GeneralIncomeOutgoingViewModel>(); }, canExecute: o => true);
            EmptyPageViewCommand = new RelayCommand(o => { Navigation.NavigateTo<EmptyPageViewModel>(); }, canExecute: o => true);
            DuplicateOperationViewCommand = new RelayCommand(o => { Navigation.NavigateTo<DuplicateOperationViewModel>(); }, canExecute: o => true);
            LoginViewCommand = new RelayCommand(o => { Navigation.NavigateTo<LoginViewModel>(); }, canExecute: o => true);
            MainWindowCommand = new RelayCommand(o => { Navigation.NavigateTo<MainWindowViewModel>(); }, canExecute: o => true);



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

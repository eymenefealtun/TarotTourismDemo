using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tourism.MainPage.Core;
using Tourism.MainPage.MVVM.View;
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

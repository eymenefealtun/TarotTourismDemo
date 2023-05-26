using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess;
using Tourism.MainPage.Core;
using Tourism.MainPage.Services;

namespace Tourism.MainPage.MVVM.ViewModel
{
    public class HomeViewModel : Core.ViewModel
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
        public RelayCommand CustomerOperationViewCommand { get; set; }
        public HomeViewModel(INavigationService navigation)
        {
            Navigation = navigation;    
            CustomerOperationViewCommand = new RelayCommand(o => { Navigation.NavigateTo<CustomerOperationViewModel>(); }, canExecute: o/*: object*/ => true);
        }
    }
}

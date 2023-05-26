using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.MainPage.Core;
using Tourism.MainPage.Services;

namespace Tourism.MainPage.MVVM.ViewModel
{
    public class CustomerViewModel : Core.ViewModel
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
        public CustomerViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            OperationViewCommand = new RelayCommand(o => { Navigation.NavigateTo<OperationViewModel>(); }, canExecute: o/*: object*/ => true);
        }
 

    }
}       

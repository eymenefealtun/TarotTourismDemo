using System;
using System.Windows;
using System.Windows.Controls;
using Tourism.Business.Abstract.Models;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.Entities.Concrete;

namespace Tourism.MainPage.MVVM.View
{

    public partial class CustomerView : UserControl
    {
        private ICustomerOperationService _customerOperationService;
        public CustomerView()
        {

            InitializeComponent();
            _customerOperationService = Instancefactory.GetInstance<ICustomerOperationService>();          
        }


        private void dgwCustomerOperation_Loaded(object sender, RoutedEventArgs e)
        {
            dgwCustomerOperation.ItemsSource = _customerOperationService.GetCustomers();

        }
    }
}

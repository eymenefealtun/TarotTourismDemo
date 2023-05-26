using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tourism.Business.Abstract.Models;
using Tourism.Business.DependencyResolvers.Ninject;     
using Tourism.Entities.Concrete;
using Tourism.MainPage.Core;
using Tourism.MainPage.MVVM.ViewModel;

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


        private void dgwCustomerOperation_Loaded_1(object sender, RoutedEventArgs e)
        {
            dgwCustomerOperation.ItemsSource = _customerOperationService.GetCustomers();
        }
    }
}

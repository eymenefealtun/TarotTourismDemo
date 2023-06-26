using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Tourism.Business.Abstract.Models;
using Tourism.Business.DependencyResolvers.Ninject;

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



        private string _firstName, _id, _reservatinCode;

        private void tboxSearchId_TextChanged(object sender, TextChangedEventArgs e)
        {
            _id = tboxSearchId.Text;
            GetCustomersWithWilter();
        }

        private void GetCustomersWithWilter()
        {

            try
            {
                dgwCustomerOperation.ItemsSource = _customerOperationService.GetCustomersWithFilter(_firstName, _id, _reservatinCode);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Tarot MIS", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void tboxSearchReservationCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            _reservatinCode = tboxSearchReservationCode.Text;
            GetCustomersWithWilter();
            if (tboxSearchName.Text == "" && tboxSearchId.Text == "" && tboxSearchReservationCode.Text == "")
            {
                dgwCustomerOperation.ItemsSource = _customerOperationService.GetCustomers();
            }

        }


        private void tboxSearchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            _firstName = tboxSearchName.Text;
            GetCustomersWithWilter();
        }


        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            dgwCustomerOperation.ItemsSource = _customerOperationService.GetCustomers();
            tboxSearchId.Text = String.Empty;
            tboxSearchReservationCode.Text = String.Empty;
            tboxSearchName.Text = String.Empty;
        }

    }
}

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Tourism.Business.Abstract.Models;
using Tourism.Business.DependencyResolvers.Ninject;

namespace Tourism.MainPage.MVVM.View
{
    public partial class CustomerOperationView : UserControl
    {

        private ICustomerOperationService _customerOperationService;
        public string _documentCode;
        public int _operationId;

        public CustomerOperationView()
        {
        }

        public CustomerOperationView(int operationId, string documentCode)
        {
            InitializeComponent();
            _customerOperationService = Instancefactory.GetInstance<ICustomerOperationService>();
            _operationId = operationId;
            _documentCode = documentCode;
            dgwCustomerOperation.ItemsSource = _customerOperationService.GetCustomerOperation(_operationId);
            txbOperation.Text = _documentCode;
        }

        private void dgwCustomerOperation_Loaded(object sender, RoutedEventArgs e)
        {
            ColoringRowsByDocumentCode();
        }

        private void ColoringRowsByDocumentCode()
        {
            DataGridRow firstRow = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(0);
            firstRow.Background = Brushes.White;
            int j = 0;

            for (int i = 1; i < dgwCustomerOperation.Items.Count; i++)
            {
                DataGridRow dataGridRow = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i);
                TextBlock cellContent = dgwCustomerOperation.Columns[9].GetCellContent(dataGridRow) as TextBlock;

                DataGridRow dataGridRowMinusOne = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i - 1);
                TextBlock cellContentMinusOne = dgwCustomerOperation.Columns[9].GetCellContent(dataGridRowMinusOne) as TextBlock;

                if (cellContent.Text == cellContentMinusOne.Text && j == 0)
                {
                    dataGridRow.Background = Brushes.White;
                }
                else if (cellContent.Text != cellContentMinusOne.Text && j == 0)
                {
                    dataGridRow.Background = Brushes.LightGray;
                    j = 1;
                }
                else if (cellContent.Text == cellContentMinusOne.Text && j != 0)
                {
                    dataGridRow.Background = Brushes.LightGray;
                    j++;
                }
                else if (cellContent.Text != cellContentMinusOne.Text && j != 0)
                {
                    dataGridRow.Background = Brushes.White;
                    j = 0;
                }
            }
        }

        private void tboxCustomerOperationSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (!String.IsNullOrEmpty(tboxCustomerOperationSearch.Text))
            {
                dgwCustomerOperation.ItemsSource = _customerOperationService.SearchCustomerOperation(tboxCustomerOperationSearch.Text, _operationId);
            }
            else
            {
                dgwCustomerOperation.ItemsSource = _customerOperationService.GetCustomerOperation(_operationId);
            }
        }

        private void GetCustomerOperationView()
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            GetCustomerOperationView();
        }

        private void btnBack_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnBack.Opacity = 0.1;
        }


    }
}

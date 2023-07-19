using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Tourism.Business.Abstract.Models;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.Entities.Models;
using Tourism.MainPage.Core;
using Tourism.MainPage.Services.Authentications;

namespace Tourism.MainPage.MVVM.View
{
    public partial class CustomerOperationView : UserControl
    {

        private ICustomerOperationService _customerOperationService;
        public string _documentCode;
        public int _operationId;
        public int _subCategoryId;
        public int _reservationId;

        public CustomerOperationView()
        {

        }

        public CustomerOperationView(int operationId, string documentCode, int subCategoryId)
        {
            InitializeComponent();
            _customerOperationService = Instancefactory.GetInstance<ICustomerOperationService>();
            _operationId = operationId;
            _documentCode = documentCode;
            _subCategoryId = subCategoryId;
            dgwCustomerOperation.ItemsSource = _customerOperationService.GetCustomerOperation(_operationId, _isActive);
            txbOperation.Text = _documentCode;
        }

        private void dgwCustomerOperation_Loaded(object sender, RoutedEventArgs e)
        {


            if (dgwCustomerOperation.Items.Count > 0)
            {
                ColoringRowsByDocumentCode();
                //DeleteBedType();
            }

        }

        private void DeleteBedType()
        {
            for (int i = 0; i < dgwCustomerOperation.Items.Count; i++)
            {
                DataGridRow dataGridRow = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i);
                TextBlock cellContent = dgwCustomerOperation.Columns[0].GetCellContent(dataGridRow) as TextBlock;

                if (cellContent.Text == "Double")
                {
                    DataGridRow dataGridRowPlusOne = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i + 1);
                    TextBlock cellContentPlusOne = dgwCustomerOperation.Columns[0].GetCellContent(dataGridRowPlusOne) as TextBlock;
                    cellContentPlusOne.Text = String.Empty;
                    i++;
                }
                else if (cellContent.Text == "Triple")
                {
                    DataGridRow dataGridRowPlusOne = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i + 1);
                    TextBlock cellContentPlusOne = dgwCustomerOperation.Columns[0].GetCellContent(dataGridRowPlusOne) as TextBlock;

                    DataGridRow dataGridRowPlusTwo = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i + 2);
                    TextBlock cellContentPlusTwo = dgwCustomerOperation.Columns[0].GetCellContent(dataGridRowPlusTwo) as TextBlock;
                    cellContentPlusOne.Text = String.Empty;
                    cellContentPlusTwo.Text = String.Empty;
                    i += 2;
                }
                else if (cellContent.Text == "Quad")
                {
                    DataGridRow dataGridRowPlusOne = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i + 1);
                    TextBlock cellContentPlusOne = dgwCustomerOperation.Columns[0].GetCellContent(dataGridRowPlusOne) as TextBlock;

                    DataGridRow dataGridRowPlusTwo = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i + 2);
                    TextBlock cellContentPlusTwo = dgwCustomerOperation.Columns[0].GetCellContent(dataGridRowPlusTwo) as TextBlock;

                    DataGridRow dataGridRowPlusThree = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i + 3);
                    TextBlock cellContentPlusThree = dgwCustomerOperation.Columns[0].GetCellContent(dataGridRowPlusThree) as TextBlock;

                    cellContentPlusOne.Text = String.Empty;
                    cellContentPlusTwo.Text = String.Empty;
                    cellContentPlusThree.Text = String.Empty;
                    i += 3;
                }
            }
        }

        private void ColoringRowsByDocumentCode()
        {
            DataGridRow firstRow = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(0);

            firstRow.Background = Brushes.White;
            int j = 0;

            for (int i = 1; i < dgwCustomerOperation.Items.Count; i++)
            {
                DataGridRow dataGridRow = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i);
                TextBlock cellContent = dgwCustomerOperation.Columns[8].GetCellContent(dataGridRow) as TextBlock;

                DataGridRow dataGridRowMinusOne = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i - 1);
                TextBlock cellContentMinusOne = dgwCustomerOperation.Columns[8].GetCellContent(dataGridRowMinusOne) as TextBlock;

                if (cellContent.Text == cellContentMinusOne.Text && j == 0)
                {
                    dataGridRow.Background = Brushes.White;
                }
                else if (cellContent.Text != cellContentMinusOne.Text && j == 0)
                {
                    dataGridRow.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#dbdcdc");
                    j = 1;
                }
                else if (cellContent.Text == cellContentMinusOne.Text && j != 0)
                {
                    dataGridRow.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#dbdcdc");
                    j++;
                }
                else if (cellContent.Text != cellContentMinusOne.Text && j != 0)
                {
                    dataGridRow.Background = Brushes.White;
                    j = 0;
                }
            }
        }
        private void ColoringRowsByDataGrid()
        {
            DataGridRow firstRow = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(0);
            firstRow.Background = Brushes.White;
            int j = 0;

            for (int i = 1; i < dgwCustomerOperation.Items.Count; i++)
            {
                DataGridRow dataGridRow = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i);
                TextBlock cellContent = dgwCustomerOperation.Columns[8].GetCellContent(dataGridRow) as TextBlock;

                DataGridRow dataGridRowMinusOne = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i - 1);
                TextBlock cellContentMinusOne = dgwCustomerOperation.Columns[8].GetCellContent(dataGridRowMinusOne) as TextBlock;

                if (cellContent.Text == cellContentMinusOne.Text && j == 0)
                {
                    dataGridRow.Background = Brushes.White;
                }
                else if (cellContent.Text != cellContentMinusOne.Text && j == 0)
                {
                    dataGridRow.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#dbdcdc");
                    j = 1;
                }
                else if (cellContent.Text == cellContentMinusOne.Text && j != 0)
                {
                    dataGridRow.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#dbdcdc");
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
                dgwCustomerOperation.ItemsSource = _customerOperationService.SearchCustomerOperation(tboxCustomerOperationSearch.Text, _operationId, _isActive);
            }
            else
            {
                dgwCustomerOperation.ItemsSource = _customerOperationService.GetCustomerOperation(_operationId, _isActive);
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

        private void dgwCustomerOperation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                CustomerOperation customerOperation = ((DataGrid)sender).SelectedItem as CustomerOperation;
                int reservationId = customerOperation.ReservationId;
                _reservationId = reservationId;
                GetReservationDetail();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void GetReservationDetail()
        {
            if (User.IsOperatorUserAuthorized(new string[] { "Admin", "Manager","Outgoing Operator" }))     
            {
                ReservationDetailView reservationDetailView = new ReservationDetailView(_operationId, _subCategoryId, _reservationId, _isActive);
                MainGrid.Children.Add(reservationDetailView);
            }
            else
                MessageBox.Show("User not authorized", "Tarot MIS", MessageBoxButton.OK, MessageBoxImage.Error);
                        
            #region TrialOfRelayComand
            //// var viewModel = (MainViewModel)DataContext;
            //var operationViewModel = (OperationViewModel)DataContext;


            //try
            //{
            //    //viewModel.ReservationDetailViewCommand.Execute(true);
            //    operationViewModel.ReservationDetailViewCommand.Execute(true);
            //}
            //catch (UserNotAuthorizedException exception)
            //{
            //    MessageBox.Show(exception.Message, "Tarot MIS", MessageBoxButton.OK, MessageBoxImage.Error);
            //    //LooseFocusOfSubButton(btnSubOperatorUser);
            //    //btnSubOperatorUser.IsChecked = false;
            //    return;
            //} 
            #endregion

        }


        private bool _isActive = true;
        private void tglIsActive_Click(object sender, RoutedEventArgs e)
        {
            if (tglIsActive.IsChecked == true)
            {
                _isActive = false;
                //CustomerOperationView customer = new CustomerOperationView();
                dgwCustomerOperation.ItemsSource = _customerOperationService.GetCustomerOperation(_operationId, _isActive);

                //object sender2 = new object[0];
                //RoutedEventArgs e2 = new RoutedEventArgs();
                //dgwCustomerOperation_Loaded(sender2, e2);

            }
            else if (tglIsActive.IsChecked == false)
            {
                _isActive = true;
                ///CustomerOperationView customer = new CustomerOperationView();
                dgwCustomerOperation.ItemsSource = _customerOperationService.GetCustomerOperation(_operationId, _isActive);

                //object sender2 = new object[0];
                //RoutedEventArgs e2 = new RoutedEventArgs();
                //dgwCustomerOperation_Loaded(sender2, e2);
            }
        }

        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            Utilities.ExportCustomerOperationToExcel(dgwCustomerOperation, _documentCode);

        }

        private void btnTools_MouseEnter(object sender, MouseEventArgs e)
        {
            btnTools.IsChecked = true;
            btnExcel.Visibility = Visibility.Visible;
            btnWord.Visibility = Visibility.Visible;
        }

        private void btnTools_MouseLeave(object sender, MouseEventArgs e)
        {
            btnTools.IsChecked = false;
            btnExcel.Visibility = Visibility.Collapsed;
            btnWord.Visibility = Visibility.Collapsed;
        }

        private void btnTools_Click(object sender, RoutedEventArgs e)
        {
            if (btnTools.IsChecked == false)
                btnTools.IsChecked = true;
            else if (btnTools.IsChecked == true)
                btnTools.IsChecked = false;
        }
    }
}

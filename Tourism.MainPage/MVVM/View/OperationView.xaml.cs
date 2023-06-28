using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tourism.Business.Abstract.Models;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.MainPage.MVVM.View.Window;
using Tourism.DataAccess.Abstract;
using Tourism.Entities.Concrete;
using Tourism.Entities.Models;
using Tourism.MainPage.Core;

namespace Tourism.MainPage.MVVM.View
{
    public partial class OperationsView : UserControl
    {
        #region Customer
        private IOperationMainService _operationMainService;
        private IOperationService _operationService;
        private ICustomerOperationService _customerOperationService;
        private IMainCategoryService _mainCategoryService;
        private ISubCategoryService _subCategoryService;
        private IUserLevelService _userLevelService;
        private IOperatorService _operatorService;
        private ICurrencyService _currencyService;
        #endregion  

        public string _documentCode;
        public string _operationSearch;
        public int _mainCategoryId;
        public int _subCategoryId;
        public int _operatorId;
        public int _operationId;
        public int _currencyId;
        public bool _isActive;

        public DateTime _startDate = DateTime.MinValue;
        public DateTime _endDate = DateTime.MaxValue;
        public OperationsView()
        {
            InitializeComponent();
            _operationMainService = Instancefactory.GetInstance<IOperationMainService>();
            _customerOperationService = Instancefactory.GetInstance<ICustomerOperationService>();
            _mainCategoryService = Instancefactory.GetInstance<IMainCategoryService>();
            _subCategoryService = Instancefactory.GetInstance<ISubCategoryService>();
            _operationService = Instancefactory.GetInstance<IOperationService>();
            _userLevelService = Instancefactory.GetInstance<IUserLevelService>();
            _operatorService = Instancefactory.GetInstance<IOperatorService>();
            _currencyService = Instancefactory.GetInstance<ICurrencyService>();

            var ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
            Thread.CurrentThread.CurrentCulture = ci;
        }

        private void dgwOperationMain_Loaded(object sender, RoutedEventArgs e)
        {
            _isActive = true;

            dgwOperationMain.ItemsSource = _operationMainService.GetOperationMain();
            cboxMainCategory.ItemsSource = _mainCategoryService.GetAll();
            cboxCurrency.ItemsSource = _currencyService.GetAll();
            cboxOperator.ItemsSource = _operatorService.GetAll();
        }

        private void cboxMainCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxMainCategory.SelectedIndex != -1)
            {
                _mainCategoryId = Convert.ToInt32(cboxMainCategory.SelectedValue);
                cboxSubCategory.ItemsSource = _subCategoryService.GetByMainCategory(_mainCategoryId);
                cboxSubCategory.Visibility = Visibility.Visible;
                _subCategoryId = 0;
                SearchOperationMain();
            }
        }

        private void cboxSubCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxSubCategory.SelectedIndex != -1)
            {
                _subCategoryId = Convert.ToInt32(cboxSubCategory.SelectedValue);
                SearchOperationMain();
            }
        }

        private void tboxOperationSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            _operationSearch = tboxOperationSearch.Text;
            SearchOperationMain();
        }


        private void dgwOperationMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                OperationMain operationMain = ((DataGrid)sender).SelectedItem as OperationMain;
                string documentCode = operationMain.DocumentCode;
                int operationId = operationMain.Id;
                int subCategoryId = operationMain.SubCategoryId;
                _operationId = operationId;
                _documentCode = documentCode;
                _subCategoryId = subCategoryId;
                GetCustomerOperationView();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Not Valid!");
                MessageBox.Show(exception.Message);
            }
        }
        private void dgwOperationMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgwOperationMain.SelectedIndex >= 0)
            {
                OperationMain? operationMain = ((DataGrid)sender).SelectedItem as OperationMain;
                string documentCode = operationMain.DocumentCode;
                int operationId = operationMain.Id;
                _documentCode = documentCode;
                _operationId = operationId;
                menuUpdateOperation.Header = $"Detail of {_documentCode}";
            }
        }

        private void datePickStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datePickStartDate.SelectedDate != null)
            {
                _startDate = (DateTime)datePickStartDate.SelectedDate;
                SearchOperationMain();
            }
        }

        private void datePickEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datePickEndDate.SelectedDate != null)
            {
                _endDate = (DateTime)datePickEndDate.SelectedDate;
                SearchOperationMain();
            }
        }

        private void SearchOperationMain()
        {


            _subCategoryId = Convert.ToInt32(cboxSubCategory.SelectedValue);
            if (tglIsActive.IsChecked == false)
            {
                _isActive = true;

            }
            else if (tglIsActive.IsChecked == true)
            {
                _isActive = false;
            }
            dgwOperationMain.ItemsSource = _operationMainService.SearchOperationMain(_operationSearch, _mainCategoryId, _subCategoryId, _startDate, _endDate, _operatorId, _currencyId, _isActive);
            dgwOperationMain.Items.SortDescriptions.Add(new SortDescription("StartDate", ListSortDirection.Ascending));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            GetAddOperationView();
        }

        private void GetCustomerOperationView()
        {
            CustomerOperationView customerOperationView = new CustomerOperationView(_operationId, _documentCode, _subCategoryId);
            OperationViewMainGrid.Children.Add(customerOperationView);
        }

        private void GetAddOperationView()
        {
            AddOperationView addOperationView = new AddOperationView();
            OperationViewMainGrid.Children.Add(addOperationView);
        }
        private void GetUpdateOperation()
        {
            UpdateOperationView updateOperationView = new UpdateOperationView(_operationId);
            OperationViewMainGrid.Children.Add(updateOperationView);
        }



        private void menuUpdateOperation_Click(object sender, RoutedEventArgs e)
        {
            GetUpdateOperation();

        }

        private void cboxOperator_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxOperator.SelectedIndex != -1)
            {
                _operatorId = Convert.ToInt32(cboxOperator.SelectedValue);
                SearchOperationMain();
            }
        }

        private void cboxCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxCurrency.SelectedIndex != -1)
            {
                _currencyId = Convert.ToInt32(cboxCurrency.SelectedValue);
                SearchOperationMain();
            }
        }

        private void tglIsActive_Click(object sender, RoutedEventArgs e)
        {
            if (tglIsActive.IsChecked == true)
            {
                _isActive = false;

                SearchOperationMain();
            }
            else if (tglIsActive.IsChecked == false)
            {
                _isActive = true;
                SearchOperationMain();
            }
        }

        private void editCurrency_Click(object sender, RoutedEventArgs e)
        {
            CurrencyWindow currencyWindow = new CurrencyWindow();
            currencyWindow.ShowDialog();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tboxOperationSearch.Text = String.Empty;
                cboxMainCategory.SelectedIndex = -1;
                cboxMainCategory.SelectedValue = 0;
                cboxSubCategory.SelectedValue = 0;
                cboxOperator.SelectedValue = 0;
                cboxCurrency.SelectedValue = 0;
                cboxSubCategory.Visibility = Visibility.Hidden;
                _mainCategoryId = 0;
                _subCategoryId = 0;
                _operatorId = 0;
                _currencyId = 0;
                _isActive = true;
                tglIsActive.IsChecked = false;
                //datePickEndDate = new DatePicker();
                //datePickStartDate = new DatePicker();

                //datePickStartDate.SelectedDate = DateTime.MinValue;
                //datePickEndDate.SelectedDate = DateTime.MaxValue;

                datePickStartDate.SelectedDate = null;
                datePickEndDate.SelectedDate = null;
                _endDate = DateTime.MaxValue;
                _startDate = DateTime.MinValue;
                dgwOperationMain.ItemsSource = _operationMainService.GetOperationMain();
                cboxMainCategory.ItemsSource = _mainCategoryService.GetAll();
                cboxOperator.ItemsSource = _operatorService.GetAll();
                cboxCurrency.ItemsSource = _currencyService.GetAll();
            }
            catch (Exception)
            {
                MessageBox.Show("Error for refreshing!");
            }
        }

        private void btnExportToExcel_Click(object sender, RoutedEventArgs e)
        {
            Utilities.ExportToExcel(dgwOperationMain);
        }



        private void editMainCategory_Click(object sender, RoutedEventArgs e)
        {
            //_category ca = _category.main;
            CategoryWindow categoryWindow = new CategoryWindow("main");
            categoryWindow.ShowDialog();
        }

        private void editSubCategory_Click(object sender, RoutedEventArgs e)
        {
            ISubCategoryService subCategoryService = _subCategoryService;
            CategoryWindow categoryWindow = new CategoryWindow("sub", _mainCategoryId, subCategoryService);
            categoryWindow.ShowDialog();
        }

        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            Utilities.ExportToExcel(dgwOperationMain);

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
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Tourism.Business.Abstract.Models;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.DataAccess.Abstract;
using Tourism.Entities.Concrete;
using Tourism.Entities.Models;

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
        #endregion  

        public string _documentCode;
        public string _operationSearch;
        public int _mainCategoryId;
        public int _subCategoryId;
        public int _operatorId;
        public int _operationId;

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
        }

        private void dgwOperationMain_Loaded(object sender, RoutedEventArgs e)
        {
            dgwOperationMain.ItemsSource = _operationMainService.GetOperationMains();
            cboxMainCategory.ItemsSource = _mainCategoryService.GetAll();
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
                _operationId = operationId;
                _documentCode = documentCode;
                GetCustomerOperationView();
            }
            catch (Exception)
            {
                MessageBox.Show("Not Valid!");
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
            dgwOperationMain.ItemsSource = _operationMainService.SearchOperationMain(_operationSearch, _mainCategoryId, _subCategoryId, _startDate, _endDate, _operatorId);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            GetAddOperationView();
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
                cboxSubCategory.Visibility = Visibility.Hidden;
                _mainCategoryId = 0;
                _subCategoryId = 0;
                _operatorId = 0;
                datePickStartDate.SelectedDate = DateTime.MinValue;
                datePickEndDate.SelectedDate = DateTime.MaxValue;
                dgwOperationMain.ItemsSource = _operationMainService.GetOperationMains();
            }
            catch (Exception)
            {
                MessageBox.Show("Error for refreshing!");
            }
        }

        private void GetCustomerOperationView()
        {
            CustomerOperationView customerOperationView = new CustomerOperationView(_operationId, _documentCode);
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

        private void btnRefresh_MouseMove(object sender, MouseEventArgs e)
        {
            btnRefresh.Opacity = 0.1;
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

    }
}
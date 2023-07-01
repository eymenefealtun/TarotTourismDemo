using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Tourism.Business.Abstract.Models;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.DataAccess.Abstract;
using Tourism.Entities.Concrete;
using Tourism.MainPage.Core;

namespace Tourism.MainPage.MVVM.View
{
    public partial class GeneralIncomeOutgoingView : UserControl
    {
        private IOperationMainService _operationMainService;
        private IIncomeInformationService _incomeInformationService;
        //private IOperationService _operationService;
        //private ICurrencyService _currencyService;
        //private ISubCategoryService _subCategoryService;
        //private IMainCategoryService _mainCategoryService;
        //private IReservationService _reservationService;
        //private IAgencyUserService _agencyUserService;
        //private IAgencyService _agencyService;
        //private IOperatorService _operatorService;
        //private IBedTypeService _bedTypeService;
        public GeneralIncomeOutgoingView()
        {
            InitializeComponent();
            _operationMainService = Instancefactory.GetInstance<IOperationMainService>();
            _incomeInformationService = Instancefactory.GetInstance<IIncomeInformationService>();
            //_operationService = Instancefactory.GetInstance<IOperationService>();
            //_currencyService = Instancefactory.GetInstance<ICurrencyService>();
            //_subCategoryService = Instancefactory.GetInstance<ISubCategoryService>();
            //_mainCategoryService = Instancefactory.GetInstance<IMainCategoryService>();
            //_reservationService = Instancefactory.GetInstance<IReservationService>();
            //_agencyUserService = Instancefactory.GetInstance<IAgencyUserService>();
            //_agencyService = Instancefactory.GetInstance<IAgencyService>();
            //_operatorService = Instancefactory.GetInstance<IOperatorService>();
            //_bedTypeService = Instancefactory.GetInstance<IBedTypeService>();


            dgwGeneralIncome.ItemsSource = _operationMainService.GetOperationMain();
            cboxForDgwGeneral.SelectedIndex = 0;
            //tboxIncomeByFar.Text = _incomeInformationService.TotalIncomeByFar().TotalIncome.ToString();

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            dgwGeneralIncome.ItemsSource = _operationMainService.GetOperationMain();
            cboxForDgwGeneral.SelectedIndex = 0;
            tboxSearchForDgwGeneral.Text = String.Empty;
        }

        #region Tools
        private void btnToolsGeneralIncome_MouseEnter(object sender, MouseEventArgs e)
        {
            ToolMouseEnter(btnToolsGeneralIncome, btnExcelGeneralIncome, btnWord);
        }

        private void btnToolsGeneralIncome_MouseLeave(object sender, MouseEventArgs e)
        {
            ToolMouseLeave(btnToolsGeneralIncome, btnExcelGeneralIncome, btnWord);
        }

        private void btnToolsGeneralIncome_Click(object sender, RoutedEventArgs e)
        {
            ToolButtonClick(btnToolsGeneralIncome);
        }

        private void btnExcelGeneralIncome_Click(object sender, RoutedEventArgs e)
        {
            Utilities.ExportToExcel(dgwGeneralIncome);

        }

        private void btnToolsForDgwGeneral_MouseEnter(object sender, MouseEventArgs e)
        {
            ToolMouseEnter(btnToolsForDgwGeneral, btnExcelsForDgwGeneral, btnWordForDgwGeneral);

        }

        private void btnToolsForDgwGeneral_MouseLeave(object sender, MouseEventArgs e)
        {
            ToolMouseLeave(btnToolsForDgwGeneral, btnExcelsForDgwGeneral, btnWordForDgwGeneral);
        }

        private void btnExcelsForDgwGeneral_Click(object sender, RoutedEventArgs e)
        {
            Utilities.ExportToExcel(dgwGeneral);
        }

        private void btnToolsForDgwGeneral_Click(object sender, RoutedEventArgs e)
        {
            ToolButtonClick(btnToolsForDgwGeneral);
        }
        private void ToolButtonClick(ToggleButton btn)
        {
            if (btn.IsChecked == false)
                btn.IsChecked = true;
            else if (btn.IsChecked == true)
                btn.IsChecked = false;

        }

        private void ToolMouseLeave(ToggleButton toggleButton, Button btn2, Button btn3)
        {
            toggleButton.IsChecked = false;
            btn2.Visibility = Visibility.Collapsed;
            btn3.Visibility = Visibility.Collapsed;
        }
        private void ToolMouseEnter(ToggleButton toggleButton, Button btn2, Button btn3)
        {
            toggleButton.IsChecked = true;
            btn2.Visibility = Visibility.Visible;
            btn3.Visibility = Visibility.Visible;
        }
        #endregion

        private void cboxForDgwGeneral_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tboxSearchForDgwGeneral.Text = String.Empty;
            if (cboxForDgwGeneral.SelectedIndex > -1)
            {
                if (borderDgwGeneral.Visibility == Visibility.Hidden)
                    borderDgwGeneral.Visibility = Visibility.Visible;

                if (cboxForDgwGeneral.SelectedIndex == 0)
                    dgwGeneral.ItemsSource = _incomeInformationService.GetByOperation(null);
                if (cboxForDgwGeneral.SelectedIndex == 1)
                    dgwGeneral.ItemsSource = _incomeInformationService.TotalIncomeByMainCategory(null);
                if (cboxForDgwGeneral.SelectedIndex == 2)
                    dgwGeneral.ItemsSource = _incomeInformationService.TotalIncomeBySubCategory(null);
                if (cboxForDgwGeneral.SelectedIndex == 3)
                    dgwGeneral.ItemsSource = _incomeInformationService.TotalIncomeByReservation(null);
                if (cboxForDgwGeneral.SelectedIndex == 4)
                    dgwGeneral.ItemsSource = _incomeInformationService.TotalIncomeByAgencyUser(null);
                if (cboxForDgwGeneral.SelectedIndex == 5)
                    dgwGeneral.ItemsSource = _incomeInformationService.TotalIncomeByAgency(null);
                if (cboxForDgwGeneral.SelectedIndex == 6)
                    dgwGeneral.ItemsSource = _incomeInformationService.TotalIncomeByOperator(null);
                if (cboxForDgwGeneral.SelectedIndex == 7)
                    dgwGeneral.ItemsSource = _incomeInformationService.TotalIncomeByCurrency(null);
                if (cboxForDgwGeneral.SelectedIndex == 8)
                    dgwGeneral.ItemsSource = _incomeInformationService.NumberOfBedSold(null);


            }
        }

        private void tboxSearchForDgwGeneral_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cboxForDgwGeneral.SelectedIndex > -1)
            {
                string text = tboxSearchForDgwGeneral.Text;
                if (cboxForDgwGeneral.SelectedIndex == 0)
                    dgwGeneral.ItemsSource = _incomeInformationService.GetByOperation(text);
                if (cboxForDgwGeneral.SelectedIndex == 1)
                    dgwGeneral.ItemsSource = _incomeInformationService.TotalIncomeByMainCategory(text);
                if (cboxForDgwGeneral.SelectedIndex == 2)
                    dgwGeneral.ItemsSource = _incomeInformationService.TotalIncomeBySubCategory(text);
                if (cboxForDgwGeneral.SelectedIndex == 3)
                    dgwGeneral.ItemsSource = _incomeInformationService.TotalIncomeByReservation(text);
                if (cboxForDgwGeneral.SelectedIndex == 4)
                    dgwGeneral.ItemsSource = _incomeInformationService.TotalIncomeByAgencyUser(text);
                if (cboxForDgwGeneral.SelectedIndex == 5)
                    dgwGeneral.ItemsSource = _incomeInformationService.TotalIncomeByAgency(text);
                if (cboxForDgwGeneral.SelectedIndex == 6)
                    dgwGeneral.ItemsSource = _incomeInformationService.TotalIncomeByOperator(text);
                if (cboxForDgwGeneral.SelectedIndex == 7)
                    dgwGeneral.ItemsSource = _incomeInformationService.TotalIncomeByCurrency(text);
                if (cboxForDgwGeneral.SelectedIndex == 8)
                    dgwGeneral.ItemsSource = _incomeInformationService.NumberOfBedSold(text);


            }
        }

        private void tboxSearchForGeneral_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = tboxSearchForGeneral.Text;
            dgwGeneralIncome.ItemsSource = _operationMainService.GetByDocumentCode(text);
        }


    }

}


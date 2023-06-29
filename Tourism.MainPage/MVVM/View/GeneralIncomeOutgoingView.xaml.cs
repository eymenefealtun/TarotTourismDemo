using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
        private IOperationService _operationService;
        private ICurrencyService _currencyService;
        private ISubCategoryService _subCategoryService;
        private IMainCategoryService _mainCategoryService;
        private IReservationService _reservationService;
        private IAgencyUserService _agencyUserService;
        private IAgencyService _agencyService;
        private IOperatorService _operatorService;
        private IBedTypeService _bedTypeService;
        public GeneralIncomeOutgoingView()
        {
            InitializeComponent();
            _operationMainService = Instancefactory.GetInstance<IOperationMainService>();
            _incomeInformationService = Instancefactory.GetInstance<IIncomeInformationService>();
            _operationService = Instancefactory.GetInstance<IOperationService>();
            _currencyService = Instancefactory.GetInstance<ICurrencyService>();
            _subCategoryService = Instancefactory.GetInstance<ISubCategoryService>();
            _mainCategoryService = Instancefactory.GetInstance<IMainCategoryService>();
            _reservationService = Instancefactory.GetInstance<IReservationService>();
            _agencyUserService = Instancefactory.GetInstance<IAgencyUserService>();
            _agencyService = Instancefactory.GetInstance<IAgencyService>();
            _operatorService = Instancefactory.GetInstance<IOperatorService>();
            _bedTypeService = Instancefactory.GetInstance<IBedTypeService>();


            dgwGeneralIncome.ItemsSource = _operationMainService.GetOperationMain();


            cboxIncomeByOperation.ItemsSource = _operationService.GetAll();

            tboxIncomeByFar.Text = _incomeInformationService.TotalIncomeByFar().TotalIncome.ToString();

            cboxMainCategory.ItemsSource = _mainCategoryService.GetAll();
            cboxSubCategory.ItemsSource = _subCategoryService.GetAll();
            cboxReservation.ItemsSource = _reservationService.GetAll();

            cboxAgencyUser.ItemsSource = _agencyUserService.GetAll();
            cboxAgency.ItemsSource = _agencyService.GetAll();
            cboxOperator.ItemsSource = _operatorService.GetAll();
            cboxCurrency.ItemsSource = _currencyService.GetAll();
            cboxBedTypeIncome.ItemsSource = _bedTypeService.GetAll();
            cboxBedTypeNumber.ItemsSource = _bedTypeService.GetAll();

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            dgwGeneralIncome.ItemsSource = _operationMainService.GetOperationMain();
        }

        #region Tools
        private void btnToolsGeneralIncome_MouseEnter(object sender, MouseEventArgs e)
        {
            btnToolsGeneralIncome.IsChecked = true;
            btnExcelGeneralIncome.Visibility = Visibility.Visible;
            btnWord.Visibility = Visibility.Visible;
        }

        private void btnToolsGeneralIncome_MouseLeave(object sender, MouseEventArgs e)
        {
            btnToolsGeneralIncome.IsChecked = false;
            btnExcelGeneralIncome.Visibility = Visibility.Collapsed;
            btnWord.Visibility = Visibility.Collapsed;
        }

        private void btnToolsGeneralIncome_Click(object sender, RoutedEventArgs e)
        {
            if (btnToolsGeneralIncome.IsChecked == false)
                btnToolsGeneralIncome.IsChecked = true;
            else if (btnToolsGeneralIncome.IsChecked == true)
                btnToolsGeneralIncome.IsChecked = false;
        }

        private void btnExcelGeneralIncome_Click(object sender, RoutedEventArgs e)
        {
            Utilities.ExportToExcel(dgwGeneralIncome);

        }
        #endregion

        private void cboxIncomeByOperation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxIncomeByOperation.SelectedIndex > -1)
            {
                string currency = _currencyService.GetByOperation(Convert.ToInt32(cboxIncomeByOperation.SelectedValue)).FirstOrDefault().Name.ToString();
                string income = _incomeInformationService.GetByOperation(Convert.ToInt32(cboxIncomeByOperation.SelectedValue)).FirstOrDefault().TotalIncome.ToString();
                if (income.IsNullOrEmpty())
                {
                    tboxIncomeByOperation.Text = "0,00";
                    return;
                }
                tboxIncomeByOperation.Text = income + " " + currency;

            }
            if (tboxIncomeByOperation.Text.IsNullOrEmpty())
                tboxIncomeByOperation.Text = "0,00 ";
        }

        private void cboxIncomeByOperation_TextChanged(object sender, TextChangedEventArgs e)
        {
            cboxIncomeByOperation.ItemsSource = _operationService.GetByDocumentCode(cboxIncomeByOperation.Text);

            if (cboxIncomeByOperation.Text.IsNullOrEmpty())
                cboxIncomeByOperation.ItemsSource = _operationService.GetAll();
        }

        private int ComboBoxSelectedValue(ComboBox box)
        {
            int selectedValue = Convert.ToInt32(box.SelectedValue);
            return selectedValue;
        }
        private void CboxTextChanged(ComboBox cbox, TextBox tbox, Array result, Array getAll)
        {
            cbox.ItemsSource = result;
            if (cbox.Text.IsNullOrEmpty())
                cbox.ItemsSource = getAll;
        }
        private void CboxSelectionChanged(ComboBox cbox, TextBox tbox, object result)
        {
            if (cbox.SelectedIndex > -1)
            {
                if (result == null)
                {
                    tbox.Text = "0,00";
                    return;
                }
                tbox.Text = result.ToString();
            }
            if (tbox.Text.IsNullOrEmpty())
                tbox.Text = "0,00 ";
        }
        private void cboxIncome_DropDownOpened(object sender, EventArgs e)
        {
            if (sender == cboxIncomeByOperation)
                cboxIncomeByOperation.ItemsSource = _operationService.GetAll();
            if (sender == cboxMainCategory)
                cboxMainCategory.ItemsSource = _mainCategoryService.GetAll();
            if (sender == cboxSubCategory)
                cboxSubCategory.ItemsSource = _subCategoryService.GetAll();
            if (sender == cboxReservation)
                cboxReservation.ItemsSource = _reservationService.GetAll();
            if (sender == cboxAgencyUser)
                cboxAgencyUser.ItemsSource = _agencyUserService.GetAll();
            if (sender == cboxAgency)
                cboxAgency.ItemsSource = _agencyService.GetAll();
            if (sender == cboxOperator)
                cboxOperator.ItemsSource = _operatorService.GetAll();
            if (sender == cboxCurrency)
                cboxCurrency.ItemsSource = _currencyService.GetAll();
            if (sender == cboxBedTypeIncome)
                cboxBedTypeIncome.ItemsSource = _bedTypeService.GetAll();
            if (sender == cboxBedTypeNumber)
                cboxBedTypeNumber.ItemsSource = _bedTypeService.GetAll();

        }

        private void cboxPart11_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender == cboxMainCategory)
                CboxSelectionChanged(cboxMainCategory, tboxMainCategory, _incomeInformationService.TotalIncomeByMainCategory(ComboBoxSelectedValue(cboxMainCategory)).TotalIncome);
            if (sender == cboxSubCategory)
                CboxSelectionChanged(cboxSubCategory, tboxSubCategory, _incomeInformationService.TotalIncomeBySubCategory(ComboBoxSelectedValue(cboxSubCategory)).TotalIncome);
            if (sender == cboxReservation)
                CboxSelectionChanged(cboxReservation, tboxReservation, _incomeInformationService.TotalIncomeByReservation(ComboBoxSelectedValue(cboxReservation)).TotalIncome);
            if (sender == cboxAgencyUser)
                CboxSelectionChanged(cboxAgencyUser, tboxAgencyUser, _incomeInformationService.TotalIncomeByAgencyUser(ComboBoxSelectedValue(cboxAgencyUser)).TotalIncome);
            if (sender == cboxAgency)
                CboxSelectionChanged(cboxAgency, tboxAgency, _incomeInformationService.TotalIncomeByAgency(ComboBoxSelectedValue(cboxAgency)).TotalIncome);
            if (sender == cboxOperator)
                CboxSelectionChanged(cboxOperator, tboxOperator, _incomeInformationService.TotalIncomeByOperator(ComboBoxSelectedValue(cboxOperator)).TotalIncome);

            if (sender == cboxCurrency)
                CboxSelectionChanged(cboxCurrency, tboxCurrency, _incomeInformationService.TotalIncomeByCurrency(ComboBoxSelectedValue(cboxCurrency)).TotalIncome);
            if (sender == cboxBedTypeIncome)
                CboxSelectionChanged(cboxBedTypeIncome, tboxBedTypeIncome, _incomeInformationService.TotalIncomeByBedType(ComboBoxSelectedValue(cboxBedTypeIncome)).TotalIncome);
            if (sender == cboxBedTypeNumber)
                CboxSelectionChanged(cboxBedTypeNumber, tboxBedTypeNumber, _incomeInformationService.NumberOfBedSold(ComboBoxSelectedValue(cboxBedTypeNumber)).TotalIncome);



        }

        private void cboxPart11_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender == cboxMainCategory)
                CboxTextChanged(cboxMainCategory, tboxMainCategory, _mainCategoryService.GetByCategoryName(cboxMainCategory.Text).ToArray(), _mainCategoryService.GetAll().ToArray());
            if (sender == cboxSubCategory)
                CboxTextChanged(cboxSubCategory, tboxSubCategory, _subCategoryService.GetByCategoryName(cboxSubCategory.Text).ToArray(), _subCategoryService.GetAll().ToArray());
            if (sender == cboxReservation)
                CboxTextChanged(cboxReservation, tboxReservation, _reservationService.GetByReservattionCode(cboxReservation.Text).ToArray(), _reservationService.GetAll().ToArray());
            if (sender == cboxAgencyUser)
                CboxTextChanged(cboxAgencyUser, tboxAgencyUser, _agencyUserService.GetByName(cboxAgencyUser.Text).ToArray(), _agencyUserService.GetAll().ToArray());
            if (sender == cboxAgency)
                CboxTextChanged(cboxAgency, tboxAgency, _agencyService.GetByName(cboxAgency.Text).ToArray(), _agencyService.GetAll().ToArray());
            if (sender == cboxOperator)
                CboxTextChanged(cboxOperator, tboxAgencyUser, _operatorService.GetByName(cboxOperator.Text).ToArray(), _operatorService.GetAll().ToArray());

            if (sender == cboxCurrency)
                CboxTextChanged(cboxCurrency, tboxCurrency, _currencyService.GetByName(cboxCurrency.Text).ToArray(), _currencyService.GetAll().ToArray());
            if (sender == cboxBedTypeIncome)
                CboxTextChanged(cboxBedTypeIncome, tboxBedTypeIncome, _bedTypeService.GetByName(cboxBedTypeIncome.Text).ToArray(), _bedTypeService.GetAll().ToArray());
            if (sender == cboxBedTypeNumber)
                CboxTextChanged(cboxBedTypeNumber, tboxBedTypeNumber, _bedTypeService.GetByName(cboxBedTypeNumber.Text).ToArray(), _bedTypeService.GetAll().ToArray());
        }






    }

}

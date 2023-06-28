using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tourism.Business.Abstract.Models;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.DataAccess.Abstract;
using Tourism.MainPage.Core;

namespace Tourism.MainPage.MVVM.View
{
    public partial class GeneralIncomeOutgoingView : UserControl
    {
        private IOperationMainService _operationMainService;
        private IIncomeInformationService _incomeInformationService;
        private IOperationService _operationService;
        public GeneralIncomeOutgoingView()
        {
            InitializeComponent();
            _operationMainService = Instancefactory.GetInstance<IOperationMainService>();
            _incomeInformationService = Instancefactory.GetInstance<IIncomeInformationService>();
            _operationService = Instancefactory.GetInstance<IOperationService>();


            dgwGeneralIncome.ItemsSource = _operationMainService.GetOperationMain();


            cboxIncomeByOperation.ItemsSource = _operationService.GetAll();
        }

        private void btnRefresh_Click(object sender, System.Windows.RoutedEventArgs e)
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
            if (cboxIncomeByOperation.SelectedIndex > 0)
                tboxIncomeByOperation.Text = _incomeInformationService.GetByOperation(Convert.ToInt32(cboxIncomeByOperation.SelectedValue)).FirstOrDefault().TotalIncome.ToString();
            if (tboxIncomeByOperation.Text.IsNullOrEmpty())
                tboxIncomeByOperation.Text = "0,00";

        }

        private void cboxIncomeByOperation_TextChanged(object sender, TextChangedEventArgs e)
        {
          
            cboxIncomeByOperation.ItemsSource = _operationService.GetByDocumentCode(cboxIncomeByOperation.Text);

            if (cboxIncomeByOperation.Text.IsNullOrEmpty())
                cboxIncomeByOperation.ItemsSource = _operationService.GetAll();
           // MessageBox.Show(cboxIncomeByOperation.Text);
        }





    }

}

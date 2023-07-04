using System.Windows.Controls;
using Tourism.Business.Abstract.Models;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.DataAccess.Abstract;
using Tourism.Entities.Concrete;
using System.Windows;
using System.Collections.Generic;
using System;

namespace Tourism.MainPage.MVVM.View
{
    public partial class DuplicateOperationView : UserControl
    {
        private IMainCategoryService _mainCategoryService;
        private ISubCategoryService _subCategoryService;
        private IOperationService _operationService;
        private IOperationMainService _operationMainService;
        private IOperationPriceService _operationPriceService;
        private TextBlock[] _textBlocks;
        private DatePicker[] _startDates;
        private DatePicker[] _endDates;
        private TextBox[] _tboxDocumentCodes;
        private Operation _operation;
        private OperationPrice _operationPrice;


        public DuplicateOperationView()
        {
            InitializeComponent();
            _mainCategoryService = Instancefactory.GetInstance<IMainCategoryService>();
            _subCategoryService = Instancefactory.GetInstance<ISubCategoryService>();
            _operationService = Instancefactory.GetInstance<IOperationService>();
            _operationMainService = Instancefactory.GetInstance<IOperationMainService>();
            _operationPriceService = Instancefactory.GetInstance<IOperationPriceService>();

            dgwOperationMain.ItemsSource = _operationService.GetAll();
            TextBlock[] textBlocks = { tboxFirst, tboxSecond, tboxThird, tboxFourth, tboxFifth, tboxSixth, tboxSeventh, tboxEighth, tboxNinth, tboxTenth };
            DatePicker[] startDates = { datePickFirstStartDate, datePickSecondStartDate, datePickThirdStartDate, datePickFourthStartDate, datePickFifthStartDate, datePickSixthStartDate, datePickSeventhStartDate, datePickEighthStartDate, datePickNinthStartDate, datePickTenthStartDate };
            DatePicker[] endDates = { datePickFirstEndDate, datePicSecondkEndDate, datePickThirdEndDate, datePickFourthEndDate, datePickFifthEndDate, datePickSixthEndDate, datePickSeventhEndDate, datePickEighthEndDate, datePickNinthEndDate, datePickTenthEndDate };
            TextBox[] tboxDocumentCodes = { tboxFirsDocumentCode, tboxSecondDocumentCode, tboxThirdDocumentCode, tboxFourthDocumentCode, tboxFifthDocumentCode, tboxSixthDocumentCode, tboxSeventhDocumentCode, tboxEighthDocumentCode, tboxNinthDocumentCode, tboxTenthDocumentCode };
            _textBlocks = textBlocks;
            _endDates = endDates;
            _startDates = startDates;
            _tboxDocumentCodes = tboxDocumentCodes;

        }

        private void btnChooseForDeuplication_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button button = sender as Button;

            Operation operation = button.CommandParameter as Operation;
            _operation = operation;
            _operationPrice = _operationPriceService.GetByOperation(_operation.Id);

            tboxNumberOfDuplicate.Visibility = Visibility.Visible;
            cboxNumberOfDuplicate.Visibility = Visibility.Visible;

            tboxSearchOperations.Visibility = Visibility.Collapsed;
            borderGrid.Visibility = Visibility.Collapsed;

            tboxNumberOfDuplicate.Text = $"Number of {_operation.DocumentCode} to duplicate";

            for (int i = 0; i < cboxNumberOfDuplicate.Items.Count; i++)
            {
                _endDates[i].SelectedDate = null;
                _startDates[i].SelectedDate = null;
                _tboxDocumentCodes[i].Text = string.Empty;
            }
        }


        private void tboxSearchOperations_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgwOperationMain.ItemsSource = _operationService.GetByDocumentCode(tboxSearchOperations.Text);
        }

        private void cboxNumberOfDuplicate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxNumberOfDuplicate.SelectedIndex > -1)
            {
                OpenDuplication();
            }
        }

        private void OpenDuplication()
        {
            tBlockEndDate.Visibility = Visibility.Visible;
            tBlockStartDate.Visibility = Visibility.Visible;
            tBlockDocumentCode.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
            grdDuplication.Visibility = Visibility.Visible;
            for (int i = 0; i < cboxNumberOfDuplicate.SelectedIndex + 1; i++)
            {

                _textBlocks[i].Visibility = Visibility.Visible;
                _endDates[i].Visibility = Visibility.Visible;
                _startDates[i].Visibility = Visibility.Visible;
                _tboxDocumentCodes[i].Visibility = Visibility.Visible;

            }
            for (int i = 9; i > cboxNumberOfDuplicate.SelectedIndex; i--)
            {
                _textBlocks[i].Visibility = Visibility.Collapsed;
                _endDates[i].Visibility = Visibility.Collapsed;
                _startDates[i].Visibility = Visibility.Collapsed;
                _tboxDocumentCodes[i].Visibility = Visibility.Collapsed;
                _endDates[i].SelectedDate = null;
                _startDates[i].SelectedDate = null;
                _tboxDocumentCodes[i].Text = string.Empty;
            }
        }

        private void CloseDuplication()
        {
            tboxSearchOperations.Visibility = Visibility.Visible;

            tBlockEndDate.Visibility = Visibility.Collapsed;
            tBlockStartDate.Visibility = Visibility.Collapsed;
            tBlockDocumentCode.Visibility = Visibility.Collapsed;
            btnSave.Visibility = Visibility.Collapsed;
            btnCancel.Visibility = Visibility.Collapsed;
            grdDuplication.Visibility = Visibility.Collapsed;
            cboxNumberOfDuplicate.SelectedIndex = -1;

            borderGrid.Visibility = Visibility.Visible;
            cboxNumberOfDuplicate.Visibility = Visibility.Collapsed;
            tboxNumberOfDuplicate.Visibility = Visibility.Collapsed;



            for (int i = 0; i < cboxNumberOfDuplicate.SelectedIndex + 1; i++)
            {
                _textBlocks[i].Visibility = Visibility.Collapsed;
                _endDates[i].Visibility = Visibility.Collapsed;
                _startDates[i].Visibility = Visibility.Collapsed;
                _tboxDocumentCodes[i].Visibility = Visibility.Collapsed;
                _endDates[i].SelectedDate = null;
                _startDates[i].SelectedDate = null;
                _tboxDocumentCodes[i].Text = string.Empty;
            }
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to duplicate?", "Tarot MIS", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    List<Operation> operation = new List<Operation>();
                    for (int i = 0; i < cboxNumberOfDuplicate.SelectedIndex + 1; i++)
                    {
                        operation.Add(new Operation
                        {
                            DocumentCode = _tboxDocumentCodes[i].Text,
                            StartDate = Convert.ToDateTime(_startDates[i].SelectedDate),
                            EndDate = Convert.ToDateTime(_endDates[i].SelectedDate),
                            Description = _operation.Description,
                            Note = null,
                            CreatedBy = _operation.CreatedBy,           //Going to be updated
                            LastUpdatedBy = _operation.LastUpdatedBy,   //Going to be updated
                            CurrencyId = _operation.CurrencyId,
                            SubCategoryId = _operation.SubCategoryId,
                            OperationPrice = new OperationPrice()
                            {
                                DoubleRoom = _operationPrice.DoubleRoom,
                                SingleRoom = _operationPrice.SingleRoom,
                                TripleRoom = _operationPrice.TripleRoom,
                                QuadRoom = _operationPrice.QuadRoom,
                                Baby = _operationPrice.Baby,
                                Child = _operationPrice.Child,
                            }

                        });
                    }
                    _operationService.BulkInsert(operation);
                    MessageBox.Show("Duplication succeed!", "Tarot MIS", MessageBoxButton.OK, MessageBoxImage.Information);
                    CloseDuplication();
                    tboxSearchOperations.Text = string.Empty;
                    dgwOperationMain.ItemsSource = _operationService.GetAll();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Tarot MIS", MessageBoxButton.OK, MessageBoxImage.Error);
                }


            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            CloseDuplication();
            tboxSearchOperations.Text = string.Empty;
            dgwOperationMain.ItemsSource = _operationService.GetAll();


        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            CloseDuplication();
            dgwOperationMain.ItemsSource = _operationService.GetByDocumentCode(tboxSearchOperations.Text);



        }

    }


}





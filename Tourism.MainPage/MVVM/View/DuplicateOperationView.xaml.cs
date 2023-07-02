using System.Windows.Controls;
using Tourism.Business.Abstract.Models;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.DataAccess.Abstract;
using Tourism.Entities.Concrete;
using Tourism.Entities.Models;
using System.Windows;

namespace Tourism.MainPage.MVVM.View
{
    public partial class DuplicateOperationView : UserControl
    {
        private IMainCategoryService _mainCategoryService;
        private ISubCategoryService _subCategoryService;
        private IOperationService _operationService;
        private IOperationMainService _operationMainService;
        private TextBlock[] _textBlocks;
        private DatePicker[] _startDates;
        private DatePicker[] _endDates;
        private TextBox[] _tboxDocumentCodes;
        public DuplicateOperationView()
        {
            InitializeComponent();
            _mainCategoryService = Instancefactory.GetInstance<IMainCategoryService>();
            _subCategoryService = Instancefactory.GetInstance<ISubCategoryService>();
            _operationService = Instancefactory.GetInstance<IOperationService>();
            _operationMainService = Instancefactory.GetInstance<IOperationMainService>();

            dgwOperationMain.ItemsSource = _operationMainService.GetOperationMain();
            TextBlock[] textBlocks = { tboxFirst, tboxSecond, tboxThird, tboxFourth, tboxFifth, tboxSixth, tboxSeventh, tboxEighth, tboxNinth, tboxTenth };
            DatePicker[] startDates = { datePickFirstStartDate, datePickSecondStartDate, datePickThirdStartDate, datePickFourthStartDate, datePickFifthStartDate, datePickSixthStartDate, datePickSeventhStartDate, datePickEighthStartDate, datePickNinthStartDate, datePickTenthStartDate };
            DatePicker[] endDates = { datePickFirstEndDate, datePicSecondkEndDate, datePickThirdEndDate, datePickFourthEndDate, datePickFifthEndDate, datePickSixthEndDate, datePickSeventhEndDate, datePickEighthEndDate, datePickNinthEndDate, datePickTenthEndDate };
            TextBox[] tboxDocumentCodes = { tboxFirsDocumentCode, tboxSecondDocumentCode, tboxThirdDocumentCode, tboxFourthDocumentCode, tboxFifthDocumentCode, tboxSixthDocumentCode, tboxSeventhDocumentCode, tboxEighthDocumentCode, tboxNinthDocumentCode, tboxTenthDocumentCode };
            _textBlocks = textBlocks;
            _endDates = endDates;
            _startDates = startDates;
            _tboxDocumentCodes = tboxDocumentCodes;

        }

        private int _chosenOperationId;
        private string _documentCode;


        private void btnChooseForDeuplication_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            borderGrid.Visibility = Visibility.Collapsed;
            Button button = sender as Button;
            OperationMain operationMain = button.CommandParameter as OperationMain;

            _chosenOperationId = operationMain.Id;
            _documentCode = operationMain.DocumentCode;
            tboxNumberOfDuplicate.Visibility = Visibility.Visible;
            cboxNumberOfDuplicate.Visibility = Visibility.Visible;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            borderGrid.Visibility = Visibility.Visible;
            dgwOperationMain.ItemsSource = _operationMainService.GetOperationMain();
            tboxNumberOfDuplicate.Visibility = Visibility.Collapsed;
            cboxNumberOfDuplicate.Visibility = Visibility.Collapsed;
        }

        private void tboxSearchOperations_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgwOperationMain.ItemsSource = _operationMainService.GetByDocumentCode(tboxSearchOperations.Text);

        }

        private void cboxNumberOfDuplicate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxNumberOfDuplicate.SelectedIndex > -1)
            {
                tBlockEndDate.Visibility = Visibility.Visible;
                tBlockStartDate.Visibility = Visibility.Visible;
                tBlockDocumentCode.Visibility = Visibility.Visible;

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

        }






    }


}





using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Tourism.Business.Abstract.Models;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.DataAccess.Abstract;
using Tourism.Entities.Concrete;

namespace Tourism.MainPage.MVVM.View
{

    public partial class AddOperationView : UserControl
    {

        #region Service
        private IOperationService _operationService;
        private IOperationMainService _operationMainService;
        private ICustomerOperationService _customerOperationService;
        private IMainCategoryService _mainCategoryService;
        private ISubCategoryService _subCategoryService;
        private IUserLevelService _userLevelService;
        private ICurrencyService _currencyService;
        #endregion
        public AddOperationView()
        {
            InitializeComponent();
            _operationMainService = Instancefactory.GetInstance<IOperationMainService>();
            _customerOperationService = Instancefactory.GetInstance<ICustomerOperationService>();
            _mainCategoryService = Instancefactory.GetInstance<IMainCategoryService>();
            _subCategoryService = Instancefactory.GetInstance<ISubCategoryService>();
            _operationService = Instancefactory.GetInstance<IOperationService>();
            _userLevelService = Instancefactory.GetInstance<IUserLevelService>();
            _currencyService = Instancefactory.GetInstance<ICurrencyService>();

            cboxCurrency.ItemsSource = _currencyService.GetAll();
            cboxMainCategory.ItemsSource = _mainCategoryService.GetAll();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnAddAll_Click(object sender, RoutedEventArgs e)
        {


            if (MessageBox.Show("Are you sure you want to add?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    var operation = new Operation()
                    {
                        DocumentCode = tboxDocumentCode.Text,
                        StartDate = (DateTime)datePickStartDate.SelectedDate,
                        EndDate = Convert.ToDateTime(datePickEndDate.SelectedDate),
                        Description = new TextRange(rbtboxDescription.Document.ContentStart, rbtboxDescription.Document.ContentEnd).Text,
                        LastUpdatedBy = 1,
                        CreatedBy = 1,
                        CreatedDate = DateTime.Now,
                        LastUpdated = DateTime.Now,
                        CurrencyId = Convert.ToInt32(cboxCurrency.SelectedValue),
                        SubCategoryId = Convert.ToInt32(cboxSubCategory.SelectedValue),
                        IsActive = true,
                        OperationPrice = new OperationPrice()
                        {

                            SingleRoom = Convert.ToDecimal(tboxSingleRoom.Text),
                            DoubleRoom = Convert.ToDecimal(tboxDoubleRoom.Text),
                            TripleRoom = Convert.ToDecimal(tboxTripleRoom.Text),
                            QuadRoom = Convert.ToDecimal(tboxQuadRoom.Text),
                            Child = Convert.ToDecimal(tboxChildRoom.Text),
                            Baby = Convert.ToDecimal(tboxBabyRoom.Text),

                        }
                    };
                    _operationService.Add(operation);
                    MessageBox.Show("Saved!");
                    Refresh();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }

        }

        private void cboxMainCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxMainCategory.SelectedIndex != -1)
            {
                cboxSubCategory.ItemsSource = _subCategoryService.GetByMainCategory((int)cboxMainCategory.SelectedValue);
            }
        }

        private void Refresh()
        {
            cboxCurrency.SelectedIndex = -1;
            cboxMainCategory.SelectedIndex = -1;
            cboxSubCategory.SelectedIndex = -1;
            tboxBabyRoom.Text = String.Empty;
            tboxChildRoom.Text = String.Empty;
            tboxDocumentCode.Text = String.Empty;
            tboxDoubleRoom.Text = String.Empty;
            tboxQuadRoom.Text = String.Empty;
            tboxSingleRoom.Text = String.Empty;
            tboxTripleRoom.Text = String.Empty;
            rbtboxDescription.Document.Blocks.Clear();
            datePickEndDate.SelectedDate = DateTime.Now;
            datePickStartDate.SelectedDate = DateTime.Now;
        }
    }
}

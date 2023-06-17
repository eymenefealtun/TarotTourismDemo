using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Tourism.Business.Abstract.Models;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.DataAccess.Abstract;
using Tourism.Entities.Concrete;
using Operation = Tourism.Entities.Concrete.Operation;

namespace Tourism.MainPage.MVVM.View
{
    public partial class UpdateOperationView : UserControl
    {
        public int _operationId;

        private string _documentCode;
        private int _updateUserId;
        private int _createUserId;
        private string _operator;
        private DateTime _createdDate;
        private DateTime _lastUpdatedDate;
        private string _createdBy;
        private string _lastUpdatedBy;
        private bool _isActive;
        public byte[] _operationVersion;
        public byte[] _operationPriceVersion;

        private IOperationInformationService _operationInformationService;
        private IOperationService _operationService;
        private IMainCategoryService _mainCategoryService;
        private ISubCategoryService _subCategoryService;
        private ICurrencyService _currencyService;
        public UpdateOperationView(int operationId)
        {
            InitializeComponent();
            _operationInformationService = Instancefactory.GetInstance<IOperationInformationService>();
            _mainCategoryService = Instancefactory.GetInstance<IMainCategoryService>();
            _subCategoryService = Instancefactory.GetInstance<ISubCategoryService>();
            _currencyService = Instancefactory.GetInstance<ICurrencyService>();
            _operationService = Instancefactory.GetInstance<IOperationService>();
            _operationId = operationId;
            GetInfo();
        }
        public UpdateOperationView()
        {
            InitializeComponent();

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void toggleBtnIsActıve_Click(object sender, RoutedEventArgs e)
        {
            if (btnEditDescriptionPart.Visibility == Visibility.Visible && btnEditMainPart.Visibility == Visibility.Visible && btnEditPricePart.Visibility == Visibility.Visible && btnEditNotePart.Visibility == Visibility.Visible)
            {
                if (toggleBtnIsActive.IsChecked == false)
                {
                    if (MessageBox.Show("Are you sure you want to deactivate this package?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            toggleBtnIsActive.IsChecked = false;
                            _isActive = false;
                            UpdateOperation();
                            GetInfo();
                            MessageBox.Show("Package succesfully deactivated!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            MessageBox.Show("This package already updated by another user while you are in this page!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            GetInfo();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message);
                        }
                    }
                    else
                    {
                        toggleBtnIsActive.IsChecked = true;
                    }
                }
                else if (toggleBtnIsActive.IsChecked == true)
                {
                    if (MessageBox.Show("Are you sure you want to activate this package?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            toggleBtnIsActive.IsChecked = true;
                            _isActive = true;
                            UpdateOperation();
                            GetInfo();
                            MessageBox.Show("Package succesfully activated!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            MessageBox.Show("This package already updated by another user while you are in this page!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            GetInfo();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message);
                        }
                    }
                    else
                    {
                        toggleBtnIsActive.IsChecked = false;

                    }
                }
            }
            else
            {
                toggleBtnIsActive.IsChecked = _isActive == true ? toggleBtnIsActive.IsChecked = true : toggleBtnIsActive.IsChecked = false;
                MessageBox.Show("You can not change activity while editing other parts!");
            }
        }

        private void btnEditMainPart_Click(object sender, RoutedEventArgs e)
        {
            btnEditMainPart.Visibility = Visibility.Hidden;
            btnCancelMainPart.Visibility = Visibility.Visible;
            btnSaveMainPart.Visibility = Visibility.Visible;
            EnableMainPart();

            btnEditDescriptionPart.IsHitTestVisible = false;
            btnEditPricePart.IsHitTestVisible = false;
            btnEditNotePart.IsHitTestVisible = false;
        }

        private void btnEditPricePart_Click(object sender, RoutedEventArgs e)
        {
            btnEditPricePart.Visibility = Visibility.Hidden;
            btnCancelPricePart.Visibility = Visibility.Visible;
            btnSavePricePart.Visibility = Visibility.Visible;
            EnablePricePart();

            btnEditDescriptionPart.IsHitTestVisible = false;
            btnEditMainPart.IsHitTestVisible = false;
            btnEditNotePart.IsHitTestVisible = false;
        }

        private void btnEditDescriptionPart_Click(object sender, RoutedEventArgs e)
        {

            btnEditDescriptionPart.Visibility = Visibility.Hidden;
            btnCancelDescriptionPart.Visibility = Visibility.Visible;
            btnSaveDescriptionPart.Visibility = Visibility.Visible;
            EnableDescriptionPart();

            btnEditPricePart.IsHitTestVisible = false;
            btnEditMainPart.IsHitTestVisible = false;
            btnEditNotePart.IsHitTestVisible = false;
        }
        private void btnEditNotePart_Click(object sender, RoutedEventArgs e)
        {
            btnEditNotePart.Visibility = Visibility.Hidden;
            btnCancelNotePart.Visibility = Visibility.Visible;
            btnSaveNotePart.Visibility = Visibility.Visible;
            EnableNotePart();

            btnEditPricePart.IsHitTestVisible = false;
            btnEditMainPart.IsHitTestVisible = false;
            btnEditDescriptionPart.IsHitTestVisible = false;
        }



        private void btnCancelDescriptionPart_Click(object sender, RoutedEventArgs e)
        {
            btnEditMainPart.IsHitTestVisible = true;
            btnEditPricePart.IsHitTestVisible = true;
            btnEditNotePart.IsHitTestVisible = true;
            DisableDescriptionPart();
            btnSaveDescriptionPart.Visibility = Visibility.Hidden;
            btnCancelDescriptionPart.Visibility = Visibility.Hidden;
            btnEditDescriptionPart.Visibility = Visibility.Visible;
            GetInfo();
        }

        private void btnCancelMainPart_Click(object sender, RoutedEventArgs e)
        {
            btnEditDescriptionPart.IsHitTestVisible = true;
            btnEditPricePart.IsHitTestVisible = true;
            btnEditNotePart.IsHitTestVisible = true;
            DisableMainPart();
            btnSaveMainPart.Visibility = Visibility.Hidden;
            btnCancelMainPart.Visibility = Visibility.Hidden;
            btnEditMainPart.Visibility = Visibility.Visible;
            GetInfo();
        }

        private void btnCancelPricePart_Click(object sender, RoutedEventArgs e)
        {
            btnEditDescriptionPart.IsHitTestVisible = true;
            btnEditMainPart.IsHitTestVisible = true;
            btnEditNotePart.IsHitTestVisible = true;
            DisablePricePart();
            btnSavePricePart.Visibility = Visibility.Hidden;
            btnCancelPricePart.Visibility = Visibility.Hidden;
            btnEditPricePart.Visibility = Visibility.Visible;
            GetInfo();
        }
        private void btnCancelNotePart_Click(object sender, RoutedEventArgs e)
        {
            btnEditDescriptionPart.IsHitTestVisible = true;
            btnEditPricePart.IsHitTestVisible = true;
            btnEditMainPart.IsHitTestVisible = true;
            DisableNotePart();
            btnSaveNotePart.Visibility = Visibility.Hidden;
            btnCancelNotePart.Visibility = Visibility.Hidden;
            btnEditNotePart.Visibility = Visibility.Visible;
            GetInfo();

        }

        private void btnSaveDescriptionPart_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    UpdateOperation();

                    MessageBox.Show("Succesfully Saved", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    _documentCode = tboxDocumentCode.Text;
                    GetInfo();
                    btnEditMainPart.IsHitTestVisible = true;
                    btnEditPricePart.IsHitTestVisible = true;
                    btnEditNotePart.IsHitTestVisible = true;
                    DisableDescriptionPart();
                    btnSaveDescriptionPart.Visibility = Visibility.Hidden;
                    btnCancelDescriptionPart.Visibility = Visibility.Hidden;
                    btnEditDescriptionPart.Visibility = Visibility.Visible;
                }
                catch (DbUpdateConcurrencyException)
                {
                    MessageBox.Show("This package already updated by another user while you are in this page!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }

        }

        private void btnSaveMainPart_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    UpdateOperation();

                    MessageBox.Show("Succesfully Saved", "", MessageBoxButton.OK, MessageBoxImage.Information);

                    GetInfo();
                    btnEditDescriptionPart.IsHitTestVisible = true;
                    btnEditPricePart.IsHitTestVisible = true;
                    btnEditNotePart.IsHitTestVisible = true;
                    DisableMainPart();
                    btnSaveMainPart.Visibility = Visibility.Hidden;
                    btnCancelMainPart.Visibility = Visibility.Hidden;
                    btnEditMainPart.Visibility = Visibility.Visible;
                }
                catch (DbUpdateConcurrencyException)
                {
                    MessageBox.Show("This package already updated by another user while you are in this page!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }

            }

        }

        private void btnSavePricePart_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    UpdateOperation();
                    MessageBox.Show("Succesfully Saved", "", MessageBoxButton.OK, MessageBoxImage.Information);

                    GetInfo();
                    btnEditDescriptionPart.IsHitTestVisible = true;
                    btnEditMainPart.IsHitTestVisible = true;
                    btnEditNotePart.IsHitTestVisible = true;
                    DisablePricePart();
                    btnSavePricePart.Visibility = Visibility.Hidden;
                    btnCancelPricePart.Visibility = Visibility.Hidden;
                    btnEditPricePart.Visibility = Visibility.Visible;
                }
                catch (DbUpdateConcurrencyException)
                {
                    MessageBox.Show("This package already updated by another user while you are in this page!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }

        private void btnSaveNotePart_Click(object sender, RoutedEventArgs e)
        {
            // tboxSingleRoom.Text = "YETER";
            if (MessageBox.Show("Are you sure you want to save?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    UpdateOperation();
                    MessageBox.Show("Succesfully Saved", "", MessageBoxButton.OK, MessageBoxImage.Information);

                    GetInfo();
                    btnEditDescriptionPart.IsHitTestVisible = true;
                    btnEditMainPart.IsHitTestVisible = true;
                    btnEditPricePart.IsHitTestVisible = true;
                    DisableNotePart();
                    btnSaveNotePart.Visibility = Visibility.Hidden;
                    btnCancelNotePart.Visibility = Visibility.Hidden;
                    btnEditNotePart.Visibility = Visibility.Visible;
                }
                catch (DbUpdateConcurrencyException)
                {
                    MessageBox.Show("This package already updated by another user while you are in this page!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }

        private void UpdateOperation()
        {
            _operationService.Update(new Operation
            {
                Id = _operationId,
                DocumentCode = tboxDocumentCode.Text,
                StartDate = Convert.ToDateTime(datePickStartDate.SelectedDate),
                EndDate = Convert.ToDateTime(datePickEndDate.SelectedDate),
                Description = new TextRange(rbtboxDescription.Document.ContentStart, rbtboxDescription.Document.ContentEnd).Text,
                Note = new TextRange(rbtboxNote.Document.ContentStart, rbtboxNote.Document.ContentEnd).Text,
                CreatedDate = _createdDate,
                LastUpdated = DateTime.Now,
                LastUpdatedBy = _updateUserId,
                CreatedBy = _createUserId,
                CurrencyId = Convert.ToInt32(cboxCurrency.SelectedValue),
                SubCategoryId = Convert.ToInt32(cboxSubCategory.SelectedValue),
                IsActive = _isActive,
                RowVersion = _operationVersion,
                OperationPrice = new OperationPrice()
                {
                    OperationId = _operationId,
                    SingleRoom = Convert.ToDecimal(tboxSingleRoom.Text),
                    DoubleRoom = Convert.ToDecimal(tboxDoubleRoom.Text),
                    TripleRoom = Convert.ToDecimal(tboxTripleRoom.Text),
                    QuadRoom = Convert.ToDecimal(tboxQuadRoom.Text),
                    Child = Convert.ToDecimal(tboxChildRoom.Text),
                    Baby = Convert.ToDecimal(tboxBabyRoom.Text),
                    RowVersion = _operationPriceVersion
                }
            });



        }

        private void GetInfo()
        {
            var operation = _operationInformationService.GetOperationInformation(_operationId);

            _operationVersion = operation.OperationRowVersion;
            _operationPriceVersion = operation.OperationPriceRowVersion;

            tboxDocumentCode.Text = operation.DocumentCode;

            tboxSingleRoom.Text = operation.SingleRoom.ToString();
            tboxDoubleRoom.Text = operation.DoubleRoom.ToString();
            tboxTripleRoom.Text = operation.TripleRoom.ToString();
            tboxQuadRoom.Text = operation.QuadRoom.ToString();
            tboxChildRoom.Text = operation.Child.ToString();
            tboxBabyRoom.Text = operation.Baby.ToString();


            rbtboxDescription.Document.Blocks.Clear();
            rbtboxDescription.Document.Blocks.Add(new Paragraph(new Run(operation.Description)));
            rbtboxNote.Document.Blocks.Clear();
            rbtboxNote.Document.Blocks.Add(new Paragraph(new Run(operation.Note)));


            datePickStartDate.SelectedDate = operation.StartDate;
            datePickEndDate.SelectedDate = operation.EndDate;

            cboxCurrency.ItemsSource = _currencyService.GetAll();
            cboxCurrency.SelectedValue = operation.CurrencyId;

            cboxMainCategory.ItemsSource = _mainCategoryService.GetAll();
            cboxMainCategory.SelectedValue = operation.MainCategoryId;
            cboxSubCategory.ItemsSource = _subCategoryService.GetByMainCategory(operation.MainCategoryId);
            cboxSubCategory.SelectedValue = operation.SubCategoryId;

            toggleBtnIsActive.IsChecked = operation.IsActive == true ? toggleBtnIsActive.IsChecked = true : toggleBtnIsActive.IsChecked = false;

            txtOperator.Text = $"Operator: {operation.CreatedByOperator}";
            txtCreatedDate.Text = $"Created Date: {operation.CreatedDate}";
            txtCreatedBy.Text = $"Created By: {operation.CreatedBy}";
            txtLastUpdated.Text = $"Last Updated: {operation.LastUpdated}";
            txtLastUpdatedBy.Text = $"Last Updated By: {operation.LastUpdatedBy}";


            _updateUserId = operation.UpdateUserId;
            _createUserId = operation.CreateUserId;
            _createdDate = Convert.ToDateTime(operation.CreatedDate);
            _lastUpdatedDate = Convert.ToDateTime(operation.LastUpdated);
            _isActive = operation.IsActive;

        }


        private void EnablePricePart()
        {
            tboxSingleRoom.IsReadOnly = false;
            tboxDoubleRoom.IsReadOnly = false;
            tboxTripleRoom.IsReadOnly = false;
            tboxQuadRoom.IsReadOnly = false;
            tboxChildRoom.IsReadOnly = false;
            tboxBabyRoom.IsReadOnly = false;
            cboxCurrency.IsHitTestVisible = true;
        }
        private void DisablePricePart()
        {
            tboxSingleRoom.IsReadOnly = true;
            tboxDoubleRoom.IsReadOnly = true;
            tboxTripleRoom.IsReadOnly = true;
            tboxQuadRoom.IsReadOnly = true;
            tboxChildRoom.IsReadOnly = true;
            tboxBabyRoom.IsReadOnly = true;
            cboxCurrency.IsHitTestVisible = false;
        }

        private void EnableMainPart()
        {
            datePickStartDate.IsHitTestVisible = true;
            datePickEndDate.IsHitTestVisible = true;
            cboxMainCategory.IsHitTestVisible = true;
            cboxSubCategory.IsHitTestVisible = true;
            tboxDocumentCode.IsReadOnly = false;
        }

        private void DisableMainPart()
        {
            datePickStartDate.IsHitTestVisible = false;
            datePickEndDate.IsHitTestVisible = false;
            cboxMainCategory.IsHitTestVisible = false;
            cboxSubCategory.IsHitTestVisible = false;
            tboxDocumentCode.IsReadOnly = true;
        }

        private void EnableDescriptionPart()
        {
            rbtboxDescription.IsReadOnly = false;
        }
        private void DisableDescriptionPart()
        {
            rbtboxDescription.IsReadOnly = true;
        }
        private void EnableNotePart()
        {
            rbtboxNote.IsReadOnly = false;
        }
        private void DisableNotePart()
        {
            rbtboxNote.IsReadOnly = true;
        }

        private void cboxMainCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Convert.ToInt32(cboxMainCategory.SelectedValue) > 0)
            {
                cboxSubCategory.ItemsSource = _subCategoryService.GetByMainCategory(Convert.ToInt32(cboxMainCategory.SelectedValue));
            }
        }

    }
}

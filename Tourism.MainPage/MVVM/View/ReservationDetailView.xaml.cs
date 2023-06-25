using System;
using System.Windows.Controls;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.Entities.Concrete;
using System.Windows;
using System.Linq;
using Tourism.Business.Abstract.Models;
using Tourism.Entities.Models;
using Tourism.DataAccess.Abstract;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Documents;
using Operation = Tourism.Entities.Concrete.Operation;
using Tourism.MainPage.Core;
using Microsoft.EntityFrameworkCore;
using System.Windows.Input;

namespace Tourism.MainPage.MVVM.View
{


    public partial class ReservationDetailView : UserControl
    {
        private IMainCategoryService _mainCategoryService;
        private ISubCategoryService _subCategoryService;
        private IAgencyUserService _agencyUserService;
        private IReservationService _reservationService;
        private ICurrencyService _currencyService;
        private IOperationMainService _operationMainService;
        private IOperationService _operationService;
        private IAgencyService _agencyService;
        private IOperatorService _operatorService;
        private IOperatorUserService _operatorUserService;
        private ICustomerOperationService _customerOperationService;
        private ICustomerService _customerService;
        private IRoomService _roomService;
        private IBedTypeService _bedTypeService;

        private int _operationId;
        private int _subCateogryId;
        private int _reservationId;
        private bool _isActive;
        private List<Customer> _customers;
        private Reservation _reservation;
        private List<CustomerOperation> _customerOperations;
        List<Room> _room;

        public ReservationDetailView(int operationId, int subCategoryId, int reservationId, bool isActive)
        {
            InitializeComponent();
            _operationId = operationId;
            _subCateogryId = subCategoryId;
            _reservationId = reservationId;
            _mainCategoryService = Instancefactory.GetInstance<IMainCategoryService>();
            _subCategoryService = Instancefactory.GetInstance<ISubCategoryService>();
            _agencyUserService = Instancefactory.GetInstance<IAgencyUserService>();
            _reservationService = Instancefactory.GetInstance<IReservationService>();
            _currencyService = Instancefactory.GetInstance<ICurrencyService>();
            _operationMainService = Instancefactory.GetInstance<IOperationMainService>();
            _operationService = Instancefactory.GetInstance<IOperationService>();
            _agencyService = Instancefactory.GetInstance<IAgencyService>();
            _operatorService = Instancefactory.GetInstance<IOperatorService>();
            _operatorUserService = Instancefactory.GetInstance<IOperatorUserService>();
            _customerOperationService = Instancefactory.GetInstance<ICustomerOperationService>();
            _customerService = Instancefactory.GetInstance<ICustomerService>();
            _roomService = Instancefactory.GetInstance<IRoomService>();
            _bedTypeService = Instancefactory.GetInstance<IBedTypeService>();
            _isActive = isActive;

            dgwCustomerOperation.ItemsSource = _customerOperationService.GetCustomerOperationByReservationId(_operationId, _reservationId, _isActive);

            _customerOperations = _customerOperationService.GetCustomerOperationByReservationId(_operationId, _reservationId, _isActive);

        }

        public ReservationDetailView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            GetInfos();
            GetBottom();
        }
        private void GetInfos()
        {

            RenewReservation();

            Operation operation = _operationService.GetByOperationId(_operationId);
            cboxMainCategory.ItemsSource = _mainCategoryService.GetAll();

            SubCategory subCategory = _subCategoryService.GetBySubCategoryId(_subCateogryId);
            MainCategory mainCategory = _mainCategoryService.GetByMainCategoryId(Convert.ToInt32(_subCateogryId));
            cboxMainCategory.SelectedItem = cboxMainCategory.Items.OfType<MainCategory>().FirstOrDefault(x => x.Id == subCategory.MainCategoryId);
            cboxSubCategory.ItemsSource = _subCategoryService.GetByMainCategory(Convert.ToInt32(cboxMainCategory.SelectedValue));
            cboxSubCategory.SelectedItem = cboxSubCategory.Items.OfType<SubCategory>().FirstOrDefault(x => x.Id == _subCateogryId);

            int agencyUserId = _reservation.AgencyUserId;
            AgencyUser agencyUser = _agencyUserService.Get(agencyUserId);
            Agency agency = _agencyService.GetByAgencyId(agencyUser.AgencyId);
            tboxAgencyUser.Text = agencyUser.Username;
            tboxAgency.Text = agency.Name;
            tboxReservationCode.Text = _reservation.ReservationCode;


            cboxCurrency.ItemsSource = _currencyService.GetAll();
            cboxCurrency.SelectedItem = cboxCurrency.Items.OfType<Tourism.Entities.Concrete.Currency>().FirstOrDefault(x => x.Id == operation.CurrencyId);

            OperatorUser createdBy = _operatorUserService.GetByUserId(operation.CreatedBy);
            OperatorUser lastUpdatedBy = _operatorUserService.GetByUserId(operation.LastUpdatedBy);
            cboxOperator.ItemsSource = _operatorService.GetAll();
            cboxOperator.SelectedItem = cboxOperator.Items.OfType<Operator>().FirstOrDefault(x => x.Id == createdBy.OperatorId);


            tboxCreatedDate.Text = _reservation.CreatedDate.ToString();
            Operator @operator = _operatorService.GetByOperatorId(createdBy.OperatorId); //operator başına @ koymayınca hata verioyr neden bilmiyorum

        }

        private void GetBottom()
        {
            RenewReservation();
            tboxTotalPrice.Text = _reservation.TotalPrice.ToString();
            tboxDiscountedPrice.Text = _reservation.DiscountedPrice.ToString();
            rbtboxNote.Document.Blocks.Clear();
            rbtboxNote.Document.Blocks.Add(new Paragraph(new Run(_reservation.Note)));
            toggleBtnIsActive.IsChecked = _reservation.IsActive == true ? toggleBtnIsActive.IsChecked = true : toggleBtnIsActive.IsChecked = false;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            btnSave.Visibility = Visibility.Hidden;
            btnCancel.Visibility = Visibility.Hidden;
            btnEdit.Visibility = Visibility.Visible;
            dgwCustomerOperation.IsReadOnly = true;
            dgwCustomerOperation.ItemsSource = _customerOperationService.GetCustomerOperationByReservationId(_operationId, _reservationId, _isActive);

        }

        private void btnEdit_Click_1(object sender, RoutedEventArgs e)
        {
            btnEdit.Visibility = Visibility.Hidden;
            btnCancel.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Visible;
            dgwCustomerOperation.IsReadOnly = false;
            dgwCustomerOperation.Columns[0].IsReadOnly = true;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save?", "Update", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _customers = new List<Customer>();
                    for (int i = 0; i < dgwCustomerOperation.Items.Count; i++)
                    {
                        DataGridRow dataGridRow = (DataGridRow)dgwCustomerOperation.ItemContainerGenerator.ContainerFromIndex(i);
                        var gender = dgwCustomerOperation.Columns[1].GetCellContent(dataGridRow) as TextBlock;
                        var firstName = dgwCustomerOperation.Columns[2].GetCellContent(dataGridRow) as TextBlock;
                        var lastName = dgwCustomerOperation.Columns[3].GetCellContent(dataGridRow) as TextBlock;
                        var birthDateTextBlock = dgwCustomerOperation.Columns[4].GetCellContent(dataGridRow) as TextBlock;
                        var phone = dgwCustomerOperation.Columns[5].GetCellContent(dataGridRow) as TextBlock;
                        var idNumber = dgwCustomerOperation.Columns[6].GetCellContent(dataGridRow) as TextBlock;
                        _customers.Add(new Customer
                        {
                            Id = Convert.ToInt32(_customerOperations[i].CustomerId),
                            FirstName = firstName.Text.ToString(),
                            LastName = lastName.Text.ToString(),
                            Phone = phone.Text.ToString(),
                            BirthDate = Convert.ToDateTime(DateTime.ParseExact(birthDateTextBlock.Text, "M/d/yyyy", CultureInfo.InvariantCulture)),
                            Gender = gender.Text.ToString(),
                            IdNumber = idNumber.Text.ToString(),
                            RoomId = _customerOperations[i].RoomId,
                            RowVersion = _customerOperations[i].CustomerRowVersion
                        });
                    }
                    _customerService.BulkUpdate(_customers);
                    MessageBox.Show("Saved", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    _customerOperations = _customerOperationService.GetCustomerOperationByReservationId(_operationId, _reservationId, _isActive);
                    dgwCustomerOperation.ItemsSource = _customerOperationService.GetCustomerOperationByReservationId(_operationId, _reservationId, _isActive);
                    btnEdit.Visibility = Visibility.Visible;
                    btnCancel.Visibility = Visibility.Hidden;
                    btnSave.Visibility = Visibility.Hidden;
                    dgwCustomerOperation.IsReadOnly = true;
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                MessageBox.Show("These customers already updated by another user while you are in this page!" + Environment.NewLine + "Customer informations are going to updated according to previous modification done by another user, after you click OK.", "Tarot MIS - Error", MessageBoxButton.OK, MessageBoxImage.Error);
                _customerOperations = _customerOperationService.GetCustomerOperationByReservationId(_operationId, _reservationId, _isActive);
                dgwCustomerOperation.ItemsSource = _customerOperationService.GetCustomerOperationByReservationId(_operationId, _reservationId, _isActive);
                btnEdit.Visibility = Visibility.Visible;
                btnCancel.Visibility = Visibility.Hidden;
                btnSave.Visibility = Visibility.Hidden;
                dgwCustomerOperation.IsReadOnly = true;
            }
            catch (Exception excepttion)
            {
                MessageBox.Show(excepttion.Message);
            }
        }



        private void btnEditBottom_Click(object sender, RoutedEventArgs e)
        {
            btnEditBottom.Visibility = Visibility.Hidden;
            btnCancelBottom.Visibility = Visibility.Visible;
            btnSaveBottom.Visibility = Visibility.Visible;
            rbtboxNote.IsReadOnly = false;
            tboxDiscountedPrice.IsReadOnly = false;
        }

        private void btnCancelBottom_Click(object sender, RoutedEventArgs e)
        {
            btnEditBottom.Visibility = Visibility.Visible;
            btnCancelBottom.Visibility = Visibility.Hidden;
            btnSaveBottom.Visibility = Visibility.Hidden;
            rbtboxNote.IsReadOnly = true;
            tboxDiscountedPrice.IsReadOnly = true;
            GetBottom();
        }

        private void btnSaveBottom_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save?", "Save", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                UpdateReservation();
            }
        }
        private void UpdateReservation()
        {
            try
            {
                var text = new TextRange(rbtboxNote.Document.ContentStart, rbtboxNote.Document.ContentEnd).Text;
                Reservation reservation = new Reservation
                {
                    Id = _reservation.Id,
                    ReservationCode = _reservation.ReservationCode,
                    Pax = _reservation.Pax,
                    Room = _reservation.Room,
                    TotalPrice = _reservation.TotalPrice,
                    Note = text,
                    DiscountedPrice = Convert.ToDecimal(tboxDiscountedPrice.Text),
                    CreatedDate = _reservation.CreatedDate,
                    AgencyUserId = _reservation.AgencyUserId,
                    OperationId = _reservation.OperationId,
                    IsActive = _reservation.IsActive,
                    RowVersion = _reservation.RowVersion,
                };
                _reservationService.Update(reservation);
                MessageBox.Show("Saved", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                btnEditBottom.Visibility = Visibility.Visible;
                btnCancelBottom.Visibility = Visibility.Hidden;
                btnSaveBottom.Visibility = Visibility.Hidden;
                rbtboxNote.IsReadOnly = true;
                tboxDiscountedPrice.IsReadOnly = true;
                GetBottom();

            }
            catch (DbUpdateConcurrencyException)
            {
                MessageBox.Show("This reservation already updated by another user while you are in this page!" + Environment.NewLine + "Reservation informations are going to updated according to previous modification done by another user, after you click OK.", "Tarot MIS - Error", MessageBoxButton.OK, MessageBoxImage.Error);
                RenewReservation();
                btnEditBottom.Visibility = Visibility.Visible;
                btnCancelBottom.Visibility = Visibility.Hidden;
                btnSaveBottom.Visibility = Visibility.Hidden;
                tboxDiscountedPrice.IsReadOnly = true;
                rbtboxNote.IsReadOnly = true;
                GetBottom();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void ChangeActicityOfReservation()
        {
            //RenewReservation();
            _reservation.IsActive = _isActive;

            if (_isActive == true)
            {
                Reservation reservation = new Reservation
                {
                    Id = _reservation.Id,
                    ReservationCode = _reservation.ReservationCode,
                    Pax = dgwCustomerOperation.Items.Count, //
                    Room = _room.Count,//

                    TotalPrice = _reservation.TotalPrice,
                    Note = new TextRange(rbtboxNote.Document.ContentStart, rbtboxNote.Document.ContentEnd).Text,
                    DiscountedPrice = Convert.ToDecimal(tboxDiscountedPrice.Text),
                    CreatedDate = _reservation.CreatedDate,
                    AgencyUserId = _reservation.AgencyUserId,
                    OperationId = _reservation.OperationId,
                    IsActive = _reservation.IsActive,
                    RowVersion = _reservation.RowVersion,
                };
                _reservationService.Update(reservation);
                btnEditBottom.Visibility = Visibility.Visible;
                btnCancelBottom.Visibility = Visibility.Hidden;
                btnSaveBottom.Visibility = Visibility.Hidden;
                rbtboxNote.IsReadOnly = true;
                tboxDiscountedPrice.IsReadOnly = true;
                GetBottom();
            }
            else if (_isActive == false)
            {
                Reservation reservation = new Reservation
                {
                    Id = _reservation.Id,
                    ReservationCode = _reservation.ReservationCode,
                    Pax = Convert.ToInt32(null),
                    Room = Convert.ToInt32(null),
                    TotalPrice = _reservation.TotalPrice,
                    Note = new TextRange(rbtboxNote.Document.ContentStart, rbtboxNote.Document.ContentEnd).Text,
                    DiscountedPrice = Convert.ToDecimal(tboxDiscountedPrice.Text),
                    CreatedDate = _reservation.CreatedDate,
                    AgencyUserId = _reservation.AgencyUserId,
                    OperationId = _reservation.OperationId,
                    IsActive = _reservation.IsActive,
                    RowVersion = _reservation.RowVersion,
                };
                _reservationService.Update(reservation);
                btnEditBottom.Visibility = Visibility.Visible;
                btnCancelBottom.Visibility = Visibility.Hidden;
                btnSaveBottom.Visibility = Visibility.Hidden;
                rbtboxNote.IsReadOnly = true;
                tboxDiscountedPrice.IsReadOnly = true;
                GetBottom();
            }



        }

        private void RenewReservation()
        {
            Reservation reservation2 = _reservationService.Get(_reservationId);
            List<Room> room = _roomService.GetByReservationId(_reservationId);
            _room = room;
            _reservation = reservation2;
        }
        private void toggleBtnIsActive_Click(object sender, RoutedEventArgs e)
        {

            if (toggleBtnIsActive.IsChecked == false)
            {
                if (MessageBox.Show("Are you sure you want to deactivate this reservation?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        _isActive = false;
                        ChangeActicityOfReservation();
                        MessageBox.Show("Reservation succesfully deactivated!", "Tarot MIS", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        MessageBox.Show("This reservation already updated by another user while you are in this page!" + Environment.NewLine + "Reservation informations are going to updated according to previous modification done by another user, after you click OK.", "Tarot MIS - Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        RenewReservation();
                        btnEditBottom.Visibility = Visibility.Visible;
                        btnCancelBottom.Visibility = Visibility.Hidden;
                        btnSaveBottom.Visibility = Visibility.Hidden;
                        tboxDiscountedPrice.IsReadOnly = true;
                        rbtboxNote.IsReadOnly = true;
                        GetBottom();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                else
                {
                    toggleBtnIsActive.IsChecked = true;
                    GetBottom();
                }
            }
            else if (toggleBtnIsActive.IsChecked == true)
            {
                if (MessageBox.Show("Are you sure you want to activate this reservation?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        _isActive = true;

                        ChangeActicityOfReservation();
                        MessageBox.Show("Reservation succesfully activated!", "Tarot MIS", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        MessageBox.Show("This reservation already updated by another user while you are in this page!" + Environment.NewLine + "Reservation informations are going to updated according to previous modification done by another user, after you click OK.", "Tarot MIS - Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        RenewReservation();
                        btnEditBottom.Visibility = Visibility.Visible;
                        btnCancelBottom.Visibility = Visibility.Hidden;
                        btnSaveBottom.Visibility = Visibility.Hidden;
                        tboxDiscountedPrice.IsReadOnly = true;
                        rbtboxNote.IsReadOnly = true;
                        GetBottom();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                else
                {
                    toggleBtnIsActive.IsChecked = false;
                    GetBottom();
                }
            }


        }

        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            Utilities.ExportReservationDetailToExcel(dgwCustomerOperation, _reservation.ReservationCode);

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

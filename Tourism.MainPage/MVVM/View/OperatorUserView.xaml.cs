using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Tourism.Business.Abstract.Models;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.Entities.Concrete;
using Tourism.Entities.Models;

namespace Tourism.MainPage.MVVM.View
{
    public partial class OperatorUserView : UserControl
    {
        IOperatorUserFullService _operatorFullService;
        IUserLevelService _userLevelService;
        IOperatorService _operatorService;
        IOperatorUserService _operatorUserService;
        OperatorUser _operatorUser;
        public OperatorUserView()
        {
            InitializeComponent();

            _operatorFullService = Instancefactory.GetInstance<IOperatorUserFullService>();
            _userLevelService = Instancefactory.GetInstance<IUserLevelService>();
            _operatorService = Instancefactory.GetInstance<IOperatorService>();
            _operatorUserService = Instancefactory.GetInstance<IOperatorUserService>();

            dgwOperatorUser.ItemsSource = _operatorFullService.GetOperatorUsers();
            //cboxAddLevel.ItemsSource = _userLevelService.GetAll();
            cboxAddOperator.ItemsSource = _operatorService.GetAll();
            //cboxUpdateLevel.ItemsSource = _userLevelService.GetAll();
            cboxUpdateOperator.ItemsSource = _operatorService.GetAll();
        }

        private void btnAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            columnEdit.Visibility = Visibility.Hidden;
            if (btnAddNewUser.IsChecked == true)
                stckAddNewUser.Visibility = Visibility.Visible;

            if (btnAddNewUser.IsChecked == false)
                stckAddNewUser.Visibility = Visibility.Hidden;
        }

        private void btnSaveNewUser_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to save?", "Tarot MIS", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) ;
            {
                try
                {
                    var operatorUser = new OperatorUser()
                    {
                        Username = tboxAddUserName.Text,
                        PasswordHash = tboxAddPassword.Text,
                        OperatorId = Convert.ToInt32(cboxAddOperator.SelectedValue),
                        //UserLevelId = Convert.ToInt32(cboxAddLevel.SelectedValue),
                        FirstName = tboxAddFirstName.Text,
                        LastName = tboxAddLastName.Text,
                        DateJoined = DateTime.Now,
                        Email = tboxAddEmail.Text,
                        IsActive = true,
                    };

                    _operatorUserService.Add(operatorUser);
                    dgwOperatorUser.ItemsSource = _operatorFullService.GetOperatorUsers();
                    MessageBox.Show("Saved!", "Tarot MIS", MessageBoxButton.OK, MessageBoxImage.Information);
                    columnEdit.Visibility = Visibility.Visible;
                    ClearAddNewUser();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Tarot MIS", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private void btnCancelNewUser_Click(object sender, RoutedEventArgs e)
        {
            ClearAddNewUser();
        }

        private void ClearAddNewUser()
        {
            stckAddNewUser.Visibility = Visibility.Hidden;
            btnAddNewUser.IsChecked = false;
            cboxAddLevel.SelectedIndex = -1;
            cboxAddOperator.SelectedIndex = -1;
            tboxAddPassword.Text = string.Empty;
            tboxAddUserName.Text = string.Empty;
            columnEdit.Visibility = Visibility.Visible;
        }
        private void ClearUpdateUser()
        {
            btnUpdateUser.Visibility = Visibility.Hidden;
            stckUpdateUser.Visibility = Visibility.Hidden;
            columnEdit.Visibility = Visibility.Visible;
            btnAddNewUser.IsHitTestVisible = true;
            tboxUpdateUsername.Text = String.Empty;
            tboxUpdateUsername.Text = String.Empty;
            cboxUpdateLevel.SelectedIndex = -1;
            cboxUpdateOperator.SelectedIndex = -1;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            btnUpdateUser.Visibility = Visibility.Visible;
            stckUpdateUser.Visibility = Visibility.Visible;

            columnEdit.Visibility = Visibility.Hidden;
            stckAddNewUser.Visibility = Visibility.Hidden;
            btnAddNewUser.IsChecked = false;
            btnAddNewUser.IsHitTestVisible = false;


            Button button = sender as Button;
            OperatorUserFull operatorUserFull = button.CommandParameter as OperatorUserFull;
            var user = _operatorUserService.GetByUserId(operatorUserFull.OperatorUserId);
            _operatorUser = user;

           // cboxUpdateLevel.SelectedItem = cboxUpdateLevel.Items.OfType<UserLevel>().FirstOrDefault(x => x.Id == user.UserLevelId);
            cboxUpdateOperator.SelectedItem = cboxUpdateOperator.Items.OfType<Operator>().FirstOrDefault(x => x.Id == user.OperatorId);
            tboxUpdatePassword.Text = user.PasswordHash;
            tboxUpdateUsername.Text = user.Username;
            tboxUpdateEmail.Text = user.Email;
            tboxUpdateFirstName.Text = user.FirstName;
            tboxUpdateLastName.Text = user.LastName;
        }

        private void btnCancelUpdate_Click(object sender, RoutedEventArgs e)
        {

            ClearUpdateUser();
        }

        private void btnSaveUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update?", "Tarot MIS", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) ;
            {
                try
                {
                    var user = new OperatorUser()
                    {
                        Id = _operatorUser.Id,
                        Username = tboxUpdateUsername.Text,
                        PasswordHash = tboxUpdatePassword.Text,
                        //UserLevelId = Convert.ToInt32(cboxUpdateLevel.SelectedValue),
                        OperatorId = Convert.ToInt32(cboxUpdateOperator.SelectedValue),
                        FirstName = tboxUpdateFirstName.Text,
                        LastName = tboxUpdateLastName.Text,
                        DateJoined = _operatorUser.DateJoined,
                        Email = tboxUpdateEmail.Text,

                        IsActive = true, //this is going to be refactored (User is going to be able to modift activation of the user)
                    };

                    _operatorUserService.Update(user);
                    dgwOperatorUser.ItemsSource = _operatorFullService.GetOperatorUsers();
                    MessageBox.Show("Updated!", "Tarot MIS", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearUpdateUser();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Tarot MIS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            dgwOperatorUser.ItemsSource = _operatorFullService.GetOperatorUsers();

        }
    }
}

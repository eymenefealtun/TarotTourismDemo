using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Tourism.Business.Abstract;
using Tourism.Business.Abstract.Models;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.Entities.Concrete;
using Tourism.Entities.Models;

namespace Tourism.MainPage.MVVM.View
{
    public partial class OperatorUserView : UserControl
    {
        IOperatorUserFullService _operatorFullService;
        //IUserLevelService _userLevelService;
        IOperatorService _operatorService;
        IOperatorUserService _operatorUserService;
        IOperatorUserRoleService _operatorUserRoleService;
        IRoleService _roleService;


        OperatorUser _operatorUser;
        ToggleButton[] _addRoleButtons;
        ToggleButton[] _updateRoleButtons;

        public OperatorUserView()
        {
            InitializeComponent();

            _operatorFullService = Instancefactory.GetInstance<IOperatorUserFullService>();
            _operatorService = Instancefactory.GetInstance<IOperatorService>();
            _operatorUserService = Instancefactory.GetInstance<IOperatorUserService>();
            _operatorUserRoleService = Instancefactory.GetInstance<IOperatorUserRoleService>();
            _roleService = Instancefactory.GetInstance<IRoleService>();




            dgwOperatorUser.ItemsSource = _operatorFullService.GetOperatorUsers();
            cboxAddOperator.ItemsSource = _operatorService.GetAll();
            cboxUpdateOperator.ItemsSource = _operatorService.GetAll();




            ToggleButton[] addRoleButtons = new ToggleButton[] { btnAddAccounting, btnAddAdmin, btnAddCustomer, btnAddHumanResources, btnAddManager, btnAddOutgoingOperationsAssistantManager, btnAddOutgoingOperationsSupervisor };
            ToggleButton[] updateRoleButtons = new ToggleButton[] { btnUpdateAccounting, btnUpdateAdmin, btnUpdateCustomer, btnUpdateHumanResources, btnUpdateManager, btnUpdateOutgoingOperationsAssistantManager, btnUpdateOutgoingOperationsSupervisor };
            _updateRoleButtons = updateRoleButtons;
            _addRoleButtons = addRoleButtons;
        }

        private void btnAddNewUser_Click(object sender, RoutedEventArgs e)
        {

            columnEdit.Visibility = Visibility.Hidden;
            if (btnAddNewUser.IsChecked == true)
                stckAddNewUser.Visibility = Visibility.Visible;

            if (btnAddNewUser.IsChecked == false)
                stckAddNewUser.Visibility = Visibility.Hidden;
        }


        private List<OperatorUserRole> GetUserRoles(ToggleButton[] buttons, List<OperatorUserRole> existingOperatorUserRoles)
        {
            var operatorUserRoles = new List<OperatorUserRole>();

            if (buttons == _addRoleButtons)
            {

                for (int i = 0; i < buttons.Length; i++)
                {
                    if (buttons[i].IsChecked == true)
                    {
                        if (buttons[i] == btnAddAccounting)
                            operatorUserRoles.Add(new OperatorUserRole { RoleId = _roleService.GetByRoleName("Accounting").Id });

                        else if (buttons[i] == btnAddAdmin)
                            operatorUserRoles.Add(new OperatorUserRole { RoleId = _roleService.GetByRoleName("Admin").Id });

                        else if (buttons[i] == btnAddCustomer)
                            operatorUserRoles.Add(new OperatorUserRole { RoleId = _roleService.GetByRoleName("Customer").Id });

                        else if (buttons[i] == btnAddHumanResources)
                            operatorUserRoles.Add(new OperatorUserRole { RoleId = _roleService.GetByRoleName("Human Resources").Id });

                        else if (buttons[i] == btnAddManager)
                            operatorUserRoles.Add(new OperatorUserRole { RoleId = _roleService.GetByRoleName("Manager").Id });

                        else if (buttons[i] == btnAddOutgoingOperationsAssistantManager)
                            operatorUserRoles.Add(new OperatorUserRole { RoleId = _roleService.GetByRoleName("Outgoing Operations Assistant Manager").Id });

                        else if (buttons[i] == btnAddOutgoingOperationsSupervisor)
                            operatorUserRoles.Add(new OperatorUserRole { RoleId = _roleService.GetByRoleName("Outgoing Operations Supervisor").Id });
                    }
                }

            }
            if (buttons == _updateRoleButtons)
            {
                for (int i = 0; i < buttons.Length; i++)
                {

                    if (buttons[i].IsChecked == true)
                    {
                        if (existingOperatorUserRoles.SingleOrDefault(x => x.Roles.Name == "Accounting") == null && buttons[i] == btnUpdateAccounting)
                            operatorUserRoles.Add(new OperatorUserRole { RoleId = _roleService.GetByRoleName("Accounting").Id });

                        if (buttons[i] == btnUpdateAdmin && existingOperatorUserRoles.SingleOrDefault(x => x.Roles.Name == "Admin") == null)
                            operatorUserRoles.Add(new OperatorUserRole { RoleId = _roleService.GetByRoleName("Admin").Id });

                        if (buttons[i] == btnUpdateCustomer && existingOperatorUserRoles.SingleOrDefault(x => x.Roles.Name == "Customer") == null)

                            operatorUserRoles.Add(new OperatorUserRole { RoleId = _roleService.GetByRoleName("Customer").Id });

                        if (buttons[i] == btnUpdateHumanResources && existingOperatorUserRoles.SingleOrDefault(x => x.Roles.Name == "Human Resources") == null)
                            operatorUserRoles.Add(new OperatorUserRole { RoleId = _roleService.GetByRoleName("Human Resources").Id });

                        if (buttons[i] == btnUpdateManager && existingOperatorUserRoles.SingleOrDefault(x => x.Roles.Name == "Manager") == null)
                            operatorUserRoles.Add(new OperatorUserRole { RoleId = _roleService.GetByRoleName("Manager").Id });

                        if (buttons[i] == btnUpdateOutgoingOperationsAssistantManager && existingOperatorUserRoles.SingleOrDefault(x => x.Roles.Name == "Outgoing Operations Assistant Manager") == null)
                            operatorUserRoles.Add(new OperatorUserRole { RoleId = _roleService.GetByRoleName("Outgoing Operations Assistant Manager").Id });

                        if (buttons[i] == btnUpdateOutgoingOperationsSupervisor && existingOperatorUserRoles.SingleOrDefault(x => x.Roles.Name == "Outgoing Operations Supervisor") == null)
                            operatorUserRoles.Add(new OperatorUserRole { RoleId = _roleService.GetByRoleName("Outgoing Operations Supervisor").Id });
                    }
                }
            }


            return operatorUserRoles;
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
                        FirstName = tboxAddFirstName.Text,
                        LastName = tboxAddLastName.Text,
                        DateJoined = DateTime.Now,
                        Email = tboxAddEmail.Text,
                        IsActive = true,
                        OperatorUserRoles = GetUserRoles(_addRoleButtons, null)
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
        private void ClearRoleButtons(ToggleButton[] buttons)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].IsChecked = false;
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
            cboxAddOperator.SelectedIndex = -1;
            tboxAddPassword.Text = string.Empty;
            tboxAddUserName.Text = string.Empty;
            columnEdit.Visibility = Visibility.Visible;
            tboxAddFirstName.Text = string.Empty;
            tboxAddLastName.Text = string.Empty;
            tboxAddEmail.Text = string.Empty;
            gridRoles.Visibility = Visibility.Collapsed;
            btnOpenRoles.Visibility = Visibility.Visible;
            btnCloseRole.Visibility = Visibility.Collapsed;
            ClearRoleButtons(_addRoleButtons);

        }

        private void ClearUpdateUser()
        {
            btnUpdateUser.Visibility = Visibility.Hidden;
            stckUpdateUser.Visibility = Visibility.Hidden;
            columnEdit.Visibility = Visibility.Visible;
            btnAddNewUser.IsHitTestVisible = true;
            tboxUpdateUsername.Text = String.Empty;
            tboxUpdateUsername.Text = String.Empty;
            cboxUpdateOperator.SelectedIndex = -1;
            tboxUpdateFirstName.Text = string.Empty;
            tboxUpdateLastName.Text = string.Empty;
            tboxUpdateEmail.Text = string.Empty;
            gridRolesForUpdate.Visibility = Visibility.Collapsed;
            btnUpdateOpenRoles.Visibility = Visibility.Visible;
            btnUpdateCloseRole.Visibility = Visibility.Collapsed;
            ClearRoleButtons(_updateRoleButtons);

        }
        List<OperatorUserRole> _operatorUserRole;
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

            List<OperatorUserRole> operatorUserRoles = _operatorUserRoleService.GetByUserUserId(user.Id);
            _operatorUserRole = operatorUserRoles;

            for (int i = 0; i < operatorUserRoles.Count; i++)
            {


                #region a
                if (operatorUserRoles[i].Roles.Name == "Accounting")
                    btnUpdateAccounting.IsChecked = true;

                else if (operatorUserRoles[i].Roles.Name == "Admin")
                    btnUpdateAdmin.IsChecked = true;

                else if (operatorUserRoles[i].Roles.Name == "Customer")
                    btnUpdateCustomer.IsChecked = true;

                else if (operatorUserRoles[i].Roles.Name == "Human Resources")
                    btnUpdateHumanResources.IsChecked = true;

                else if (operatorUserRoles[i].Roles.Name == "Manager")
                    btnUpdateManager.IsChecked = true;

                else if (operatorUserRoles[i].Roles.Name == "Outgoing Operations Assistant Manager")
                    btnUpdateOutgoingOperationsAssistantManager.IsChecked = true;

                else if (operatorUserRoles[i].Roles.Name == "Outgoing Operations Supervisor")
                    btnUpdateOutgoingOperationsSupervisor.IsChecked = true;
                #endregion
            }


        }

        private void btnCancelUpdate_Click(object sender, RoutedEventArgs e)
        {

            ClearUpdateUser();
        }

        private void btnSaveUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to update?", "Tarot MIS", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) ;
            {
                //try
                //{
                var existingRoles = _operatorUserRoleService.GetByUserUserId(_operatorUser.Id);
                var user = new OperatorUser()
                {
                    Id = _operatorUser.Id,
                    Username = tboxUpdateUsername.Text,
                    PasswordHash = tboxUpdatePassword.Text,
                    OperatorId = Convert.ToInt32(cboxUpdateOperator.SelectedValue),
                    FirstName = tboxUpdateFirstName.Text,
                    LastName = tboxUpdateLastName.Text,
                    DateJoined = _operatorUser.DateJoined,
                    Email = tboxUpdateEmail.Text,
                    OperatorUserRoles = GetUserRoles(_updateRoleButtons, existingRoles),

                    IsActive = true, //this is going to be refactored (User is going to be able to modift activation of the user)
                };

                _operatorUserService.Update(user);
                dgwOperatorUser.ItemsSource = _operatorFullService.GetOperatorUsers();
                MessageBox.Show("Updated!", "Tarot MIS", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearUpdateUser();
                //}
                //catch (Exception exception)
                //{
                //    MessageBox.Show(exception.Message, "Tarot MIS", MessageBoxButton.OK, MessageBoxImage.Error);
                //}
            }

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            dgwOperatorUser.ItemsSource = _operatorFullService.GetOperatorUsers();

        }


        private void btnOpenRoles_Click(object sender, RoutedEventArgs e)
        {
            if (gridRoles.Visibility != Visibility.Visible)
            {
                gridRoles.Visibility = Visibility.Visible;
                btnOpenRoles.Visibility = Visibility.Collapsed;
                btnCloseRole.Visibility = Visibility.Visible;
            }
        }

        private void btnCloseRole_Click(object sender, RoutedEventArgs e)
        {
            if (gridRoles.Visibility == Visibility.Visible)
            {
                gridRoles.Visibility = Visibility.Collapsed;
                btnOpenRoles.Visibility = Visibility.Visible;
                btnCloseRole.Visibility = Visibility.Collapsed;
            }

        }

        private void btnUpdateOpenRoles_Click(object sender, RoutedEventArgs e)
        {
            if (gridRolesForUpdate.Visibility != Visibility.Visible)
            {
                gridRolesForUpdate.Visibility = Visibility.Visible;
                btnUpdateOpenRoles.Visibility = Visibility.Collapsed;
                btnUpdateCloseRole.Visibility = Visibility.Visible;
            }
        }

        private void btnUpdateCloseRole_Click(object sender, RoutedEventArgs e)
        {
            if (gridRolesForUpdate.Visibility == Visibility.Visible)
            {
                gridRolesForUpdate.Visibility = Visibility.Collapsed;
                btnUpdateOpenRoles.Visibility = Visibility.Visible;
                btnUpdateCloseRole.Visibility = Visibility.Collapsed;
            }
        }

        private void btnUpdateUser_UnChecked(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateUser_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}

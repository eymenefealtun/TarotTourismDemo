using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using Tourism.Business.Abstract;
using Tourism.Business.Authentication;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.Entities.Concrete;
using Tourism.MainPage.MVVM.ViewModel;
using Tourism.MainPage.Services;
using Tourism.MainPage.Services.Authentications;

namespace Tourism.MainPage.MVVM.View.Window
{
    public partial class LoginWindow : System.Windows.Window
    {
        private readonly ServiceProvider _serviceProvider;
        private IOperatorUserService _operatorUserService;
        private IAuthenticationService _authenticationService;
        private IOperatorUserRoleService _operatorUserRoleService;


        private readonly IPasswordHasher _passwordHasher;//Asp.Net package downloaded for this


        private int _operatorUserId;
        public LoginWindow()
        {
            InitializeComponent();
            IServiceCollection services = new ServiceCollection();  //specifying the DI Container

            services.AddSingleton<MainWindow>(provider => new MainWindow(_operatorUserId)
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<OperationViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<CustomerViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddSingleton<CustomerOperationViewModel>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<AddOperationViewModel>();
            services.AddSingleton<UpdateOperationViewModel>();
            services.AddSingleton<ReservationDetailViewModel>();
            services.AddSingleton<OperatorUserViewModel>();
            services.AddSingleton<CurrencyViewModel>();
            services.AddSingleton<MainCategoryViewModel>();
            services.AddSingleton<SubCategoryViewModel>();
            services.AddSingleton<GeneralIncomeOutgoingViewModel>();
            services.AddSingleton<EmptyPageViewModel>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<DuplicateOperationViewModel>();
            services.AddSingleton<LoginViewModel>();

            services.AddScoped<IAuthenticator, Authenticator>(); //

            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<Func<Type, Core.ViewModel>>(serviceProvider => viewModelType => (Core.ViewModel)serviceProvider.GetRequiredService(viewModelType));
            _serviceProvider = services.BuildServiceProvider();

            _operatorUserService = Instancefactory.GetInstance<IOperatorUserService>();
            _authenticationService = Instancefactory.GetInstance<IAuthenticationService>();
            _operatorUserRoleService = Instancefactory.GetInstance<IOperatorUserRoleService>();
            _passwordHasher = new PasswordHasher();


        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            Login();
        }

        private void tboxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            //e.Handled = true;
            Login();
        }

        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Login()
        {


            #region 1
            //try
            //{
            //    string userName = tboxUsername.Text;
            //    string password = tboxPassword.Password.ToString();


            //    Mouse.OverrideCursor = Cursors.Wait;
            //    Thread.Sleep(100);
            //    var user = _operatorUserService.GetByUsernameAndPassword(userName, password);
            //    Mouse.OverrideCursor = null;

            //    if (user == null)
            //    {
            //        lblWrongCredentials.Visibility = Visibility.Visible;

            //    }
            //    else
            //    {
            //        lblWrongCredentials.Visibility = Visibility.Collapsed;
            //        _operatorUserId = user.Id;
            //        MainWindow mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            //        mainWindow.Show();
            //        this.Close();

            //    }
            //}
            //catch (Exception) { }
            #endregion

            string usernameByUser = tboxUsername.Text;
            string passwordByUser = pboxPassword.Password;

            Mouse.OverrideCursor = Cursors.Wait;
            Thread.Sleep(100);
            //var user = _operatorUserService.GetByUsername(usernameByUser);
            var user = _operatorUserService.GetByUsernameSqlRaw(usernameByUser);

            Mouse.OverrideCursor = null;

            if (user == null)
            {
                lblWrongCredentials.Visibility = Visibility.Visible;
                return;
            }
            var userRoles = _operatorUserRoleService.GetByUserUserId(user.Id);

            string hashedPassword = _passwordHasher.HashPassword(user.PasswordHash);

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(hashedPassword, passwordByUser);
            if (passwordResult != PasswordVerificationResult.Success)
            {
                lblWrongCredentials.Visibility = Visibility.Visible;
            }
            else if (passwordResult == PasswordVerificationResult.Success)
            {
                lblWrongCredentials.Visibility = Visibility.Collapsed;

                User._operatorUserRoles = userRoles;

                var userRolesInString = new List<string>();         

                for (int i = 0; i < User.GetCurrentUserRoles().Count; i++)
                {
                    userRolesInString.Add(User.GetCurrentUserRoles()[i].Roles.Name.ToString());
                }
                User._operatorUserRolesInString = userRolesInString;

              User._currentOperatorUser = user; //Current user is set in order to use it in all over the app

                #region RoleTrial
                //var builder = new StringBuilder();
                ////var list = User.GetCurrentUserRoles();
                //var list = User.GetCurrentUserRolesInString();
                //for (int i = 0; i < User.GetCurrentUserRolesInString().Count; i++)
                //{
                //    builder.Append(list[i].ToString() + " ");
                //}
                //MessageBox.Show(builder.ToString()); 
                #endregion


                _operatorUserId = User.CurrentUser().Id;
                MainWindow mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
                mainWindow.Show();
                this.Close();
            }




        }

        private void tglBtnShowHide_Click(object sender, RoutedEventArgs e)
        {

            // pboxPassword.CaretIndex = pboxPassword.Password.Length;

            if (tglBtnShowHide.IsChecked == true)
            {
                tboxPassword.Text = pboxPassword.Password;
                tglBtnShowHide.Content = "Hide";
                tboxPassword.Visibility = Visibility.Visible;

            }
            if (tglBtnShowHide.IsChecked == false)
            {
                // tboxPassword.Text = pboxPassword.Password;
                tglBtnShowHide.Content = "Show";
                tboxPassword.Visibility = Visibility.Hidden;

            }
        }






    }
}

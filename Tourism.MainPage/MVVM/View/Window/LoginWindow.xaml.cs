using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Tourism.Business.Authentication;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.Entities.Concrete;
using Tourism.MainPage.MVVM.ViewModel;
using Tourism.MainPage.Services;

namespace Tourism.MainPage.MVVM.View.Window
{
    public partial class LoginWindow : System.Windows.Window
    {
        private readonly ServiceProvider _serviceProvider;
        private IOperatorUserService _operatorUserService;
        private IAuthenticationService _authenticationService;

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

            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<Func<Type, Core.ViewModel>>(serviceProvider => viewModelType => (Core.ViewModel)serviceProvider.GetRequiredService(viewModelType));
            _serviceProvider = services.BuildServiceProvider();

            _operatorUserService = Instancefactory.GetInstance<IOperatorUserService>();
            _authenticationService = Instancefactory.GetInstance<IAuthenticationService>();

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

        // App _app;





        //MainWindow _mainWindow = new MainWindow();      

        private void Login()
        {
            //return;
            try
            {
                string userName = tboxUsername.Text;
                string password = tboxPassword.Password.ToString();

                Mouse.OverrideCursor = Cursors.Wait;
                Thread.Sleep(100);
                var user = _operatorUserService.GetByUsernameAndPassword(userName, password);
                Mouse.OverrideCursor = null;


                if (user == null)
                {
                    lblWrongCredentials.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    lblWrongCredentials.Visibility = Visibility.Collapsed;
                    _operatorUserId = user.Id;
                    MainWindow mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
                    mainWindow.Show();
                    this.Close();

                }
            }
            catch (Exception) { }


        }





    }
}

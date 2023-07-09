using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System;
using System.Windows;
using Tourism.Entities.Concrete;
using Tourism.Business.DependencyResolvers.Ninject;
using System.Windows.Input;

namespace Tourism.LoginPage
{

    public partial class MainWindow : Window
    {
        //private readonly ServiceProvider _serviceProvider;
        private IOperatorUserService _operatorUserService;

        public MainWindow()
        {
            InitializeComponent();
            //IServiceCollection services = new ServiceCollection();  //specifying the DI Container

            //services.AddSingleton<MainWindow>(provider => new MainWindow
            //{
            //    DataContext = provider.GetRequiredService<MainViewModel>()
            //});
            _operatorUserService = Instancefactory.GetInstance<IOperatorUserService>();

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


        //MainWindow _mainWindow = new MainWindow();      

        //Tourism.MainPage.App _mainPage;
       
        private void Login()
        {
            try
            {
                string userName = tboxUsername.Text;
                string password = tboxPassword.Password.ToString();

                Mouse.OverrideCursor = Cursors.Wait;
                Thread.Sleep(100);
                var user = _operatorUserService.GetByUsernameAndPassword(userName, password);
                Mouse.OverrideCursor = Cursors.Arrow;


                if (user == null)
                {
                    lblWrongCredentials.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    lblWrongCredentials.Visibility = Visibility.Collapsed;
                    //MainWindow mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
                    //mainWindow.Show();
                    //  _mainPage = new MainPage.App();
                    //Tourism.MainPage.App app = new Tourism.MainPage.App();

                    //Tourism.MainPage. = new Tourism.MainPage.MVVM.View.Window.MainWindow();
                    //Tourism.MainPage.App app = new MainPage.App();
                    //app.Run();

                    Tourism.MainPage.MVVM.View.Window.MainWindow _mainPage = new Tourism.MainPage.MVVM.View.Window.MainWindow();

                    _mainPage.Show();
                    //_mainPage = new MainPage.MVVM.ViewModel.MainWindowViewModel();
                    //_mainPage.Show();

                    MessageBox.Show("1");



                    //MainWindow mainWindow = new MainWindow(user.Id);

                    //mainWindow.Show();


                    //this.Close();








                    //var mainwindow = _serviceProvider.GetRequiredService<MainWindow>();


                }
            }
            catch (Exception) { }


        }






    }
}

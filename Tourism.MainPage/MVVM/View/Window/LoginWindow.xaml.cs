﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.Entities.Concrete;
using Tourism.MainPage.MVVM.ViewModel;
using Tourism.MainPage.Services;
using ViewModel = Tourism.Core;


namespace Tourism.MainPage.MVVM.View.Window
{
    public partial class LoginWindow : System.Windows.Window
    {
        private readonly ServiceProvider _serviceProvider;
        private IOperatorUserService _operatorUserService;

        public LoginWindow()
        {
            InitializeComponent();
            IServiceCollection services = new ServiceCollection();  //specifying the DI Container
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

        App _app;
        //MainWindow _mainWindow = new MainWindow();      

        private void Login()
        {
            return;
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
                    MainWindow mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
                    mainWindow.Show();

                    //App app = new App();
                    //app.Start();                    

                    //app.Start(2);
                    //var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();


                    //MainWindowViewModel viewModel = new MainWindowViewModel(user.Id);
                    // mainWindow.Show();

                    //App app = new App();
                    //app.Start();
                    // _mainWindow.Visibility = Visibility.Visible;    
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

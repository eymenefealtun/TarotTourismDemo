using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using Tourism.MainPage.Core;
using Tourism.MainPage.MVVM.ViewModel;
using Tourism.MainPage.MVVM.View.Window;
using Tourism.MainPage.Services;        

namespace Tourism.MainPage
{

    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        public string _documentCode;

        public App()
        {
            IServiceCollection services = new ServiceCollection();  //specifying the DI Container
            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<OperationViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<CustomerViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddSingleton<CustomerOperationViewModel>();
            services.AddSingleton<MainViewModel>();
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

            services.AddSingleton<INavigationService, Services.NavigationService>();

            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

    }
}

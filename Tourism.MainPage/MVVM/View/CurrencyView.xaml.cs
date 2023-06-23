using System.Windows.Controls;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.Entities.Concrete;
using System.Windows;
using System;

namespace Tourism.MainPage.MVVM.View
{
    public partial class CurrencyView : UserControl
    {
        private ICurrencyService _currencyService;

        public CurrencyView()
        {
            InitializeComponent();
            _currencyService = Instancefactory.GetInstance<ICurrencyService>();
            dgwCurrency.ItemsSource = _currencyService.GetAll();


        }

        private void btnRefresh_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            dgwCurrency.ItemsSource = _currencyService.GetAll();

        }

        private int _currencyId;
        private string _currencyName;
        private void btnEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            tboxUpdateName.Text = string.Empty;
            btnAddCurrency.IsHitTestVisible = false;
            columnEdit.Visibility = Visibility.Hidden;
            stckUpdateUser.Visibility = Visibility.Visible;
            btnUpdateCurrrency.Visibility = Visibility.Visible;

            Button button = sender as Button;
            Currency currency = button.CommandParameter as Currency;

            _currencyId = currency.Id;
            _currencyName = currency.Name;

            if (currency != null)
            {
                tboxUpdateName.Text = currency.Name;
            }
        }
        private void btnSaveUpdatedCurrency_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    _currencyService.Update(new Tourism.Entities.Concrete.Currency
                    {
                        Id = _currencyId,
                        Name = tboxUpdateName.Text,
                    });

                    MessageBox.Show("Saved", "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Information);

                    dgwCurrency.ItemsSource = _currencyService.GetAll();
                    stckUpdateUser.Visibility = Visibility.Hidden;
                    btnUpdateCurrrency.Visibility = Visibility.Hidden;
                    columnEdit.Visibility = Visibility.Visible;
                    btnAddCurrency.IsHitTestVisible = true;

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnCancelUpdatedCurrency_Click(object sender, RoutedEventArgs e)
        {
            btnAddCurrency.IsHitTestVisible = true;
            btnUpdateCurrrency.Visibility = Visibility.Hidden;
            stckUpdateUser.Visibility = Visibility.Hidden;
            columnEdit.Visibility = Visibility.Visible;
        }


        private void btnAddCurrency_Click(object sender, RoutedEventArgs e)
        {
            if (btnAddCurrency.IsChecked == true)
                stckAddNewCurrency.Visibility = Visibility.Visible;
            btnAddCurrency.IsHitTestVisible = false;

            if (btnAddCurrency.IsChecked == false)
                stckAddNewCurrency.Visibility = Visibility.Hidden;
        }


        private void btnCancelNewCurrency_Click(object sender, RoutedEventArgs e)
        {
            ClearAddNewUser();

        }

        private void btnSaveNewCurrency_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to add?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    var currency = new Tourism.Entities.Concrete.Currency()
                    {
                        Name = tboxAddName.Text,
                    };
                    _currencyService.Add(currency);
                    dgwCurrency.ItemsSource = _currencyService.GetAll();
                    ClearAddNewUser();
                    MessageBox.Show("Added", "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ClearAddNewUser()
        {
            stckAddNewCurrency.Visibility = Visibility.Hidden;
            btnAddCurrency.IsChecked = false;
            tboxAddName.Text = string.Empty;
            btnAddCurrency.IsHitTestVisible = true;

        }


    }

}

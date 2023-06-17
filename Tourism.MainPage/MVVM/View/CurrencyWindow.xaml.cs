using System;
using System.Windows;
using System.Windows.Controls;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.Entities.Concrete;

namespace Tourism.MainPage.MVVM.View
{

    public partial class Currency : Window
    {
        private ICurrencyService _currencyService;

        private int _currencyId;
        private string _currencyName;
        public Currency()
        {
            InitializeComponent();

            _currencyService = Instancefactory.GetInstance<ICurrencyService>();

        }

        private void dgwCurrency_Loaded(object sender, RoutedEventArgs e)
        {
            dgwCurrency.ItemsSource = _currencyService.GetAll();

        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            tboxCurrencyName.IsReadOnly = false;
            columnEdit.Visibility = Visibility.Hidden;
            btnAddCurrency.Visibility = Visibility.Hidden;
            stackUpdate.Visibility = Visibility.Visible;

            Button button = sender as Button;
            Tourism.Entities.Concrete.Currency currency = button.CommandParameter as Tourism.Entities.Concrete.Currency;

            _currencyId = currency.Id;
            _currencyName = currency.Name;

            if (currency != null)
            {
                tboxCurrencyName.Text = currency.Name;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    _currencyService.Update(new Tourism.Entities.Concrete.Currency
                    {
                        Id = _currencyId,
                        Name = tboxCurrencyName.Text,
                    });

                    MessageBox.Show("Saved", "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Information);

                    dgwCurrency.ItemsSource = _currencyService.GetAll();
                    stackUpdate.Visibility = Visibility.Collapsed;
                    columnEdit.Visibility = Visibility.Visible;
                    btnAddCurrency.Visibility = Visibility.Visible;

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            dgwCurrency.ItemsSource = _currencyService.GetAll();
            stackUpdate.Visibility = Visibility.Collapsed;
            columnEdit.Visibility = Visibility.Visible;
            btnAddCurrency.Visibility = Visibility.Visible;


        }

        private void btnAddCurrency_Checked(object sender, RoutedEventArgs e)
        {
            tboxAddCurrency.Text = string.Empty;
            columnEdit.Visibility = Visibility.Hidden;
            stackAdd.Visibility = Visibility.Visible;
        }

        private void btnAddCurrency_Unchecked(object sender, RoutedEventArgs e)
        {
            tboxAddCurrency.Text = string.Empty;
            columnEdit.Visibility = Visibility.Visible;
            stackAdd.Visibility = Visibility.Collapsed;
        }

        private void btnAddCancel_Click(object sender, RoutedEventArgs e)
        {
            tboxAddCurrency.Text = string.Empty;
            columnEdit.Visibility = Visibility.Visible;
            stackAdd.Visibility = Visibility.Collapsed;
            btnAddCurrency.IsChecked = false;
        }

        private void btnAddSave_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to add?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    var currency = new Tourism.Entities.Concrete.Currency()
                    {
                        Name = tboxAddCurrency.Text,
                    };
                    _currencyService.Add(currency);
                    MessageBox.Show("Added", "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Information);
                    tboxAddCurrency.Text = string.Empty;
                    dgwCurrency.ItemsSource = _currencyService.GetAll();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
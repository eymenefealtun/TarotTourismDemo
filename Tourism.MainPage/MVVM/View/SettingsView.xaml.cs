using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;


namespace Tourism.MainPage.MVVM.View
{
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();


        }
        private void btnDarkTheme_Checked(object sender, RoutedEventArgs e)
        {
            var color = Brushes.Black;
            MainWindow mainWindow = new MainWindow(color);

     

            if (btnRedTheme.IsChecked == true)
            {

                //MainWindow mainWindow = new MainWindow();
                //mainWindow.mainText.Text = "TAROTTTTTTTTTTTT";

                //btnRedTheme.Background = Brushes.Transparent;
                //btnDarkTheme.Background = Brushes.White;
                //btnRedTheme.IsChecked = false;
                //Brush color = (Brush)new BrushConverter().ConvertFrom("#36393F");
                //MainWindow mainWindow2 = new MainWindow(color);
            }

        }

        private void btnRedTheme_Checked(object sender, RoutedEventArgs e)
        {

            if (btnDarkTheme.IsChecked == true)
            {
                //MainWindow mainWindow = new MainWindow();
                //btnDarkTheme.Background = Brushes.Transparent;
                //btnDarkTheme.Background = Brushes.White;
                //btnDarkTheme.IsChecked = false;
                ////  Brush color = (Brush)new BrushConverter().ConvertFrom("#da4543");
                //Brush color = Brushes.DarkRed;
                //MainWindow mainWindow2 = new MainWindow(color);
            }

        }
    }
}

using System;
using System.Windows;
using System.Windows.Controls;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.Entities.Concrete;

namespace Tourism.MainPage.MVVM.View
{
    public partial class MainCategoryView : UserControl
    {
        private IMainCategoryService _mainCategoryService;
        private int _categoryId;
        public MainCategoryView()
        {
            InitializeComponent();
            _mainCategoryService = Instancefactory.GetInstance<IMainCategoryService>();
            dgwCategory.ItemsSource = _mainCategoryService.GetAll();

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            columnEdit.Visibility = Visibility.Hidden;
            stckUpdateCategory.Visibility = Visibility.Visible;
            btnUpdateCategory.Visibility = Visibility.Visible;
            btnAddNewCategory.IsHitTestVisible = false;
            Button button = sender as Button;

            MainCategory mainCategory = button.CommandParameter as MainCategory;
            _categoryId = mainCategory.Id;
            tboxUpdateCategory.Text = mainCategory != null ? tboxUpdateCategory.Text = mainCategory.Name : null;


        }
        private void btnCancelUpdate_Click(object sender, RoutedEventArgs e)
        {
            columnEdit.Visibility = Visibility.Visible;
            stckUpdateCategory.Visibility = Visibility.Hidden;
            btnUpdateCategory.Visibility = Visibility.Hidden;
            btnAddNewCategory.IsHitTestVisible = true;

        }

        private void btnSaveUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                try
                {
                    _mainCategoryService.Update(new MainCategory
                    {
                        Id = _categoryId,
                        Name = tboxUpdateCategory.Text,
                    });
                    dgwCategory.ItemsSource = _mainCategoryService.GetAll();
                    MessageBox.Show("Saved", "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Information);
                    columnEdit.Visibility = Visibility.Visible;
                    stckUpdateCategory.Visibility = Visibility.Hidden;
                    btnUpdateCategory.Visibility = Visibility.Hidden;
                    btnAddNewCategory.IsHitTestVisible = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


        }



        private void btnAddNewCategory_Click(object sender, RoutedEventArgs e)
        {
            tboxAddCategoryName.Text = String.Empty;
            if (btnAddNewCategory.IsChecked == true)
            {
                stckAddNewCategory.Visibility = Visibility.Visible;
                btnAddNewCategory.IsHitTestVisible = false;
                columnEdit.Visibility = Visibility.Hidden;
            }
        }

        private void btnSaveAddCategory_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to add?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                try
                {
                    var mainCategory = new MainCategory()
                    {
                        Name = tboxAddCategoryName.Text,
                    };

                    _mainCategoryService.Add(mainCategory);
                    MessageBox.Show("Added", "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Information);
                    columnEdit.Visibility = Visibility.Visible;
                    stckAddNewCategory.Visibility = Visibility.Hidden;
                    btnAddNewCategory.IsChecked = false;
                    btnAddNewCategory.IsHitTestVisible = true;
                    tboxAddCategoryName.Text = string.Empty;
                    dgwCategory.ItemsSource = _mainCategoryService.GetAll();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


        }

        private void btnCancelAddCategory_Click(object sender, RoutedEventArgs e)
        {
            btnAddNewCategory.IsHitTestVisible = true;
            stckAddNewCategory.Visibility = Visibility.Hidden;
            btnAddNewCategory.IsChecked = false;
            columnEdit.Visibility = Visibility.Visible;
        }





        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            dgwCategory.ItemsSource = _mainCategoryService.GetAll();
        }


    }



}

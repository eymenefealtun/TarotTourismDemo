using System;
using System.Windows.Controls;
using System.Windows;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.Entities.Concrete;
using System.Security.Policy;

namespace Tourism.MainPage.MVVM.View
{
    public partial class SubCategoryView : UserControl
    {
        private ISubCategoryService _subCategoryService;
        private IMainCategoryService _mainCategoryService;
        private int _mainCategoryId;
        private int _subCategoryId;
        public SubCategoryView()
        {
            InitializeComponent();
            _subCategoryService = Instancefactory.GetInstance<ISubCategoryService>();
            _mainCategoryService = Instancefactory.GetInstance<IMainCategoryService>();
            cboxMainCategory.ItemsSource = _mainCategoryService.GetAll();
            cboxAddMainCategoryId.ItemsSource = _mainCategoryService.GetAll();
            cboxRelocateMainCategory.ItemsSource = _mainCategoryService.GetAll();
        }

        private void cboxMainCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxMainCategory.SelectedIndex >= 0)
            {


                lblNoData.Visibility = Visibility.Hidden;
                dgwCategory.ItemsSource = _subCategoryService.GetByMainCategory(Convert.ToInt32(cboxMainCategory.SelectedValue));
                if (borderDgw.Visibility == Visibility.Hidden)
                    borderDgw.Visibility = Visibility.Visible;
                btnAddNewCategory.Visibility = Visibility.Visible;

                if (dgwCategory.Items.Count == 0)
                {
                    lblNoData.Visibility = Visibility.Visible;
                }
            }


        }

        private void btnAddNewCategory_Click(object sender, RoutedEventArgs e)
        {
            tboxAddCategoryName.Text = String.Empty;
            cboxAddMainCategoryId.SelectedIndex = -1;
            stckAddNewCategory.Visibility = Visibility.Visible;
            btnAddNewCategory.IsHitTestVisible = false;
            columnEdit.Visibility = Visibility.Hidden;
            columnRelocate.Visibility = Visibility.Hidden;
            cboxMainCategory.IsHitTestVisible = false;


        }

        private void btnCancelAddCategory_Click(object sender, RoutedEventArgs e)
        {
            stckAddNewCategory.Visibility = Visibility.Hidden;
            btnAddNewCategory.IsHitTestVisible = true;
            btnAddNewCategory.IsChecked = false;
            columnEdit.Visibility = Visibility.Visible;
            columnRelocate.Visibility = Visibility.Visible;
            cboxMainCategory.IsHitTestVisible = true;

        }

        private void btnSaveAddCategory_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to add?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    var subCategory = new SubCategory()
                    {
                        Name = tboxAddCategoryName.Text,
                        MainCategoryId = Convert.ToInt32(cboxAddMainCategoryId.SelectedValue),
                    };

                    _subCategoryService.Add(subCategory);
                    MessageBox.Show("Added", "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Information);
                    columnEdit.Visibility = Visibility.Visible;
                    columnRelocate.Visibility = Visibility.Visible;
                    stckAddNewCategory.Visibility = Visibility.Hidden;
                    btnAddNewCategory.IsChecked = false;
                    btnAddNewCategory.IsHitTestVisible = true;
                    cboxMainCategory.SelectedValue = Convert.ToInt32(cboxAddMainCategoryId.SelectedValue);
                    dgwCategory.ItemsSource = _subCategoryService.GetByMainCategory(Convert.ToInt32(cboxMainCategory.SelectedValue));
                    cboxMainCategory.IsHitTestVisible = true;

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnSaveUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    _subCategoryService.Update(new SubCategory
                    {
                        Id = _subCategoryId,
                        Name = tboxUpdateCategory.Text,
                        MainCategoryId = _mainCategoryId,
                    });
                    dgwCategory.ItemsSource = _subCategoryService.GetByMainCategory(Convert.ToInt32(cboxMainCategory.SelectedValue));
                    MessageBox.Show("Saved", "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Information);
                    columnEdit.Visibility = Visibility.Visible;
                    columnRelocate.Visibility = Visibility.Visible;
                    stckUpdateCategory.Visibility = Visibility.Hidden;
                    btnUpdateCategory.Visibility = Visibility.Hidden;
                    btnAddNewCategory.IsHitTestVisible = true;
                    cboxMainCategory.IsHitTestVisible = true;

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnCancelUpdate_Click(object sender, RoutedEventArgs e)
        {
            columnEdit.Visibility = Visibility.Visible;
            columnRelocate.Visibility = Visibility.Visible;
            btnUpdateCategory.Visibility = Visibility.Hidden;
            stckUpdateCategory.Visibility = Visibility.Hidden;

            btnAddNewCategory.IsHitTestVisible = true;
            cboxMainCategory.IsHitTestVisible = true;


        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            tboxUpdateCategory.Text = String.Empty;
            btnAddNewCategory.IsHitTestVisible = false;
            columnEdit.Visibility = Visibility.Hidden;
            columnRelocate.Visibility = Visibility.Hidden;
            btnUpdateCategory.Visibility = Visibility.Visible;
            stckUpdateCategory.Visibility = Visibility.Visible;
            btnRelocateCategory.Visibility = Visibility.Hidden;
            stckRelocate.Visibility = Visibility.Hidden;
            cboxMainCategory.IsHitTestVisible = false;

            Button button = sender as Button;
            SubCategory subCategory = button.CommandParameter as SubCategory;
            _mainCategoryId = subCategory.MainCategoryId;
            _subCategoryId = subCategory.Id;
            tboxUpdateCategory.Text = subCategory != null ? tboxUpdateCategory.Text = subCategory.Name : null;

        }

        private void btnRelocate_Click(object sender, RoutedEventArgs e)
        {
            cboxRelocateMainCategory.SelectedIndex = -1;
            tboxRelocateSubCategoryName.Text = String.Empty;
            columnEdit.Visibility = Visibility.Hidden;
            columnRelocate.Visibility = Visibility.Hidden;
            btnRelocateCategory.Visibility = Visibility.Visible;
            stckRelocate.Visibility = Visibility.Visible;
            btnUpdateCategory.Visibility = Visibility.Hidden;
            stckUpdateCategory.Visibility = Visibility.Hidden;
            btnAddNewCategory.IsHitTestVisible = false;
            stckAddNewCategory.Visibility = Visibility.Hidden;
            cboxMainCategory.IsHitTestVisible = false;

            Button button = sender as Button;
            SubCategory subCategory = button.CommandParameter as SubCategory;
            _mainCategoryId = subCategory.MainCategoryId;
            _subCategoryId = subCategory.Id;
            tboxRelocateSubCategoryName.Text = subCategory != null ? tboxUpdateCategory.Text = subCategory.Name : null;


        }

        private void btnRelocateSave_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    var subCategory = new SubCategory()
                    {
                        Id = _subCategoryId,
                        Name = tboxRelocateSubCategoryName.Text,
                        MainCategoryId = Convert.ToInt32(cboxRelocateMainCategory.SelectedValue),
                    };
                    _subCategoryService.Update(subCategory);
                    dgwCategory.ItemsSource = _subCategoryService.GetByMainCategory(Convert.ToInt32(cboxRelocateMainCategory.SelectedValue));
                    cboxMainCategory.SelectedValue = (Convert.ToInt32(cboxRelocateMainCategory.SelectedValue));
                    MessageBox.Show("Relocated", "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Information);
                    columnEdit.Visibility = Visibility.Visible;
                    columnRelocate.Visibility = Visibility.Visible;
                    btnAddNewCategory.IsHitTestVisible = true;
                    btnRelocateCategory.Visibility = Visibility.Hidden;
                    stckRelocate.Visibility = Visibility.Hidden;
                    cboxMainCategory.IsHitTestVisible = true;

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


        }

        private void btnRelocateCancel_Click(object sender, RoutedEventArgs e)
        {
            columnEdit.Visibility = Visibility.Visible;
            columnRelocate.Visibility = Visibility.Visible;
            btnAddNewCategory.IsHitTestVisible = true;
            btnRelocateCategory.Visibility = Visibility.Hidden;
            stckRelocate.Visibility = Visibility.Hidden;
            cboxMainCategory.IsHitTestVisible = true;

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            cboxMainCategory.SelectedIndex = -1;
            borderDgw.Visibility = Visibility.Hidden;


            btnAddNewCategory.IsHitTestVisible = true;
            stckAddNewCategory.Visibility = Visibility.Hidden;

            btnUpdateCategory.Visibility = Visibility.Hidden;
            stckUpdateCategory.Visibility = Visibility.Hidden;

            btnRelocateCategory.Visibility = Visibility.Hidden;
            stckRelocate.Visibility = Visibility.Hidden;

            cboxMainCategory.IsHitTestVisible = true;
            columnEdit.Visibility = Visibility.Visible;
            columnRelocate.Visibility = Visibility.Visible;
            lblNoData.Visibility = Visibility.Hidden;

        }
    }


}

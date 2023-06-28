using System;
using System.Windows;
using System.Windows.Controls;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.Entities.Concrete;

namespace Tourism.MainPage.MVVM.View.Window
{


    public partial class CategoryWindow : System.Windows.Window
    {
        private IMainCategoryService _mainCategoryService;
        private ISubCategoryService _subCategoryService;
        private int _mainCategoryId;
        private int _categoryId;
        private bool _category;


        public CategoryWindow(string category)
        {
            InitializeComponent();
            _mainCategoryService = Instancefactory.GetInstance<IMainCategoryService>();
            columnRelocate.Visibility = Visibility.Hidden;
            _category = false;
        }

        public CategoryWindow(string category, int mainCateoryId, object service)
        {
            InitializeComponent();
            _mainCategoryId = mainCateoryId;
            _subCategoryService = Instancefactory.GetInstance<ISubCategoryService>();
            _mainCategoryService = Instancefactory.GetInstance<IMainCategoryService>();
            _category = true;
        }


        private void LoadGrid()
        {
            dgwCategory.ItemsSource = !_category ? dgwCategory.ItemsSource = _mainCategoryService.GetAll() : dgwCategory.ItemsSource = dgwCategory.ItemsSource = _subCategoryService.GetByMainCategory(_mainCategoryId);
        }

        private void dgwCategory_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGrid();
        }

        private void btnSaveAdd_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to add?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (_category)
                {
                    try
                    {
                        var subCategory = new SubCategory()
                        {
                            Name = tboxAddCategory.Text,
                            MainCategoryId = _mainCategoryId,
                        };
                        _subCategoryService.Add(subCategory);
                        MessageBox.Show("Added", "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Information);
                        tboxAddCategory.Text = string.Empty;
                        LoadGrid();
                        columnEdit.Visibility = Visibility.Visible;
                        columnRelocate.Visibility = Visibility.Visible;
                        stackAdd.Visibility = Visibility.Hidden;
                        btnAddCategory.IsChecked = false;

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if (!_category)
                {
                    try
                    {
                        var mainCategory = new MainCategory()
                        {
                            Name = tboxAddCategory.Text,
                        };
                        _mainCategoryService.Add(mainCategory);
                        MessageBox.Show("Added", "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Information);
                        columnEdit.Visibility = Visibility.Visible;
                        stackAdd.Visibility = Visibility.Hidden;
                        btnAddCategory.IsChecked = false;
                        tboxAddCategory.Text = string.Empty;
                        LoadGrid();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
        }

        private void btnCancelAdd_Click(object sender, RoutedEventArgs e)
        {
            tboxAddCategory.Text = string.Empty;
            columnEdit.Visibility = Visibility.Visible;
            stackAdd.Visibility = Visibility.Collapsed;
            btnAddCategory.IsChecked = false;
        }

        private void btnAddCategory_Checked(object sender, RoutedEventArgs e)
        {
            tboxAddCategory.Text = string.Empty;
            columnEdit.Visibility = Visibility.Hidden;
            if (_category)
                columnRelocate.Visibility = Visibility.Hidden;

            stackAdd.Visibility = Visibility.Visible;

        }

        private void btnAddCategory_Unchecked(object sender, RoutedEventArgs e)
        {
            tboxUpdateCategory.Text = string.Empty;
            columnEdit.Visibility = Visibility.Visible;
            if (_category)
                columnRelocate.Visibility = Visibility.Visible;
            stackAdd.Visibility = Visibility.Collapsed;
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }




        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            tboxUpdateCategory.IsReadOnly = false;
            columnEdit.Visibility = Visibility.Hidden;
            btnAddCategory.Visibility = Visibility.Hidden;
            stackUpdate.Visibility = Visibility.Visible;
            columnRelocate.Visibility = Visibility.Hidden;
            Button button = sender as Button;

            if (_category)
            {
                SubCategory subCategory = button.CommandParameter as SubCategory;
                _categoryId = subCategory.Id;
                tboxUpdateCategory.Text = subCategory != null ? tboxUpdateCategory.Text = subCategory.Name : null;
            }
            if (!_category)
            {
                MainCategory mainCategory = button.CommandParameter as MainCategory;
                _categoryId = mainCategory.Id;
                tboxUpdateCategory.Text = mainCategory != null ? tboxUpdateCategory.Text = mainCategory.Name : null;
            }
        }

        private void btnSaveUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (_category)
                {
                    try
                    {
                        _subCategoryService.Update(new SubCategory
                        {
                            Id = _categoryId,
                            Name = tboxUpdateCategory.Text,
                            MainCategoryId = _mainCategoryId,
                        });
                        MessageBox.Show("Saved", "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadGrid();
                        stackUpdate.Visibility = Visibility.Collapsed;
                        columnEdit.Visibility = Visibility.Visible;
                        btnAddCategory.Visibility = Visibility.Visible;
                        columnEdit.Visibility = Visibility.Visible;
                        columnRelocate.Visibility = Visibility.Visible;

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if (!_category)
                {
                    try
                    {
                        _mainCategoryService.Update(new MainCategory
                        {
                            Id = _categoryId,
                            Name = tboxUpdateCategory.Text,
                        });
                        MessageBox.Show("Saved", "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadGrid();
                        stackUpdate.Visibility = Visibility.Collapsed;
                        columnEdit.Visibility = Visibility.Visible;
                        btnAddCategory.Visibility = Visibility.Visible;
                        columnEdit.Visibility = Visibility.Visible;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "TAROT MIS", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
        }

        private void btnCancelUpdate_Click(object sender, RoutedEventArgs e)
        {
            LoadGrid();
            stackUpdate.Visibility = Visibility.Collapsed;
            columnEdit.Visibility = Visibility.Visible;
            btnAddCategory.Visibility = Visibility.Visible;
            if (_category)
                columnRelocate.Visibility = Visibility.Visible;

        }

        private string _subCategoryName;
        private void btnSaveRelocate_Click(object sender, RoutedEventArgs e)
        {

            if (cboxMainCategory.SelectedIndex >= 0 && MessageBox.Show("Are you sure you want to relocate?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var subCategory = new SubCategory()
                {
                    Id = _categoryId,
                    Name = _subCategoryName,
                    MainCategoryId = Convert.ToInt32(cboxMainCategory.SelectedValue),
                };
                _subCategoryService.Update(subCategory);
                MessageBox.Show("Relocation succeed!", "Tarot MIS", MessageBoxButton.OK, MessageBoxImage.Information);
                stackRelocate.Visibility = Visibility.Hidden;
                columnRelocate.Visibility = Visibility.Visible;
                btnAddCategory.Visibility = Visibility.Visible;
                columnRelocate.Visibility = Visibility.Visible;
                return;
            }
            MessageBox.Show("You must choose main category first!", "Tarot MIS", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnCancelRelocate_Click(object sender, RoutedEventArgs e)
        {
            stackRelocate.Visibility = Visibility.Hidden;
            columnRelocate.Visibility = Visibility.Visible;
            btnAddCategory.Visibility = Visibility.Visible;
            columnEdit.Visibility = Visibility.Visible;
        }

        private void btnRelocate_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            SubCategory subc = button.CommandParameter as SubCategory;
            _categoryId = subc.Id;
            tboxSubToMain.Text = subc.Name;
            _subCategoryName = subc.Name;
            columnRelocate.Visibility = Visibility.Hidden;
            cboxMainCategory.ItemsSource = _mainCategoryService.GetAll();
            cboxMainCategory.SelectedIndex = -1;
            stackRelocate.Visibility = Visibility.Visible;
            btnAddCategory.Visibility = Visibility.Hidden;
            columnEdit.Visibility = Visibility.Hidden;
        }


    }
}

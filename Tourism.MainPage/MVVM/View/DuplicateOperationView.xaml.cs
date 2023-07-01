using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.DataAccess.Abstract;
using Tourism.Entities.Concrete;

namespace Tourism.MainPage.MVVM.View
{
    public partial class DuplicateOperationView : UserControl
    {
        private IMainCategoryService _mainCategoryService;
        private ISubCategoryService _subCategoryService;
        private IOperationService _operationService;
        public DuplicateOperationView()
        {
            InitializeComponent();
            _mainCategoryService = Instancefactory.GetInstance<IMainCategoryService>();
            _subCategoryService = Instancefactory.GetInstance<ISubCategoryService>();
            _operationService = Instancefactory.GetInstance<IOperationService>();

            cboxMainCategory.ItemsSource = _mainCategoryService.GetAll();

        }

        private void cboxMainCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxMainCategory.SelectedIndex > -1)
            {
                cboxSubCategory.IsHitTestVisible = true;
                cboxSubCategory.ItemsSource = _subCategoryService.GetByMainCategory(Convert.ToInt32(cboxMainCategory.SelectedValue));
            }
        }

        private void cboxSubCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxSubCategory.SelectedIndex > -1)
            {
                cboxOperation.IsHitTestVisible = true;
                cboxOperation.ItemsSource = _operationService.GetBySubCategory(Convert.ToInt32(cboxSubCategory.SelectedValue));
            }
        }

        private void cboxOperation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxOperation.SelectedIndex > -1)
            {
                cboxNumberOfDuplicate.IsHitTestVisible = true;

            }
       

            MessageBox.Show(cboxOperation.SelectedIndex.ToString());
            cboxOperation.Text = "asdasdasdasdasdasdasdasds";

        }

        private void cboxOperation_TextChanged(object sender, TextChangedEventArgs e)
        {
            //MessageBox.Show(cboxOperation.Text);

            if (cboxOperation.Text != String.Empty)
            {
                cboxOperation.ItemsSource = _operationService.GetBySubCategoryAndDocumentCode(cboxOperation.Text, Convert.ToInt32(cboxSubCategory.SelectedValue));
            }
            else if (cboxOperation.Text == String.Empty)
            {
                cboxOperation.ItemsSource = _operationService.GetBySubCategory(Convert.ToInt32(cboxSubCategory.SelectedValue));
            }

        }

    }



}

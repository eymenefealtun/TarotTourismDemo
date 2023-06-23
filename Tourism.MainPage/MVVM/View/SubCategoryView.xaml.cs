using System;
using System.Windows.Controls;
using System.Windows;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.Entities.Concrete;

namespace Tourism.MainPage.MVVM.View
{
    public partial class SubCategoryView : UserControl
    {
        private ISubCategoryService _subCategoryService;
        private IMainCategoryService _mainCategoryService;

        public SubCategoryView()
        {
            InitializeComponent();
            _subCategoryService = Instancefactory.GetInstance<ISubCategoryService>();
            _mainCategoryService = Instancefactory.GetInstance<IMainCategoryService>();
            cboxMainCategory.ItemsSource = _mainCategoryService.GetAll();

        }

        private void cboxMainCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxMainCategory.SelectedIndex >= 0)
            {
                lblNoData.Visibility = Visibility.Hidden;
                dgwCategory.ItemsSource = _subCategoryService.GetByMainCategory(Convert.ToInt32(cboxMainCategory.SelectedValue));
                if (borderDgw.Visibility == Visibility.Hidden)
                    borderDgw.Visibility = Visibility.Visible;
                if (dgwCategory.Items.Count == 0)
                {
                    lblNoData.Visibility = Visibility.Visible;
                }
                    
            }


        }

        private void infoIcon_Click(object sender, RoutedEventArgs e)
        {
            //var toolTip = new ToolTip();
            ////var castToolTip = (ToolTip)infoIcon.ToolTip;
            ////castToolTip.IsOpen = true;
            //toolTip.Content = infoIcon.ToolTip;         
            //toolTip.StaysOpen = false;
            //toolTip.IsOpen = true;


        }
    }


}

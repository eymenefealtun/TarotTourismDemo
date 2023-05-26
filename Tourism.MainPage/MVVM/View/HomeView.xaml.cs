using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tourism.Business.Abstract.Models;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.DataAccess.Abstract;

namespace Tourism.MainPage.MVVM.View
{

    public partial class HomeView : UserControl
    {
        private IOperationService _operationService;
        private IOperationMainService _operationMainService;
        private IDailySaleService _dailySaleService;

        public HomeView()
        {
            InitializeComponent();
            _operationService = Instancefactory.GetInstance<IOperationService>();
            _operationMainService = Instancefactory.GetInstance<IOperationMainService>();
            _dailySaleService = Instancefactory.GetInstance<IDailySaleService>();
        }

        private void dgwDailySales_Loaded(object sender, RoutedEventArgs e)
        {
            dgwDailySales.ItemsSource = _dailySaleService.GetDailySale();
        }
    }
}

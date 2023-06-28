using System.Drawing;
using System.Windows.Media;
using Tourism.MainPage.Core;

namespace Tourism.MainPage.MVVM.ViewModel
{
    public class GlobalViewModel
    {
        public static GlobalViewModel Instance { get; } = new GlobalViewModel();

        private SolidColorBrush _pinkTheme = new SolidColorBrush(Colors.Pink);
        private SolidColorBrush _blackTheme = new SolidColorBrush(Colors.Black);            

        public SolidColorBrush PinkTheme
        {
            get { return _pinkTheme; }
            set
            {       
                _pinkTheme = value;
            }
        }
        public SolidColorBrush BlackTheme
        {
            get { return _blackTheme; }
            set
            {
                _blackTheme = value;
            }
        }


    }
}

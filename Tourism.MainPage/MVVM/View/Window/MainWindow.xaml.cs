using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using Tourism.Business.Authentication;
using Tourism.Business.DependencyResolvers.Ninject;
using Tourism.Entities.Concrete;
using Tourism.MainPage.MVVM.ViewModel;
using Tourism.MainPage.Services;
using Tourism.MainPage.Services.Authentications;

namespace Tourism.MainPage.MVVM.View.Window
{
    public partial class MainWindow : System.Windows.Window
    {
        public string _textMain;
        private IOperatorUserService _operatorUserService;

        ToggleButton[] _allButtons;
        ToggleButton[] _allMainButtons;
        ToggleButton[] _firstSubButtons;
        ToggleButton[] _secondSubButtons;
        ToggleButton[] _modificationSubButtons;
        ToggleButton[] _modificationSecondSubButtons;
        ToggleButton[] _incomeSubButtons;
        ToggleButton[] _mainWithSubButtons;
        ToggleButton[] _modificationCategorySecondSubButton;
        ToggleButton[] _firstSubButtonsWithSubs;
        public MainWindow()
        {
            InitializeComponent();
            ToggleButton[] allButtons = new ToggleButton[] { btnCategories, btnCurrency, btnCustomers, btnHome, btnIncome, btnIncomeIncoming, btnIncomeOutgoing, btnMainCategory, btnModifications, btnOperations, btnOutcome, btnSubCategory, btnSubOperatorUser, btnSubOperations, btnAddOperation, btnDuplicateOperation };

            ToggleButton[] allMainButtons = new ToggleButton[] { btnHome, btnOperations, btnModifications, btnCustomers, btnIncome, btnOutcome };
            ToggleButton[] mainWithSubButtons = new ToggleButton[] { btnModifications, btnIncome, btnOutcome };


            #region firstSubButtons
            ToggleButton[] firstSubButtons = new ToggleButton[] { btnSubOperatorUser, btnCategories, btnCurrency, btnIncomeIncoming, btnIncomeOutgoing, btnSubOperations };
            ToggleButton[] firstSubButtonsWithSubs = new ToggleButton[] { btnCategories, btnSubOperations };

            ToggleButton[] modificationSubButtons = new ToggleButton[] { btnSubOperatorUser, btnCategories, btnCurrency, btnSubOperations };

            ToggleButton[] incomeSubButtons = new ToggleButton[] { btnIncomeIncoming, btnIncomeOutgoing };
            #endregion


            #region secondSubButtons
            ToggleButton[] secondSubButtons = new ToggleButton[] { btnSubCategory, btnMainCategory, btnAddOperation, btnDuplicateOperation };

            ToggleButton[] modificationSecondSubButtons = new ToggleButton[] { btnSubCategory, btnMainCategory, btnAddOperation, btnDuplicateOperation };
            ToggleButton[] modificationCategorySecondSubButton = new ToggleButton[] { btnSubCategory, btnMainCategory };

            #endregion

            _firstSubButtons = firstSubButtons;
            _secondSubButtons = secondSubButtons;
            _allMainButtons = allMainButtons;
            _modificationSecondSubButtons = modificationSecondSubButtons;
            _modificationSubButtons = modificationSubButtons;
            _incomeSubButtons = incomeSubButtons;
            _allButtons = allButtons;
            _mainWithSubButtons = mainWithSubButtons;
            _modificationCategorySecondSubButton = modificationCategorySecondSubButton;
            _firstSubButtonsWithSubs = firstSubButtonsWithSubs;
        }
        public MainWindow(int operatorUserId)
        {
            InitializeComponent();
            ToggleButton[] allButtons = new ToggleButton[] { btnCategories, btnCurrency, btnCustomers, btnHome, btnIncome, btnIncomeIncoming, btnIncomeOutgoing, btnMainCategory, btnModifications, btnOperations, btnOutcome, btnSubCategory, btnSubOperatorUser, btnSubOperations, btnAddOperation, btnDuplicateOperation };

            ToggleButton[] allMainButtons = new ToggleButton[] { btnHome, btnOperations, btnModifications, btnCustomers, btnIncome, btnOutcome };
            ToggleButton[] mainWithSubButtons = new ToggleButton[] { btnModifications, btnIncome, btnOutcome };


            #region firstSubButtons
            ToggleButton[] firstSubButtons = new ToggleButton[] { btnSubOperatorUser, btnCategories, btnCurrency, btnIncomeIncoming, btnIncomeOutgoing, btnSubOperations };
            ToggleButton[] firstSubButtonsWithSubs = new ToggleButton[] { btnCategories, btnSubOperations };

            ToggleButton[] modificationSubButtons = new ToggleButton[] { btnSubOperatorUser, btnCategories, btnCurrency, btnSubOperations };

            ToggleButton[] incomeSubButtons = new ToggleButton[] { btnIncomeIncoming, btnIncomeOutgoing };
            #endregion


            #region secondSubButtons
            ToggleButton[] secondSubButtons = new ToggleButton[] { btnSubCategory, btnMainCategory, btnAddOperation, btnDuplicateOperation };

            ToggleButton[] modificationSecondSubButtons = new ToggleButton[] { btnSubCategory, btnMainCategory, btnAddOperation, btnDuplicateOperation };
            ToggleButton[] modificationCategorySecondSubButton = new ToggleButton[] { btnSubCategory, btnMainCategory };

            #endregion

            _firstSubButtons = firstSubButtons;
            _secondSubButtons = secondSubButtons;
            _allMainButtons = allMainButtons;
            _modificationSecondSubButtons = modificationSecondSubButtons;
            _modificationSubButtons = modificationSubButtons;
            _incomeSubButtons = incomeSubButtons;
            _allButtons = allButtons;
            _mainWithSubButtons = mainWithSubButtons;
            _modificationCategorySecondSubButton = modificationCategorySecondSubButton;
            _firstSubButtonsWithSubs = firstSubButtonsWithSubs;

            _operatorUserService = Instancefactory.GetInstance<IOperatorUserService>();
            string username = _operatorUserService.GetByUserId(operatorUserId).FirstName;
            tblockUsername.Text = username;

            int userLevel = User.CurrentUser().UserLevelId;

        }


        //public MainWindow(int number)
        //{
        //    InitializeComponent();
        //    this.IsHitTestVisible = false;
        //}

        #region Screen
        private void btnTopLeft_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (this.WindowState == WindowState.Maximized)
            {
                var mouseX = e.GetPosition(this).X;
                Top = 0;
                this.WindowState = WindowState.Normal;
                var width = RestoreBounds.Width;
                var x = mouseX - width / 2;
                var screenSize = SystemParameters.WorkArea.Width;
                if (x < 0)
                {
                    x = 0;
                }
                else if (x + width > 0)
                {
                    x = screenSize - width;
                }

                this.WindowState = WindowState.Normal;
                Left = x;
                DragMove();
                return;

            }
            DragMove();

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RestoreDown()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                btnRestoreDown.Content = "1";
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                btnRestoreDown.Content = "2";
                if (WindowState == WindowState.Normal)
                {
                    WindowStyle = WindowStyle.SingleBorderWindow;
                    WindowState = WindowState.Maximized;
                    WindowStyle = WindowStyle.None;
                }
            }
        }
        private void btnRestoreDown_Click(object sender, RoutedEventArgs e)
        {
            RestoreDown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void btnTop_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            RestoreDown();
        }

        private void btnTopLeft_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RestoreDown();
        }


        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            ((HwndSource)PresentationSource.FromVisual(this)).AddHook(HookProc);
        }

        public static IntPtr HookProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_GETMINMAXINFO)
            {
                // We need to tell the system what our size should be when maximized. Otherwise it will
                // cover the whole screen, including the task bar.
                MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

                // Adjust the maximized size and position to fit the work area of the correct monitor
                IntPtr monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);

                if (monitor != IntPtr.Zero)
                {
                    MONITORINFO monitorInfo = new MONITORINFO();
                    monitorInfo.cbSize = Marshal.SizeOf(typeof(MONITORINFO));
                    GetMonitorInfo(monitor, ref monitorInfo);
                    RECT rcWorkArea = monitorInfo.rcWork;
                    RECT rcMonitorArea = monitorInfo.rcMonitor;
                    mmi.ptMaxPosition.X = Math.Abs(rcWorkArea.Left - rcMonitorArea.Left);
                    mmi.ptMaxPosition.Y = Math.Abs(rcWorkArea.Top - rcMonitorArea.Top);
                    mmi.ptMaxSize.X = Math.Abs(rcWorkArea.Right - rcWorkArea.Left);
                    mmi.ptMaxSize.Y = Math.Abs(rcWorkArea.Bottom - rcWorkArea.Top);
                }

                Marshal.StructureToPtr(mmi, lParam, true);
            }

            return IntPtr.Zero;
        }

        private const int WM_GETMINMAXINFO = 0x0024;

        private const uint MONITOR_DEFAULTTONEAREST = 0x00000002;

        [DllImport("user32.dll")]
        private static extern IntPtr MonitorFromWindow(IntPtr handle, uint flags);

        [DllImport("user32.dll")]
        private static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);

        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                this.Left = left;
                this.Top = top;
                this.Right = right;
                this.Bottom = bottom;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MONITORINFO
        {
            public int cbSize;
            public RECT rcMonitor;
            public RECT rcWork;
            public uint dwFlags;
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        }
        #endregion

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            btnCustomers.IsChecked = false;
            btnOperations.IsChecked = false;
            btnHome.IsChecked = false;


            LooseFocusOfSubButton(btnModifications);
            btnCurrency.IsChecked = false;
            btnSubOperatorUser.IsChecked = false;


            btnSubCategory.IsChecked = false;
            btnMainCategory.IsChecked = false;

            btnAddOperation.IsChecked = false;
            btnDuplicateOperation.IsChecked = false;


            LooseFocusOfSubButton(btnIncome);
            btnIncomeIncoming.IsChecked = false;
            btnIncomeOutgoing.IsChecked = false;


        }


        private void btnModifications_Click(object sender, RoutedEventArgs e)
        {
            if (btnSubOperatorUser.Visibility == Visibility.Collapsed)
            {
                btnSubOperatorUser.Visibility = Visibility.Visible;
                btnCurrency.Visibility = Visibility.Visible;
                btnCategories.Visibility = Visibility.Visible;
                btnSubOperations.Visibility = Visibility.Visible;
            }
            else if (btnSubOperatorUser.Visibility == Visibility.Visible)
            {
                btnSubOperatorUser.Visibility = Visibility.Collapsed;
                btnCurrency.Visibility = Visibility.Collapsed;
                btnCategories.Visibility = Visibility.Collapsed;
                btnSubCategory.Visibility = Visibility.Collapsed;
                btnMainCategory.Visibility = Visibility.Collapsed;
                btnSubOperations.Visibility = Visibility.Collapsed;
                btnAddOperation.Visibility = Visibility.Collapsed;
                btnDuplicateOperation.Visibility = Visibility.Collapsed;


                LooseFocusOfSubButton(btnCategories);
                LooseFocusOfSubButton(btnSubOperations);
                btnCategories.IsChecked = false;
                btnSubOperations.IsChecked = false;
            }

        }



        private void btnMenuButtonTheme_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                throw new Exception();
                LooseFocusOfSubButton(btnModifications);
                LooseFocusOfSubButton(btnIncome);
                btnSettings.IsChecked = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }


        private void btnModificationsSubMenu_Click(object sender, RoutedEventArgs e)
        {
            if (sender.GetType() == typeof(RadioButton))
            {
                RadioButton radioButton = (RadioButton)sender;
            }
            if (sender.GetType() == typeof(ToggleButton))
            {
                ToggleButton toggleButton = (ToggleButton)sender;
                if (sender == btnCategories)
                    OpenCategories();
                if (sender == btnSubOperations)
                    OpenSubOperations();

                return;
            }
            LooseFocusOfSubButton(btnIncome);
            FocusToSubButton(btnModifications);
        }
        private void btnSubOperations_Click(object sender, RoutedEventArgs e)
        {

            if (sender.GetType() == typeof(RadioButton))
            {
                RadioButton radioButton = (RadioButton)sender;
            }
            if (sender.GetType() == typeof(ToggleButton))
            {
                ToggleButton toggleButton = (ToggleButton)sender;
                if (sender == btnSubOperations)
                    OpenSubOperations();

                return;
            }
            LooseFocusOfSubButton(btnIncome);
            FocusToSubButton(btnSubOperations);
        }

        private void LooseFocusOfSubButton(ToggleButton button)
        {
            button.BorderThickness = new Thickness(0);
        }

        private void FocusToSubButton(ToggleButton button)
        {
            button.BorderThickness = new Thickness(1);
            btnSettings.IsChecked = false;
        }


        private void OpenCategories()
        {

            if (btnCategories.IsChecked == true)
            {
                btnSubCategory.Visibility = Visibility.Visible;
                btnMainCategory.Visibility = Visibility.Visible;
            }
            else if (btnCategories.IsChecked == false)
            {
                btnSubCategory.Visibility = Visibility.Collapsed;
                btnMainCategory.Visibility = Visibility.Collapsed;
                LooseFocusOfSubButton(btnCategories);
            }


        }
        private void OpenSubOperations()
        {

            if (btnSubOperations.IsChecked == true)
            {
                btnAddOperation.Visibility = Visibility.Visible;
                btnDuplicateOperation.Visibility = Visibility.Visible;
            }
            else if (btnSubOperations.IsChecked == false)
            {
                btnAddOperation.Visibility = Visibility.Collapsed;
                btnDuplicateOperation.Visibility = Visibility.Collapsed;
                LooseFocusOfSubButton(btnSubOperations);
            }
        }


        private void btnIncome_Click(object sender, RoutedEventArgs e)
        {
            if (btnIncomeIncoming.Visibility == Visibility.Collapsed)
            {
                btnIncomeIncoming.Visibility = Visibility.Visible;
                btnIncomeOutgoing.Visibility = Visibility.Visible;
                btnIncome.IsChecked = true; //changes the icon
            }
            else if (btnIncomeIncoming.Visibility == Visibility.Visible)
            {
                btnIncomeIncoming.Visibility = Visibility.Collapsed;
                btnIncomeOutgoing.Visibility = Visibility.Collapsed;
                btnIncome.IsChecked = false;

            }
        }


        private void btnIncomeSubClick(object sender, RoutedEventArgs e)
        {
            LooseFocusOfSubButton(btnModifications);
            FocusToSubButton(btnIncome);
        }

        private void tboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = tboxSearch.Text.ToLower();


            for (int i = 0; i < _mainWithSubButtons.Length; i++)
            {
                _mainWithSubButtons[i].IsChecked = false;
            }
            for (int i = 0; i < _firstSubButtonsWithSubs.Length; i++)
            {
                _firstSubButtonsWithSubs[i].IsChecked = false;
            }


            for (int i = 0; i < _allMainButtons.Length; i++)
            {
                var button = _allMainButtons[i];
                if (Search(button, search))
                {
                    button.Visibility = Visibility.Visible;
                }
                else if (!Search(button, search))
                {
                    button.Visibility = Visibility.Collapsed;
                }
            }

            for (int i = 0; i < _firstSubButtons.Length; i++)
            {
                var button = _firstSubButtons[i];
                if (Search(button, search))
                {
                    button.Visibility = Visibility.Visible;
                    //if (IsInsideOfTheArray(button, _modificationSubButtons))
                    //{
                    //    btnModifications.Visibility = Visibility.Visible;
                    //    //btnModifications.IsChecked = true;
                    //}
                    //else if (IsInsideOfTheArray(button, _incomeSubButtons))
                    //{
                    //    btnIncome.Visibility = Visibility.Visible;
                    //    //btnIncome.IsChecked = true;
                    //}
                }
                else if (!Search(button, search))
                {
                    button.Visibility = Visibility.Collapsed;

                }
            }
            for (int i = 0; i < _secondSubButtons.Length; i++)
            {
                var button = _secondSubButtons[i];
                if (Search(button, search))
                {
                    button.Visibility = Visibility.Visible;

                    //if (IsInsideOfTheArray(button, _modificationCategorySecondSubButton))
                    //{
                    //    btnModifications.Visibility = Visibility.Visible;
                    //    //btnModifications.IsChecked = true;
                    //    //btnCategories.IsChecked = true;
                    //    btnCategories.Visibility = Visibility.Visible;
                    //}
                }
                else if (!Search(button, search))
                {
                    button.Visibility = Visibility.Collapsed;
                }
            }


            if (search == null || search == "")
            {
                for (int i = 0; i < _firstSubButtons.Length; i++)
                {
                    _firstSubButtons[i].Visibility = Visibility.Collapsed;
                }
                for (int i = 0; i < _secondSubButtons.Length; i++)
                {
                    _secondSubButtons[i].Visibility = Visibility.Collapsed;
                }
                for (int i = 0; i < _allMainButtons.Length; i++)
                {
                    _allMainButtons[i].Visibility = Visibility.Visible;
                }
                for (int i = 0; i < _mainWithSubButtons.Length; i++)
                {
                    _mainWithSubButtons[i].IsChecked = false;
                }
                for (int i = 0; i < _firstSubButtonsWithSubs.Length; i++)
                {
                    _firstSubButtonsWithSubs[i].IsChecked = false;

                }
            }


        }

        private bool IsInsideOfTheArray(object button, Array array)
        {
            if (Array.IndexOf(array, button) > -1)
                return true;
            return false;
        }
        private bool Search(ToggleButton button, string search)
        {
            if (button.Content.ToString().ToLower().Contains(search))
            {
                return true;
            }
            return false;
        }


    }
}

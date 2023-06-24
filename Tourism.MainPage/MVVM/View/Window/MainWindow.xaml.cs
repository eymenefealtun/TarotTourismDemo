﻿using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using Tourism.MainPage.MVVM.View;

namespace Tourism.MainPage
{
    public partial class MainWindow : Window
    {
        public string _textMain;

        public MainWindow()
        {
            InitializeComponent();

        }

        public MainWindow(int number)
        {
            InitializeComponent();

            this.IsHitTestVisible = false;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btnRestoreDown_Click(object sender, RoutedEventArgs e)
        {
            RestoreDown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            btnCustomers.IsChecked = false;
            btnOperations.IsChecked = false;
            btnHome.IsChecked = false;
            btnModifications.BorderThickness = new Thickness(0);
            btnCurrency.IsChecked = false;
            btnSubOperatorUser.IsChecked = false;
            btnCategories.IsChecked = false;

            btnSubCategory.IsChecked = false;
            btnMainCategory.IsChecked = false;
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


        #region Screen
        private void btnTop_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnTopLeft_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
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



        private void btnModifications_Click(object sender, RoutedEventArgs e)
        {
            btnSettings.IsChecked = false;
            if (btnSubOperatorUser.Visibility == Visibility.Collapsed)
            {
                btnSubOperatorUser.Visibility = Visibility.Visible;
                btnCurrency.Visibility = Visibility.Visible;
                btnCategories.Visibility = Visibility.Visible;


            }
            else if (btnSubOperatorUser.Visibility == Visibility.Visible)
            {
                btnSubOperatorUser.Visibility = Visibility.Collapsed;
                btnCurrency.Visibility = Visibility.Collapsed;
                btnCategories.Visibility = Visibility.Collapsed;
                btnSubCategory.Visibility = Visibility.Collapsed;
                btnMainCategory.Visibility = Visibility.Collapsed;
                btnCategories.BorderThickness = new Thickness(0);

            }

        }



        private void btnMenuButtonTheme_Click(object sender, RoutedEventArgs e)
        {
            btnModifications.BorderThickness = new Thickness(0);
            btnSettings.IsChecked = false;

        }


        private void btnSubMenu_Click(object sender, RoutedEventArgs e)
        {
            if (sender.GetType() == typeof(RadioButton))
            {
                RadioButton radioButton = (RadioButton)sender;

            }
            if (sender.GetType() == typeof(ToggleButton))
            {
                ToggleButton toggleButton = (ToggleButton)sender;
                OpenCategories(toggleButton);
                return;

            }

            btnModifications.IsChecked = true;
            btnModifications.BorderThickness = new Thickness(1);
            btnSettings.IsChecked = false;


        }

        private void OpenCategories(ToggleButton radioButton)
        {
            if (radioButton == btnCategories)
            {
                if (btnSubCategory.Visibility == Visibility.Collapsed)
                {
                    btnSubCategory.Visibility = Visibility.Visible;
                    btnMainCategory.Visibility = Visibility.Visible;
                    btnCategories.BorderThickness = new Thickness(1);
                }
                else if (btnSubCategory.Visibility == Visibility.Visible)
                {
                    btnSubCategory.Visibility = Visibility.Collapsed;
                    btnMainCategory.Visibility = Visibility.Collapsed;
                    btnCategories.BorderThickness = new Thickness(0);

                }

            }
        }




    }
}

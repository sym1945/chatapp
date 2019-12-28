using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace chatapp.ViewModel
{
    public class WindowViewModel : BaseViewModel
    {
        #region Private Memeber

        private Window mWindow;

        private int mOuterMarginSize = 10;
        private int mWindowRadius = 10;

        #endregion

        #region Public Properties

        public double WindowMinimunWidth { get; set; } = 400;

        public double WindowMinimunHeight { get; set; } = 400;

        public int ResizeBorder { get; set; } = 6;

        public Thickness ResizeBorderThickness { get => new Thickness(ResizeBorder + OutermarginSize); }

        public Thickness InnerContentPadding { get => new Thickness(ResizeBorder); }

        public int OutermarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }

        public Thickness OutermarginSizeThickness { get => new Thickness(OutermarginSize); }

        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }

        public CornerRadius WindowCornerRadius { get => new CornerRadius(WindowRadius); }

        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLength { get => new GridLength(TitleHeight + ResizeBorder); }

        #endregion

        #region Commands

        public ICommand MinimizeCommand { get; set; }

        public ICommand MaximizeCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public ICommand MenuCommand { get; set; }

        #endregion


        #region Constructor

        public WindowViewModel(Window window)
        {
            mWindow = window;

            mWindow.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OutermarginSize));
                OnPropertyChanged(nameof(OutermarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, mWindow.PointToScreen(Mouse.GetPosition(mWindow))));

            // Fix window resize issue
            var resizer = new WindowResizer(mWindow);
        }

        #endregion
    }
}

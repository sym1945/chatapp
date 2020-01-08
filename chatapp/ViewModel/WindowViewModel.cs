using chatapp.core;
using System.Windows;
using System.Windows.Input;

namespace chatapp
{
    public class WindowViewModel : BaseViewModel
    {
        #region Private Memeber

        private Window mWindow;

        private WindowResizer mWindowResizer;

        private Thickness mOuterMarginSize = new Thickness(5);

        private int mWindowRadius = 10;

        private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;

        #endregion

        #region Public Properties

        public double WindowMinimunWidth { get; set; } = 800;

        public double WindowMinimunHeight { get; set; } = 500;

        public bool Borderless => (mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked);

        public int ResizeBorder => (mWindow.WindowState == WindowState.Maximized) ? 0 : 4;

        public Thickness ResizeBorderThickness => new Thickness(OuterMarginSize.Left + ResizeBorder
                                                                , OuterMarginSize.Top + ResizeBorder
                                                                , OuterMarginSize.Right + ResizeBorder
                                                                , OuterMarginSize.Bottom + ResizeBorder);

        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        public Thickness OuterMarginSize
        {
            get
            {
                if (mWindow.WindowState == WindowState.Maximized)
                    return mWindowResizer.CurrentMonitorMargin;
                else
                {
                    return Borderless ? new Thickness(0) : mOuterMarginSize;
                }
            }
            set => mOuterMarginSize = value;
        }

        public int WindowRadius
        {
            get => Borderless ? 0 : mWindowRadius;
            set => mWindowRadius = value;
        }

        public int FlatBorderThickness => Borderless && mWindow.WindowState != WindowState.Maximized ? 1 : 0;

        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

        public bool DimmableOverlayVisible { get; set; }

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
                WindowResized();
            };

            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, mWindow.PointToScreen(Mouse.GetPosition(mWindow))));

            // Fix window resize issue
            mWindowResizer = new WindowResizer(mWindow);

            mWindowResizer.WindowDockChanged += (dock) =>
            {
                mDockPosition = dock;

                WindowResized();
            };

            // Fix dropping an undocked window at top which should be positioned at the
            // very top of screen
            mWindowResizer.WindowFinishedMove += () =>
            {
                // Check for moved to top of window and not at an edge
                if (mDockPosition == WindowDockPosition.Undocked && mWindow.Top == mWindowResizer.CurrentScreenSize.Top)
                    // If so, move it to the true top (the border size)
                    mWindow.Top = -OuterMarginSize.Top;
            };
        }

        #endregion

        #region Private Helpers

        private void WindowResized()
        {
            // Fire off events for all properties that are affected by a resize
            OnPropertyChanged(nameof(Borderless));
            OnPropertyChanged(nameof(FlatBorderThickness));
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }

        #endregion
    }
}

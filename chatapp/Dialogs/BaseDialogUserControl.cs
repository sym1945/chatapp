using chatapp.core;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace chatapp
{
    public class BaseDialogUserControl : UserControl
    {
        #region Private Members

        private readonly DialogWindow mDialogWindow;

        #endregion

        #region Public Commands

        public ICommand CloseCommand { get; private set; }

        #endregion

        #region Public Properties

        public int WindowMinimunWidth { get; set; } = 250;

        public int WindowMinimunHeight { get; set; } = 100;

        public int TitleHeight { get; set; } = 30;

        public string Title { get; set; }

        #endregion

        #region Constructor

        public BaseDialogUserControl()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                mDialogWindow = new DialogWindow();
                mDialogWindow.ViewModel = new DialogWindowViewModel(mDialogWindow);

                CloseCommand = new RelayCommand(() => mDialogWindow.Close());
            }
        }

        #endregion

        #region Public Dialog Show Methods

        public Task ShowDialog<T>(T viewModel)
            where T : BaseDialogViewModel
        {
            var tcs = new TaskCompletionSource<bool>();

            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    mDialogWindow.ViewModel.WindowMinimunWidth = WindowMinimunWidth;
                    mDialogWindow.ViewModel.WindowMinimunHeight = WindowMinimunHeight;
                    mDialogWindow.ViewModel.TitleHeight = TitleHeight;
                    mDialogWindow.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title) ? Title : viewModel.Title;

                    mDialogWindow.ViewModel.Content = this;

                    DataContext = viewModel;

                    mDialogWindow.Owner = Application.Current.MainWindow;
                    mDialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                    mDialogWindow.ShowDialog();
                }
                finally
                {
                    tcs.TrySetResult(true);
                }
            });

            return tcs.Task;
        }

        #endregion

    }
}

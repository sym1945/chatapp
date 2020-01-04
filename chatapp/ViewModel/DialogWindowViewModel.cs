using chatapp.core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace chatapp
{
    public class DialogWindowViewModel : WindowViewModel
    {
        #region Public Properties

        public string Title { get; set; }

        public Control Content { get; set; }

        #endregion

        #region Constructor

        public DialogWindowViewModel(Window window) : base(window)
        {
            WindowMinimunWidth = 250;
            WindowMinimunHeight = 100;

            TitleHeight = 30;
        }

        #endregion
    }
}

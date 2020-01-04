using System.Windows;

namespace chatapp
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        #region Private Members

        private DialogWindowViewModel mViewModel;

        #endregion

        #region Public Properties

        public DialogWindowViewModel ViewModel
        {
            get => mViewModel;
            set
            {
                mViewModel = value;

                DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor

        public DialogWindow()
        {
            InitializeComponent();
        } 

        #endregion
    }
}

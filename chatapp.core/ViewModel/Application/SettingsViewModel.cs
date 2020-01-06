using System;
using System.Windows.Input;

namespace chatapp.core
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Public Properties

        public TextEntryViewModel Name { get; set; }

        public TextEntryViewModel Username { get; set; }

        public TextEntryViewModel Password { get; set; }

        public TextEntryViewModel Email { get; set; }

        #endregion

        #region Public Commands

        public ICommand OpenCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        #endregion

        #region Constructor

        public SettingsViewModel()
        {
            OpenCommand = new RelayCommand(Open);
            CloseCommand = new RelayCommand(Close);
        }

        #endregion

        private void Open()
        {
            IoC.Application.SettingsMenuVisible = true;
        }

        private void Close()
        {
            IoC.Application.SettingsMenuVisible = false;
        }
    }
}

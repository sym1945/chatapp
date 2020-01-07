using System;
using System.Windows.Input;

namespace chatapp.core
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Public Properties

        public TextEntryViewModel Name { get; set; }

        public TextEntryViewModel Username { get; set; }

        public PasswordEntryViewModel Password { get; set; }

        public TextEntryViewModel Email { get; set; }

        public string LogoutButtonText { get; set; }

        #endregion

        #region Public Commands

        public ICommand OpenCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public ICommand ClearUserDataCommand { get; set; }

        #endregion

        #region Constructor

        public SettingsViewModel()
        {
            OpenCommand = new RelayCommand(Open);
            CloseCommand = new RelayCommand(Close);
            LogoutCommand = new RelayCommand(Logout);
            ClearUserDataCommand = new RelayCommand(ClearUserData);

            // TODO :  Remove this
            Name = new TextEntryViewModel { Label = "Name", OriginalText = "Youngmin Shin" };
            Username = new TextEntryViewModel { Label = "Username", OriginalText = "Nass" };
            Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "sym1945@gmail.com" };

            // TODO : Get from localization
            LogoutButtonText = "Logout";
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

        private void Logout()
        {
            // TODO : Confirm the user wants to logout

            // TODO : Clear any user data/cache

            // Clean all application level view models that contain
            // any information about the current user
            ClearUserData();

            IoC.Application.GoToPage(ApplicationPage.Login);
        }

        public void ClearUserData()
        {
            Name = null;
            Username = null;
            Password = null;
            Email = null;
        }
    }
}

using System.Collections.Generic;

namespace chatapp.core
{
    public class SettingsDesignModel : SettingsViewModel
    {
        #region Singleton

        public static SettingsDesignModel Instance => new SettingsDesignModel();

        #endregion

        #region Constructor

        public SettingsDesignModel()
        {
            Name = new TextEntryViewModel { Label = "Name", OriginalText = "Youngmin Shin" };
            Username = new TextEntryViewModel { Label = "Username", OriginalText = "Nass" };
            Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "fake-design" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "sym1945@gmail.com" };
        }

        #endregion

    }
}

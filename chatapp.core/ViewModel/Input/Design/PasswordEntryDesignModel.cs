using System.Security;
using System.Windows.Input;

namespace chatapp.core
{
    public class PasswordEntryDesignModel : PasswordEntryViewModel
    {
        #region Singleton

        public static PasswordEntryDesignModel Instance => new PasswordEntryDesignModel();

        #endregion

        #region Constructor

        public PasswordEntryDesignModel()
        {
            Label = "Name";
            FakePassword = "fake-design";
        }

        #endregion
    }
}
namespace chatapp.core
{
    public class MessageBoxDialogDesignModel : MessageBoxDialogViewModel
    {
        #region Singleton

        public static MessageBoxDialogDesignModel Instance => new MessageBoxDialogDesignModel();

        #endregion

        #region Constructor

        public MessageBoxDialogDesignModel()
        {
            OkText = "OK";
            Message = "Design time message are fun :)";
        }

        #endregion
    }
}

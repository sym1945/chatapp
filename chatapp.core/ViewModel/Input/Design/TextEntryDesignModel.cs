namespace chatapp.core
{
    public class TextEntryDesignModel : TextEntryViewModel
    {
        #region Singleton

        public static TextEntryDesignModel Instance => new TextEntryDesignModel();

        #endregion

        #region Constructor

        public TextEntryDesignModel()
        {
            Label = "Name";
            OriginalText = "Youngmin Shin";
            EditedText = "Youngmin Shin";
        }

        #endregion
    }
}

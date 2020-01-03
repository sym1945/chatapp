namespace chatapp.core
{
    public class MenuItemDesignModel : MenuItemViewModel
    {
        #region Singleton

        public static readonly MenuItemDesignModel Instance = new MenuItemDesignModel();

        #endregion


        #region Constructor

        public MenuItemDesignModel()
        {
            Text = "Hello, World!";
            Icon = IconType.File;
        } 

        #endregion

    }
}

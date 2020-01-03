using System.Collections.Generic;

namespace chatapp.core
{
    public class MenuDesignModel : MenuViewModel
    {
        #region Singleton

        public static readonly MenuDesignModel Instance = new MenuDesignModel();

        #endregion

        #region Constructor

        public MenuDesignModel()
        {
            Items = new List<MenuItemViewModel>
            {
                new MenuItemViewModel
                { 
                    Type = MenuItemType.Header
                    , Text = "Design time header..."
                },
                new MenuItemViewModel
                {
                    Text = "Menu item 1"
                    , Icon = IconType.File
                },
                new MenuItemViewModel
                {
                    Text = "Menu item 2"
                    , Icon = IconType.Picture
                },
            };
        } 

        #endregion

    }
}

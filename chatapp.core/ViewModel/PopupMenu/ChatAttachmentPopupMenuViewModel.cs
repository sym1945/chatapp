using System.Collections.Generic;

namespace chatapp.core
{
    public class ChatAttachmentPopupMenuViewModel : BasePopupViewModel
    {
        #region Constructor

        public ChatAttachmentPopupMenuViewModel()
        {
            Content = new MenuViewModel
            {
                Items = new List<MenuItemViewModel>
                { 
                    new MenuItemViewModel
                    {
                        Text = "Attach a file..."
                        , Type = MenuItemType.Header
                    },
                    new MenuItemViewModel
                    {
                        Text = "From Computer"
                        , Icon = IconType.File
                    },
                    new MenuItemViewModel
                    {
                        Text = "From Pictures"
                        , Icon = IconType.Picture
                    },
                }
            };
        }

        #endregion
    }
}

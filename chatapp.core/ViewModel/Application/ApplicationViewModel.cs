using System;

namespace chatapp.core
{
    public class ApplicationViewModel : BaseViewModel
    {
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Chat;

        public bool SideMenuVisible { get; set; } = true;

        public bool SettingsMenuVisible { get; set; }

        public void GoToPage(ApplicationPage page)
        {
            SettingsMenuVisible = false;

            CurrentPage = page;

            SideMenuVisible = (page == ApplicationPage.Chat);
        }
    }
}

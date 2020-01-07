using System;

namespace chatapp.core
{
    public class ApplicationViewModel : BaseViewModel
    {
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Chat;

        public BaseViewModel CurrnetPageViewModel { get; set; }

        public bool SideMenuVisible { get; set; } = true;

        public bool SettingsMenuVisible { get; set; }

        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            SettingsMenuVisible = false;

            CurrnetPageViewModel = viewModel;

            CurrentPage = page;

            OnPropertyChanged(nameof(CurrentPage));

            SideMenuVisible = (page == ApplicationPage.Chat);
        }
    }
}

using chatapp.core;
using System.Diagnostics;

namespace chatapp
{
    public static class ApplicationPageHelpers
    {
        public static BasePage ToBasePage(this ApplicationPage page, object viewModel = null)
        {
            switch (page)
            {
                case ApplicationPage.Login:
                    return new LoginPage(viewModel as LoginViewModel);

                case ApplicationPage.Chat:
                    return new ChatPage(viewModel as ChatMessageListViewModel);

                case ApplicationPage.Register:
                    return new RegisterPage(viewModel as RegisterViewModel);

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public static ApplicationPage ToApplicationPage(this BasePage page)
        {
            switch (page)
            {
                case LoginPage _:
                    return ApplicationPage.Login;

                case ChatPage _:
                    return ApplicationPage.Chat;

                case RegisterPage _:
                    return ApplicationPage.Register;

                default:
                    Debugger.Break();
                    return default;
            }
        }
    }
}

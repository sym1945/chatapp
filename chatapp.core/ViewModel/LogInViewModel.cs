using System.Threading.Tasks;
using System.Windows.Input;

namespace chatapp.core
{
    public class LoginViewModel : BaseViewModel
    {
        #region Public Properties

        public string Email { get; set; }

        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }

        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructor

        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
            RegisterCommand = new RelayCommand(async () => await RegisterAsync());
        }

        public async Task LoginAsync(object parameter)
        {
            await RunCommandAsync(() => LoginIsRunning, async () =>
            {
                await Task.Delay(1000);

                // Go to chat page
                IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Chat);

                //var email = Email;
                //var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });
        }

        public async Task RegisterAsync()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Register);

            await Task.Delay(1);
        }

        #endregion
    }
}

using chatapp.core;
using System.Threading.Tasks;
using System.Windows;

namespace chatapp
{
    public class UIManager : IUIManager
    {
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            return new DialogMessageBox().ShowDialog(viewModel);
        }
    }
}

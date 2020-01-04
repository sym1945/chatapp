using System.Threading.Tasks;

namespace chatapp.core
{
    public interface IUIManager
    {
        Task ShowMessage(MessageBoxDialogViewModel viewModel);
    }
}

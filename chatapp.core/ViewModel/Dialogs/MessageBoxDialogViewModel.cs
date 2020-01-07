namespace chatapp.core
{
    public class MessageBoxDialogViewModel : BaseDialogViewModel
    {
        public string Message { get; set; }

        public string OkText { get; set; } = "OK";
    }
}

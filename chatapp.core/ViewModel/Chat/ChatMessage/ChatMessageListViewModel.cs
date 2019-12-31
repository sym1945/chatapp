using System.Collections.Generic;

namespace chatapp.core
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        public List<ChatMessageListItemViewModel> Items { get; set; }
    }
}

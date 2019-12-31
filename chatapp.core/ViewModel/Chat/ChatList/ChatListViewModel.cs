using System.Collections.Generic;

namespace chatapp.core
{
    public class ChatListViewModel : BaseViewModel
    {
        public List<ChatListItemViewModel> Items { get; set; }
    }
}

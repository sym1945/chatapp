using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace chatapp.core
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region Public Properties

        public ObservableCollection<ChatMessageListItemViewModel> Items { get; set; }

        public bool AttachmentMenuVisible { get; set; }

        public bool AnyPopupVisible => AttachmentMenuVisible;

        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        public string PendingMessageText { get; set; }

        #endregion

        #region Public Command

        public ICommand AttachmentButtonCommand { get; set; }

        public ICommand PopupClickawayCommand { get; set; }

        public ICommand SendCommand { get; set; }

        #endregion

        #region Constructor

        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            PopupClickawayCommand = new RelayCommand(PopupClickaway);
            SendCommand = new RelayCommand(Send);

            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();
        }

        #endregion

        #region Command Methods

        public void AttachmentButton()
        {
            AttachmentMenuVisible ^= true;
        }

        private void PopupClickaway()
        {
            AttachmentMenuVisible = false;
        }

        public void Send()
        {
            if (Items == null)
                Items = new ObservableCollection<ChatMessageListItemViewModel>();

            Items.Add(new ChatMessageListItemViewModel
            {
                Initials = "YM",
                Message = PendingMessageText,
                MessageSentTime = DateTime.UtcNow,
                SentByMe = true,
                SenderName = "Youngmin",
                NewItem = true,
            });

            PendingMessageText = string.Empty;
        }

        #endregion
    }
}

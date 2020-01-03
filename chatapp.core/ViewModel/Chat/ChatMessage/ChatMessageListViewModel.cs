using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace chatapp.core
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region Public Properties

        public List<ChatMessageListItemViewModel> Items { get; set; }

        public bool AttachmentMenuVisible { get; set; }

        public bool AnyPopupVisible => AttachmentMenuVisible;

        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        #endregion

        #region Public Command

        public ICommand AttachmentButtonCommand { get; set; }

        public ICommand PopupClickawayCommand { get; set; }

        #endregion

        #region Constructor

        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            PopupClickawayCommand = new RelayCommand(PopupClickaway);
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

        #endregion
    }
}

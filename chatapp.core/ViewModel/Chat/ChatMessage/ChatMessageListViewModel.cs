using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace chatapp.core
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region Protected Members

        protected string mLastSeachText;

        protected string mSearchText;

        protected ObservableCollection<ChatMessageListItemViewModel> mItems;

        protected bool mSearchIsOpen;

        #endregion

        #region Public Properties

        public ObservableCollection<ChatMessageListItemViewModel> Items
        {
            get => mItems;
            set
            {
                if (mItems == value)
                    return;

                mItems = value;

                // Update filtered list to match
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(mItems);
            }
        }

        public ObservableCollection<ChatMessageListItemViewModel> FilteredItems { get; set; }

        public string DisplayTitle { get; set; }

        public bool AttachmentMenuVisible { get; set; }

        public bool AnyPopupVisible => AttachmentMenuVisible;

        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        public string PendingMessageText { get; set; }

        public string SearchText
        {
            get => mSearchText;
            set
            {
                if (mSearchText == value)
                    return;

                mSearchText = value;

                if (string.IsNullOrEmpty(SearchText))
                    Search();
            }
        }

        public bool SearchIsOpen
        {
            get => mSearchIsOpen;
            set
            {
                if (mSearchIsOpen == value)
                    return;

                mSearchIsOpen = value;

                if (!mSearchIsOpen)
                    SearchText = string.Empty;
            }
        }

        #endregion

        #region Public Command

        public ICommand AttachmentButtonCommand { get; set; }

        public ICommand PopupClickawayCommand { get; set; }

        public ICommand SendCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand OpenSearchCommand { get; set; }

        public ICommand CloseSearchCommand { get; set; }

        public ICommand ClearSearchCommand { get; set; }

        #endregion

        #region Constructor

        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            PopupClickawayCommand = new RelayCommand(PopupClickaway);
            SendCommand = new RelayCommand(Send);
            SearchCommand = new RelayCommand(Search);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            ClearSearchCommand = new RelayCommand(ClearSearch);

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
            if (string.IsNullOrEmpty(PendingMessageText))
                return;

            if (Items == null)
                Items = new ObservableCollection<ChatMessageListItemViewModel>();
            if (FilteredItems == null)
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>();

            var message = new ChatMessageListItemViewModel
            {
                Initials = "YM",
                Message = PendingMessageText,
                MessageSentTime = DateTime.UtcNow,
                SentByMe = true,
                SenderName = "Youngmin",
                NewItem = true,
            };

            Items.Add(message);
            FilteredItems.Add(message);

            PendingMessageText = string.Empty;
        }

        public void Search()
        {
            if ((string.IsNullOrEmpty(mLastSeachText) && string.IsNullOrEmpty(SearchText)) ||
                string.Equals(mLastSeachText, SearchText))
                return;

            if (string.IsNullOrEmpty(SearchText) || Items == null || Items.Count <= 0)
            {
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(
                    Items ?? Enumerable.Empty<ChatMessageListItemViewModel>());

                mLastSeachText = SearchText;

                return;
            }

            // TODO: make more efficcient search
            FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(
                Items.Where(item => item.Message.ToLower().Contains(SearchText)));

            mLastSeachText = SearchText;
        }

        public void ClearSearch()
        {
            if (!string.IsNullOrEmpty(SearchText))
                SearchText = string.Empty;
            else
                SearchIsOpen = false;
        }

        public void OpenSearch() => SearchIsOpen = true;

        public void CloseSearch() => SearchIsOpen = false;

        #endregion
    }
}

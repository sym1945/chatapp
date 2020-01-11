using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace chatapp.core
{
    public class ChatListItemViewModel : BaseViewModel
    {
        #region Public Properties

        public string Name { get; set; }

        public string Message { get; set; }

        public string Initials { get; set; }

        public string ProfilePictureRGB { get; set; }

        public bool NewContentAvailable { get; set; }

        public bool IsSelected { get; set; }

        #endregion

        #region Public Commands

        public ICommand OpenMessageCommand { get; set; }

        #endregion

        #region Constructor

        public ChatListItemViewModel()
        {
            OpenMessageCommand = new RelayCommand(OpenMessage);
        }

        #endregion

        #region Command Methods

        private void OpenMessage()
        {
            if (Name == "Jesse")
            {
                IoC.Application.GoToPage(ApplicationPage.Login, new LoginViewModel
                {
                    Email = "jesse@helloworld.com"
                });
                return;
            }

            IoC.Application.GoToPage(ApplicationPage.Chat, new ChatMessageListViewModel
            {
                DisplayTitle = Name,

                Items = new ObservableCollection<ChatMessageListItemViewModel>
                {
                    new ChatMessageListItemViewModel
                    {
                        Message = Message
                        , Initials = Initials
                        , MessageSentTime = DateTime.UtcNow
                        , ProfilePictureRGB = ProfilePictureRGB
                        , SenderName = Name
                        , SentByMe = false
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received Message"
                        , Initials = Initials
                        , MessageSentTime = DateTime.UtcNow
                        , ProfilePictureRGB = "FFFFFF"
                        , SenderName = "youngmin"
                        , SentByMe = true
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received Message"
                        , Initials = Initials
                        , MessageSentTime = DateTime.UtcNow
                        , ProfilePictureRGB = "FFFFFF"
                        , SenderName = "youngmin"
                        , SentByMe = true
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received Message"
                        , Initials = Initials
                        , MessageSentTime = DateTime.UtcNow
                        , ProfilePictureRGB = "FFFFFF"
                        , SenderName = "youngmin"
                        , SentByMe = true
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = Message
                        , Initials = Initials
                        , MessageSentTime = DateTime.UtcNow
                        , ProfilePictureRGB = ProfilePictureRGB
                        , SenderName = Name
                        , SentByMe = false
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received Message"
                        , Initials = Initials
                        , MessageSentTime = DateTime.UtcNow
                        , ProfilePictureRGB = "FFFFFF"
                        , SenderName = "youngmin"
                        , SentByMe = true
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received Message"
                        , Initials = Initials
                        , MessageSentTime = DateTime.UtcNow
                        , ProfilePictureRGB = "FFFFFF"
                        , SenderName = "youngmin"
                        , SentByMe = true
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received Message"
                        , Initials = Initials
                        , MessageSentTime = DateTime.UtcNow
                        , ProfilePictureRGB = "FFFFFF"
                        , SenderName = "youngmin"
                        , SentByMe = true
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received Message"
                        , ImageAttatchment = new ChatMessageListItemAttachmentViewModel
                        {
                            ThumbnailUrl = "https://anywhere"
                        }
                        , Initials = Initials
                        , MessageSentTime = DateTime.UtcNow
                        , ProfilePictureRGB = "FFFFFF"
                        , SenderName = "youngmin"
                        , SentByMe = true
                    },

                },
            });
        }

        #endregion
    }
}

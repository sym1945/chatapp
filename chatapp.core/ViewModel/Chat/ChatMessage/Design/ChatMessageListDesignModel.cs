using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace chatapp.core
{
    public class ChatMessageListDesignModel : ChatMessageListViewModel
    {
        #region Singleton

        public static ChatMessageListDesignModel Instance => new ChatMessageListDesignModel();

        #endregion

        #region Constructor

        public ChatMessageListDesignModel()
        {
            DisplayTitle = "Parnell";

            Items = new ObservableCollection<ChatMessageListItemViewModel>
            {
                new ChatMessageListItemViewModel
                {
                    Initials = "PL"
                    , SenderName = "Parnell"
                    , Message = "I'm about to wipe the old server. We need to update the old server to Windows 2016"
                    , ProfilePictureRGB = "00d405"
                    , MessageSentTime = DateTimeOffset.UtcNow
                    , SentByMe = false
                },
                new ChatMessageListItemViewModel
                {
                    Initials = "LM"
                    , SenderName = "Luke"
                    , Message = "Let me know when you manage to spin up the new 2016 server"
                    , ProfilePictureRGB = "3099c5"
                    , MessageSentTime = DateTimeOffset.UtcNow
                    , MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3))
                    , SentByMe = true
                },
                new ChatMessageListItemViewModel
                {
                    Initials = "PL"
                    , SenderName = "Parnell"
                    , Message = "The new server is up. Go to 192.168.1.1.\r\nUsername is admin, password id P8ssw0rd!"
                    , ProfilePictureRGB = "00d405"
                    , MessageSentTime = DateTimeOffset.UtcNow
                    , SentByMe = false
                },

            };
        }

        #endregion

    }
}

using System.Collections.Generic;

namespace chatapp
{
    public class ChatListDesignModel : ChatListViewModel
    {
        #region Singleton

        public static ChatListDesignModel Instance => new ChatListDesignModel();

        #endregion

        #region Constructor

        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Initials = "LM"
                    , Name = "Luke"
                    , Message = "This chat app is awesome! I bet it will be fast too"
                    , ProfilePictureRGB = "3099c5"
                    , NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Initials = "JA"
                    , Name = "Jesse"
                    , Message = "Hey dude,"
                    , ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Initials = "PL"
                    , Name = "Parnell"
                    , Message = "The new server"
                    , ProfilePictureRGB = "00d405"
                    , IsSelected = true
                },
                new ChatListItemViewModel
                {
                    Initials = "LM"
                    , Name = "Luke"
                    , Message = "This chat app is awesome! I bet it will be fast too"
                    , ProfilePictureRGB = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Initials = "JA"
                    , Name = "Jesse"
                    , Message = "Hey dude,"
                    , ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Initials = "PL"
                    , Name = "Parnell"
                    , Message = "The new server"
                    , ProfilePictureRGB = "00d405"
                },
                new ChatListItemViewModel
                {
                    Initials = "LM"
                    , Name = "Luke"
                    , Message = "This chat app is awesome! I bet it will be fast too"
                    , ProfilePictureRGB = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Initials = "JA"
                    , Name = "Jesse"
                    , Message = "Hey dude,"
                    , ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Initials = "PL"
                    , Name = "Parnell"
                    , Message = "The new server"
                    , ProfilePictureRGB = "00d405"
                },
                new ChatListItemViewModel
                {
                    Initials = "LM"
                    , Name = "Luke"
                    , Message = "This chat app is awesome! I bet it will be fast too"
                    , ProfilePictureRGB = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Initials = "JA"
                    , Name = "Jesse"
                    , Message = "Hey dude,"
                    , ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Initials = "PL"
                    , Name = "Parnell"
                    , Message = "The new server"
                    , ProfilePictureRGB = "00d405"
                },
            };
        }

        #endregion

    }
}

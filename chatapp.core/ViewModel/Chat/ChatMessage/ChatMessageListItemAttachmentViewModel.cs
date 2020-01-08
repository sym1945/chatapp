using System;

namespace chatapp.core
{
    public class ChatMessageListItemAttachmentViewModel : BaseViewModel
    {
        #region Private Members

        private string mThumbnailUrl;

        #endregion

        public string Title { get; set; }

        public string FileName { get; set; }

        public long FileSize { get; set; }

        public string ThumbnailUrl
        {
            get => mThumbnailUrl;
            set
            {
                if (mThumbnailUrl == value)
                    return;

                mThumbnailUrl = value;

                // TODO: Download image from website
                //       Save file to local storage/cache
                //       Set LocalFilePath value
                //
                //       For now, just set the file path directly
                LocalFilePath = "/Images/Samples/inori.jfif";
            }
        }

        public string LocalFilePath { get; set; }

    }
}

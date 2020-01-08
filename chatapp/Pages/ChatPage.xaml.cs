using chatapp.core;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace chatapp
{
    /// <summary>
    /// LoginPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ChatPage : BasePage<ChatMessageListViewModel>
    {
        #region Constructor

        public ChatPage()
        {
            InitializeComponent();
        }

        public ChatPage(ChatMessageListViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion

        #region Override Methods

        protected override void OnViewModelChanged()
        {
            if (ChatMessageList == null)
                return;

            var storyboard = new Storyboard();
            storyboard.AddFadeIn(1);
            storyboard.Begin(ChatMessageList);

            MessageText.Focus();
        }

        #endregion

        private void MessageText_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var textbox = sender as TextBox;

            if (e.Key == Key.Enter)
            {
                if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
                {
                    var index = textbox.CaretIndex;

                    textbox.Text = textbox.Text.Insert(index, Environment.NewLine);

                    textbox.CaretIndex = index + Environment.NewLine.Length;
                }
                else
                    ViewModel.Send();

                e.Handled = true;
            }
        }

    }
}

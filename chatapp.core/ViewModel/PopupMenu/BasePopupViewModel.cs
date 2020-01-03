namespace chatapp.core
{
    public class BasePopupViewModel : BaseViewModel
    {
        #region Public Properties

        public string BubbleBackgroud { get; set; }

        public ElementHorizontalAlignment ArrowAlignment { get; set; }

        public BaseViewModel Content { get; set; }

        #endregion

        #region Constructor

        public BasePopupViewModel()
        {
            BubbleBackgroud = "ffffff";
            ArrowAlignment = ElementHorizontalAlignment.Left;
        }

        #endregion
    }
}

namespace chatapp.core
{
    public class BasePopupMenuViewModel : BaseViewModel
    {
        #region Public Properties

        public string BubbleBackgroud { get; set; }

        public ElementHorizontalAlignment ArrowAlignment { get; set; }

        #endregion

        #region Constructor

        public BasePopupMenuViewModel()
        {
            BubbleBackgroud = "ffffff";
            ArrowAlignment = ElementHorizontalAlignment.Left;
        }

        #endregion
    }
}

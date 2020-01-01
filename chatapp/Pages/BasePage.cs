using chatapp.core;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace chatapp
{
    public class BasePage : Page
    {
        #region Public Properties
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        public float SlideSeconds { get; set; } = 0.4f;

        public bool ShouldAnimateOut { get; set; }
        #endregion

        #region Constructor

        public BasePage()
        {
            // Don't bother animation in design time
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            Loaded += BasePage_LoadedAsync;
        }

        #endregion

        #region Animation Load / Unload

        private async void BasePage_LoadedAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ShouldAnimateOut)
                await AnimateOutAsync();
            else
                await AnimateInAsync();
        }

        public async Task AnimateInAsync()
        {
            if (PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    await this.SlideAndFadeInFromRightAsync(SlideSeconds);

                    break;
            }
        }

        public async Task AnimateOutAsync()
        {
            if (PageUnloadAnimation == PageAnimation.None)
                return;

            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    await this.SlideAndFadeOutToLeftAsync(SlideSeconds);

                    break;
            }
        }

        #endregion
    }

    public class BasePage<VM> : BasePage
        where VM : BaseViewModel, new()
    {
        #region Private Member

        private VM mViewModel;

        #endregion

        #region Public Properties

        public VM ViewModel
        {
            get => mViewModel;
            set
            {
                if (mViewModel == value)
                    return;

                mViewModel = value;

                DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor

        public BasePage() : base()
        {
            ViewModel = new VM();
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace chatapp
{
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool>
        where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
        #region Protected Properties

        /// <summary>
        /// True if this is the very first time the value has been updated
        /// Used to make sure we run the logic at least once during first load
        /// </summary>
        protected Dictionary<WeakReference, bool> mAlreadyLoaded = new Dictionary<WeakReference, bool>();

        /// <summary>
        /// The most recent value used if we get a value changed before we do the first load
        /// </summary>
        protected Dictionary<WeakReference, bool> mFirstLoadValue = new Dictionary<WeakReference, bool>();

        #endregion

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            if (!(sender is FrameworkElement element))
                return;

            // Try and get the already loaded reference
            var alreadyLoadedReference = mAlreadyLoaded.FirstOrDefault(f => f.Key.Target == sender);

            // Try and get the first load reference
            var firstLoadReference = mFirstLoadValue.FirstOrDefault(f => f.Key.Target == sender);

            // Don't fire if the value doesn't change
            if ((bool)sender.GetValue(ValueProperty) == (bool)value && alreadyLoadedReference.Key != null)
                return;

            // On first load...
            if (alreadyLoadedReference.Key == null)
            {
                // Create weak reference
                var weakReference = new WeakReference(sender);

                // Flag that we are in first load but have not finished it
                mAlreadyLoaded[weakReference] = false;

                // Start off hidden before we decide how to animate
                element.Visibility = Visibility.Hidden;

                // Create a single self-unhookalbe event
                // for the elements Loaded event
                async void onLoaded(object ss, RoutedEventArgs ee)
                {
                    // Unhook ourselves
                    element.Loaded -= onLoaded;

                    // Slight delay after load is needed for some elements to get laid out
                    // and their width/height correctly calculated
                    await Task.Delay(5);

                    // Do desired animation
                    DoAnimation(element, firstLoadReference.Key != null ? firstLoadReference.Value : (bool)value, true);

                    // Flag that we have finished first load
                    mAlreadyLoaded[weakReference] = true;
                }

                // Hook into the Loaded event of the element
                element.Loaded += onLoaded;
            }
            else if (alreadyLoadedReference.Value == false)
            {
                // If we have started a first load but not fired the animation yet, update the property
                mFirstLoadValue[new WeakReference(sender)] = (bool)value;
            }
            else
            {
                // Do desired animation
                DoAnimation(element, (bool)value, false);
            }
        }

        /// <summary>
        /// The animation method that is fired when the value changes
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        protected virtual void DoAnimation(FrameworkElement element, bool value, bool firstLoad) { }
    }

    public class FadeInImageOnLoadProperty : AnimateBaseProperty<FadeInImageOnLoadProperty>
    {
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            if (!(sender is Image image))
                return;

            if ((bool)value)
                image.TargetUpdated += Image_TargetUpdatedAsync;
            else
                image.TargetUpdated -= Image_TargetUpdatedAsync;
        }

        private async void Image_TargetUpdatedAsync(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            await (sender as Image).FadeInAsync(false);
        }
    }

    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Left, firstLoad, firstLoad ? 0 : 0.3f, false);
            else
                // Animate out
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Left, firstLoad ? 0 : 0.3f, false);

        }
    }

    public class AnimateSlideInFromRightProperty : AnimateBaseProperty<AnimateSlideInFromRightProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Right, firstLoad, firstLoad ? 0 : 0.3f, false);
            else
                // Animate out
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Right, firstLoad ? 0 : 0.3f, false);
        }
    }

    public class AnimateSlideInFromRightMarginProperty : AnimateBaseProperty<AnimateSlideInFromRightMarginProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Right, firstLoad, firstLoad ? 0 : 0.3f, true);
            else
                // Animate out
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Right, firstLoad ? 0 : 0.3f, true);
        }
    }

    public class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: false);
            else
                // Animate out
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Bottom, firstLoad ? 0 : 0.3f, keepMargin: false);

        }
    }

    public class AnimateSlideInFromBottomOnLoadProperty : AnimateBaseProperty<AnimateSlideInFromBottomOnLoadProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, !value, !value ? 0 : 0.3f, keepMargin: false);
        }
    }

    public class AnimateSlideInFromBottomMarginProperty : AnimateBaseProperty<AnimateSlideInFromBottomMarginProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: true);
            else
                // Animate out
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Bottom, firstLoad ? 0 : 0.3f, keepMargin: true);

        }
    }

    public class AnimateFadeInProperty : AnimateBaseProperty<AnimateFadeInProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Animate in
                await element.FadeInAsync(firstLoad, firstLoad ? 0 : 0.3f);
            else
                // Animate out
                await element.FadeOutAsync(firstLoad ? 0 : 0.3f);

        }
    }
}

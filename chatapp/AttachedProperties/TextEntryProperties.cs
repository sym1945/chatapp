using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace chatapp
{
    public class TextEntryWidthMatcherProperty : BaseAttachedProperty<TextEntryWidthMatcherProperty, bool> 
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var panel = (sender as Panel);

            SetWidths(panel);

            RoutedEventHandler onLoaded = null;
            onLoaded += (s, ee) => 
            {
                panel.Loaded -= onLoaded;

                SetWidths(panel);

                foreach (var child in panel.Children)
                {
                    if (!(child is TextEntryControl control))
                        continue;

                    control.Label.SizeChanged += (ss, eee) =>
                    {
                        SetWidths(panel);
                    };
                }
            };

            panel.Loaded += onLoaded;
        }

        private void SetWidths(Panel panel)
        {
            var maxSize = 0d;

            foreach (var child in panel.Children)
            {
                if (!(child is TextEntryControl control))
                    continue;

                maxSize = Math.Max(maxSize, control.Label.RenderSize.Width + control.Label.Margin.Left + control.Label.Margin.Right);
            }

            var gridLength = (GridLength)new GridLengthConverter().ConvertFromString(maxSize.ToString());

            foreach (var child in panel.Children)
            {
                if (!(child is TextEntryControl control))
                    continue;

                control.LabelWidth = gridLength;
            }
        }
    }
}

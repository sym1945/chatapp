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
                    var label = GetLabelFromTextEntryControl(child);
                    if (label == null)
                        continue;

                    label.SizeChanged += (ss, eee) =>
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
                var label = GetLabelFromTextEntryControl(child);
                if (label == null)
                    continue;

                maxSize = Math.Max(maxSize, label.RenderSize.Width + label.Margin.Left + label.Margin.Right);
            }

            var gridLength = (GridLength)new GridLengthConverter().ConvertFromString(maxSize.ToString());

            foreach (var child in panel.Children)
            {
                switch (child)
                {
                    case TextEntryControl t: t.LabelWidth = gridLength; break;
                    case PasswordEntryControl p: p.LabelWidth = gridLength; break;
                    default: continue;
                }
            }
        }

        private TextBlock GetLabelFromTextEntryControl(object control)
        {
            TextBlock label = null;
            switch (control)
            {
                case TextEntryControl t: label = t.Label; break;
                case PasswordEntryControl p: label = p.Label; break;
                default: break;
            }

            return label;
        }


    }
}

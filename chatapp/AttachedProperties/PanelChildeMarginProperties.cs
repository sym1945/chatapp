using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace chatapp
{
    public class PanelChildeMarginProperty : BaseAttachedProperty<PanelChildeMarginProperty, string> 
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var panel = (sender as Panel);

            panel.Loaded += (s, ee) => 
            {
                foreach (var child in panel.Children)
                {
                    (child as FrameworkElement).Margin = (Thickness)(new ThicknessConverter().ConvertFromString(e.NewValue as string));
                }
            };

        }

    }
}

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace chatapp
{
    /// <summary>
    /// TextEntryControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TextEntryControl : UserControl
    {
        #region Dependency Properties

        public GridLength LabelWidth
        {
            get => (GridLength)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }

        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register(
                "LabelWidth"
                , typeof(GridLength)
                , typeof(TextEntryControl)
                , new PropertyMetadata(GridLength.Auto, LableWidthChangedCallback)
            );
        
        #endregion

        #region Constructor

        public TextEntryControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Dependency Callbacks

        private static void LableWidthChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                (d as TextEntryControl).LabelColumnDefinition.Width = (GridLength)e.NewValue;
            }
            catch
            {
                Debugger.Break();

                (d as TextEntryControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }

        #endregion
    }
}

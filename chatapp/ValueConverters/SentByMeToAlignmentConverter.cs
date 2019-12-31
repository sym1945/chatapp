using System;
using System.Globalization;
using System.Windows;

namespace chatapp
{
    public class SentByMeToAlignmentConverter : BaseValueConverter<SentByMeToAlignmentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var sentByMe = (bool)value;

            if (parameter == null)
                return sentByMe ? HorizontalAlignment.Right : HorizontalAlignment.Left;
            else
                return sentByMe ? HorizontalAlignment.Left : HorizontalAlignment.Right;
        }   

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

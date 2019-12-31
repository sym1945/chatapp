using System;
using System.Globalization;
using System.Windows;

namespace chatapp
{
    public class TimeToReadDisplayTimeConverter : BaseValueConverter<TimeToReadDisplayTimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (DateTimeOffset)value;

            // If is not read...
            if (time == DateTimeOffset.MinValue)
                return string.Empty;

            // If it is today...
            if (time.Date == DateTimeOffset.UtcNow.Date)
                return $"Read {time.ToLocalTime().ToString("HH:mm")}";

            // Otherwise, return a full date
            return $"Read {time.ToLocalTime().ToString("HH:mm, MMM yyyy")}";
        }   

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

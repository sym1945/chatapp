﻿using System;
using System.Globalization;
using System.Windows;

namespace chatapp
{
    public class TimeToDisplayTimeConverter : BaseValueConverter<TimeToDisplayTimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (DateTimeOffset)value;

            // If it is today...
            if (time.Date == DateTimeOffset.UtcNow.Date)
                return time.ToLocalTime().ToString("HH:mm");

            // Otherwise, return a full date
            return time.ToLocalTime().ToString("HH:mm, MMM yyyy");
        }   

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;


namespace DeskClock.Lib
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool? isVisible = value as bool?;
            if (parameter != null && isVisible.HasValue)
                isVisible = !isVisible;
            if (isVisible.HasValue && isVisible.Value == true)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }

    public class IntToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int? number = value as int?;
            if (number == null) return Visibility.Collapsed;

            int? minimum = parameter as int?;

            if (minimum == null)
            {
                if (number > 0) return Visibility.Visible;
                else return Visibility.Collapsed;
            }
            else
            {
                if (number > minimum) return Visibility.Visible;
                else return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace ProConverter
{
    public   class BoolToWindowStateConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null != value && value.GetType() == typeof (bool))
            {
                if ((bool) value)
                {
                    return WindowState.Maximized;
                }
            }
            return WindowState.Normal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null != value && value.GetType() == typeof(WindowState))
            {
                if ((WindowState)value == WindowState.Maximized)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

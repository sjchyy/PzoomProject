using System;
using System.Collections;
using System.Windows;
using System.Windows.Data;

namespace ProCommon.Converter
{
    public class CollectionToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null != value )
            {
                IList list = value as IList;
                if (null != list && list.Count > 0)
                    return Visibility.Visible;
                else
                {

                    return Visibility.Collapsed;
                }
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

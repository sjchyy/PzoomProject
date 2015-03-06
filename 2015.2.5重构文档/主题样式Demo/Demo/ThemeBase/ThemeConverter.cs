using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ThemeBase
{
    public class ThemeConverter : TypeConverter
    {
        public ThemeConverter()
        {

        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            else
            {
                return base.CanConvertFrom(context, sourceType);
            }
        }
      public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            var stringValue = value as string;

            Theme theme = CreateDynamicTheme(stringValue);
            if (theme == null)
            {
                return base.ConvertFrom(value);
            }

            return theme;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            else
            {
                return base.CanConvertTo(context, destinationType);
            }
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            return value.ToString();
        }

        private static Theme CreateDynamicTheme(string themeTypeName)
        {
            Type themeType = Type.GetType(themeTypeName);
            if (themeType != null)
            {
                return (Theme)Activator.CreateInstance(themeType);
            }
            else
            {
                return null;
            }
        }
    }
}

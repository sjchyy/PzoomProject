using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace ThemesProject
{
    public class Style
    {

    }
    public  class Style_Win7:Style
    {


        public static ComponentResourceKey BigFontStyleKey
        {
            get
            {
                return new ComponentResourceKey(typeof(Style_Win7), "bigFontStyle");
            }
            set
            {

            }
        }
        public static ComponentResourceKey ALabelStyleKey
        {
            get
            {
                ComponentResourceKey key = new ComponentResourceKey(typeof(Style_Win7), "ALabelStyle");
             
                return key;
            }
        }
    }
    public class Style_Blue:Style
    {
        public static ComponentResourceKey BigFontStyleKey
        {
            get
            {
                return new ComponentResourceKey(typeof(Style_Win7), "bigFontStyle");
            }
        }
        public static ComponentResourceKey ALabelStyleKey
        {
            get
            {
                ComponentResourceKey key = new ComponentResourceKey(typeof(Style_Win7), "ALabelStyle");
                return key;
            }
        }
    }
   [TypeConverter(typeof(ThemeConverter))]
    public  class Theme
    {

    }
    public class Theme_Win7:Theme
    {

    }
    public class Theme_Blue:Theme
    {

    }
     [System.Windows.Markup.MarkupExtensionReturnType(typeof(ThemeResourceKey))]
    public class ThemeResourceKey:ResourceKey
    {

        private Type themeType;
   
        public ThemeResourceKey()
        {
        }
        public ThemeResourceKey(Type themeType, Type elementType)
        {
            this.ThemeType = themeType;
            this.ElementType = elementType;
        }
        public ThemeResourceKey(Type themeType, Type elementType, object resourceId)
        {
            this.ThemeType = themeType;
            this.ElementType = elementType;
            this.ResourceId = resourceId;
        }
        public Type ThemeType
        {
            get
            {
                if (themeType == null)
                    this.themeType = PrepareThemeType(null);
                return this.themeType;
            }
            set
            {
                this.themeType = value;
            }
        }
        public Type ElementType
        {
            get;
            set;
        }
        public object ResourceId
        {
            get;
            set;
        }
        public override System.Reflection.Assembly Assembly
        {
            get 
            {
              return this.ElementType.Assembly;
            }
        }
        public override int GetHashCode()
        {
            int resourceHashCode = this.ResourceId != null ? this.ResourceId.GetHashCode() : 0;

            if (this.ThemeType != null && this.ElementType != null)
            {
                return this.ThemeType.GetHashCode() ^ this.ElementType.GetHashCode() ^ resourceHashCode;
            }
            return resourceHashCode;
        }
        public override bool Equals(object obj)
        {
            ThemeResourceKey key = obj as ThemeResourceKey;
            if (key == null)
            {
                return false;
            }
            else
            {
                return
                    (key.ThemeType == this.ThemeType) &&
                    (key.ElementType == this.ElementType) &&
                    object.Equals(key.ResourceId, this.ResourceId);
            }
        }
        private static Type PrepareThemeType(Theme theme)
        {
            Type themeType = null;
            if (theme == null)
            {
                themeType = ApplicationTheme.GetType();
            }
            else
            {
                themeType = theme.GetType();
            }
            return themeType;
        }
        private static Theme ApplicationTheme
        {
            get
            {
                if (StyleManager.ApplicationTheme != null)
                {
                    return StyleManager.ApplicationTheme;
                }
                else
                {
                    return null;
                }

                //string appSettingsTheme = ConfigurationManager.AppSettings["Telerik.Theme"];
                //if (!string.IsNullOrEmpty(appSettingsTheme))
                //{
                //    return (Theme)new ThemeConverter().ConvertFrom(null, CultureInfo.CurrentUICulture, appSettingsTheme);
                //}
                //else
                //{
                //    return DefaultSuiteTheme;
                //}
            }
        }


    }

    public class ThemeConverter:TypeConverter
    {
       
            public ThemeConverter()
            {

            }


		/// <summary>
		/// Returns whether this object supports a standard set of values that can be picked from a list, using the specified context.
		/// </summary>
		/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
		/// <returns>
		/// True if <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"/> should be called to find a common set of values the object supports; otherwise, false.
		/// </returns>
		public override bool GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext context)
		{
			return true;
		}

		/// <summary>
		/// Returns a collection of standard values for the data type this type converter is designed for when provided with a format context.
		/// </summary>
		/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context that can be used to extract additional information about the environment from which this converter is invoked. This parameter or properties of this parameter can be null.</param>
		/// <returns>
		/// A <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection"/> that holds a standard set of valid values, or null if the data type does not support a standard set of values.
		/// </returns>
		public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new StandardValuesCollection(ThemeManager.StandardThemeNames);
		}


            /// <summary>
            /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <param name="sourceType">A <see cref="T:System.Type"/> that represents the type you want to convert from.</param>
            /// <returns>
            /// True if this converter can perform the conversion; otherwise, false.
            /// </returns>
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

            /// <summary>
            /// Converts the given object to the type of this converter, using the specified context and culture information.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use as the current culture.</param>
            /// <param name="value">The <see cref="T:System.Object"/> to convert.</param>
            /// <returns>
            /// An <see cref="T:System.Object"/> that represents the converted value.
            /// </returns>
            /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
            public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
            {
                var stringValue = value as string;

                Theme theme = ThemeManager.FromName(stringValue);

			if (theme == null)
			{
				theme = CreateDynamicTheme(stringValue);
			}

                if (theme == null)
                {
                    return base.ConvertFrom(value);
                }

                return theme;
            }

            /// <summary>
            /// Returns whether this converter can convert the object to the specified type, using the specified context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <param name="destinationType">A <see cref="T:System.Type"/> that represents the type you want to convert to.</param>
            /// <returns>
            /// True if this converter can perform the conversion; otherwise, false.
            /// </returns>
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

            /// <summary>
            /// Converts the given value object to the specified type, using the specified context and culture information.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo"/>. If null is passed, the current culture is assumed.</param>
            /// <param name="value">The <see cref="T:System.Object"/> to convert.</param>
            /// <param name="destinationType">The <see cref="T:System.Type"/> to convert the <paramref name="value"/> parameter to.</param>
            /// <returns>
            /// An <see cref="T:System.Object"/> that represents the converted value.
            /// </returns>
            /// <exception cref="T:System.ArgumentNullException">The <paramref name="destinationType"/> parameter is null. </exception>
            /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
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

    /// <summary>
    /// Provides functionality for changing control themes.
    /// </summary>
    public static class StyleManager
    {
        private static Theme applicationTheme;

        /// <summary>
        /// Specifies a Theme that will be automatically applied on all controls in the application. 
        /// </summary>
        public static Theme ApplicationTheme
        {
            get
            {
                return StyleManager.applicationTheme;
            }
            set
            {
                if (StyleManager.applicationTheme != value)
                {
                    Theme oldValue = StyleManager.applicationTheme;

                    StyleManager.applicationTheme = value;

                }
            }
        }
    }

    /// <summary>
    /// This class supports the Telerik theming infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public static class ThemeManager
    {
        internal static readonly string DefaultThemeName = "Office_Black";

        /// <summary>
        /// Contains all standard themes.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes")]
        public static readonly Dictionary<string, Theme> StandardThemes = new Dictionary<string, Theme>();

        /// <summary>
        /// Contains the names of all common themes - used for the QSF Theme dropdown and intellisense.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes")]
        public static readonly ReadOnlyCollection<string> StandardThemeNames;

        private static readonly List<string> standardThemeNames = new List<string>();

        /// <summary>
        /// Initializes static members of the ThemeManager class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
        static ThemeManager()
        {
            RegisterTheme("Theme_Win7", new Theme_Win7(), true);
            RegisterTheme("Theme_Blue", new Theme_Blue(), true);
            StandardThemeNames = new ReadOnlyCollection<string>(standardThemeNames);
        }

        /// <summary>
        /// Returns a standard theme with the specified name. Fallbacks to the default theme 
        /// if a standard theme was not found.
        /// </summary>
        /// <param name="themeName">Name of the theme.</param>
        public static Theme FromName(string themeName)
        {
            if (themeName != null)
            {
                if (StandardThemes.ContainsKey(themeName))
                {
                    return StandardThemes[themeName];
                }
                else
                {
                    return StandardThemes[DefaultThemeName];
                }
            }
            return null;
        }

        private static void RegisterTheme(string name, Theme theme, bool isCommon)
        {
            StandardThemes.Add(name, theme);
            if (isCommon)
            {
                standardThemeNames.Add(name);
            }
        }
    }
    public enum ThemeType
    {
        Office_Red,
        Win7_Blue,
    }
}

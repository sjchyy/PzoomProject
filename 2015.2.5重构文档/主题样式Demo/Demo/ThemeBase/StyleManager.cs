using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ThemeBase
{
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
}

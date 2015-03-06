using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ThemeBase
{
    [System.Windows.Markup.MarkupExtensionReturnType(typeof(ThemeResourceKey))]
    public class ThemeResourceKey : ResourceKey
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
                if (ApplicationTheme != null)
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
                if (this.ThemeType != null)
                    return this.ThemeType.Assembly;
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
            }
        }


    }
}

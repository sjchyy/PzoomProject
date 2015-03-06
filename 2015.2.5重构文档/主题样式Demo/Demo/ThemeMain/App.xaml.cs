using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using ThemeBase;

namespace ThemeMain
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            string file = System.IO.Directory.GetCurrentDirectory() + @"\Theme_Red.dll";
            if (System.IO.File.Exists(file))
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile(file);
                if (null != assembly)
                {
                    object obj = assembly.CreateInstance("Theme_Red.Theme_Red");
                    if (null != obj)
                    {
                        StyleManager.ApplicationTheme = obj as Theme;
                    }
                }
                App.Current.Resources.Clear();
                ResourceDictionary dict = Application.LoadComponent(new Uri("/Theme_Red;component/Style/StyleMain.xaml", UriKind.RelativeOrAbsolute)) as ResourceDictionary;
                if (null != dict)
                {
                    App.Current.Resources.MergedDictionaries.Add(dict);
                }
            }
        }
    }
}

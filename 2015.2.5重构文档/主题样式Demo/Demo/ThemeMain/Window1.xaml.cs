using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ThemeBase;

namespace ThemeMain
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
             string file = System.IO.Directory.GetCurrentDirectory() + @"\Theme_Blue.dll";
             if (System.IO.File.Exists(file))
             {
                 System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile(file);
                 if (null != assembly)
                 {
                     object obj = assembly.CreateInstance("Theme_Blue.Theme_Blue");
                     if (null != obj)
                     {
                         StyleManager.ApplicationTheme = obj as Theme;
                     }
                 }
             }
            InitializeComponent();
        }
    }
}

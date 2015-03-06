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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ThemeBase;

namespace ThemeMain
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.aButton.Click+=aButton_Click;
        }

        bool b = false;
        private void aButton_Click(object sender, RoutedEventArgs e)
        {
            //Window1 window = new Window1();
            //window.ShowDialog();
            if (b)
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
                    ResourceDictionary dict = Application.LoadComponent(new Uri("/Theme_Red;component/Style/StyleMain.xaml", UriKind.RelativeOrAbsolute)) as ResourceDictionary;
                    if (null != dict)
                    {
                        App.Current.Resources.MergedDictionaries.Add(dict);
                    }
                }
            }
            else
            {
             string   file = System.IO.Directory.GetCurrentDirectory() + @"\Theme_Blue.dll";
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
                    ResourceDictionary dict = Application.LoadComponent(new Uri("/Theme_Blue;component/Style/StyleMain.xaml", UriKind.RelativeOrAbsolute)) as ResourceDictionary;
                    if (null != dict)
                    {
                        App.Current.Resources.MergedDictionaries.Add(dict);
                    }
                }

            }
            b = !b;
           
        }
    }
}

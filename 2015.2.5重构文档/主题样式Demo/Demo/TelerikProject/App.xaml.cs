using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;

namespace TelerikProject
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
       public App()
        {
            Telerik.Windows.Controls.StyleManager.ApplicationTheme = new  Windows7Theme();
        }
    }
}

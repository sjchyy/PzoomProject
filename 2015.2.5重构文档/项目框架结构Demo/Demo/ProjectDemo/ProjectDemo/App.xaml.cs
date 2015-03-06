using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace ProjectDemo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

            InitTheme();
            this.DispatcherUnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }
        public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected override void OnStartup(StartupEventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            base.OnStartup(e);
            log.Info("Start");
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            log.Info(e.ToString()+"==="+e.ExceptionObject.ToString());
        }
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            log.Info(e.ToString() + "===" + e.Exception.ToString());
        }
        private void InitTheme()
        {
            string file = System.IO.Directory.GetCurrentDirectory() + @"\ThemeLibrary.dll";
            if (System.IO.File.Exists(file))
            {
                //System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile(file);
                //if (null != assembly)
                //{
                //    object obj = assembly.CreateInstance("Theme_Red.Theme_Red");
                //    if (null != obj)
                //    {
                //        StyleManager.ApplicationTheme = obj as Theme;
                //    }
                //}
                App.Current.Resources.Clear();
                ResourceDictionary dict = Application.LoadComponent(new Uri("/ThemeLibrary;component/Style.xaml", UriKind.RelativeOrAbsolute)) as ResourceDictionary;
                if (null != dict)
                {
                    App.Current.Resources.MergedDictionaries.Add(dict);
                }
            }
        }
     
    }
}

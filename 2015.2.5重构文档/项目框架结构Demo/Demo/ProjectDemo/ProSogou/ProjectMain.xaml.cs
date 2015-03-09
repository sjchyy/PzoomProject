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

namespace ProSogou
{
    /// <summary>
    /// ProjectMain.xaml 的交互逻辑
    /// </summary>
    public partial class ProjectMain : UserControl
    {
        public ProjectMain()
        {
       
            InitializeComponent();
            this.Loaded += ProjectMain_Loaded;
            this.IsVisibleChanged += ProjectMain_IsVisibleChanged;
            this.Button_Login.Click += Button_Login_Click;
        }
        public event RoutedEventHandler LoginEvent;

        void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            if (null != LoginEvent)
                LoginEvent(this, e);
          
        }
        void ProjectMain_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("ProjectMain_IsVisibleChanged");
        }

        void ProjectMain_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("ProjectMain_Loaded");
        }
        public void InitSettingAsync(object obj)
        {

        }
        public void InitSettingAsyncCancel(object state)
        {
           
        }
        private bool _IsBusy;
        public bool IsBusy
        {
            get
            {
                return _IsBusy;
            }
            set
            {
                _IsBusy = value;
            }
        }
        public event System.ComponentModel.AsyncCompletedEventHandler InitCompleted;

        public event System.ComponentModel.ProgressChangedEventHandler InitProgressChanged;
    }
}

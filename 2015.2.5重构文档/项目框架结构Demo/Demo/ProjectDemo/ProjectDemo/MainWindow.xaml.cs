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
using ProjectDemo.Model.User;

namespace ProjectDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow 
    {
        ProSogou.ProjectMain sogouMain;
        ProBaidu.ProjectMain baiduMain;

      
        public MainWindow()
        {
            InitializeComponent();
            Wr.addWindowHeader(UserHeader);
            Wr.addWindowMinButton(WindowMin);
           // Wr.addWindowMaxButton(WindowMax);
            Wr.addWindowCloseButton(WindowCls);
            this.HeaderPanel.DataContext = GetUserView();
        //    WindowFullScreenManager.RepairWpfWindowFullScreenBehavior(this);
         //   this.Button_Baidu.Click += Button_Baidu_Click;
          //  this.Button_Sogou.Click += Button_Sogou_Click;
            sogouMain = new ProSogou.ProjectMain();
            baiduMain = new ProBaidu.ProjectMain();
          
        }

        void Button_Sogou_Click(object sender, RoutedEventArgs e)
        {
            Grid_Container.Children.Clear();
            Grid_Container.Children.Add(sogouMain);
        }

        void Button_Baidu_Click(object sender, RoutedEventArgs e)
        {
            Grid_Container.Children.Clear();
            Grid_Container.Children.Add(baiduMain);
        }

         void _ApplicationCloseCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            Console.WriteLine("adfafasfaddsf");
        }
          void _ApplicationCloseCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
         {
             e.CanExecute = true;
         }

        private UserView GetUserView()
        {
            UserView userView = new UserView();
            userView.UserName = "sjchyy@163.com";
            userView.Modules = new List<Module>();
            userView.Modules.Add(new Module(){ Text = "百度管理",Enable = true,Children = new List<Module>(){new Module(){Text = "物料管理"}}});
            userView.Modules.Add(new Module() { Text = "搜狗管理", Enable = true, Children = new List<Module>() { new Module() { Text = "物料管理" }, new Module() { Text = "搜狗调价" } } });
            userView.Modules.Add(new Module() { Text = "360管理", Enable = true, Children = new List<Module>() { new Module() { Text = "物料管理" }, new Module() { Text = "360调价" } } });
            userView.Modules.Add(new Module() { Text = "创意拓展", Enable = true });
            userView.HeaderChanged += userView_HeaderChanged;
            userView.ModuleChanged += userView_ModuleChanged;
            userView.CurrentModule = userView.Modules[0];
            return userView;
        }

        void userView_ModuleChanged(object sender,  ModulechangedEvengArgs  e)
        {
            Console.WriteLine(e.Current.Text);
         
        }

        void userView_HeaderChanged(object sender, ModulechangedEvengArgs e)
        {
            Console.WriteLine(e.Current.Text);
        }

    }
}

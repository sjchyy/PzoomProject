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
using ProInterface;

using ProjectDemo.Common;
using ProjectDemo.Model.User;

using ProInterface.Model;
using ProCommon.ProEnum;
using ProCommon.ExtendAttribute;
using ProInterface.Delegate;
using ProCommon.Extensions;

namespace ProjectDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
            Wr.addWindowHeader(UserHeader);
            Wr.addWindowMinButton(WindowMin);
            Wr.addWindowCloseButton(WindowCls);
            PublicToken = new TokenManager();
            _controlDictionary = new Dictionary<EModule, UserControl>();
            _eventsDictionary = new Dictionary<EModule, ERouteEvent>();
            this._lsetting = new Setting() { UserList = new List<User>(), Permissions = new List<Permission>() };
            _lsetting.UserList.Add(new User() { UserName = "Init" });
            this.HeaderPanel.DataContext = GetUserView();
          
        }
        public TokenManager PublicToken { get; set; }
        private Setting _lsetting;

        public Setting LSetting
        {
            get { return _lsetting; }
            set { _lsetting = value; }
        }

        /// <summary>
        /// 用于存储已初始化的模块列表
        /// </summary>
        private Dictionary<EModule, UserControl> _controlDictionary;
        /// <summary>
        /// 用于存储暂未执行的事件
        /// </summary>
        private Dictionary<EModule, ERouteEvent> _eventsDictionary;
        /// <summary>
        /// 用于存放模块可接受的事件
        /// </summary>
        private Dictionary<EModule, ERouteEvent> _eventSource; 

         void _ApplicationCloseCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            Console.WriteLine("adfafasfaddsf");
        }
          void _ApplicationCloseCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
         {
             e.CanExecute = true;
         }

        private UserView userView;
        private UserView GetUserView()
        {
            userView  = new UserView();
            userView.UserName = "sjchyy@163.com";
            userView.Modules = new List<Module>();
            userView.Modules.Add(new Module() { Text = "概览", Enable = true, ModuleName = EModule.AccountView });
            userView.Modules.Add(new Module() { Text = "百度管理", Enable = true, Children = new List<Module>() { new Module() { Text = "物料管理", ModuleName =EModule.BaiduEdit } } });
            userView.Modules.Add(new Module() { Text = "搜狗管理", Enable = true, Children = new List<Module>() { new Module() { Text = "物料管理" }, new Module() { Text = "搜狗调价" } } });
            userView.Modules.Add(new Module() { Text = "360管理", Enable = true, Children = new List<Module>() { new Module() { Text = "物料管理" }, new Module() { Text = "360调价" } } });
            userView.Modules.Add(new Module() { Text = "创意拓展", Enable = true });
            userView.HeaderChanged += userView_HeaderChanged;
            userView.ModuleChanged += userView_ModuleChanged;
            userView.CurrentModule = userView.Modules[0];
            return userView;
        }

        private void SetCurrentMenu(EModule type)
        {
            switch (type)
            {
                    case EModule.AccountView:
                  
                    break;
                    case EModule.BaiduEdit:
                    userView.CurrentModule = userView.Modules[1];
                    userView.CurrentHeader = userView.Modules[1].Children[0];

                    break;
                    case EModule.BaiduBidding:

                    break;
                    case EModule.SogouBidding:

                    break;
                    case EModule.SogouEdit:

                    break;
            }
        }
        void userView_ModuleChanged(object sender,  ModulechangedEvengArgs  e)
        {
            if (null == e.Current.Children)
            {
                ModuleChanged(e.Current.ModuleName);
            }
        }
        /// <summary>
        /// settingChanged事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void MainWindow_SettingChanged(object sender, SettingChangedEventArgs args)
        {
            this.LSetting.UserList.AddRange(args.Config.UserList);
            AcceptEventAttribute atts = Attribute.GetCustomAttributes(sender.GetType(), true)[0] as AcceptEventAttribute;
            string dll = sender.GetType().Assembly.ManifestModule.Name;
            if (null != atts)
            {
                foreach (EModule key in _eventSource.Keys)
                {
                    if (key.GetModuleDllName() != dll)
                    {
                        ((IProjectMain) _controlDictionary[key]).AcceptRoutedEvent(ERouteEvent.SettingChangedEvent, args);
                    }
                }
            }
        }
        /// <summary>
        /// 路由事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void MainWindow_ModuleRoutedEvent(object sender, ModuleRoutedEventArgs args)
        {
           string dllName = args.TargetModule.GetModuleDllName();
            if (!string.IsNullOrEmpty(dllName))
            {
               
                Modulechanged(args.TargetModule, args);
                ((IProjectMain)_controlDictionary[args.TargetModule]).AcceptRoutedEvent(args.RoutedType, args);
                SetCurrentMenu(args.TargetModule);
            }
            else
            {
                MessageBox.Show("该模块正在施工中，敬情期待");
            }

        }
        void userView_HeaderChanged(object sender, ModulechangedEvengArgs e)
        {
            if (null != e.Current && null == e.Current.Children)
            {
                ModuleChanged(e.Current.ModuleName);
            }
        }
        void ModuleChanged(EModule module)
        {
            Modulechanged(module, null);
        }
        private void Modulechanged(EModule module, ModuleRoutedEventArgs args)
        {

            string dll = module.GetModuleDllName();
            if (!_controlDictionary.ContainsKey(module))
            {
                UserControl control = Assembly.InstanceControl(dll);
                IProjectMain iprojectMain = control as IProjectMain;
                if (null != iprojectMain)
                {
                    iprojectMain.SettingChanged += MainWindow_SettingChanged;
                    iprojectMain.PublicToken = PublicToken;
                }
                IModuleRoute iModuleRoute = control as IModuleRoute;
                if (null != iModuleRoute)
                {
                    iModuleRoute.ModuleRoutedEvent += MainWindow_ModuleRoutedEvent;
                }
                _controlDictionary.Add(module, control);
            }
            if (null == args)
            {
                Grid_Container.Children.Clear();
                Grid_Container.Children.Add(_controlDictionary[module]);
                ((IProjectMain)_controlDictionary[module]).InitSettingAsync(this.LSetting);
            }
            else if (args.RoutedType == ERouteEvent.WindowRouteEvent)
            {
                Grid_Container.Children.Clear();
                Grid_Container.Children.Add(_controlDictionary[module]);
            }
        }
    }
}

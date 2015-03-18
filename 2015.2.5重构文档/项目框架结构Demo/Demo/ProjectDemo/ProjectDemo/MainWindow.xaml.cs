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

using ProInterface.Model;
using ProCommon.ProEnum;
using ProCommon.ExtendAttribute;
using ProInterface.Delegate;
using ProCommon.Extensions;
using ProjectDemo.Login;
using ProjectDemo.Menu;
using ProjectDemo.Setting;

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
            Login = new LoginMain();
            Menu = new MenuMain();
            Menu.MenuSource.MenuItemSelectedChanged += MenuSource_MenuItemSelectedChanged;
            _controlDictionary = new Dictionary<EModule, UserControl>();
            _eventsDictionary = new Dictionary<EModule, ERouteEvent>();
            this._lsetting = new SettingMain() { UserList = new List<User>(), Permissons = new List<Permission>() };
            _lsetting.UserList.Add(new User() { UserName = "Init" });
            Menu.InitMenuView(new List<EModule>(){EModule.AccountView,EModule.BaiduEdit,EModule.BaiduBidding},"roc@pzoom.com",EModuleLevel.Double );
            this.HeaderPanel.DataContext = Menu.MenuSource;

            Menu.SetCurrentMenu(EModule.AccountView);
            
        }

        void MenuSource_MenuItemSelectedChanged(object sender, MenuItemSelectedchangedEvengArgs args)
        {
            ModuleChanged(args.Current.Module);
        }
        public LoginMain Login { get; set; }

        public MenuMain Menu { get; set; }
        private SettingMain _lsetting;

        public SettingMain LSetting
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

         void _ApplicationCloseCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            Console.WriteLine("adfafasfaddsf");
        }
          void _ApplicationCloseCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
         {
             e.CanExecute = true;
         }
        /// <summary>
        /// 路由事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MainWindow_ModuleRoutedEvent(object sender, ModuleRoutedEventArgs args)
        {
            switch (args.RoutedType)
            {
                case ERouteEvent.SettingChangedEvent:
                    ///同步主框架存储
                    string dll = sender.GetType().Assembly.ManifestModule.Name;
                    foreach (EModule key in _controlDictionary.Keys)
                    {
                        if (key.GetModuleDllName() != dll)
                        {
                            ((IProjectMain) _controlDictionary[key]).AcceptRoutedEvent(ERouteEvent.SettingChangedEvent,
                                this.LSetting);
                        }
                    }
                    break;
                case ERouteEvent.MethodRouteEvent:
                    if (!_controlDictionary.ContainsKey(args.TargetModule))
                    {
                        InitModule(args.TargetModule);
                    }
                    ((IProjectMain) _controlDictionary[args.TargetModule]).AcceptRoutedEvent(args.RoutedType, args);
                    break;
                case ERouteEvent.WindowRouteEvent:
                    if (!_controlDictionary.ContainsKey(args.TargetModule))
                    {
                        InitModule(args.TargetModule);
                    }
                    ((IProjectMain) _controlDictionary[args.TargetModule]).AcceptRoutedEvent(args.RoutedType, args);
                    Menu.SetCurrentMenu(args.TargetModule);
                    break;
            }
        }
      private  void ModuleChanged(EModule module)
        {
            ModuleChanged(module, null);
        }
      private void ModuleChanged(EModule module, ModuleRoutedEventArgs args)
        {
            if (!_controlDictionary.ContainsKey(module))
            {
                InitModule(module);
            }
            if (null == args)
            {
                Grid_Container.Children.Clear();
                Grid_Container.Children.Add(_controlDictionary[module]);
            }
            else if (args.RoutedType == ERouteEvent.WindowRouteEvent)
            {
                Grid_Container.Children.Clear();
                Grid_Container.Children.Add(_controlDictionary[module]);
            }
        }

        private void InitModule(EModule module)
        {
            if (!_controlDictionary.ContainsKey(module))
            {
                string dll = module.GetModuleDllName();
                UserControl control = Assembly.InstanceControl(dll);
                if (null != control)
                {
                    IProjectMain iprojectMain = control as IProjectMain;
                    if (null != iprojectMain)
                    {
                        iprojectMain.LoginMain = Login;
                        iprojectMain.SettingMain = LSetting;
                    }
                    IModuleRoute iModuleRoute = control as IModuleRoute;
                    if (null != iModuleRoute)
                    {
                        iModuleRoute.ModuleRoutedEvent += MainWindow_ModuleRoutedEvent;
                    }
                    _controlDictionary.Add(module, control);
                    ((IProjectMain) control).InitSettingAsync();
                }
            }
        }
    }
}

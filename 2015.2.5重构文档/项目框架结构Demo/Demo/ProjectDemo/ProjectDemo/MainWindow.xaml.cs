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
using ProInterface.Delegate;
using ProjectDemo.Common;
using ProjectDemo.Model.User;
using ProInterface.Enum;
using ProInterface.ExtendAttribute;
using ProInterface.Model;

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
            _controlDictionary = new Dictionary<string, UserControl>();
            _eventsDictionary = new Dictionary<string, ERoutedEvent>();
            _eventSource = new Dictionary<string, ERoutedEvent>();
            this._lsetting = new Setting() { UserList = new List<User>(), Permissions = new List<Permission>() };
            _lsetting.UserList.Add(new User() { UserName = "Init" });

            this.HeaderPanel.DataContext = GetUserView();
          
        }

        private Setting _lsetting;

        public Setting LSetting
        {
            get { return _lsetting; }
            set { _lsetting = value; }
        }

        /// <summary>
        /// 用于存储已初始化的模块列表
        /// </summary>
        private Dictionary<string, UserControl> _controlDictionary;
        /// <summary>
        /// 用于存储暂未执行的事件
        /// </summary>
        private Dictionary<string,ERoutedEvent > _eventsDictionary;

        private Dictionary<string, ERoutedEvent> _eventSource; 

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
            userView.Modules.Add(new Module() { Text = "概览", Enable = true, DllName = "ProView.dll" });
            userView.Modules.Add(new Module(){ Text = "百度管理",Enable = true,Children = new List<Module>(){new Module(){Text = "物料管理",DllName = "ProBaidu.dll"}}});
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
            if (null == e.Current.Children && null != e.Current.DllName)
            {
                ModuleChanged(e.Current.DllName);
            }
        }
        void MainWindow_SettingChanged(object sender, ProInterface.Delegate.SettingChangedEventArgs args)
        {
            this.LSetting = args.Config;
            AcceptEventAttribute atts = Attribute.GetCustomAttributes(sender.GetType(), true)[0] as AcceptEventAttribute;
            string dll = sender.GetType().Assembly.ManifestModule.Name;
            if (null != atts)
            {
                foreach (string key in _eventSource.Keys)
                {
                    if (key != dll)
                    {
                       
                            if ((_eventSource[key] & ERoutedEvent.SettingChangedEvent) > 0)
                            {
                                if (!_eventsDictionary.ContainsKey(key))
                                {
                                _eventsDictionary.Add(key, ERoutedEvent.SettingChangedEvent);
                            }
                        }
                    }
                    
                }
            }
        }


        void userView_HeaderChanged(object sender, ModulechangedEvengArgs e)
        {
            if (null != e.Current && null == e.Current.Children && null != e.Current.DllName)
            {
                ModuleChanged(e.Current.DllName);
            }
        }

        void ModuleChanged(string dll)
        {
            if (!_controlDictionary.ContainsKey(dll))
            {
                UserControl control = Assembly.InstanceControl(dll);

             
                ((IProjectMain)control).SettingChanged += MainWindow_SettingChanged;
                _controlDictionary.Add(dll, control);
                AcceptEventAttribute atts = Attribute.GetCustomAttributes(control.GetType(), true)[0] as AcceptEventAttribute;
                if (!_eventSource.ContainsKey(dll) && null != atts)
                    _eventSource.Add(dll,atts.Value);
            }
            Grid_Container.Children.Clear();
            Grid_Container.Children.Add(_controlDictionary[dll]);
            if (_eventsDictionary.ContainsKey(dll))
            {
                if (_eventsDictionary[dll] == ERoutedEvent.SettingChangedEvent)
                {
                    ((IProjectMain) _controlDictionary[dll]).AcceptRoutedEvent(ERoutedEvent.SettingChangedEvent,
                        this.LSetting);
                }
                _eventsDictionary.Remove(dll);
            }
        }
    }
}

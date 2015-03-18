using ProInterface;
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
using ProInterface.Delegate;
using ProInterface.Model;
using ProCommon.ProEnum;
using ProCommon.ExtendAttribute;
using ProView;

/// <summary>
    /// ProjectMain.xaml 的交互逻辑
    /// </summary>
    public partial class ProjectMain : UserControl,IProjectMain,IModuleRoute
    {
        public ProjectMain()
        {
            InitializeComponent();
            AcceptedEvents = new Queue<AcceptEvent>();
            this.ButtonAdd.Click += ButtonAdd_Click;
            this.ButtonDelete.Click += ButtonDelete_Click;
            this.ButtonUpdate.Click += ButtonUpdate_Click;
            this.ButtonRouteToKeyword.Click += ButtonRouteToKeyword_Click;
            this.ButtonRouteToDownloadData.Click += ButtonRouteToDownloadData_Click;
            this.ButtonRouteToAddPlan.Click += ButtonRouteToAddPlan_Click;
            this.ButtonTokenUpdate.Click += ButtonTokenUpdate_Click;
            this.Loaded += ProjectMain_Loaded;
            this.ButtonAddPlan.Click += ButtonAddPlan_Click;
        }

        void ButtonAddPlan_Click(object sender, RoutedEventArgs e)
        {
            AccountAdd win = new AccountAdd();
            win.Owner = Application.Current.MainWindow;
            win.ShowDialog();
        }
        public ILoginMain LoginMain { get; set; }
        public Queue<AcceptEvent> AcceptedEvents { get; set; }
        public ISetting SettingMain { get; set; }


        public event ModuleRoutedEventHandler ModuleRoutedEvent;

        void ButtonTokenUpdate_Click(object sender, RoutedEventArgs e)
        {
            LoginMain.Token += "UPDate";
        }

        void ButtonRouteToAddPlan_Click(object sender, RoutedEventArgs e)
        {
            if (null != ModuleRoutedEvent)
            {
                ModuleRoutedEvent(this, new ModuleRoutedEventArgs() { TargetModule = EModule.BaiduEdit, RoutedType = ERouteEvent.MethodRouteEvent, TargetMethod = ERouteMethod.AddPlan });
            }
        }
        void ButtonRouteToDownloadData_Click(object sender, RoutedEventArgs e)
        {
            if (null != ModuleRoutedEvent)
            {
                ModuleRoutedEvent(this, new ModuleRoutedEventArgs() { TargetModule = EModule.BaiduEdit, RoutedType = ERouteEvent.MethodRouteEvent, TargetMethod = ERouteMethod.DownLoadData });
            }
        }
        void ProjectMain_Loaded(object sender, RoutedEventArgs e)
        {
            while (AcceptedEvents.Count > 0)
            {
                AcceptEvent item = AcceptedEvents.Dequeue();
                ExecuteAcceptEvent(item);
            }
        }


        void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.SettingMain.UserList[0].UserName += "Editor--";
            if (null != ModuleRoutedEvent)
            {
                ModuleRoutedEvent(this, new ModuleRoutedEventArgs(){ RoutedType= ERouteEvent.SettingChangedEvent});
            }
        }

        void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            SettingMain.UserList.RemoveAt(0);
            if (null != ModuleRoutedEvent)
            {
                ModuleRoutedEvent(this, new ModuleRoutedEventArgs() { RoutedType = ERouteEvent.SettingChangedEvent });
            }
        }

        void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            User use = new User() {UserName = "新增用户"};
            SettingMain.UserList.Add(use);

            this.AccountListView.ItemsSource = new List<User>(SettingMain.UserList);

            if (null != ModuleRoutedEvent)
            {
                ModuleRoutedEvent(this, new ModuleRoutedEventArgs() { RoutedType = ERouteEvent.SettingChangedEvent });
            }
        }

        public void ExecuteAcceptEvent(AcceptEvent item)
    {
        switch (item.EventType)
        {
            case ERouteEvent.SettingChangedEvent:

                AccountListView.ItemsSource = new List<User>(this.SettingMain.UserList);
               break;
        }
    }

        
        public void AcceptRoutedEvent(ERouteEvent type,object  arg)
        {

            AcceptedEvents.Enqueue(new AcceptEvent() { EventType = type, EventArgs = arg });
 
        }
        void ButtonRouteToKeyword_Click(object sender, RoutedEventArgs e)
        {
            if (null != ModuleRoutedEvent)
            {
                ModuleRoutedEvent(this,new ModuleRoutedEventArgs(){ TargetModule = EModule.BaiduEdit,  RoutedType = ERouteEvent.WindowRouteEvent, TargetWindow = ERouteWindow.EditKeywordTab});
            }
        }
        public void InitSettingAsync()
        {
         
        }


    }

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

/// <summary>
    /// ProjectMain.xaml 的交互逻辑
    /// </summary>
    public partial class ProjectMain : UserControl,IProjectMain,IModuleRoute
    {
        public ProjectMain()
        {
            InitializeComponent();
         AcceptedEvents = new Queue<AcceptEvent>();
            this._lsetting = new Setting() { UserList = new List<User>(), Permissions=new List<Permission>() };
            this.ButtonAdd.Click += ButtonAdd_Click;
            this.ButtonDelete.Click += ButtonDelete_Click;
            this.ButtonUpdate.Click += ButtonUpdate_Click;
            this.ButtonRouteToKeyword.Click += ButtonRouteToKeyword_Click;
            this.ButtonRouteToDownloadData.Click += ButtonRouteToDownloadData_Click;
            this.ButtonRouteToAddPlan.Click += ButtonRouteToAddPlan_Click;
            this.ButtonTokenUpdate.Click += ButtonTokenUpdate_Click;
            this.Loaded += ProjectMain_Loaded;
            PublicToken = new TokenManager();
        }

        void ButtonTokenUpdate_Click(object sender, RoutedEventArgs e)
        {
            PublicToken.Token += "UPDate";
        }
        public TokenManager PublicToken { get; set; }
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
        private Setting  _lsetting;

        public Setting LSetting
        {
            get{return _lsetting;}
            set { _lsetting = value; }
        }




        void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            LSetting.UserList[0].UserName += "Editor--";
            if (null != SettingChanged)
            {
                SettingChanged(this, new SettingChangedEventArgs(){ Config =this._lsetting });
            }
        }

        void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            LSetting.UserList.RemoveAt(0);
            if (null != SettingChanged)
            {
                SettingChanged(this, new SettingChangedEventArgs() { Config = this._lsetting });
            }
        }

        void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            User use = new User() {UserName = "新增用户"};
            LSetting.UserList.Add(use);

            this.AccountListView.ItemsSource =new List<User>(LSetting.UserList);
           
            if (null != SettingChanged)
            {
                SettingChanged(this, new SettingChangedEventArgs() { Config = new Setting(){UserList = new List<User>(){use}} });
            }
        }

        public void ExecuteAcceptEvent(AcceptEvent item)
    {
        switch (item.EventType)
        {
            case ERouteEvent.SettingChangedEvent:
                Setting set = item.EventArgs as Setting;
                AccountListView.Items.Clear();
                for (int i = 0; i < set.UserList.Count; i++)
                {

                    AccountListView.Items.Add(set.UserList[i].UserName);
                }
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
        public bool IsBusy
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void InitSettingAsync(object obj)
        {
            throw new NotImplementedException();
        }

        public void InitSettingAsyncCancel(object state)
        {
            throw new NotImplementedException();
        }

        public event System.ComponentModel.AsyncCompletedEventHandler InitCompleted;

        public event System.ComponentModel.ProgressChangedEventHandler InitProgressChanged;

        public void InitSettingAsync(Setting obj)
        {
         
        }
        public event SettingChangedEventHandler SettingChanged;




        public event ModuleRoutedEventHandler ModuleRoutedEvent;


        public Queue<AcceptEvent> AcceptedEvents { get; set; }

    }

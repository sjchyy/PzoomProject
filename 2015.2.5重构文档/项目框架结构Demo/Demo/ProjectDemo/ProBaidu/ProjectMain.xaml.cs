using ProInterface;
using System;
using System.Collections;
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
    public partial class ProjectMain : UserControl,IProjectMain
    {
        public ProjectMain()
        {
            InitializeComponent();
           this.AcceptedEvents = new Queue<AcceptEvent>();
           this.Loaded += ProjectMain_Loaded;
            this.ButtonToken.Click += ButtonToken_Click;
            PublicToken = new TokenManager();
        }

    public TokenManager PublicToken { get; set; }
    private void ProjectMain_Loaded(object sender, RoutedEventArgs e)
    {

        while (AcceptedEvents.Count > 0)
        {
            AcceptEvent item = AcceptedEvents.Dequeue();
            ExecuteAcceptEvent(item);
        }
    }

    private void ButtonToken_Click(object sender, RoutedEventArgs e)
    {
        if (null != PublicToken)
        {
            MessageBox.Show(PublicToken.Token);
        }
    }

    public void ExecuteAcceptEvent(AcceptEvent item)
    {
            switch (item.EventType)
            {
                case ERouteEvent.SettingChangedEvent:
                    Setting set = item.EventArgs as Setting;
                    this.ListBox_Account.ItemsSource = new List<User>(set.UserList);
                    break;
                    case ERouteEvent.WindowRouteEvent:
                    ModuleRoutedEventArgs args = item.EventArgs as ModuleRoutedEventArgs;
                    SetRoutedWindow(args.TargetWindow);
                    break;
            }
    }

        public void AcceptRoutedEvent(ERouteEvent type, object arg)
        {
            if (type == ERouteEvent.MethodRouteEvent)
            {
                ModuleRoutedEventArgs item = arg as ModuleRoutedEventArgs;

                switch (item.TargetMethod)
                {
                    case ERouteMethod.DownLoadData:
                        MessageBox.Show("下载账户数据");
                        break;
                        case ERouteMethod.AddPlan:
                        MessageBox.Show("添加计划");
                        break;
                }
            }
            else
            {
                AcceptedEvents.Enqueue(new AcceptEvent() {EventType = type, EventArgs = arg});
            }
        }
    void SetRoutedWindow(ERouteWindow win)
    {

        switch (win)
        {
                case ERouteWindow.EditAccountTab:
                break;
                case ERouteWindow.EditGroupTab:
                break;
                case ERouteWindow.EditPlanTab:
                break;
                case ERouteWindow.EditKeywordTab:
                this.TabItemKeyword.IsSelected = true;
                break;
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


        public void InitSettingAsyncCancel(object state)
        {
            throw new NotImplementedException();
        }
        public event System.ComponentModel.AsyncCompletedEventHandler InitCompleted;

        public event System.ComponentModel.ProgressChangedEventHandler InitProgressChanged;

        public string UserName
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


        public void InitSettingAsync(Setting obj)
        {
            Setting set = obj as Setting;


            ListBox_Account.ItemsSource = set.UserList;

        }
        public event SettingChangedEventHandler SettingChanged;


        public Queue<AcceptEvent> AcceptedEvents
        {
            get; set;
        }
    }

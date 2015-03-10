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
using ProInterface.Enum;
using ProInterface.ExtendAttribute;
using ProInterface.Model;

/// <summary>
    /// ProjectMain.xaml 的交互逻辑
    /// </summary>
    [AcceptEventAttribute("AcceptRoutedEvent",ERoutedEvent.SettingChangedEvent)]
    public partial class ProjectMain : UserControl,IProjectMain
    {
        public ProjectMain()
        {
            InitializeComponent();
            this.Loaded += ProjectMain_Loaded;
            this._lsetting = new Setting() { UserList = new List<User>(), Permissions=new List<Permission>() };
          
        }

        private Setting  _lsetting;

        public Setting LSetting
        {
            get{return _lsetting;}
            set { _lsetting = value; }
        }



        void ProjectMain_Loaded(object sender, RoutedEventArgs e)
        {
            this.ButtonAdd.Click += ButtonAdd_Click;
            this.ButtonDelete.Click += ButtonDelete_Click;
            this.ButtonUpdate.Click += ButtonUpdate_Click;
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
            LSetting.UserList.Add(new User(){UserName = "新增用户"});
           
            if (null != SettingChanged)
            {
                SettingChanged(this, new SettingChangedEventArgs() { Config = this._lsetting });
            }
        }

        public void AcceptRoutedEvent(ERoutedEvent type,object  arg)
        {

            switch (type)
            {
                  case ERoutedEvent.SettingChangedEvent:
                    Setting set = arg as Setting;
                    AccountListView.Items.Clear();
                    for (int i = 0; i < set.UserList.Count; i++)
                    {

                        AccountListView.Items.Add(set.UserList[i].UserName);
                    }
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
            throw new NotImplementedException();
        }
        public event SettingChangedEventHandler SettingChanged;


    
    }

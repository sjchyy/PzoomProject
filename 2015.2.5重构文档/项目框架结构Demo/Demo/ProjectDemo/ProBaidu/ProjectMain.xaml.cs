using ProInterface;
using ProInterface.Enum;
using ProInterface.ExtendAttribute;
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

/// <summary>
    /// ProjectMain.xaml 的交互逻辑
    /// </summary>
    [AcceptEventAttribute("AcceptRoutedEvent", ERoutedEvent.SettingChangedEvent)]
    public partial class ProjectMain : UserControl,IProjectMain
    {
        public ProjectMain()
        {
            InitializeComponent();
        }

        public void AcceptRoutedEvent(ERoutedEvent type, object arg)
        {

            switch (type)
            {
                case ERoutedEvent.SettingChangedEvent:
                    Setting set = arg as Setting;
                    ListBox_Account.Items.Clear();
                    for (int i = 0; i < set.UserList.Count; i++)
                    {

                        ListBox_Account.Items.Add(set.UserList[i].UserName);
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
            throw new NotImplementedException();
        }

        public void AcceptRoutedEvent(Setting set)
        {
            throw new NotImplementedException();
        }

        public event SettingChangedEventHandler SettingChanged;
    }

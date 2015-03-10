using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using ProInterface.Model;

namespace ProInterface.Delegate
{
    public delegate void SettingChangedEventHandler(object sender, SettingChangedEventArgs args);
    public   class SettingChangedEventArgs:RoutedEventArgs
    {
        private Setting _config;

        public Setting Config
        {
            get { return _config; }
            set { _config = value; }
        }
    }
    /// <summary>
    /// 全部设置
    /// </summary>
    public class Setting
    {
        public Setting()
        {

        }
        /// <summary>
        /// 账户列表
        /// </summary>
        public List<User> UserList { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public List<Permission> Permissions { get; set; }
    }
}

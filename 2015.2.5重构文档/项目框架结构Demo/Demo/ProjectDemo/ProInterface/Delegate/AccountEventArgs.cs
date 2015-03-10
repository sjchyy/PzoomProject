using System.Collections.Generic;
using System.Windows;
using ProCommon.ProEnum;
using ProInterface.Model;

namespace ProInterface.Delegate
{
    public delegate void SettingChangedEventHandler(object sender, SettingChangedEventArgs args);

    public delegate void ModuleRoutedEventHandler(object sender, ModuleRoutedEventArgs args);

    public   class SettingChangedEventArgs:RoutedEventArgs
    {
        private Setting _config;

        public Setting Config
        {
            get { return _config; }
            set { _config = value; }
        }
    }
    public class ModuleRoutedEventArgs
    {
        public EModule TargetModule { get; set; }
        public ERouteEvent RoutedType { get; set; }
        public ERouteWindow TargetWindow { get; set; }
        public ERouteMethod TargetMethod { get; set; }
        public object State { get; set; }
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

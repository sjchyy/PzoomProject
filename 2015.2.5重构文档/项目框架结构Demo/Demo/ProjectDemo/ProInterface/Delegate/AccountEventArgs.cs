using System.Collections.Generic;
using System.Windows;
using ProCommon.ProEnum;
using ProInterface.Model;

namespace ProInterface.Delegate
{
    public delegate void ModuleRoutedEventHandler(object sender, ModuleRoutedEventArgs args);

    public class ModuleRoutedEventArgs
    {
        public EModule TargetModule { get; set; }
        public ERouteEvent RoutedType { get; set; }
        public ERouteWindow TargetWindow { get; set; }
        public ERouteMethod TargetMethod { get; set; }
        public object State { get; set; }
    }
}

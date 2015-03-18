using System;
using System.Collections;
using System.ComponentModel;
using ProInterface.Delegate;
using ProCommon.ProEnum;
using ProInterface.Model;
using System.Collections.Generic;

namespace ProInterface
{
   public  interface IProjectMain
    {
        ILoginMain LoginMain { get; set; }
        ISetting SettingMain { get; set; }
        void InitSettingAsync();
        Queue<AcceptEvent> AcceptedEvents { get; set; }
        void AcceptRoutedEvent(ERouteEvent typf,object arg);
    }
}

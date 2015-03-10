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
        bool IsBusy { get; set; }
        TokenManager PublicToken { get; set; }
        void InitSettingAsync(Setting obj);
        void InitSettingAsyncCancel(Object state);
        Queue<AcceptEvent> AcceptedEvents { get; set; }
        void AcceptRoutedEvent(ERouteEvent typf,object arg);
        event SettingChangedEventHandler SettingChanged;
        event AsyncCompletedEventHandler InitCompleted;
        event ProgressChangedEventHandler InitProgressChanged;
      
       

    }
}

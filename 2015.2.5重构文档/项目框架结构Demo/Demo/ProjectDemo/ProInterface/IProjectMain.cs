using System;
using System.ComponentModel;
using ProInterface.Delegate;
using ProInterface.Enum;

namespace ProInterface
{
   public  interface IProjectMain
    {
        bool IsBusy { get; set; }
        void InitSettingAsync(Setting obj);
        void InitSettingAsyncCancel(Object state);

        void AcceptRoutedEvent(ERoutedEvent typf,object arg);

        event SettingChangedEventHandler SettingChanged;
        event AsyncCompletedEventHandler InitCompleted;
        event ProgressChangedEventHandler InitProgressChanged;
      
       

    }
}

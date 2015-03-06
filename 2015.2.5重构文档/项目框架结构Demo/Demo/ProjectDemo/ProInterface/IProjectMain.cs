using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace ProInterface
{
   public  interface IProjectMain
    {
        bool IsBusy { get; set; }
        void InitSettingAsync(Object obj);
        void InitSettingAsyncCancel(Object state);

        event AsyncCompletedEventHandler InitCompleted;
        event ProgressChangedEventHandler InitProgressChanged;
      
       

    }
}

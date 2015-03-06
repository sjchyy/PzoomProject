using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace UIProject.Model
{
     public  class MGroup:INotifyPropertyChanged
     {
         private string _GroupName;

         public string GroupName
         {
             get { return _GroupName; }
             set { _GroupName = value; OnPropertyChanged("GroupName"); }
         }
         private string _State;

         public string State
         {
             get { return _State; }
             set { _State = value; OnPropertyChanged("State"); }
         }

         public event PropertyChangedEventHandler PropertyChanged;

         public void OnPropertyChanged(string value)
         {
             if(null != PropertyChanged)
             {
                 PropertyChanged(this, new PropertyChangedEventArgs(value));
             }
         }
     }
}

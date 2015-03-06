using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace UIProject.Model
{
   public  class MAddPlan:INotifyPropertyChanged
    {

        private string _PlanName;

        public string PlanName
        {
            get { return _PlanName; }
            set { _PlanName = value; OnPropertyChanged("PlanName"); }
        }
        private ObservableCollection<MGroup> _GroupSource;

        public ObservableCollection<MGroup> GroupSource
        {
            get { return _GroupSource; }
            set { _GroupSource = value; OnPropertyChanged("GroupSource"); }
        }

        private ICommand _AddGroupCommand;

        public ICommand AddGroupCommand
        {
            get { return _AddGroupCommand; }
            set { _AddGroupCommand = value; OnPropertyChanged("AddGroupCommand"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

       public void OnPropertyChanged(string value)
        {
            if (null != PropertyChanged)
                PropertyChanged(this, new PropertyChangedEventArgs(value));
        }
    }

 
}

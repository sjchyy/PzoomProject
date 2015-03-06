using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace ProModel.User
{
    public delegate void ModuleChangedEventHandle(object sender, ModulechangedEvengArgs args);

    public class ModulechangedEvengArgs
    {

        public ModulechangedEvengArgs(Module obj)
        {
            Current = obj;
        }

        public Module Current { get; set; }
    }

    public  class UserView :INotifyPropertyChanged
    {

        public event ModuleChangedEventHandle ModuleChanged;
        public event ModuleChangedEventHandle HeaderChanged;

        private string _userName;

        public string UserName
        {
            get { return _userName;}
            set
            {
                _userName = value; OnPropertyChanged("UserName");}
        }
        private List<Module> _modules;

        public List<Module> Modules
        {
            get { return _modules; }
            set { _modules = value; OnPropertyChanged("Modules"); }
        }
        private Module _currentHeader;

        public Module CurrentHeader
        {
            get { return _currentHeader; }
            set { _currentHeader = value; OnPropertyChanged("CurrentHeader");
                 _currentModule.Current = _currentHeader;
                 OnHeaderChanged(_currentHeader);
            }
        }
        private Module _currentModule;

        public Module CurrentModule
        {
            get { return _currentModule;}
            set { _currentModule = value; OnPropertyChanged("CurrentModule");
               if(null == _currentModule.Current)
                CurrentHeader = _currentModule.Children !=  null && _currentModule.Children.Count>0 ? _currentModule.Children[0]:null;
               else
               {
                   CurrentHeader = _currentModule.Current;

               }
                OnModuleChanged(_currentModule);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string value)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(value));
            }
        }

        public void OnModuleChanged(Module value)
        {
            if (null != ModuleChanged)
            {
                ModuleChanged(this, new ModulechangedEvengArgs(value));
            }
        }
        public void OnHeaderChanged(Module value)
        {
            if (null != HeaderChanged)
            {
                HeaderChanged(this, new ModulechangedEvengArgs(value));
            }
        }
    }
}

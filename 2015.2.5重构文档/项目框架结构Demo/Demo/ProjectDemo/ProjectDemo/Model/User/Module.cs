﻿using ProCommon.ProEnum;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProjectDemo.Model.User
{
    public class Module:INotifyPropertyChanged
    {
        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged("Text"); }
        }

        private bool _enable;

        public bool Enable
        {
            get { return _enable; }
            set { _enable = value;OnPropertyChanged("Enable"); }
        }

        private Module _parent;

        public Module Parent
        {
            get { return _parent;}
            set { _parent = value; }
        }
        private EModule _moduleName;

        public EModule ModuleName
        {
            get { return _moduleName; }
            set { _moduleName = value; OnPropertyChanged("ModuleName"); }
        }

        private List<Module> _children;

        public List<Module> Children
        {
            get { return _children; }
            set { _children = value; OnPropertyChanged("Children"); }
        }
        private Module _current;

        public Module Current
        {
            get { return _current; }
            set { _current = value; OnPropertyChanged("Current"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string value)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(value));
            }
        }
    }
}

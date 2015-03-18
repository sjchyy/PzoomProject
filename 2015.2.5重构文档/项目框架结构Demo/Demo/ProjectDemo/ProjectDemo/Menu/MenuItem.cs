using ProCommon.ProEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ProjectDemo.Menu
{
    public class MenuItem : INotifyPropertyChanged
    {

        public MenuItem()
        {
            _children = new List<MenuItem>();
        }
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
            set { _enable = value; OnPropertyChanged("Enable"); }
        }

        private MenuItem _parent;

        public MenuItem Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
        private EModule _module;

        public EModule Module
        {
            get { return _module; }
            set { _module = value; OnPropertyChanged("Module"); }
        }

        private List<MenuItem> _children;

        public List<MenuItem> Children
        {
            get { return _children; }
            set { _children = value; OnPropertyChanged("Children"); }
        }
        private MenuItem _current;

        public MenuItem Current
        {
            get { return _current; }
            set { _current = value; OnPropertyChanged("Current"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string value)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(value));
            }
        }
    }
}

using ProCommon.ProEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ProjectDemo.Menu
{
    public delegate void MenuItemSelectedChangedEventHandle(object sender, MenuItemSelectedchangedEvengArgs args);

    public class MenuItemSelectedchangedEvengArgs
    {
        public MenuItemSelectedchangedEvengArgs(MenuItem obj)
        {
            Current = obj;
        }
        public MenuItem Current { get; set; }
    }
    public class MenuView : INotifyPropertyChanged
    {

        public MenuView()
        {
            _menuItemSource = new List<MenuItem>();
        }

        public event MenuItemSelectedChangedEventHandle MenuItemSelectedChanged;

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value; OnPropertyChanged("UserName");
            }
        }
        private List<MenuItem> _menuItemSource;

        public List<MenuItem> MenuItemSource
        {
            get { return _menuItemSource; }
            set { _menuItemSource = value; OnPropertyChanged("MenuItemSource"); }
        }

        private MenuItem _currentFirstMenuItem;

        public MenuItem CurrentFirstMenuItem
        {
            get { return _currentFirstMenuItem; }
            set
            {
                _currentFirstMenuItem = value; OnPropertyChanged("CurrentFirstMenuItem");
                 if(null != _currentFirstMenuItem.Children && _currentFirstMenuItem.Children.Count>0)
                 {
                     CurrentSecondMenuItem = _currentFirstMenuItem.Current ??
                                             _currentFirstMenuItem.Children[0];

                 }
                 else
                 {
                     CurrentMenuItem = _currentFirstMenuItem;
                 }
            }
        }
        private MenuItem _currentSecondMenuItem;

        public MenuItem CurrentSecondMenuItem
        {
            get { return _currentSecondMenuItem; }
            set
            {
               
                _currentSecondMenuItem = value;
                if (null != _currentSecondMenuItem)
                {
                    _currentFirstMenuItem.Current = _currentSecondMenuItem;
                    OnPropertyChanged("CurrentSecondMenuItem");
                    CurrentMenuItem = _currentSecondMenuItem;
                }
            }
        }
        private MenuItem _currentMenuItem;

        public MenuItem CurrentMenuItem
        {
            get { return _currentMenuItem; }
            set
            {
                if (_currentMenuItem != value)
                {
                    _currentMenuItem = value;
                    OnMenuItemSelectedChanged(_currentMenuItem);
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string value)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(value));
            }
        }


        public void OnMenuItemSelectedChanged(MenuItem item)
        {
            if (null != MenuItemSelectedChanged)
            {
                MenuItemSelectedChanged(this, new MenuItemSelectedchangedEvengArgs(item));
            }
        }
        public void SetCurrentModule(MenuItem item)
        {
             _currentMenuItem = item;
           
            if (null != item.Parent)
            {
                item.Parent.Current = item;
                CurrentFirstMenuItem = item.Parent;
            }
            else
            {
                CurrentFirstMenuItem = item;
            }
            OnMenuItemSelectedChanged(_currentMenuItem);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DNBSoft.WPF
{
    public  class UserWindow :Window
    {

        static UserWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UserWindow),new PropertyMetadata(typeof(UserWindow)));
        
        }


    }
}

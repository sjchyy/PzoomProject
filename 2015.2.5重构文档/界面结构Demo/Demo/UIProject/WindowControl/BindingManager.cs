using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WindowControl.AddWindow;

namespace WindowControl
{

    internal class BindingManager
    {
        public  void InitBinding(Window window)
        {
            if (null == window)
                return;
            if (window.GetType() == typeof(AddPlan))
                InitBindingAddPlan(window);

        }
        private  void InitBindingAddPlan(Window win)
        {
            AddPlan window = win as AddPlan;
            window.TextBox_PlanName.SetBinding(TextBox.TextProperty, new Binding("PlanName") );
            window.ListView_GroupSource.SetBinding(ListView.ItemsSourceProperty, new Binding("GroupSource") );
            window.GridViewColumn_GroupName.DisplayMemberBinding = new Binding("GroupName");
            window.GridViewColumn_State.DisplayMemberBinding = new Binding("State") ;
            window.Button_AddGroup.SetBinding(Button.CommandProperty, new Binding("AddGroupCommand"));
        }
    }
     

}

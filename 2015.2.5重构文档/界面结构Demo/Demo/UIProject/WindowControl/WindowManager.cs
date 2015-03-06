using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowControl.AddWindow;

namespace WindowControl
{
   public  class WindowManager
    {
       private static  BindingManager _bManager;

       static WindowManager()
       {
           _bManager = new BindingManager();
       }
       public static AddPlan CreateAddPlanWindow()
       {
           AddPlan _addPlan = new AddPlan();
           _bManager.InitBinding(_addPlan);
           return _addPlan;
       }
    }
}

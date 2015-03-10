using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ProjectDemo.Common
{
   public class Assembly
    {
       public static UserControl InstanceControl(string dll)
       {

           UserControl control=null;
           string file = System.IO.Directory.GetCurrentDirectory() + @"\" + dll;
           if (System.IO.File.Exists(file))
           {



               System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile(file);
               if (null != assembly)
               {
                   control = assembly.CreateInstance("ProjectMain") as UserControl;
               }
           }

           return control;
       }


    }
}

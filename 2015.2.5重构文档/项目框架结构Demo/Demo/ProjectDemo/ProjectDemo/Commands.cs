using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ProjectDemo
{
   public  class Commands
   {
       private static CommandBinding _applicationCloseCommandBinding;
       public static  CommandBinding ApplicationCloseCommandBinding
       {
           get
           {
               if (null == _applicationCloseCommandBinding)
               {
                   _applicationCloseCommandBinding = new CommandBinding();
                   _applicationCloseCommandBinding.Command = ApplicationCommands.Close;
                   _applicationCloseCommandBinding.CanExecute+= UserCanExecute.ApplicationCloseCmdCanExecute;
                   _applicationCloseCommandBinding.Executed += UserExecute.ApplicationCloseCmdExecuted;
               }
               return _applicationCloseCommandBinding;  
           }
       }
    }

    public  class UserCanExecute
    {

     
       public    static   void ApplicationCloseCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }

    public  class UserExecute
    {

      
        public static   void ApplicationCloseCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
         Console.WriteLine("adfafasfaddsf");
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace UIProject.Command
{
    public class AddGroupCommand : ExcuteCommand
    {
        public AddGroupCommand(Action<object> exec)
            : base(exec)
        {

        }
        public AddGroupCommand(Predicate<object> canEx, Action<object> exec)
            : base(canEx,exec)
        {

        }


        public override void Execute(object parameter)
        {
            base.Execute(parameter);
        }
    }
   public class ExcuteCommand : System.Windows.Input.ICommand
   {

       public Action<object> _exec = null;
       public Predicate<object> _canEx = null;

       public ExcuteCommand(Action<object> exec)
           : this(null, exec)
       {

       }
       public ExcuteCommand(Predicate<object> canEx, Action<object> exec)
       {
           this._canEx = canEx;
           this._exec = exec;
       }

       public bool CanExecute(object parameter)
       {
           return _canEx == null ? true : _canEx(parameter);
       }

       public event EventHandler CanExecuteChanged
       {
           add { CommandManager.RequerySuggested += value; }
           remove { CommandManager.RequerySuggested -= value; }

       }

       public virtual void Execute(object parameter)
       {
           _exec(parameter);
       }
   }
}

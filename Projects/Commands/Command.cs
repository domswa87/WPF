using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Commands
{
    public class Command : ICommand
    {
        Action<object> executeMethod;
        Func<object, bool> canExecteMethod;

        public event EventHandler CanExecuteChanged;

        public Command(Action<object> executeMethod, Func<object,bool> canExecuteMethod)
        {
            this.executeMethod = executeMethod;
            this.canExecteMethod = canExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            executeMethod(parameter);
        }
    }
}

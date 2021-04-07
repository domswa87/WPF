using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Commands
{
    public class MyClassDS
    {
        public ICommand MyCommandDS { get; set; }

        public MyClassDS()
        {
            MyCommandDS = new Command(ExecuteMethod, canExecuteMethod);
        }

        private bool canExecuteMethod(object parameter)
        {
            return MyCommandDS.CanExecute(parameter);
        }

        private void ExecuteMethod(object parameter)
        {
            MessageBox.Show("No code behind - Commands works !");
        }
    }
}

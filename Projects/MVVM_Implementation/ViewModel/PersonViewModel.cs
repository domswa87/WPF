using MVVM_Implementation.Command;
using MVVM_Implementation.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_Implementation.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person obj;
        public PersonViewModel()
        {
            obj = new Person();
        }

        public string PersonFName
        {
            get { return obj.FName;  }
            set { obj.FName = value;  NotifyPropertyChanged("PersonFName"); }
        }

        public string PersonLName
        {
            get { return obj.LName; }
            set { obj.LName = value;  NotifyPropertyChanged("PersonLName"); }
        }

        #region Commands
        private void SubmitExecute(object parameter) 
        {
            obj.FName = obj.FName + "a";
        }

        private void SubmitExecute2(object parameter)
        {
            PersonFName = PersonFName;

        }
      

        private ICommand _SubmitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(SubmitExecute, CanSubmitExecute, false);
                }
                return _SubmitCommand;
            }
        }

        private ICommand _SubmitCommand2;
        public ICommand SubmitCommand2
        {
            get
            {
                if (_SubmitCommand2 == null)
                {
                    _SubmitCommand2 = new RelayCommand(SubmitExecute2, CanSubmitExecute, false);
                }
                return _SubmitCommand2;
            }
        }

        private bool CanSubmitExecute(object parameter)
        {
            if (string.IsNullOrEmpty(obj.FName) || string.IsNullOrEmpty(obj.LName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                // nie kumam tego
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

using MVVM_Implementation.Command;
using MVVM_Implementation.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private void MyMethod1(object parameter) 
        {
            MessageBox.Show("MyMethod1");
        }

        private void MyMethod2(object parameter)
        {
            MessageBox.Show("MyMethod2");
        }
      

        private ICommand _ChangeModelCommand;
        public ICommand ChangeModelCommand
        {
            get
            {
                if (_ChangeModelCommand == null)
                {
                    _ChangeModelCommand = new RelayCommand(MyMethod1, CanSubmitExecute, false);
                }
                return _ChangeModelCommand;
            }
        }

        private ICommand _RefreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                if (_RefreshCommand == null)
                {
                    _RefreshCommand = new RelayCommand(MyMethod2, CanSubmitExecute, false);
                }
                return _RefreshCommand;
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
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

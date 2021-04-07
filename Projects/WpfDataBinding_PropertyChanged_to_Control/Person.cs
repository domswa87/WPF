using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDataBinding
{
    public class Person : INotifyPropertyChanged
    {
        private int _wiek;
        public int Wiek
        {
            get
            {
                return _wiek;
            }
            set
            {
                _wiek = value;
                OnPropertyRaised("Wiek");
            }
        }

        private string _imie;
        public string Imie
        {
            get
            {
                return _imie;
            }
            set
            {
                _imie = value;
                OnPropertyRaised("Imie");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyRaised(string propertname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertname));
            }
        }

    }
}



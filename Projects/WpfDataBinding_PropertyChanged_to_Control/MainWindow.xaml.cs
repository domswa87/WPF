using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Person Person { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Update_Model(object sender, RoutedEventArgs e)
        {
            Person person = new Person
            {
                Wiek = int.Parse(textBoxWiek.Text),
                Imie = textBoxImie.Text
            };
            this.DataContext = person;
            Person = person;
        }

        private void Button_Click_Check_Model(object sender, RoutedEventArgs e)
        {
            if (Person == null)
                MessageBox.Show($"Object Person is null");
            else
                MessageBox.Show($"Name:{Person.Imie} Age:{Person.Wiek}");
        }
    }
}

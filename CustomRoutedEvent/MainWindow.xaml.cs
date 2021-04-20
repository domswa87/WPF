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
using System.Windows.Threading;

namespace CustomRoutedEvent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate int DelegateDS(string s);
        event DelegateDS myEvent;
        
        public MainWindow()
        {
            InitializeComponent();
            TimeSpan interval = new TimeSpan(0, 0, 1);
            DispatcherTimer dispatcher = new DispatcherTimer();
            dispatcher.Interval = interval;
            dispatcher.Tick += Dispatcher_Tick;
            dispatcher.Start();
        }

        private void Dispatcher_Tick(object sender, EventArgs e)
        {
            TextBlock1.Text = DateTime.Now.Second.ToString();
        }


    }
}

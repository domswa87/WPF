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

namespace VisualStates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Counter { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
           // timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Counter ++;
            if (Counter%5 == 0)
            {
                VisualStateManager.GoToState(MyButton, "MyState1", false);
            }
            else if (Counter % 3 == 0)
            {
                VisualStateManager.GoToState(MyButton, "MyState2", false);
            }
            else if(Counter % 1 == 0)
            {
                VisualStateManager.GoToState(MyButton, "MyState3", false);
            }
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            Counter++;
            if (Counter % 5 == 0)
            {
                VisualStateManager.GoToState((FrameworkElement)sender, "FirstState", false);
            }
            else if (Counter % 3 == 0)
            {
                VisualStateManager.GoToState((FrameworkElement)sender, "SecondState", false);
            }

        }
     
    }
}

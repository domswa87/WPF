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
        }

        private void GoToStateA_Click(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToElementState(StackPanelWithStates, "StateA", true);
        }

        private void GoToStateB_Click(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToElementState(StackPanelWithStates, "StateB", true);
        }
    
    }
}

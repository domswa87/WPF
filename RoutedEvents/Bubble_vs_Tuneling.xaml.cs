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
using System.Windows.Shapes;

namespace RoutedEvents
{
    /// <summary>
    /// Interaction logic for Bubble_vs_Tuneling.xaml
    /// </summary>
    public partial class Bubble_vs_Tuneling : Window
    {
        public Bubble_vs_Tuneling()
        {
            InitializeComponent();
        }

        private void Outer1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Outer");
            Result1.Content += " Outer ";
        }

        private void Inner1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Inner");
            Result1.Content += " Inner ";
        }

        private void Outer2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Outer");
            Result2.Content += " Outer ";
        }

        private void Inner2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Inner");
            Result2.Content += " Inner ";
        }
    }
}

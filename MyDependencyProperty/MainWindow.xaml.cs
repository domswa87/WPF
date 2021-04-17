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

namespace MyDependencyProperty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Propercje NORMAL PROPERTY i DEPENDENCY PROPERTY są połączone ze sobą  - dzięki temu mechanizmowi działa Binding
        // to create use snippet "propdp"
        public MainWindow()
        {
            InitializeComponent();
        }

        // NORMAL PROPERTY
        public int NormalPropertyDS
        {
            get
            {
                MessageBox.Show("Normal Property GET is called");
                return (int)GetValue(DependencyPropertyDS);
            }

            set
            {
                MessageBox.Show("Normal Property SET is called");
                SetValue(DependencyPropertyDS, value);
            }
        }

        // DEPENDENCY PROPERTY
        // Using a DependencyProperty as the backing store for NormalPropertyDS.  This enables animation, styling, binding, etc...
      
        public static readonly DependencyProperty DependencyPropertyDS =
            DependencyProperty.Register("NormalPropertyDS", typeof(int), typeof(MainWindow), new PropertyMetadata(0));



        private void Set_Dependency1_Click(object sender, RoutedEventArgs e)
        {
            SetValue(DependencyPropertyDS, 1);
        }

        private void Set_Dependency2_Click(object sender, RoutedEventArgs e)
        {
            SetValue(DependencyPropertyDS, 2);
        }

        private void Set_Normal3_Click(object sender, RoutedEventArgs e)
        {
            NormalPropertyDS = 3;
        }

        private void Set_Normal4_Click(object sender, RoutedEventArgs e)
        {
            NormalPropertyDS = 4;
        }
      
        private void GetDependencyPropertyValue_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(GetValue(DependencyPropertyDS).ToString());
        }

        private void GetNormalPropertyValue_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(NormalPropertyDS.ToString());
        }
    }
}

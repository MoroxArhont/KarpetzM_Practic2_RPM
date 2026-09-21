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

namespace KarpetzM_Practic2_RPM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Task1_Click(object sender, RoutedEventArgs e)
        {
            new Task1Window().Show();
        }

        private void Task2_Click(object sender, RoutedEventArgs e)
        {
            new Task2Window().Show();
        }

        private void Task3_Click(object sender, RoutedEventArgs e)
        {
            new Task3Window().Show();
        }

        private void Task4_Click(object sender, RoutedEventArgs e)
        {
            new Task4Window().Show();
        }

        private void Task5_Click(object sender, RoutedEventArgs e)
        {
            new Task5Window().Show();
        }
    }
}

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
using System.Numerics;

namespace KarpetzM_Practic2_RPM
{
    public partial class Task1Window : Window
    {
        public Task1Window()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            // Проверка: число ли это
            if (!int.TryParse(txtInput.Text, out int n))
            {
                MessageBox.Show("Введите целое число!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверка: натуральное и n <= 100
            if (n < 1 || n > 100)
            {
                MessageBox.Show("n должно быть от 1 до 100!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Считаем факториал от 2n
            int limit = 2 * n;
            BigInteger factorial = 1;
            for (int i = 2; i <= limit; i++)
            {
                factorial *= i;
            }

            txtResult.Text = $"2n = {limit}\n{limit}! = {factorial}";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

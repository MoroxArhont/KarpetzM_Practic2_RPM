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

namespace KarpetzM_Practic2_RPM
{
    public partial class Task4Window : Window
    {
        public Task4Window()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            // Парсим массив
            string[] parts = txtArray.Text.Split(new[] { ' ', ',', ';' },
                                                  StringSplitOptions.RemoveEmptyEntries);
            List<int> arr = new List<int>();
            foreach (string p in parts)
            {
                if (!int.TryParse(p, out int val))
                {
                    MessageBox.Show($"'{p}' — не целое число!", "Ошибка",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                arr.Add(val);
            }

            if (arr.Count == 0)
            {
                MessageBox.Show("Введите массив!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Парсим b
            if (!int.TryParse(txtB.Text, out int b))
            {
                MessageBox.Show("Введите корректное число b!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string before = string.Join(", ", arr);

            // Алгоритм двух указателей
            int left = 0;
            int right = arr.Count - 1;
            while (left < right)
            {
                // Ищем слева элемент > b
                while (left < right && arr[left] <= b) left++;
                // Ищем справа элемент < b
                while (left < right && arr[right] >= b) right--;

                // Меняем местами
                if (left < right)
                {
                    int tmp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = tmp;
                }
            }

            txtResult.Text = $"Исходный массив: {before}\n" +
                             $"b = {b}\n" +
                             $"Результат: {string.Join(", ", arr)}";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

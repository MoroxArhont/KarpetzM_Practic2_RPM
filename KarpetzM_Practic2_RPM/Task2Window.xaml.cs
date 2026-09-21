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
    public partial class Task2Window : Window
    {
        public Task2Window()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInput.Text;

            // Проверка: не пустая
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Введите строку!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверка: только русские буквы и пробелы
            foreach (char c in input)
            {
                if (!((c >= 'А' && c <= 'я') || c == 'ё' || c == 'Ё' || c == ' '))
                {
                    MessageBox.Show("Строка должна содержать только русские буквы и пробелы!",
                                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            // Разбиваем по пробелам, убираем пустые элементы
            string[] words = input.Split(new[] { ' ' },
                                          StringSplitOptions.RemoveEmptyEntries);

            // Переворачиваем массив
            Array.Reverse(words);

            // Склеиваем через один пробел
            txtResult.Text = string.Join(" ", words);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

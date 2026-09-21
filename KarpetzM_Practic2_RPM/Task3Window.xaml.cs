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
    public partial class Task3Window : Window
    {
        public Task3Window()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInput.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Введите числа!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Парсим числа
            string[] parts = input.Split(new[] { ' ', ',', ';' },
                                          StringSplitOptions.RemoveEmptyEntries);
            List<int> nums = new List<int>();

            foreach (string p in parts)
            {
                if (!int.TryParse(p, out int val))
                {
                    MessageBox.Show($"'{p}' — не целое число!", "Ошибка",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                nums.Add(val);
            }

            if (nums.Count == 0)
            {
                MessageBox.Show("Не введено ни одного числа!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int n = nums.Count;
            int[] dp = new int[n];     // длина лучшей цепочки, заканчивающейся на i
            int[] prev = new int[n];   // предыдущий индекс в цепочке

            for (int i = 0; i < n; i++)
            {
                dp[i] = 1;
                prev[i] = -1;
            }

            int bestEnd = 0;
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    // nums[i] делится на nums[j] нацело
                    if (nums[j] != 0 && nums[i] % nums[j] == 0 && dp[j] + 1 > dp[i])
                    {
                        dp[i] = dp[j] + 1;
                        prev[i] = j;
                    }
                }
                if (dp[i] > dp[bestEnd])
                    bestEnd = i;
            }

            // Восстанавливаем цепочку
            List<int> chain = new List<int>();
            int cur = bestEnd;
            while (cur != -1)
            {
                chain.Add(nums[cur]);
                cur = prev[cur];
            }
            chain.Reverse();

            txtResult.Text = $"Исходная последовательность: {string.Join(", ", nums)}\n" +
                             $"Максимальная длина: {chain.Count}\n" +
                             $"Подпоследовательность: {string.Join(", ", chain)}";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

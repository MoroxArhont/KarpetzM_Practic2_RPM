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
using System.Data;

namespace KarpetzM_Practic2_RPM
{
    public partial class Task5Window : Window
    {
        private Random rnd = new Random();

        public Task5Window()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            // Парсим N и M
            if (!int.TryParse(txtN.Text, out int n) || n <= 0 || n > 20)
            {
                MessageBox.Show("N должно быть от 1 до 20!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!int.TryParse(txtM.Text, out int m) || m <= 0 || m > 20)
            {
                MessageBox.Show("M должно быть от 1 до 20!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Генерируем массив
            int[,] arr = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    arr[i, j] = rnd.Next(-10, 11);

            // Собираем все элементы в один список
            int total = n * m;
            int[] flat = new int[total];
            int k = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    flat[k++] = arr[i, j];

            // Копии для сортировки
            int[] asc = (int[])flat.Clone();
            int[] desc = (int[])flat.Clone();
            Array.Sort(asc);
            Array.Sort(desc);
            Array.Reverse(desc);

            // min и max
            int min = flat[0], max = flat[0];
            foreach (int v in flat)
            {
                if (v < min) min = v;
                if (v > max) max = v;
            }

            // Заполняем DataGrid-ы
            dgAsc.ItemsSource = BuildTable(asc, n, m).DefaultView;
            dgDesc.ItemsSource = BuildTable(desc, n, m).DefaultView;

            txtMinMax.Text = $"Минимальный элемент: {min}   |   Максимальный элемент: {max}";
        }

        // Превращаем одномерный массив в DataTable размером n×m
        private DataTable BuildTable(int[] flat, int n, int m)
        {
            DataTable dt = new DataTable();
            for (int j = 0; j < m; j++)
                dt.Columns.Add($"Столбец {j + 1}", typeof(int));

            int k = 0;
            for (int i = 0; i < n; i++)
            {
                DataRow row = dt.NewRow();
                for (int j = 0; j < m; j++)
                    row[j] = flat[k++];
                dt.Rows.Add(row);
            }
            return dt;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

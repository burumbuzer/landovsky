using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        public enum test_types
        {
            random_tests,
            textbox_tests
        }
        public test_types TestType = test_types.random_tests;

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked && radioButton.Name == "rbRandom")
            {
                TestType = test_types.random_tests;
                mlText.Enabled = false;
                textBox1.Enabled = true;
                
            }
            if (radioButton.Checked && radioButton.Name == "rbText")
            {
                TestType = test_types.textbox_tests;
                mlText.Enabled = true;
                textBox1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear(); // Очистка диаграммы

            // Преполагаемое распределение для 4 варианта
            // y = (-1/2)*x + 1
            chart1.Series[1].Points.AddXY(0.0, 1.0);
            chart1.Series[1].Points.AddXY(2.0, 0.0);


            Random rnd = new Random();

            int arr_size = 0;
            if (TestType == test_types.random_tests)
            {
                arr_size = Convert.ToInt32(textBox1.Text);
            }
            else if (TestType == test_types.textbox_tests)
            {
                arr_size = mlText.Lines.Length;
            }
            double[] tests = new double[arr_size];
            if (TestType == test_types.random_tests)
            {
                for (int i = 0; i < arr_size; i++)
                {
                    tests[i] = 2.0 - 2.0 * Math.Sqrt(1.0 - rnd.NextDouble()); // Метод обратной функции
                }
            }
            else if (TestType == test_types.textbox_tests)
            {
                for (int i = 0; i < arr_size; i++)
                {
                    string s = mlText.Lines[i];
                    tests[i] = Convert.ToDouble(s);
                }
            }

            Array.Sort(tests);

            double mx = tests.Max();
            double mn = tests.Min();
            // Для разделения тестов на интервалы найдём левую и правую границу для них – минимальное и максимальное значение соотв.
            double left_bound = mn;
            double right_bound = mx;
            int interval = Convert.ToInt32(textBox2.Text); // Узнаем кол-во интервалов
            int[] intervals = new int[interval]; // И объявим массив, в котором будем хранить сколько "тестов" попало в интервал
            double step = (right_bound - left_bound) / interval; // Шаг интервала

            for (int i = 0; i < interval; i++)
            {
                foreach (var test in tests)
                {
                    if ((test >= left_bound + step * (i)) && (test <= left_bound + step * (i+1)))
                    {
                        intervals[i]++; // "Тест" попал в интервал
                    }
                }
            }

            chart1.ChartAreas[0].AxisX.Interval = Math.Round(step, 5);
            for (int i = 0; i < interval; i++)
            {
                double y = (Convert.ToDouble(intervals[i]) / arr_size) / step;
                chart1.Series[0].Points.AddXY(Math.Round((left_bound + step*(i) + (step/2)), 5), y); // Рисуем столбики
            }

            double mean = tests.Average(); // Среднее

            double median; // Медиана
            if (tests.Length % 2 == 0) median = (tests[tests.Length / 2] + tests[tests.Length / 2 + 1]) / 2.0;
            else median = tests[tests.Length / 2];

            double mode = tests[0]; // Поиск моды, cmax – кол-во встреч текущего элемента, rmax - наибольшее значение встреч
            double cmax = 0, rmax = 0;
            for (int i = 0; i < arr_size; i++)
            {
                if (cmax > rmax)
                {
                    rmax = cmax;
                    mode = tests[i - 1];
                }
                cmax = 0;
                for (int j = i; j < arr_size; j++)
                {
                    if (Math.Round(tests[j], 5) == Math.Round(tests[i], 5)) cmax++;
                }
            }

            double disp = 0; // Поиск дисперсии
            for (int i = 0; i < arr_size; i++) {
                disp += (tests[i] - mean) * (tests[i] - mean);
            }
            disp = disp / Convert.ToDouble(arr_size - 1);

            lblMean.Text = $"Среднее: {mean:F5}";
            lblMediana.Text = $"Медиана: {median:F5}";
            lblMode.Text = $"Мода: {mode:F5}";
            lblDisp.Text = $"Дисперсия: {disp:F5}";

            // Проверка Хи2
            double Xi2 = 0;
            double t_left_bound = 0.0;
            double t_right_bound = 2.0;
            double t_step = (t_right_bound - t_left_bound) / interval;
            int validIntervals = 0;
            for (int i = 0; i < interval; i++)
            {
                // y = x - (x^2/4)
                double x1, x2;
                x1 = t_left_bound + (t_step * (i + 1));
                x2 = t_left_bound + (t_step * i);
                double Ni = ((x1 - (x1 * x1 / 4)) - (x2 - (x2 * x2 / 4))) * arr_size;
                
                if (i == 0 || i == interval - 1)
                {
                    if (Ni > 1.0)
                    {
                        Xi2 += ((Convert.ToDouble(intervals[i]) - Ni) * (Convert.ToDouble(intervals[i]) - Ni)) / Ni;
                        validIntervals++;
                    }
                }
                else
                {
                    if (Ni > 5.0)
                    {
                        Xi2 += ((Convert.ToDouble(intervals[i]) - Ni) * (Convert.ToDouble(intervals[i]) - Ni)) / Ni;
                        validIntervals++;
                    }
                }
                
            }
            // Степень свободы
            int freedom = validIntervals - 1;

            var Xi2Table = new Dictionary<int, double>()
            {
            {1, 6.635}, {2, 9.210}, {3, 11.345}, {4, 13.277}, {5, 15.086},
            {6, 16.812}, {7, 18.475}, {8, 20.090}, {9, 21.666}, {10, 23.209},
            {11, 24.725}, {12, 26.217}, {13, 27.688}, {14, 29.141}, {15, 30.578},
            {16, 32.000}, {17, 33.409}, {18, 34.805}, {19, 36.191}, {20, 37.566},
            {21, 38.932}, {22, 40.289}, {23, 41.638}, {24, 42.980}, {25, 44.314},
            {26, 45.642}, {27, 46.963}, {28, 48.278}, {29, 49.588}, {30, 50.892}
            };

            if (Xi2Table.ContainsKey(freedom))
            {
                if (Xi2 < Xi2Table[freedom]) lblXiToF.Text = "Гипотеза принимается";
                else lblXiToF.Text = "Гипотеза отклоняется";

            }
            lblXi.Text = $"Хи-квадрат: {Xi2:F5}";
        }
    }
}

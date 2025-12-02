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

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear(); // Очистка диаграммы

            Random rnd = new Random();
            int arr_size = mlText.Lines.Length;
            double[] tests = new double[arr_size];
            for (int i = 0; i < arr_size; i++)
            {
                string s = mlText.Lines[i];
                // s = s.Replace(',', '.');
                tests[i] = Convert.ToDouble(s);
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
        }
    }
}

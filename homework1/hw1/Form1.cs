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

            // Заполняем список "тестов" случайными значениями, записываем максимальное и минимальное значение
            int arr_size = Convert.ToInt32(textBox1.Text);
            double[] tests = new double[arr_size];
            double mn = double.MaxValue;
            double mx = double.MinValue;
            for (int i = 0; i < arr_size; i++)
            {
                tests[i] = rnd.NextDouble();
                mx = Math.Max(tests[i], mx);
                mn = Math.Min(mn, tests[i]);
            }

            // Для разделения тестов на интервалы найдём левую и правую границу для них – минимальное и максимальное значение соотв.
            double left_bound = mn;
            double right_bound = mx;
            int interval = Convert.ToInt32(textBox2.Text); // Узнаем кол-во интервалов
            int[] intervals = new int[interval]; // И объявим массив, в котором будем хранить сколько "тестов" попало в интервал
            double step = (right_bound - left_bound) / interval; // Шаг интервала
            //
            //                        left_bound+step   left_bound+(2*step)   left_bound+(3*step)   left_bound+(4*step)
            // left_bound --> |_____________________|_____________________|_____________________|_____________________| <-- right_bound
            //
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

            for (int i = 1; i <= interval; i++)
            {
                chart1.Series[0].Points.AddXY(i, intervals[i - 1]); // Рисуем столбики
            }

            label3.Text = String.Format("min = {0:f5}", mn);
            label4.Text = String.Format("max = {0:f5}", mx);
        }
    }
}

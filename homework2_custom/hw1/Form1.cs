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
using System.Windows.Forms.DataVisualization.Charting;

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
            double userMu = Convert.ToDouble(tbMu.Text);
            double userSigma = Convert.ToDouble(tbSigma.Text);

            chart1.Series[0].Points.Clear(); // Очистка диаграммы
            chart1.ChartAreas[0].AxisX.Minimum = -10; // Зададим границы, чтобы увидеть разницу при изменении Сигмы
            chart1.ChartAreas[0].AxisX.Maximum = 10;
            chart1.Series[0].Points.AddXY(userMu, 0);

            Random rnd = new Random();

            // Заполняем список "тестов" случайными значениями, записываем максимальное и минимальное значения
            int arr_size = Convert.ToInt32(textBox1.Text);
            double[] tests = new double[arr_size];

            // Нормальное распределение с параметрами μ, σ;
            // Z - СТАНДАРТНАЯ (центр 0, дисп. 1) нормальная случайная величина
            // (https://w.wiki/GGiD) - преобразование Бокса-Мюллера, при помощи которого получаем Z
            for (int i = 0; i < arr_size; i++)
            {
                double r = 1.0 - rnd.NextDouble(); //NextDouble возвр. значения из [0.0, 1.0)
                double phi = 1.0 - rnd.NextDouble(); // Отнимем случайное число от 1, чтобы получить интервал (0.0, 1.0]
                double z = Math.Cos(2.0 * Math.PI * phi) * Math.Sqrt(-2.0 * Math.Log(r)); // Получим стандартную норм. случ. вел.
                //                  /\
                //                Первый вариант Метода Бокса - Мюллера, формула Z0
                //                Переход к общ. нормальному распределению
                //                  \/
                tests[i] = userMu + userSigma * z;
            }

            Array.Sort(tests);

            // Для разделения тестов на интервалы найдём левую и правую границу для них – минимальное и максимальное значение соотв.
            int columns = Convert.ToInt32(textBox2.Text); // Узнаем кол-во колонок
            double left_bound = tests.Min();
            double right_bound = tests.Max();
            double step = (right_bound - left_bound) / columns;

            for (int b = 0; b < columns; b++)
            {
                double left = left_bound + b * step;
                double right = left + step;

                int countInColumn = 0;
                for (int i = 0; i < arr_size; i++)
                {
                    if (tests[i] >= left && tests[i] < right)
                        countInColumn++;
                }
                Debug.WriteLine($"Точка {left + step / 2:F2}");
                chart1.Series[0].Points.AddXY(Math.Round(left+step/2, 2), countInColumn);
            }


            double mean = tests.Average(); // Среднее

            double median; // Медиана
            if (tests.Length % 2 == 0) median = (tests[tests.Length / 2] + tests[tests.Length / 2 + 1]) / 2.0;
            else median = tests[tests.Length / 2];

            // Поиск моды, cmax – кол-во встреч текущего элемента, rmax - наибольшее значение встреч
            // Работает, как можно легко понять, ОЧЕНЬ медлнно
            double mode = tests[0]; 
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
                    if (Math.Round(tests[j], 3) == Math.Round(tests[i], 3)) cmax++;
                }
            }

            double disp = 0; // Поиск дисперсии
            for (int i = 0; i < arr_size; i++)
            {
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

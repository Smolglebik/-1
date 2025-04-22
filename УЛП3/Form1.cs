using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SeriesCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Настройка элементов управления при загрузке формы
            lblN.Text = "n = 1";
            scrollBarN.Minimum = 1;
            scrollBarN.Maximum = 50; // Уменьшил максимальное значение для предотвращения переполнения
            scrollBarN.Value = 1;
            scrollBarN.LargeChange = 5;
            scrollBarN.SmallChange = 1;

            CalculateResults(1);
        }

        private void scrollBarN_Scroll(object sender, ScrollEventArgs e)
        {
            int n = scrollBarN.Value;
            lblN.Text = $"n = {n}";
            CalculateResults(n);
        }

        private void CalculateResults(int n)
        {
            try
            {
                // Вычисление суммы в цикле
                long cycleSum = CalculateCycleSum(n);
                txtCycleResult.Text = cycleSum.ToString();

                // Вычисление суммы по формуле
                long formulaSum = CalculateFormulaSum(n);
                txtFormulaResult.Text = formulaSum.ToString();

                // Проверка совпадения результатов
                if (cycleSum == formulaSum)
                {
                    lblVerification.Text = "Результаты совпадают";
                    lblVerification.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblVerification.Text = "Результаты не совпадают!";
                    lblVerification.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (OverflowException)
            {
                txtCycleResult.Text = "Переполнение!";
                txtFormulaResult.Text = "Переполнение!";
                lblVerification.Text = "Ошибка вычислений";
                lblVerification.ForeColor = System.Drawing.Color.Red;
            }
            catch (Exception ex)
            {
                txtCycleResult.Text = "Ошибка!";
                txtFormulaResult.Text = "Ошибка!";
                lblVerification.Text = $"Ошибка: {ex.Message}";
                lblVerification.ForeColor = System.Drawing.Color.Red;
            }
        }

        private long CalculateCycleSum(int n)
        {
            checked // Проверка на переполнение
            {
                long sum = 0;
                for (int i = 1; i <= n; i++)
                {
                    long term = Power(i, 5); // Используем безопасное возведение в степень
                    if (i % 2 == 0)
                    {
                        sum -= term;
                    }
                    else
                    {
                        sum += term;
                    }
                }
                return sum;
            }
        }

        private long CalculateFormulaSum(int n)
        {
            checked
            {
                try
                {
                    double nDouble = n;
                    double part = Math.Pow(-1, n - 1);
                    double formula = (1.0 / 4.0) * (1 + part * (5 * Math.Pow(nDouble, 2) - 5 * Math.Pow(nDouble, 4) - 2 * Math.Pow(nDouble, 5) - 1));
                    return (long)Math.Round(formula);
                }
                catch (OverflowException)
                {
                    return long.MinValue; // Вернем минимальное значение в случае ошибки
                }
            }
        }

        // Безопасное возведение в степень для предотвращения переполнения
        private static long Power(int baseNum, int exponent)
        {
            checked
            {
                long result = 1;
                for (int i = 0; i < exponent; i++)
                {
                    result *= baseNum;
                }
                return result;
            }
        }
    }
}
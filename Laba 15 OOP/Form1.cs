using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_15_OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e) // TASK 1
        {
            try
            {
                int x = Convert.ToInt32(valueX.Text);
                int y = Convert.ToInt32(valueY.Text);
                MessageBox.Show("Значення виразу = " + ((3 + Math.Exp(y - 1)) / (1 + x * x * Math.Abs(y - Math.Tan(x)))));
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Ділити на нуль не можна!!!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCalculate_Click(object sender, EventArgs e) // TASK 2
        {
            // перевіримо, чи всі три текстові поля містять значення
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox9.Text))
            {
                MessageBox.Show("Будь ласка, введіть довжини всіх сторін трикутника.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // вийти з методу, щоб не продовжувати обчислення
            }
            // Зчитуємо значення сторін з текстових полів
            double a = double.Parse(textBox9.Text);
            double b = double.Parse(textBox1.Text);
            double c = double.Parse(textBox2.Text);

            // перевіримо, чи може існувати трикутник з введеними сторонами
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                MessageBox.Show("Такого трикутника не існує. Будь ласка, введіть правильні значення сторін.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // вийти з методу, щоб не продовжувати обчислення
            }

            // Знаходимо кути трикутника у радіанах
            double alpha = Math.Acos((b * b + c * c - a * a) / (2 * b * c));
            double beta = Math.Acos((a * a + c * c - b * b) / (2 * a * c));
            double gamma = Math.Acos((a * a + b * b - c * c) / (2 * a * b));

            // Конвертуємо радіани в градуси
            double alphaDeg = alpha * 180 / Math.PI;
            double betaDeg = beta * 180 / Math.PI;
            double gammaDeg = gamma * 180 / Math.PI;

            // Виводимо результати у текстові поля
            label10.Text = alpha.ToString();
            label12.Text = beta.ToString();
            label13.Text = gamma.ToString();

            label14.Text = alphaDeg.ToString();
            label15.Text = betaDeg.ToString();
            label16.Text = gammaDeg.ToString();

        }           

        private void buttonPage3_Click_1(object sender, EventArgs e) // TASK 3
        {
            int N;
            bool isInteger = int.TryParse(chislo.Text, out N); // Перевірка на те, чи є введене значення цілим числом

            if (!isInteger || N < 10 || N > 99)
            {
                MessageBox.Show("Введіть двозначне ціле число!"); // Виведення повідомлення про помилку
                return;
            }

            if (isInteger && N >= 10 && N <= 99 && N % 2 == 0) // Перевірка на те, чи є введене значення парним двозначним числом
            {
                MessageBox.Show("True"); // Виведення результату "True"
            }
            else
            {
                MessageBox.Show("False"); // Виведення результату "False"
            }
        }

        private void buy_Click(object sender, EventArgs e) //TASK 4
        {
            try
            {
                // Отримуємо вартість книг та суму грошей, внесену покупцем
                decimal price = decimal.Parse(Price.Text);
                decimal money = decimal.Parse(Money.Text);

                // Обчислюємо решту
                decimal change = money - price;

                // Виводимо результат
                if (change < 0)
                {
                    MessageBox.Show($"Необхідно додатково внести {Math.Abs(change):C}");
                }
                else if (change == 0)
                {
                    MessageBox.Show("Дякуємо!");
                }
                else
                {
                    MessageBox.Show($"Візьміть решту {change:C}");
                }
            }
            catch (FormatException)
            {
                // Обробляємо помилку форматування введеного тексту
                MessageBox.Show("Введіть коректні дані!");
            }
        }

        private void button1_Click(object sender, EventArgs e) //TASK 5
        {
            int n = Convert.ToInt32(Input.Text);
            listBox1.Items.Clear();
            listBox1.Items.Add("Усі досконалі числа менше заданого числа:");

            for (int i = 1; i < n; i++)
            {
                int sum = 0;
                for (int j = 1; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        sum += j;
                    }
                }
                if (sum == i)
                {
                    listBox1.Items.Add(i);
                }
            }
        }
        private void processButton_Click_1(object sender, EventArgs e) // TASK 6
        {
            try
            {
                // Отримання введеного користувачем масиву
                string[] inputArray = inputTxT.Text.Split(' ');
                int n = inputArray.Length;
                int[] array = new int[n];
                for (int i = 0; i < n; i++)
                {
                    array[i] = Convert.ToInt32(inputArray[i]);
                }

                // Отримання значення k
                int k = Convert.ToInt32(kTxT.Text);

                // Формування нового масиву
                int[] newArray = new int[n];
                int count = 0;
                for (int i = 0; i < n; i++)
                {
                    if (array[i] % 10 == k)
                    {
                        newArray[count] = array[i];
                        count++;
                    }
                }

                // Виведення результату
                string result = "";
                for (int i = 0; i < count; i++)
                {
                    result += newArray[i] + " ";
                }
                MessageBox.Show("Числа що закінчуються числом К: " + result);
            }
            catch (FormatException)
            {
                MessageBox.Show("Некоректний формат введених даних. Будь ласка, перевірте вхідні дані та спробуйте ще раз.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e) // TASK 7
        {
            string text = someTxT.Text;
            string[] words = text.Split(' ');

            int shortestLength = int.MaxValue;
            int longestLength = 0;

            foreach (string word in words)
            {
                int length = word.Length;
                if (length < shortestLength)
                {
                    shortestLength = length;
                }
                if (length > longestLength)
                {
                    longestLength = length;
                }
            }

            MessageBox.Show($"Найкоротше слово має довжину {shortestLength}, а найдовше - {longestLength}.");

        }

    }
}
    


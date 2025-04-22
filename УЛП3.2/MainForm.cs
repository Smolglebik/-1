using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace ZodiacApp
{
    public partial class MainForm : Form
    {
        private List<ZNAK> people = new List<ZNAK>();
        private readonly string dataFilePath = "zodiac_data.dat";
        private readonly Random random = new Random();

        // Списки для генерации случайных данных
        private readonly string[] lastNames = { "Иванов", "Петров", "Сидоров", "Смирнов", "Кузнецов",
                                              "Васильев", "Попов", "Новиков", "Федоров", "Морозов" };
        private readonly string[] firstNames = { "Алексей", "Дмитрий", "Сергей", "Андрей", "Михаил",
                                              "Елена", "Ольга", "Наталья", "Ирина", "Анна" };
        private readonly string[] zodiacSigns = { "Овен", "Телец", "Близнецы", "Рак", "Лев",
                                                "Дева", "Весы", "Скорпион", "Стрелец", "Козерог",
                                                "Водолей", "Рыбы" };

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(dataFilePath))
            {
                LoadDataFromFile();
                DisplayAllData();
            }
        }

        // Генерация случайных данных
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            people = GenerateRandomData(10);
            SaveDataToFile();
            DisplayAllData();
            MessageBox.Show("Сгенерировано 10 случайных записей и сохранено в файл.", "Успех");
        }

        // Загрузка данных из файла
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (File.Exists(dataFilePath))
            {
                LoadDataFromFile();
                DisplayAllData();
                MessageBox.Show("Данные успешно загружены из файла.", "Успех");
            }
            else
            {
                MessageBox.Show("Файл данных не найден.", "Ошибка");
            }
        }

        // Поиск по знаку зодиака
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sign = txtSearchSign.Text.Trim();
            if (string.IsNullOrEmpty(sign))
            {
                MessageBox.Show("Введите знак зодиака для поиска.", "Ошибка");
                return;
            }

            List<ZNAK> found = people.FindAll(p =>
                p.ZodiacSign.Equals(sign, StringComparison.OrdinalIgnoreCase));

            if (found.Count > 0)
            {
                lstResults.Items.Clear();
                foreach (var person in found)
                {
                    lstResults.Items.Add(person.ToString());
                }
            }
            else
            {
                MessageBox.Show($"Людей со знаком '{sign}' не найдено.", "Результат");
            }
        }

        // Генерация случайных данных
        private List<ZNAK> GenerateRandomData(int count)
        {
            var randomData = new List<ZNAK>();

            for (int i = 0; i < count; i++)
            {
                var person = new ZNAK
                {
                    LastName = lastNames[random.Next(lastNames.Length)],
                    FirstName = firstNames[random.Next(firstNames.Length)],
                    ZodiacSign = zodiacSigns[random.Next(zodiacSigns.Length)],
                    BirthDate = GenerateRandomBirthDate()
                };
                randomData.Add(person);
            }

            return randomData;
        }

        // Генерация случайной даты рождения (от 18 до 70 лет назад)
        private DateTime GenerateRandomBirthDate()
        {
            int year = DateTime.Now.Year - random.Next(18, 70);
            int month = random.Next(1, 13);
            int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);

            return new DateTime(year, month, day);
        }

        // Сохранение данных в файл
        private void SaveDataToFile()
        {
            try
            {
                using (FileStream fs = new FileStream(dataFilePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, people);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка");
            }
        }

        // Загрузка данных из файла
        private void LoadDataFromFile()
        {
            try
            {
                using (FileStream fs = new FileStream(dataFilePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    people = (List<ZNAK>)formatter.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка");
            }
        }

        // Отображение всех данных
        private void DisplayAllData()
        {
            lstResults.Items.Clear();
            foreach (var person in people)
            {
                lstResults.Items.Add(person.ToString());
            }
        }
    }
}
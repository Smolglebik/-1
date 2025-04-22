using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string inputFile = "текстисходник.txt";
        string outputFile = "текстрезультат.txt";

        try
        {
            // 1. Проверка существования файла
            if (!File.Exists(inputFile))
            {
                Console.WriteLine($"Файл {inputFile} не найден!");
                Console.WriteLine("Создайте файл 'текстисходник.txt' с текстом для анализа.");
                return;
            }

            // 2. Чтение и фильтрация текста
            string text = File.ReadAllText(inputFile).ToLower();
            var filteredText = text.Where(c => char.IsLetter(c) && c <= 'z'); // Только английские буквы

            // 3. Подсчет частоты букв
            Dictionary<char, int> letterCounts = new Dictionary<char, int>();

            // Инициализация для всех английских букв
            for (char c = 'a'; c <= 'z'; c++)
            {
                letterCounts.Add(c, 0);
            }

            // Подсчет
            foreach (char c in filteredText)
            {
                if (letterCounts.ContainsKey(c))
                {
                    letterCounts[c]++;
                }
            }

            // 4. Запись результатов
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                writer.WriteLine("Отчет о частоте букв");
                writer.WriteLine("====================");
                writer.WriteLine($"Анализируемый файл: {inputFile}");
                writer.WriteLine($"Дата анализа: {DateTime.Now}\n");

                writer.WriteLine("Буква | Количество | График");
                writer.WriteLine("------|------------|-------");

                var sortedLetters = letterCounts.OrderBy(x => x.Key);
                foreach (var pair in sortedLetters)
                {
                    writer.WriteLine($"{char.ToUpper(pair.Key)}    | {pair.Value,10} | {new string('■', pair.Value)}");
                }

                // Статистика
                int totalLetters = letterCounts.Sum(x => x.Value);
                var mostFrequent = letterCounts.OrderByDescending(x => x.Value).First();

                writer.WriteLine("\nИтоговая статистика:");
                writer.WriteLine($"Всего букв: {totalLetters}");
                writer.WriteLine($"Уникальных букв: {letterCounts.Count(x => x.Value > 0)}");
                writer.WriteLine($"Самая частая буква: '{char.ToUpper(mostFrequent.Key)}' ({mostFrequent.Value} раз)");
            }

            Console.WriteLine($"Анализ завершен. Результаты сохранены в {outputFile}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
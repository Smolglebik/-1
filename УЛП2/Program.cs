using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string inputFile = "УЛП2.txt";
        string outputFile = "output.txt";

        try
        {
            // Чтение всех чисел из файла
            double[] numbers = File.ReadAllLines(inputFile)
                                 .Select(line => double.Parse(line))
                                 .ToArray();

            if (numbers.Length == 0)
            {
                Console.WriteLine("Файл пуст!");
                return;
            }

            // Находим минимум и максимум
            double min = numbers.Min();
            double max = numbers.Max();

            // Обрабатываем числа и записываем в выходной файл
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                foreach (double num in numbers)
                {
                    double divided = num / min + max;
                    writer.WriteLine(divided.ToString("0.########")); // Запись с 8 знаками после запятой
                }

                // Добавляем максимум в конец файла
                writer.WriteLine($"\nМаксимум: {max}");
            }

            Console.WriteLine($"Обработка завершена. Результат записан в {outputFile}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
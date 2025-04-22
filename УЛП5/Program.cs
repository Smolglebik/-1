using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using УЛП5.Models;

namespace УЛП5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Создаем документы
            var doc1 = new Document("Важный документ", "Это секретная информация");
            var doc2 = new EncryptedDocument("Секретный файл", "Сверхсекретные данные", "key123");

            // 1. Работа с JSON
            Console.WriteLine("\n=== JSON Сериализация ===");

            // Сериализация в JSON
            string jsonDoc1 = JsonSerializer.Serialize(doc1, new JsonSerializerOptions { WriteIndented = true });
            string jsonDoc2 = JsonSerializer.Serialize(doc2, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText("document.json", jsonDoc1);
            File.WriteAllText("encrypted_document.json", jsonDoc2);
            Console.WriteLine("Документы сохранены в JSON файлы");

            // Десериализация из JSON
            var jsonDoc1FromFile = File.ReadAllText("document.json");
            var jsonDoc2FromFile = File.ReadAllText("encrypted_document.json");

            Document deserializedDoc1 = JsonSerializer.Deserialize<Document>(jsonDoc1FromFile);
            EncryptedDocument deserializedDoc2 = JsonSerializer.Deserialize<EncryptedDocument>(jsonDoc2FromFile);

            Console.WriteLine("\nДесериализованные из JSON документы:");
            deserializedDoc1.Display();
            deserializedDoc2.Display();

            // 2. Работа с XML
            Console.WriteLine("\n=== XML Сериализация ===");

            // Сериализация в XML
            var xmlSerializer = new XmlSerializer(typeof(AbstractDocument), new[] { typeof(Document), typeof(EncryptedDocument) });

            using (var writer = new StreamWriter("document.xml"))
            {
                xmlSerializer.Serialize(writer, doc1);
            }

            using (var writer = new StreamWriter("encrypted_document.xml"))
            {
                xmlSerializer.Serialize(writer, doc2);
            }
            Console.WriteLine("Документы сохранены в XML файлы");

            // Десериализация из XML
            AbstractDocument xmlDoc1, xmlDoc2;

            using (var reader = new StreamReader("document.xml"))
            {
                xmlDoc1 = (AbstractDocument)xmlSerializer.Deserialize(reader);
            }

            using (var reader = new StreamReader("encrypted_document.xml"))
            {
                xmlDoc2 = (AbstractDocument)xmlSerializer.Deserialize(reader);
            }

            Console.WriteLine("\nДесериализованные из XML документы:");
            xmlDoc1.Display();
            xmlDoc2.Display();

            // 3. Использование using и Dispose
            Console.WriteLine("\n=== Использование Dispose ===");

            using (var tempDoc = new EncryptedDocument("Временный файл", "Данные", "tempkey"))
            {
                tempDoc.Display();
                tempDoc.Encrypt();
                tempDoc.Display();
            }

            // 4. Вызов сборщика мусора для демонстрации финализаторов
            Console.WriteLine("\n=== Сборка мусора ===");
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
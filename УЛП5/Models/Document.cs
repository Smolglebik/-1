using System;
using System.Xml.Serialization;

namespace УЛП5.Models
{
    public class Document : AbstractDocument
    {
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;

        public Document() : this("Без названия", "") { }

        public Document(string title, string content)
        {
            Title = title;
            Content = content;
            Console.WriteLine($"Документ создан: {Title}");
        }

        public override void Display()
        {
            Console.WriteLine($"Документ: {Title}");
            Console.WriteLine($"Создан: {Created}, Изменен: {Modified}");
            Console.WriteLine($"Содержимое: {Content}");
        }

        public void UpdateContent(string newContent)
        {
            Content = newContent;
            Modified = DateTime.Now;
        }
    }
}
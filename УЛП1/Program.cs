using System;
using System.Text;

// Базовый абстрактный класс для полиморфизма
public abstract class AbstractDocument : IDisposable
{
    protected string content;
    protected string title;
    public bool disposed = false;

    public abstract void Display(); // Абстрактный метод для полиморфизма

    // Защищенный виртуальный метод для паттерна Dispose
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Освобождаем управляемые ресурсы
                Console.WriteLine($"Освобождаем ресурсы документа: {title}");
            }

            // Освобождаем неуправляемые ресурсы
            content = null;
            title = null;

            disposed = true;
        }
    }

    // Финализатор (деструктор)
    ~AbstractDocument()
    {
        Console.WriteLine($"Финализатор вызван для: {title}");
        Dispose(false);
    }

    // Реализация IDisposable
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public string GetContent() => content;
    public string GetTitle() => title;
}

// Основной класс Документ
public class Document : AbstractDocument
{
    // Приватный вложенный класс для обработки метаданных
    private class DocumentMetadata
    {
        public DateTime Created { get; } = DateTime.Now;
        public DateTime Modified { get; private set; } = DateTime.Now;

        public void UpdateModified() => Modified = DateTime.Now;
    }

    private readonly DocumentMetadata metadata;

    public Document() : this("Untitled", "") { }

    public Document(string title, string content)
    {
        this.title = title;
        this.content = content;
        this.metadata = new DocumentMetadata();
        Console.WriteLine($"Документ создан: {title}");
    }

    public override void Display()
    {
        Console.WriteLine($"Документ: {title}");
        Console.WriteLine($"Создан: {metadata.Created}, Изменен: {metadata.Modified}");
        Console.WriteLine($"Содержимое: {content}");
    }

    public void UpdateContent(string newContent)
    {
        content = newContent;
        metadata.UpdateModified();
    }
}

// Зашифрованный документ с полиморфным поведением
public class EncryptedDocument : AbstractDocument
{
    private string encryptionKey;
    private bool isEncrypted;

    // Приватный класс для обработки шифрования
    private class EncryptionHelper
    {
        public static string SimpleEncrypt(string data, string key)
        {
            StringBuilder result = new StringBuilder(data.Length);
            for (int i = 0; i < data.Length; i++)
                result.Append((char)(data[i] ^ key[i % key.Length]));
            return result.ToString();
        }
    }

    public EncryptedDocument(string key) : this("Encrypted", "", key) { }

    public EncryptedDocument(string title, string content, string key, bool encrypted = false)
    {
        this.title = title;
        this.encryptionKey = key;
        this.isEncrypted = encrypted;
        this.content = encrypted ? EncryptionHelper.SimpleEncrypt(content, key) : content;
        Console.WriteLine($"Зашифрованный документ создан: {title}");
    }

    public override void Display()
    {
        Console.WriteLine($"Зашифрованный документ: {title}");
        Console.WriteLine($"Статус: {(isEncrypted ? "ЗАШИФРОВАН" : "расшифрован")}");
        Console.WriteLine($"Содержимое: {(isEncrypted ? "[ЗАШИФРОВАННЫЕ ДАННЫЕ]" : content)}");
    }

    public void Encrypt()
    {
        if (!isEncrypted)
        {
            content = EncryptionHelper.SimpleEncrypt(content, encryptionKey);
            isEncrypted = true;
        }
    }

    public void Decrypt()
    {
        if (isEncrypted)
        {
            content = EncryptionHelper.SimpleEncrypt(content, encryptionKey);
            isEncrypted = false;
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                Console.WriteLine($"Освобождаем ресурсы зашифрованного документа: {title}");
            }

            encryptionKey = null;
            base.Dispose(disposing);
        }
    }

    ~EncryptedDocument()
    {
        Console.WriteLine($"Финализатор вызван для зашифрованного документа: {title}");
    }
}

// Пример использования
public class Program
{
    public static void Main()
    {
        // Полиморфизм: работаем через базовый тип
        AbstractDocument[] documents = new AbstractDocument[2];

        documents[0] = new Document("Важный документ", "Это секретная информация");
        documents[1] = new EncryptedDocument("Секретный файл", "Сверхсекретные данные", "key123");

        foreach (var doc in documents)
        {
            doc.Display(); // Полиморфный вызов
            Console.WriteLine();
        }

        // Явный вызов Dispose
        documents[0].Dispose();

        // Использование using для автоматического вызова Dispose
        using (var encDoc = new EncryptedDocument("Временный файл", "Данные", "tempkey"))
        {
            encDoc.Display();
            encDoc.Encrypt();
            encDoc.Display();
        } // Dispose вызовется автоматически

        // Финализаторы будут вызваны сборщиком мусора
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
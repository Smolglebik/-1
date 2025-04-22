using System;
using System.Text;
using System.Xml.Serialization;

namespace УЛП5.Models
{
    public class EncryptedDocument : AbstractDocument
    {
        public string EncryptionKey { get; set; }
        public bool IsEncrypted { get; set; }

        public EncryptedDocument() : this("secretkey") { }

        public EncryptedDocument(string key) : this("Зашифрованный", "", key) { }

        public EncryptedDocument(string title, string content, string key, bool encrypted = false)
        {
            Title = title;
            EncryptionKey = key;
            IsEncrypted = encrypted;
            Content = encrypted ? SimpleEncrypt(content, key) : content;
            Console.WriteLine($"Зашифрованный документ создан: {Title}");
        }

        public override void Display()
        {
            Console.WriteLine($"Зашифрованный документ: {Title}");
            Console.WriteLine($"Статус: {(IsEncrypted ? "ЗАШИФРОВАН" : "расшифрован")}");
            Console.WriteLine($"Содержимое: {(IsEncrypted ? "[ЗАШИФРОВАННЫЕ ДАННЫЕ]" : Content)}");
        }

        public void Encrypt()
        {
            if (!IsEncrypted)
            {
                Content = SimpleEncrypt(Content, EncryptionKey);
                IsEncrypted = true;
            }
        }

        public void Decrypt()
        {
            if (IsEncrypted)
            {
                Content = SimpleEncrypt(Content, EncryptionKey);
                IsEncrypted = false;
            }
        }

        private static string SimpleEncrypt(string data, string key)
        {
            StringBuilder result = new StringBuilder(data.Length);
            for (int i = 0; i < data.Length; i++)
                result.Append((char)(data[i] ^ key[i % key.Length]));
            return result.ToString();
        }

        protected override void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    Console.WriteLine($"Освобождаем ресурсы зашифрованного документа: {Title}");
                }
                EncryptionKey = null;
                base.Dispose(disposing);
            }
        }

        ~EncryptedDocument()
        {
            Console.WriteLine($"Финализатор вызван для зашифрованного документа: {Title}");
        }
    }
}
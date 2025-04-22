using System;
using System.Reflection.Metadata;
using System.Xml.Serialization;

namespace УЛП5.Models
{
    [XmlInclude(typeof(Document))]
    [XmlInclude(typeof(EncryptedDocument))]
    public abstract class AbstractDocument : IDisposable
    {
        public string Content { get; set; }
        public string Title { get; set; }
        [XmlIgnore]
        public bool Disposed { get; protected set; } = false;

        public abstract void Display();

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    Console.WriteLine($"Освобождаем ресурсы документа: {Title}");
                }
                Content = null;
                Title = null;
                Disposed = true;
            }
        }

        ~AbstractDocument()
        {
            Console.WriteLine($"Финализатор вызван для: {Title}");
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
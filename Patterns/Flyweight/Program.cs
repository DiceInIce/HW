using System;
using System.Collections.Generic;

namespace DocumentWorkflow
{
    public class DocumentMetadata
    {
        public string TemplateId { get; }
        public string CompanyName { get; }
        public string Inn { get; }
        public string Kpp { get; }
        public string LegalAddress { get; }
        public byte[] LogoBytes { get; }

        public DocumentMetadata(string templateId, string companyName, string inn, string kpp, string legalAddress, byte[] logoBytes)
        {
            TemplateId = templateId;
            CompanyName = companyName;
            Inn = inn;
            Kpp = kpp;
            LegalAddress = legalAddress;
            LogoBytes = logoBytes;
        }

        public void DisplayMetadata()
        {
            Console.WriteLine($"[Метаданные шаблона: {TemplateId}]");
            Console.WriteLine($"Компания: {CompanyName}");
            Console.WriteLine($"ИНН: {Inn}, КПП: {Kpp}");
            Console.WriteLine($"Юридический адрес: {LegalAddress}");
            Console.WriteLine($"Логотип: {LogoBytes?.Length ?? 0} байт\n");
        }
    }


    public class Document
    {
        public string DocumentNumber { get; }
        public DateTime DateCreated { get; }
        public string Content { get; }
        public string Signature { get; }
        public DocumentMetadata Metadata { get; }

        public Document(string documentNumber, DateTime dateCreated, string content, string signature, DocumentMetadata metadata)
        {
            DocumentNumber = documentNumber;
            DateCreated = dateCreated;
            Content = content;
            Signature = signature;
            Metadata = metadata;
        }

        public void Display()
        {
            Console.WriteLine("--- Документ ---");
            Console.WriteLine($"№: {DocumentNumber}");
            Console.WriteLine($"Дата: {DateCreated}");
            Console.WriteLine($"Содержание: {Content}");
            Console.WriteLine($"Подпись: {Signature}");
            Console.WriteLine("--- Общие метаданные ---");
            Metadata.DisplayMetadata();
            Console.WriteLine("------------------------------\n");
        }
    }

    public static class DocumentMetadataFactory
    {
        private static readonly Dictionary<string, DocumentMetadata> _cache = new();

        public static DocumentMetadata GetMetadata(
            string templateId,
            string companyName,
            string inn,
            string kpp,
            string legalAddress,
            byte[] logoBytes)
        {
            string key = $"{inn}_{templateId}";
            if (_cache.ContainsKey(key))
            {
                Console.WriteLine($"[Фабрика] Метаданные найдены в кеше: {key}");
                return _cache[key];
            }

            Console.WriteLine($"[Фабрика] Создание новых метаданных: {key}");
            var metadata = new DocumentMetadata(templateId, companyName, inn, kpp, legalAddress, logoBytes);
            _cache[key] = metadata;
            return metadata;
        }
    }

    /// <summary>
    /// Демонстрация работы
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var metadata1 = DocumentMetadataFactory.GetMetadata(
                "TEMPLATE_1",
                "ООО МояОборона",
                "1234567890",
                "987654321",
                "г. Москва, ул. Пушкина, д. 1",
                new byte[] { 1, 2, 3 });

            var doc1 = new Document("001", DateTime.Now, "Служебная записка о командировке", "Иванов И.И.", metadata1);
            var doc2 = new Document("002", DateTime.Now, "Приказ о премировании", "Петров П.П.", metadata1);

            var metadata2 = DocumentMetadataFactory.GetMetadata(
                "TEMPLATE_1",
                "ООО МояОборона",
                "1234567890",
                "987654321",
                "г. Москва, ул. Пушкина, д. 1",
                new byte[] { 1, 2, 3 });

            var doc3 = new Document("003", DateTime.Now, "Акт выполненных работ", "Сидоров С.С.", metadata2);

            // Вывод документов
            doc1.Display();
            doc2.Display();
            doc3.Display();
        }

    }
}

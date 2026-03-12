using System;
using System.IO;
using System.Threading;

class Program
{
  private static readonly string filePath = "shared_file.txt";
  private static readonly object fileLock = new object();
  private static int writeCount = 0;
  private static readonly int maxWrites = 10;
  private static bool shouldStop = false;

  static void Main(string[] args)
  {
    // Удаляем файл, если он существует
    if (File.Exists(filePath))
    {
      File.Delete(filePath);
    }

    // Создаем потоки
    Thread writerThread = new Thread(Writer);
    Thread readerThread = new Thread(Reader);

    // Запускаем потоки
    writerThread.Start();
    readerThread.Start();

    // Ожидаем завершения потоков
    writerThread.Join();
    readerThread.Join();

    Console.WriteLine("Программа завершена.");
  }

  static void Writer()
  {
    int counter = 0;
    while (counter < maxWrites)
    {
      try
      {
        // Синхронизация записи
        lock (fileLock)
        {
          using (StreamWriter writer = new StreamWriter(filePath, true))
          {
            string content = $"Запись {++counter} - {DateTime.Now:HH:mm:ss.fff}";
            writer.WriteLine(content);
            Console.WriteLine($"Записано: {content}");
          }
        }

        // Увеличиваем счетчик записей
        Interlocked.Increment(ref writeCount);

        // Ждем 200 миллисекунд
        Thread.Sleep(200);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Ошибка записи: {ex.Message}");
        break;
      }
    }

    // Финальное чтение
    shouldStop = true;
    Thread.Sleep(100); // Небольшая задержка для завершения чтения

    lock (fileLock)
    {
      if (File.Exists(filePath))
      {
        Console.WriteLine("Финальное чтение:");
        string content = File.ReadAllText(filePath);
        Console.WriteLine(content);
      }
    }
  }

  static void Reader()
  {
    while (!shouldStop || writeCount < maxWrites)
    {
      try
      {
        // Синхронизация чтения
        lock (fileLock)
        {
          if (File.Exists(filePath))
          {
            string content = File.ReadAllText(filePath);
            if (!string.IsNullOrEmpty(content))
            {
              Console.WriteLine($"Чтение: {content}");
            }
          }
        }

        // Ждем 500 миллисекунд
        Thread.Sleep(500);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Ошибка чтения: {ex.Message}");
      }
    }
  }
}

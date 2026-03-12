using System;
using System.IO;
using System.Threading;

class Program2
{
  private static readonly string filePath = "shared_file_stream.txt";
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
    Thread writerThread = new Thread(WriterStream);
    Thread readerThread = new Thread(ReaderStream);

    // Запускаем потоки
    writerThread.Start();
    readerThread.Start();

    // Ожидаем завершения потоков
    writerThread.Join();
    readerThread.Join();

    Console.WriteLine("Программа завершена.");
  }

  static void WriterStream()
  {
    int counter = 0;
    while (counter < maxWrites)
    {
      try
      {
        // Синхронизация записи через FileStream
        lock (fileLock)
        {
          using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
          using (StreamWriter writer = new StreamWriter(fs))
          {
            string content = $"Запись {++counter} - {DateTime.Now:HH:mm:ss.fff}";
            writer.WriteLine(content);
            Console.WriteLine($"Записано: {content}");
          }
        }

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
    Thread.Sleep(100);

    lock (fileLock)
    {
      if (File.Exists(filePath))
      {
        Console.WriteLine("Финальное чтение:");
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        using (StreamReader reader = new StreamReader(fs))
        {
          string content = reader.ReadToEnd();
          Console.WriteLine(content);
        }
      }
    }
  }

  static void ReaderStream()
  {
    while (!shouldStop || writeCount < maxWrites)
    {
      try
      {
        // Синхронизация чтения через FileStream
        lock (fileLock)
        {
          if (File.Exists(filePath))
          {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader reader = new StreamReader(fs))
            {
              string content = reader.ReadToEnd();
              if (!string.IsNullOrEmpty(content))
              {
                Console.WriteLine($"Чтение: {content}");
              }
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

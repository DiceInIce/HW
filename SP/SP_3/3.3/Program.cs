using System;
using System.IO;
using System.Threading;

class Program3
{
  private static readonly string filePath = "shared_file_multi.txt";
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

    // Создаем несколько потоков записи
    Thread writerThread1 = new Thread(() => Writer("Поток-1"));
    Thread writerThread2 = new Thread(() => Writer("Поток-2"));
    Thread readerThread = new Thread(Reader);

    // Запускаем потоки
    writerThread1.Start();
    writerThread2.Start();
    readerThread.Start();

    // Ожидаем завершения потоков записи
    writerThread1.Join();
    writerThread2.Join();

    // Ждем немного для завершения всех операций
    Thread.Sleep(1000);

    // Завершаем чтение
    shouldStop = true;
    readerThread.Join();

    Console.WriteLine("Программа завершена.");
  }

  static void Writer(string threadName)
  {
    int counter = 0;
    while (counter < maxWrites / 2) // Каждый поток записывает половину строк
    {
      try
      {
        lock (fileLock)
        {
          using (StreamWriter writer = new StreamWriter(filePath, true))
          {
            string content = $"{threadName} - Запись {++counter} - {DateTime.Now:HH:mm:ss.fff}";
            writer.WriteLine(content);
            Console.WriteLine($"Записано: {content}");
          }
        }

        Interlocked.Increment(ref writeCount);

        Thread.Sleep(200);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Ошибка записи: {ex.Message}");
        break;
      }
    }
  }

  static void Reader()
  {
    while (!shouldStop)
    {
      try
      {
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

        Thread.Sleep(500);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Ошибка чтения: {ex.Message}");
      }
    }

    // Финальное чтение после завершения записи
    try
    {
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
    catch (Exception ex)
    {
      Console.WriteLine($"Ошибка финального чтения: {ex.Message}");
    }
  }
}

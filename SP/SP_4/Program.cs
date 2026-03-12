using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

class Program
{
  // Ограниченное количество мест в кинотеатре
  private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(5, 5);

  // Счетчик клиентов для уникальных ID
  private static int customerCounter = 0;

  // Очередь ожидания клиентов
  private static readonly ConcurrentQueue<int> waitingQueue = new ConcurrentQueue<int>();

  // Список активных бронирований (для отмены)
  private static readonly ConcurrentDictionary<int, CancellationTokenSource> activeBookings =
      new ConcurrentDictionary<int, CancellationTokenSource>();

  static async Task Main(string[] args)
  {
    Console.WriteLine("Запуск расширенной системы бронирования билетов в кинотеатре...\n");

    // Создаем 20 клиентов (потоков)
    var tasks = new List<Task>();
    for (int i = 0; i < 20; i++)
    {
      int customerId = ++customerCounter;
      tasks.Add(BookTicketAsync(customerId));
    }

    // Ждем завершения всех задач
    await Task.WhenAll(tasks);

    Console.WriteLine("\nБронирование завершено.");
    Console.ReadKey();
  }

  static async Task BookTicketAsync(int customerId)
  {
    Console.WriteLine($"Клиент {customerId} пытается забронировать место...");

    // Добавляем клиента в очередь ожидания
    waitingQueue.Enqueue(customerId);
    Console.WriteLine($"Клиент {customerId} добавлен в очередь ожидания. Очередь: {waitingQueue.Count}");

    try
    {
      // Пытаемся занять место (ожидание семафора)
      await semaphore.WaitAsync();

      // Удаляем из очереди
      waitingQueue.TryDequeue(out _);

      int available = semaphore.CurrentCount;
      Console.WriteLine($"Клиент {customerId} успешно забронировал место. Осталось мест: {available}");

      // Создаем токен для отмены
      var cts = new CancellationTokenSource();
      activeBookings[customerId] = cts;

      // Имитируем обработку заказа
      await Task.Delay(1000, cts.Token); // 1 секунда на обработку

      Console.WriteLine($"Клиент {customerId} завершил обработку бронирования.");
    }
    catch (OperationCanceledException)
    {
      Console.WriteLine($"Клиент {customerId} отменил бронирование.");
    }
    finally
    {
      // Освобождаем место
      if (activeBookings.TryRemove(customerId, out var cts))
      {
        cts.Dispose();
      }

      semaphore.Release();
      int available = semaphore.CurrentCount;
      Console.WriteLine($"Место освобождено клиентом {customerId}. Осталось мест: {available}");
    }
  }

  // Метод для отмены бронирования
  static async Task CancelBooking(int customerId)
  {
    if (activeBookings.TryGetValue(customerId, out var cts))
    {
      Console.WriteLine($"Отмена бронирования для клиента {customerId}...");
      cts.Cancel();
    }
    else
    {
      Console.WriteLine($"Клиент {customerId} не имеет активного бронирования.");
    }
  }
}

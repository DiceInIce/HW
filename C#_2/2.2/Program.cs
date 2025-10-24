using System;

class Program
{
    static void Main()
    {
        int[,] arr = new int[5, 5];
        Random rand = new Random();
        int minIndex = 0, maxIndex = 0;

        Console.WriteLine("Массив:");
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                arr[i, j] = rand.Next(-100, 101);
                Console.Write(arr[i, j] + "\t");
            }
            Console.WriteLine();
        }

        int[] flat = new int[25];
        int index = 0;
        foreach (int x in arr)
        {
            flat[index] = x;
            if (flat[index] < flat[minIndex]) minIndex = index;
            if (flat[index] > flat[maxIndex]) maxIndex = index;
            index++;
        }

        int start = Math.Min(minIndex, maxIndex);
        int end = Math.Max(minIndex, maxIndex);
        int sum = 0;

        for (int i = start + 1; i < end; i++)
            sum += flat[i];

        Console.WriteLine($"\nСумма между минимальным и максимальным элементами: {sum}");
    }
}
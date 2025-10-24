using System;

class Program
{
    static void Main()
    {
        double[] A = new double[5];
        double[,] B = new double[3, 4];
        Random rand = new Random();

        Console.WriteLine("Введите 5 чисел для массива A:");
        for (int i = 0; i < A.Length; i++)
        {
            Console.Write($"A[{i}] = ");
            A[i] = double.Parse(Console.ReadLine());
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                B[i, j] = Math.Round(rand.NextDouble() * 100, 2);
            }
        }

        Console.WriteLine("\nМассив A:");
        foreach (var x in A) Console.Write(x + " ");
        Console.WriteLine();

        Console.WriteLine("\nМассив B:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
                Console.Write(B[i, j] + "\t");
            Console.WriteLine();
        }

        double max = Math.Max(A[0], B[0, 0]);
        double min = Math.Min(A[0], B[0, 0]);
        double sum = 0, product = 1, sumEvenA = 0, sumOddColsB = 0;

        foreach (double x in A)
        {
            sum += x;
            product *= x;
            if (x % 2 == 0) sumEvenA += x;
            if (x > max) max = x;
            if (x < min) min = x;
        }

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 4; j++)
            {
                double x = B[i, j];
                sum += x;
                product *= x;
                if (x > max) max = x;
                if (x < min) min = x;
                if ((j + 1) % 2 != 0) sumOddColsB += x;
            }

        Console.WriteLine($"\nОбщий максимум: {max}");
        Console.WriteLine($"Общий минимум: {min}");
        Console.WriteLine($"Сумма всех элементов: {sum}");
        Console.WriteLine($"Произведение всех элементов: {product}");
        Console.WriteLine($"Сумма чётных элементов массива A: {sumEvenA}");
        Console.WriteLine($"Сумма нечётных столбцов массива B: {sumOddColsB}");
    }
}
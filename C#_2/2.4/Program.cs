using System;

class Program
{
    static void Main()
    {
        double[,] A = { { 1, 2 }, { 3, 4 } };
        double[,] B = { { 5, 6 }, { 7, 8 } };

        Console.Write("Введите число для умножения: ");
        double k = double.Parse(Console.ReadLine());

        Console.WriteLine("\nA * k:");
        Print(MultiplyByNumber(A, k));

        Console.WriteLine("\nA + B:");
        Print(Add(A, B));

        Console.WriteLine("\nA * B:");
        Print(Multiply(A, B));
    }

    static double[,] MultiplyByNumber(double[,] m, double k)
    {
        int r = m.GetLength(0), c = m.GetLength(1);
        double[,] res = new double[r, c];
        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                res[i, j] = m[i, j] * k;
        return res;
    }

    static double[,] Add(double[,] a, double[,] b)
    {
        int r = a.GetLength(0), c = a.GetLength(1);
        double[,] res = new double[r, c];
        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                res[i, j] = a[i, j] + b[i, j];
        return res;
    }

    static double[,] Multiply(double[,] a, double[,] b)
    {
        int r1 = a.GetLength(0), c1 = a.GetLength(1), c2 = b.GetLength(1);
        double[,] res = new double[r1, c2];
        for (int i = 0; i < r1; i++)
            for (int j = 0; j < c2; j++)
                for (int k = 0; k < c1; k++)
                    res[i, j] += a[i, k] * b[k, j];
        return res;
    }

    static void Print(double[,] m)
    {
        int r = m.GetLength(0), c = m.GetLength(1);
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
                Console.Write(m[i, j] + "\t");
            Console.WriteLine();
        }
    }
}
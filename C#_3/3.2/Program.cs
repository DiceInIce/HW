using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(IsPalindrome(1221)); // true
        Console.WriteLine(IsPalindrome(7854)); // false
    }

    static bool IsPalindrome(int number)
    {
        string str = number.ToString();
        char[] reversed = str.ToCharArray();
        Array.Reverse(reversed);
        return str == new string(reversed);
    }
}
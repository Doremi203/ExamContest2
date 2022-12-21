using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        var mas = Array.ConvertAll(Console.ReadLine().Split(), Convert.ToInt32);
        var sum = mas.Sum();
        double res = sum * 10.0;
        Console.WriteLine($"{res:f3}");
    }
}
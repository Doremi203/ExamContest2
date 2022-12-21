using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static List<int> nums = new();
    private static void Main(string[] args)
    {
        string el;
        do
        {
            el = Console.ReadLine();
            if ((!int.TryParse(el, out var x) || x is < 190 or > 250)&& x != 0)
            {
                Console.WriteLine("Incorrect input");
            }

            if (x != 0)
            {
                nums.Add(x);
            }
        } while (el != "0");

        var min1 = nums.Min();
        nums.Remove(min1);
        var min2 = nums.Min();
        Console.WriteLine(min1);
        Console.WriteLine(min2);
    }
}
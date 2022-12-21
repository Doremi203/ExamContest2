using System;
using System.Linq;

internal class ChristmasArray : BaseArray
{
    public ChristmasArray(int[] arr) : base(arr) { }
    
    public override int this[int number]
    {
        get
        {
            var res = array.Where(i => i > number).ToList();
            if (!res.Any())
                throw new ArgumentException("Number does not exist.");
            return res.Min();
        }
    }

    public override double GetMetric()
    {
        var numCount = 0;
        foreach (var i in array)
        {
            var x = i; 
            while (x > 0)
            {
                numCount += 1;
                x /= 10;
            }
        }

        var n1 = array.Count(i => i % 2 == 0);
        var res = (double)n1 / numCount;
        return res;
    }
}
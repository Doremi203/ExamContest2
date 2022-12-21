using System;
using System.Collections.Generic;
using System.Linq;

public class Mushroom
{
    public string Name { get; }
    public double Weight { get; }
    public double Diameter { get; }

    private Mushroom(string name, double weight, double diameter)
    {
        Name = name;
        Weight = weight;
        Diameter = diameter;
    }

    public static Mushroom Parse(string line)
    {
        var masStr = line.Split();
        if (masStr.Length != 3 
            || !double.TryParse(masStr[1], out var m) || m <= 0 
            || !double.TryParse(masStr[2], out var d) || d <= 0)
        {
            throw new ArgumentException("Incorrect input");
        }

        return new Mushroom(masStr[0],  m,  d);
    }

    public static double GetMinimalDiameter(List<Mushroom> mushrooms, double m)
    {
        var res = mushrooms.Where(mushroom => mushroom.Weight < m).ToList();
        if (!res.Any())
        {
            return 0;
        }

        return res.Min(mushroom => mushroom.Diameter);
    }
}


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

internal class GeometryRef
{
    public List<Point> Points { get; }

    protected GeometryRef(List<Point> points)
    {
        Points = points;
    }

    protected virtual double GetPerimeter()
    {
        return 0;
    }

    public virtual double GetSquare()
    {
        return 0;
    }

    public static GeometryRef Parse(string line)
    {
        var masStr = line.Split();
        var points = new List<Point>();
        for (int i = 1; i < masStr.Length - 1; i+=2)
        {
            if ((masStr.Length - 1) % 2 !=0 || !double.TryParse(masStr[i], NumberStyles.Any ,CultureInfo.InvariantCulture, out var x) || !double.TryParse(masStr[i+1], NumberStyles.Any ,CultureInfo.InvariantCulture, out var y))
                throw new ArgumentException("Incorrect input");
            points.Add(new Point(x,y));
        }
        switch (masStr[0])
        {
            case "Parallelogram":
                if (masStr.Skip(1).Count() != 8)
                    throw new ArgumentException("Incorrect input");
                return new Parallelogram(points);
            case "Trapezoid":
                if (masStr.Skip(1).Count() != 8)
                    throw new ArgumentException("Incorrect input");
                return new Trapezoid(points);
            case "GeometryRef":
                if (!masStr.Skip(1).Any() || masStr.Skip(1).Count() % 2 !=0)
                    throw new ArgumentException("Incorrect input");
                return new GeometryRef(points);
            default:
                throw new ArgumentException("Incorrect input");
        }
    }

    public override string ToString()
    {
        return $"{GetType()}. P = {GetPerimeter():f2}. S = {GetSquare():f2}";
    }
}
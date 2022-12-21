using System;

internal static class CircleInSquare
{
    public static double CircumFerence(double side) => side / 2 * 2 * Math.PI;

    public static double Square(double side) => Math.Pow(side / 2, 2) * Math.PI;

    public static double FreeSpace(double side) => side * side - Math.Pow(side / 2, 2) * Math.PI;
}
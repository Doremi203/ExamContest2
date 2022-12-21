using System;
using System.Collections.Generic;

internal class Trapezoid : GeometryRef
{
    public double a => Points[1].X - Points[0].X;
    public double b => Points[2].X - Points[3].X;
    
    public double SideR => Math.Sqrt(Math.Pow(Points[2].X - Points[1].X, 2) + Math.Pow(Points[2].Y - Points[1].Y, 2));
    public double SideL => Math.Sqrt(Math.Pow(Points[3].X - Points[0].X, 2) + Math.Pow(Points[3].Y - Points[0].Y, 2));
    
    public double Height => Points[2].Y - Points[1].Y;
    public Trapezoid(List<Point> list) : base(list)
    {
    }

    protected override double GetPerimeter()
    {
        return a + b + SideR + SideL;
    }

    public override double GetSquare()
    {
        return (a + b) / 2 * Height;
    }
}
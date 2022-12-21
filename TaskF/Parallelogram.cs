using System;
using System.Collections.Generic;

internal class Parallelogram : GeometryRef
{
    public double SideA => Points[1].X - Points[0].X;
    
    public double SideB => Math.Sqrt(Math.Pow(Points[2].X - Points[1].X, 2) + Math.Pow(Points[2].Y - Points[1].Y, 2));
    public double Height => Points[2].Y - Points[1].Y;
    
    
    public Parallelogram(List<Point> points) : base(points)
    { }

    public override double GetSquare() => SideA * Height;

    protected override double GetPerimeter()
    {
        return SideA * 2 + SideB * 2;
    }
}
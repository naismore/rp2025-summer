using System.Drawing;
using System.Runtime.InteropServices;

namespace GeometryLib;

public class Triangle2D
{
    private readonly Point2D _a;
    private readonly Point2D _b;
    private readonly Point2D _c;

    public Triangle2D(Point2D a, Point2D b, Point2D c)
    {
        _a = a;
        _b = b;
        _c = c;

        // выбрасывайте ArgumentException для вырожденного треугольника (то есть когда все три точки лежат на одной прямой)
    }

    /// <summary>
    /// Длина стороны AB.
    /// </summary>
    public double SideAB
    {
        get
        {
            return _a.DistanceTo(_b);
        }
    }

    /// <summary>
    /// Длина стороны BC.
    /// </summary>
    public double SideBC
    {
        get
        {
            return _b.DistanceTo(_c);
        }
    }

    /// <summary>
    /// Длина стороны CA.
    /// </summary>
    public double SideCA
    {
        get
        {
            return _c.DistanceTo(_a);
        }
    }

    /// <summary>
    /// Периметр треугольника.
    /// </summary>
    public double Perimeter
    {
        get
        {
            return this.SideAB + this.SideBC + this.SideCA;
        }
    }

    /// <summary>
    /// Площадь треугольника.
    /// </summary>
    public double Area
    {
        get
        {
            double p = this.Perimeter / 2;
            return Math.Sqrt(p * (p - this.SideAB) * (p - this.SideBC) * (p - this.SideCA));
        }
    }

    // TODO: Реализовать свойство

    /// <summary>
    /// Центр масс треугольника.
    /// </summary>
    public Point2D Centroid { get; }

    /// <summary>
    /// Проверка на прямоугольный треугольник.
    /// </summary>
    public bool IsRightAngled()
    {
        // TODO: реализовать метод
        return true;
    }

    /// <summary>
    /// Треугольник содержит точку.
    /// </summary>
    public bool Contains(Point2D p)
    {
        // TODO: Реализовать метод
        return true;
    }
}
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
        // Проверка по теореме пифагора
        bool firstOption = Math.Pow(this.SideAB, 2) == Math.Pow(this.SideBC, 2) + Math.Pow(this.SideCA, 2);
        bool secondOption = Math.Pow(this.SideBC, 2) == Math.Pow(this.SideAB, 2) + Math.Pow(this.SideCA, 2);
        bool thirdOption = Math.Pow(this.SideCA, 2) == Math.Pow(this.SideAB, 2) + Math.Pow(this.SideBC, 2);
        return firstOption || secondOption || thirdOption;
    }

    /// <summary>
    /// Треугольник содержит точку.
    /// </summary>
    public bool Contains(Point2D point)
    {
        // Метод сравнения площадей
        double areaABC = TriangleArea(_a, _b, _c);
        double areaPAB = TriangleArea(point, _a, _b);
        double areaPBC = TriangleArea(point, _b, _c);
        double areaPCA = TriangleArea(point, _c, _a);

        // Учитываем погрешность double (ε = 1e-10)
        return Math.Abs(areaABC - (areaPAB + areaPBC + areaPCA)) < 1e-10;
    }

    private static double TriangleArea(Point2D A, Point2D B, Point2D C)
    {
        return Math.Abs((B.X - A.X) * (C.Y - A.Y) - (B.Y - A.Y) * (C.X - A.X)) / 2.0;
    }
}
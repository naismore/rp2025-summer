using System.Drawing;
using System.Runtime.InteropServices;

namespace GeometryLib;

public class Triangle2D
{
    private readonly Point2D a;
    private readonly Point2D b;
    private readonly Point2D c;

    public Triangle2D(Point2D a, Point2D b, Point2D c)
    {
        double area = (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
        if (Math.Abs(area) < 1e-10)
        {
            throw new ArgumentException("Все три точки лежат на одной прямой");
        }

        this.a = a;
        this.b = b;
        this.c = c;
    }

    /// <summary>
    /// Длина стороны AB.
    /// </summary>
    public double SideAB
    {
        get
        {
            return a.DistanceTo(b);
        }
    }

    /// <summary>
    /// Длина стороны BC.
    /// </summary>
    public double SideBC
    {
        get
        {
            return b.DistanceTo(c);
        }
    }

    /// <summary>
    /// Длина стороны CA.
    /// </summary>
    public double SideCA
    {
        get
        {
            return c.DistanceTo(a);
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
    public Point2D Centroid
    {
        get
        {
            double gx = (a.X + b.X + c.X) / 3;
            double gy = (a.Y + b.Y + c.Y) / 3;
            return new Point2D(x: gx, y: gy);
        }
    }

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
        double areaABC = TriangleArea(a, b, c);
        double areaPAB = TriangleArea(point, a, b);
        double areaPBC = TriangleArea(point, b, c);
        double areaPCA = TriangleArea(point, c, a);

        // Учитываем погрешность double (ε = 1e-10)
        return Math.Abs(areaABC - (areaPAB + areaPBC + areaPCA)) < 1e-10;
    }

    private static double TriangleArea(Point2D a, Point2D b, Point2D c)
    {
        return Math.Abs((b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X)) / 2.0;
    }
}
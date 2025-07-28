namespace GeometryLib;

public struct Point2D(double x, double y)
{
    /// <summary>
    /// Координата по оси OX.
    /// </summary>
    public double X { get; } = x;

    /// <summary>
    /// Координата по оси OY.
    /// </summary>
    public double Y { get; } = y;

    /// <summary>
    /// Евклидово расстояние до точки.
    /// </summary>
    public double DistanceTo(Point2D point)
    {
        return Math.Sqrt(Math.Pow(X - point.X, 2) + Math.Pow(Y - point.Y, 2));
    }
}
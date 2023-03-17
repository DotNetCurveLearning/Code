using System.Xml.Serialization;

namespace Shapes.Shared;

[XmlInclude(typeof(Circle))]
[XmlInclude(typeof(Rectangle))]
public abstract class Shape
{
    public string? Colour { get; set; }
    public abstract double Area { get; }
}

public class Circle : Shape
{
    private double _radius;

    public double Radius
    {
        get => _radius;
        set => _radius = value;
    }
    public override double Area => Math.PI * Radius * Radius;
}

public class Rectangle : Shape
{
    private double _height;
    private double _width;

    public double Height
    {
        get => _height;
        set => _height = value;
    }

    public double Width
    {
        get => _width;
        set => _width = value;
    }
    public override double Area => Height * Width;

    public Rectangle()
    {
    }
}

namespace Exercise02
{
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(double radius) : base(radius)
        {            
            Area = Math.PI * Height * Height;
        }
    }
}

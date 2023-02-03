namespace Exercise02
{
    public class Rectangle : Shape 
    {
        public Rectangle(double height, double width) : base(height, width)
        {
            Height= height;
            Width= width;
            Area = Height * Width;
        }
    }
}

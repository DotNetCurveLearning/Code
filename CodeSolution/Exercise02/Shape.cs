﻿namespace Exercise02
{
    public class Shape
    {

        public double Height { get; set; }
        public double Width { get; set; }
        public double Area { get; set; }

        public Shape(double height, double width = 0)
        {
            Height = height;
            Width = width != 0 ? width : 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02
{
    public class Square : Shape
    {

        public Square(double height) : base(height)
        {
            Area = Height * Height;
        }
    }
}

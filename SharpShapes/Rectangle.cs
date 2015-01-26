using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShapes
{
    public class Rectangle : Shape
    {
        private decimal width;
        public decimal Width {
            get { return this.width; } 
        }

        private decimal height;
        public decimal Height {
            get { return this.height; } 
        }

        public override int SidesCount {
            get { return 4; } 
        }

        public Rectangle(int width, int height)
        {
            if( width <= 0 || height <= 0)
            {
                throw new ArgumentException();
            }
            this.width = width;
            this.height = height;
        }

        public override decimal Area()
        {
            return Height * Width;
        }

        public override decimal Perimeter()
        {
            return (2 * Height) + (2 * Width);
        }

        public override void Scale(int percent)
        {
            if(percent <= 0)
            {
                throw new ArgumentException();
            }
            this.width = width * percent / 100;
            this.height = height * percent / 100;
        }
    }
}

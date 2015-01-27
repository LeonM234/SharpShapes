using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShapes
{
    public class Trapezoid : Shape
    {
        private decimal baseTop;
        public decimal BaseTop
        {
            get { return this.baseTop; }
        }

        private decimal baseBottom;
        public decimal BaseBottom
        {
            get {return this.baseBottom; }
        }

        private decimal height;
        public decimal Height
        {
            get {return this.height; }
        }

        public override int SidesCount
        {
            get { return 4; }
        }

        public Trapezoid(int baseTop, int baseBottom, int height)
        {
            if (baseTop <= 0 || baseBottom <= 0 || height <= 0 || baseTop == baseBottom)
            {
                throw new ArgumentException();
            }
            this.baseTop = baseTop;
            this.baseBottom = baseBottom;
            this.height = height;
        }

        public override decimal Area()
        {
            return ((BaseTop + BaseBottom)/2) * Height;
        }

        public override decimal Perimeter()
        {
            decimal bottomtriangle = Math.Abs(baseTop - baseBottom) / 2;
            double side = Math.Sqrt((double)(bottomtriangle * bottomtriangle + Height * Height));

            return baseBottom + baseTop + (decimal)side * 2;
        }

        public override void Scale(int percent)
        {
            if (percent <= 0)
            {
                throw new ArgumentException();
            }
            this.baseTop = baseTop * percent / 100;
            this.baseBottom = baseBottom * percent / 100;
            this.height = height * percent / 100;
        }
    }
    


}

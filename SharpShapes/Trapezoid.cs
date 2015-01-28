using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShapes
{
    public class Trapezoid : Quadrilateral
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
            get { return this.height; }
        }

        public decimal AcuteAngle { get; private set; }
        public decimal ObtuseAngle { get; private set; }

        public Trapezoid(int baseTop, int baseBottom, int height)
        {
            if (baseTop <= 0 || baseBottom <= 0 || height <= 0 || baseTop == baseBottom)
            {
                throw new ArgumentException();
            }
            this.baseTop = baseTop;
            this.baseBottom = baseBottom;
            this.height = height;

            decimal wingLength = (BaseBottom - BaseTop) / 2;
            this.AcuteAngle = Decimal.Round((decimal) (Math.Atan((double)(height / wingLength)) * (180.0 / Math.PI)), 2);
            this.ObtuseAngle = 180 - AcuteAngle;
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

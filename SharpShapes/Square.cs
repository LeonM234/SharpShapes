using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpShapes
{
    public class Square : Shape
    {
        private decimal side;
        public decimal Side
        {
            get { return this.side; }
        }

        public override int SidesCount
        {
            get { return 4; }
        }

        public Square(int side)
        {
            if ( side <= 0)
            {
                throw new ArgumentException();
            }
            this.side = side;
        }

        public override decimal Area()
        {
            return side * side;
        }

        public override decimal Perimeter()
        {
            return side * 4;
        }

        public override void Scale(int percent)
        {
            if (percent <= 0)
            {
                throw new ArgumentException();
            }
            this.side = side * percent / 100;
        }
    }
}

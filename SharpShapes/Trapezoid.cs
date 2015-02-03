using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SharpShapes
{
    public class Trapezoid : Quadrilateral
    {
        private decimal shortbase;
        public decimal Shortbase
        {
            get { return this.shortbase; }
        }

        private decimal longbase;
        public decimal Longbase
        {
            get {return this.longbase; }
        }

        private decimal height;
        public decimal Height
        {
            get { return this.height; }
        }

        public decimal AcuteAngle { get; private set; }
        public decimal ObtuseAngle { get; private set; }

        public Trapezoid(int shortbase, int longbase, int height)
        {
            if (shortbase <= 0 || longbase <= 0 || height <= 0 || shortbase >= longbase)
            {
                throw new ArgumentException();
            }
            this.shortbase = shortbase;
            this.longbase = longbase;
            this.height = height;

            decimal wingLength = (longbase - shortbase) / 2;

            this.AcuteAngle = Decimal.Round((decimal) (Math.Atan((double)(height / wingLength)) * (180.0 / Math.PI)), 2);

            this.ObtuseAngle = 180 - AcuteAngle;
        }

        public override decimal Area()
        {
            return ((shortbase + longbase)/2) * height;
        }

        public override decimal Perimeter()
        {
            decimal longbasetriangle = Math.Abs(shortbase - longbase) / 2;
            double side = Math.Sqrt((double)(longbasetriangle * longbasetriangle + height * height));

            return shortbase + longbase + (decimal)side * 2;
        }

        public override void Scale(int percent)
        {
            if (percent <= 0)
            {
                throw new ArgumentException();
            }
            this.shortbase = shortbase * percent / 100;
            this.longbase = longbase * percent / 100;
            this.height = height * percent / 100;
        }

        public override void DrawOnto(Canvas ShapeCanvas, int x, int y)
        {
            System.Windows.Shapes.Polygon myPolygon = new System.Windows.Shapes.Polygon();


            //FillColor of Shape// 
            var brushFillColor = new SolidColorBrush(this.FillColor);
            myPolygon.Fill = brushFillColor;

            //BorderColor of Shape//
            var brushBorderColor = new SolidColorBrush(this.BorderColor);
            myPolygon.Stroke = brushBorderColor;
            myPolygon.StrokeThickness = 2;

            int wingLength = (int)(Longbase - Shortbase);

            myPolygon.HorizontalAlignment = HorizontalAlignment.Right;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;
            System.Windows.Point Point1 = new System.Windows.Point(x - wingLength, y);
            System.Windows.Point Point2 = new System.Windows.Point(x + (int)(this.Shortbase) + wingLength, y);
            System.Windows.Point Point3 = new System.Windows.Point(x + (int)(this.Shortbase), y - (int)(this.Shortbase));
            System.Windows.Point Point4 = new System.Windows.Point(x, y - (int)(this.Shortbase));

            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPointCollection.Add(Point4);
            myPolygon.Points = myPointCollection;
            ShapeCanvas.Children.Add(myPolygon);
        }

    }
    


}

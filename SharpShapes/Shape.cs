using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SharpShapes
{
    abstract public class Shape
    {
        
        /// <summary>
        /// The color of the interior of the shape, when drawn
        /// </summary>
        public Color FillColor { get; set; }

        /// <summary>
        /// The color of the border of the shape, when drawn
        /// </summary>
        public Color BorderColor { get; set; }

        /// <summary>
        /// The number of sides of this shape.
        /// </summary>
        abstract public int SidesCount { get; }

        public Shape()
        {
            BorderColor = Color.Black;
            FillColor = Color.Black;
        }

        /// <summary>
        /// Calculates the area of the shape.
        /// </summary>
        /// <returns>the area of the shape</returns>
        abstract public decimal Area();


        /// <summary>
        /// Calculates the perimeter of the shape.
        /// </summary>
        /// <returns>the perimeter of the shape</returns>
        abstract public decimal Perimeter();

        /// <summary>
        /// Scales the shape in size.
        /// </summary>
        /// <param name="percent">the percentage by which to scale the shape</param>
        abstract public void Scale(int percent);

        /// <summary>
        /// Creates a polygon representing this shape and adds it to the ShapeCanvas.
        /// </summary>
        /// <param name="ShapeCanvas">The Canvas on which to draw this Shape.</param>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        abstract public void DrawOnto(Canvas ShapeCanvas, int x, int y);
    }
}

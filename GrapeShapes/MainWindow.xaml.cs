using SharpShapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace GrapeShapes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopulateClassList();
            DrawRectangle();
            Square square = new Square(200);
            square.FillColor = System.Drawing.Color.Blue;
            square.BorderColor = System.Drawing.Color.Fuchsia;
            DrawSquare(50, 5, square);

        }
        private void PopulateClassList()
        {
            var classList = new List<string>();
            var shapeType = typeof(Shape);
            foreach (Type type in Assembly.GetAssembly(shapeType).GetTypes())
            {
                if (type.IsSubclassOf(shapeType) && !type.IsAbstract)
                {
                    classList.Add(type.Name);
                }
            }
            ShapeTypeComboBox.ItemsSource = classList;
        }

        private void DrawRectangle()
        {
            System.Windows.Shapes.Polygon myPolygon = new System.Windows.Shapes.Polygon();
            myPolygon.Stroke = System.Windows.Media.Brushes.Tomato;
            myPolygon.Fill = System.Windows.Media.Brushes.Bisque;
            myPolygon.StrokeThickness = 2;
            myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;
            System.Windows.Point Point1 = new System.Windows.Point(1, 50);
            System.Windows.Point Point2 = new System.Windows.Point(1, 80);
            System.Windows.Point Point3 = new System.Windows.Point(50, 80);
            System.Windows.Point Point4 = new System.Windows.Point(50, 50);
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPointCollection.Add(Point4);
            myPolygon.Points = myPointCollection;
            ShapeCanvas.Children.Add(myPolygon);
        }
        private void DrawSquare(int x, int y, Square square)
        {
            int sqrSide = (int)square.Width;

            SolidColorBrush mediaFillColor = new SolidColorBrush();
            mediaFillColor.Color = System.Windows.Media.Color.FromArgb(square.FillColor.A, square.FillColor.R, square.FillColor.G, square.FillColor.B);

            SolidColorBrush mediaBorderColor = new SolidColorBrush();
            mediaBorderColor.Color = System.Windows.Media.Color.FromArgb(square.BorderColor.A, square.BorderColor.R, square.BorderColor.B, square.BorderColor.G);

            System.Windows.Shapes.Polygon mySquare = new System.Windows.Shapes.Polygon();
            mySquare.Stroke = mediaBorderColor;
            mySquare.Fill = mediaFillColor;
            mySquare.StrokeThickness = 2;
            mySquare.HorizontalAlignment = HorizontalAlignment.Left;
            mySquare.VerticalAlignment = VerticalAlignment.Center;
            System.Windows.Point Point1 = new System.Windows.Point(x, y);
            System.Windows.Point Point2 = new System.Windows.Point(x + sqrSide, y);
            System.Windows.Point Point3 = new System.Windows.Point(x + sqrSide, y + sqrSide);
            System.Windows.Point Point4 = new System.Windows.Point(x, y + sqrSide);
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPointCollection.Add(Point4);
            mySquare.Points = myPointCollection;
            ShapeCanvas.Children.Add(mySquare);
        }
    }
}

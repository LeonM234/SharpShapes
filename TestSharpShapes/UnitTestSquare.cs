using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpShapes;

namespace TestSharpShapes
{
    [TestClass]
    public class UnitTestSquare
    {
        [TestMethod]
        public void TestSquareConstructor()
        {
            Square square = new Square(40);
            Assert.AreEqual(40, square.Width);
            Assert.AreEqual(40, square.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSquareConstructorSanityChecksWidth()
        {
            Square square = new Square(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSquareConstructorSanityChecksWidthPositivity()
        {
            Square square = new Square(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSquareConstructorSanityChecksHeight()
        {
            Square square = new Square(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSquareConstructorSanityChecksHeightPositivity()
        {
            Square square = new Square(-1);
        }

        [TestMethod]
        public void TestScaleSquare200Percent()
        {
            Square square = new Square(20);
            square.Scale(200);
            Assert.AreEqual(40, square.Width);
            Assert.AreEqual(40, square.Height);
        }

        [TestMethod]
        public void TestScaleSquare150Percent()
        {
            Square square = new Square(20);
            square.Scale(150);
            Assert.AreEqual((decimal)30, square.Width);
            Assert.AreEqual((decimal)30, square.Height);
        }

        [TestMethod]
        public void TestScaleSquare100Percent()
        {
            Square square = new Square(20);
            square.Scale(100);
            Assert.AreEqual(20, square.Width);
            Assert.AreEqual(20, square.Height);
        }

        [TestMethod]
        public void TestScaleSquare37Percent()
        {
            Square square = new Square(20);
            square.Scale(37);
            Assert.AreEqual((decimal)7.4, square.Width);
            Assert.AreEqual((decimal)7.4, square.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestScaleSquareTo0Percent()
        {
            Square square = new Square(20);
            square.Scale(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestScaleSquareToNegativePercent()
        {
            Square square = new Square(20);
            square.Scale(-5);
        }

        [TestMethod]
        public void TestSidesCount()
        {
            Square square = new Square(20);
            Assert.AreEqual(4, square.SidesCount);
        }

        [TestMethod]
        public void TestSquareArea()
        {
            Square square = new Square(20);
            Assert.AreEqual(400, square.Area());
        }

        [TestMethod]
        public void TestBiggerSquareArea()
        {
            Square square = new Square(100);
            Assert.AreEqual(10000, square.Area());
        }

        [TestMethod]
        public void TestSquarePerimeter()
        {
            Square square = new Square(20);
            Assert.AreEqual(80, square.Perimeter());
        }

        [TestMethod]
        public void TestBiggerSquarePerimeter()
        {
            Square square = new Square(100);
            Assert.AreEqual(400, square.Perimeter());
        }

        [TestMethod]
        public void TestDefaultColor()
        {
            Square shape = new Square(20);
            Assert.AreEqual(System.Drawing.Color.Bisque, shape.FillColor);
            Assert.AreEqual(System.Drawing.Color.Tomato, shape.BorderColor);
        }
    }
}

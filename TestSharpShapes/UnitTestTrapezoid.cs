using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpShapes;

namespace TestSharpShapes
{
    [TestClass]
    public class UnitTestTrapezoid
    {
        [TestMethod]
        public void TestTrapezoidConstructor()
        {
            Trapezoid trapezoid = new Trapezoid(40, 50, 10);
            Assert.AreEqual(40, trapezoid.BaseTop);
            Assert.AreEqual(50, trapezoid.BaseBottom);
            Assert.AreEqual(10, trapezoid.Height);
        }

        [TestMethod]
        public void TestTrapezoidConstructorCalculateAngles()
        {
            Trapezoid trapezoid = new Trapezoid(20, 15, 2);
            Assert.AreEqual((decimal)38.66, trapezoid.AcuteAngle);
            Assert.AreEqual((decimal)141.34, trapezoid.ObtuseAngle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTrapezoidConstructorSanityChecksTopWidth()
        {
            Trapezoid trapezoid = new Trapezoid(0, 50, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTrapezoidConstructorSanityChecksTopWidthPositivity()
        {
            Trapezoid trapezoid = new Trapezoid(-1, 50, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTrapezoidConstructorSanityChecksHeight()
        {
            Trapezoid trapezoid = new Trapezoid(50, 0, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTrapezoidConstructorSanityChecksHeightPositivity()
        {
            Trapezoid trapezoid = new Trapezoid(50, -1, 10);
        }

        [TestMethod]
        public void TestScaleTrapezoid200Percent()
        {
            Trapezoid trapezoid = new Trapezoid(20, 30, 10);
            trapezoid.Scale(200);
            Assert.AreEqual(40, trapezoid.BaseTop);
            Assert.AreEqual(60, trapezoid.BaseBottom);
            Assert.AreEqual(20, trapezoid.Height);
        }

        [TestMethod]
        public void TestScaleTrapezoid150Percent()
        {
            Trapezoid trapezoid = new Trapezoid(20, 30, 10);
            trapezoid.Scale(150);
            Assert.AreEqual((decimal)30, trapezoid.BaseTop);
            Assert.AreEqual((decimal)45, trapezoid.BaseBottom);
            Assert.AreEqual((decimal)15, trapezoid.Height);
        }

        [TestMethod]
        public void TestScaleTrapezoid100Percent()
        {
            Trapezoid trapezoid = new Trapezoid(20, 30, 10);
            trapezoid.Scale(100);
            Assert.AreEqual(20, trapezoid.BaseTop);
            Assert.AreEqual(30, trapezoid.BaseBottom);
            Assert.AreEqual(10, trapezoid.Height);
        }

        [TestMethod]
        public void TestScaleTrapezoid37Percent()
        {
            Trapezoid trapezoid = new Trapezoid(20, 30, 10);
            trapezoid.Scale(37);
            Assert.AreEqual((decimal)7.4, trapezoid.BaseTop);
            Assert.AreEqual((decimal)11.1, trapezoid.BaseBottom);
            Assert.AreEqual((decimal)3.7, trapezoid.Height);
        }

        [TestMethod]
        public void TestScaleTrapezoidUpAndDown()
        {
            Trapezoid trapezoid = new Trapezoid(20, 30, 10);
            trapezoid.Scale(50);
            trapezoid.Scale(200);
            Assert.AreEqual(20, trapezoid.BaseTop);
            Assert.AreEqual(30, trapezoid.BaseBottom);
            Assert.AreEqual(10, trapezoid.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestScaleTrapezoidTo0Percent()
        {
            Trapezoid trapezoid = new Trapezoid(20, 30, 10);
            trapezoid.Scale(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestScaleTrapezoidToNegativePercent()
        {
            Trapezoid trapezoid = new Trapezoid(20, 30, 10);
            trapezoid.Scale(-5);
        }

        [TestMethod]
        public void TestSidesCount()
        {
            Trapezoid trapezoid = new Trapezoid(20, 30, 10);
            Assert.AreEqual(4, trapezoid.SidesCount);
        }

        [TestMethod]
        public void TestTrapezoidArea()
        {
            Trapezoid trapezoid = new Trapezoid(20, 30, 10);
            Assert.AreEqual(250, trapezoid.Area());
        }

        [TestMethod]
        public void TestBiggerTrapezoidArea()
        {
            Trapezoid trapezoid = new Trapezoid(30, 60, 10);
            Assert.AreEqual(450, trapezoid.Area());
        }

        [TestMethod]
        public void TestTrapezoidPerimeter()
        {
            Trapezoid trapezoid = new Trapezoid(4, 10, 4);
            Assert.AreEqual(24, trapezoid.Perimeter());
        }

        [TestMethod]
        public void TestBiggerTrapezoidPerimeter()
        {
            Trapezoid trapezoid = new Trapezoid(40, 100, 40);
            Assert.AreEqual(240, trapezoid.Perimeter());
        }

        [TestMethod]
        public void TestDefaultTrapezoidColor()
        {
            Trapezoid shape = new Trapezoid(20, 30, 10);
            Assert.AreEqual(System.Drawing.Color.Bisque, shape.FillColor);
            Assert.AreEqual(System.Drawing.Color.Tomato, shape.BorderColor);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAgainstEqualBaseTopAndBaseTop()
        {
            Trapezoid shape = new Trapezoid(30, 30, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAgainstBiggerEqualBaseTopAndBaseTop()
        {
            Trapezoid shape = new Trapezoid(700, 700, 100);
        }
    }
}

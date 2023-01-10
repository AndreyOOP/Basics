using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Samples.Sample1
{
    [TestClass]
    public class DeconstructorsSample
    {
        [TestMethod]
        public void DeconstructRect()
        {
            var rect = new Rectangle(1, 5);
            var (x, y) = rect;
            (var a, var b) = rect;
            (int n, int m) = rect;

            Assert.IsTrue(x == a && a == n && n == 1);
            Assert.IsTrue(y == b && b == m && m == 5);
        }

        [TestMethod]
        public void DeconstructPointViaExtensionMethod()
        {
            // if we not control class like Point - we can add deconstructor as extension method
            var p = new Point(2, 3);
            var (x, y) = p;
            Assert.IsTrue(x == 2 && y == 3);
        }
    }

    class Rectangle
    {
        private int _x;
        private int _y;

        public Rectangle(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void Deconstruct(out int x, out int y)
        {
            x = _x;
            y = _y;
        }
    }

    static class PointExtension
    {
        public static void Deconstruct(this Point p, out int x, out int y)
        {
            x = p.X;
            y = p.Y;
        }
    }
}

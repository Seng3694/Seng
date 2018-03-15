using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Seng.MonoGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.CoreTests
{
    [TestClass]
    public class RectTests
    {
        [TestMethod]
        public void EquatableTest()
        {
            var rect1 = new Rect();
            rect1.X = 10;
            rect1.Y = 20;
            rect1.Width = 20;
            rect1.Height = 20;

            var rect2 = new Rect();
            rect2.X = 10;
            rect2.Y = 20;
            rect2.Width = 20;
            rect2.Height = 20;

            var eq1 = rect1 as IEquatable<Rect>;
            var eq2 = rect2 as IEquatable<Rect>;

            Assert.IsTrue(eq1.Equals(eq2));
        }

        [TestMethod]
        public void SetLeft()
        {
            var rect = new Rect();
            rect.Left = 20;

            Assert.IsTrue(rect.Left == 20);
            Assert.IsTrue(rect.X == 20);
        }

        [TestMethod]
        public void SetTop()
        {
            var rect = new Rect();
            rect.Top = 20;

            Assert.IsTrue(rect.Top == 20);
            Assert.IsTrue(rect.Y == 20);
        }

        [TestMethod]
        public void SetRight()
        {
            var rect = new Rect();
            rect.X = 3;
            rect.Y = 3;
            rect.Width = 10;
            rect.Height = 10;

            rect.Right = 0;

            Assert.IsTrue(rect.Right == 0);
            Assert.IsTrue(rect.X == -10);
            Assert.IsTrue(rect.Y == 3);
            Assert.IsTrue(rect.Width == 10);
            Assert.IsTrue(rect.Height == 10);
        }

        [TestMethod]
        public void SetBottom()
        {
            var rect = new Rect();
            rect.X = 3;
            rect.Y = 3;
            rect.Width = 10;
            rect.Height = 10;

            rect.Bottom = 0;

            Assert.IsTrue(rect.Bottom == 0);
            Assert.IsTrue(rect.X == 3);
            Assert.IsTrue(rect.Y == -10);
            Assert.IsTrue(rect.Width == 10);
            Assert.IsTrue(rect.Height == 10);
        }

        [TestMethod]
        public void SetPosition()
        {
            var rect = new Rect();
            rect.Position = new Vector2(10, 20);

            Assert.IsTrue(rect.X == 10);
            Assert.IsTrue(rect.Y == 20);
        }

        [TestMethod]
        public void SetCenter()
        {
            var rect = new Rect();
            rect.X = 10;
            rect.Y = 10;
            rect.Width = 20;
            rect.Height = 20;

            Assert.IsTrue(rect.Center.X == 20);
            Assert.IsTrue(rect.Center.Y == 20);

            rect.Center = new Vector2(50, 50);

            Assert.IsTrue(rect.X == 40);
            Assert.IsTrue(rect.Y == 40);
            Assert.IsTrue(rect.Width == 20);
            Assert.IsTrue(rect.Height == 20);
        }

        [TestMethod]
        public void InflateTest()
        {
            var rect = new Rect();
            rect.X = 20;
            rect.Y = 20;
            rect.Width = 20;
            rect.Height = 20;
            rect.Inflate(10);

            Assert.IsTrue(rect.X == 10);
            Assert.IsTrue(rect.Y == 10);
            Assert.IsTrue(rect.Width == 40);
            Assert.IsTrue(rect.Height == 40);
        }

        [TestMethod]
        public void ContainsTest()
        {
            var rect = new Rect();
            rect.X = 20;
            rect.Y = 20;
            rect.Width = 20;
            rect.Height = 20;

            var vector = Vector2.Zero;

            Assert.IsFalse(rect.Contains(vector));

            vector.X = 20;
            Assert.IsFalse(rect.Contains(vector));

            vector.Y = 20;
            Assert.IsTrue(rect.Contains(vector));

            vector.X = 0;
            Assert.IsFalse(rect.Contains(vector));

            vector.X = rect.Right;
            vector.Y = rect.Bottom;
            Assert.IsTrue(rect.Contains(vector));

            vector.X += 1;
            Assert.IsFalse(rect.Contains(vector));

            vector.X = rect.Right;
            vector.Y += 1;
            Assert.IsFalse(rect.Contains(vector));

            var other = new Rect();
            other.X = 25;
            other.Y = 25;
            other.Width = 10;
            other.Height = 10;

            Assert.IsTrue(rect.Contains(other));
            other.X = 0;
            Assert.IsFalse(rect.Contains(other));
        }

        [TestMethod]
        public void RectangleXRectangleIntersection()
        {
            var rect1 = new Rect();
            rect1.Width = 20;
            rect1.Height = 20;

            var rect2 = new Rect();
            rect2.Width = 20;
            rect2.Height = 20;


            for (int i = 0; i < 20; i++, rect2.X++, rect2.Y++)
                Assert.IsTrue(rect1.Intersects(rect2));

            rect2.X++;
            rect2.Y++;

            Assert.IsFalse(rect1.Intersects(rect2));

            rect2.Y = 0;
            rect2.Left = rect1.Right;
            Assert.IsTrue(rect1.Intersects(rect2));

            rect2.X++;
            Assert.IsFalse(rect1.Intersects(rect2));

            rect2.X = 0;

            rect2.Top = rect1.Bottom;
            Assert.IsTrue(rect1.Intersects(rect2));

            rect2.Y++;
            Assert.IsFalse(rect1.Intersects(rect2));
        }

        [TestMethod]
        public void RectangleXRectangleIntersectionArea()
        {
            var rect1 = new Rect();
            rect1.Width = 20;
            rect1.Height = 20;

            var rect2 = new Rect();
            rect2.X = 10;
            rect2.Y = 10;
            rect2.Width = 20;
            rect2.Height = 20;

            var i1 = rect2.IntersectionArea(rect1);
            var i2 = rect1.IntersectionArea(rect2);

            Assert.IsTrue(i1 == i2);
            Assert.IsTrue(i1.X == 10);
            Assert.IsTrue(i1.Y == 10);
            Assert.IsTrue(i1.Width == 10);
            Assert.IsTrue(i1.Height == 10);
        }
    }
}

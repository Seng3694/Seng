using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Seng.MonoGame.Core;
using System;

namespace Tests.CoreTests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void EquatableTest()
        {
            var circle1 = new Circle();
            circle1.X = 10;
            circle1.Y = 20;
            circle1.Radius = 20;

            var circle2 = new Circle();
            circle2.X = 10;
            circle2.Y = 20;
            circle2.Radius = 20;

            var eq1 = circle1 as IEquatable<Circle>;
            var eq2 = circle2 as IEquatable<Circle>;

            Assert.IsTrue(eq1.Equals(eq2));
        }

        [TestMethod]
        public void SetLeft()
        {
            var circle = new Circle();
            circle.Radius = 10;
            circle.Left = 20;

            Assert.IsTrue(circle.Left == 20);
            Assert.IsTrue(circle.X == 20);
        }

        [TestMethod]
        public void SetTop()
        {
            var circle = new Circle();
            circle.Radius = 10;
            circle.Top = 20;

            Assert.IsTrue(circle.Top == 20);
            Assert.IsTrue(circle.Y == 20);
        }

        [TestMethod]
        public void SetRight()
        {
            var circle = new Circle();
            circle.X = 3;
            circle.Y = 3;
            circle.Radius = 10;

            circle.Right = 0;

            Assert.IsTrue(circle.Right == 0);
            Assert.IsTrue(circle.X == -20);
            Assert.IsTrue(circle.Y == 3);
            Assert.IsTrue(circle.Radius == 10);
        }

        [TestMethod]
        public void SetBottom()
        {
            var circle = new Circle();
            circle.X = 3;
            circle.Y = 3;
            circle.Radius = 10;

            circle.Bottom = 0;

            Assert.IsTrue(circle.Bottom == 0);
            Assert.IsTrue(circle.Y == -20);
            Assert.IsTrue(circle.X == 3);
            Assert.IsTrue(circle.Radius == 10);
        }

        [TestMethod]
        public void SetPosition()
        {
            var circle = new Circle();
            circle.Position = new Vector2(10, 20);

            Assert.IsTrue(circle.X == 10);
            Assert.IsTrue(circle.Y == 20);
        }

        [TestMethod]
        public void CircleXCircleIntersection()
        {
            var circle1 = new Circle();
            circle1.X = 10;
            circle1.Y = 10;
            circle1.Radius = 10;

            var circle2 = new Circle();
            circle2.X = 31;
            circle2.Y = 10;
            circle2.Radius = 10;

            Assert.IsFalse(circle1.Intersects(circle2));

            circle2.Left = circle1.Right;
            Assert.IsTrue(circle1.Intersects(circle2));

            circle2.Position = new Vector2(11, 11);
            Assert.IsTrue(circle1.Intersects(circle2));
        }

        [TestMethod]
        public void CircleXRectIntersection()
        {
            var circle = new Circle();
            circle.X = 10;
            circle.Y = 10;
            circle.Radius = 10;

            var rect = new Rect();
            rect.Width = 30;
            rect.Height = 60;

            rect.Center = new Vector2(rect.Center.X, circle.Y);

            //rect.Right touches circle.Left
            rect.Right = circle.Left;
            Assert.IsTrue(circle.Intersects(rect));
            rect.X--;
            Assert.IsFalse(circle.Intersects(rect));

            //rect.Left touches circle.Right
            rect.Left = circle.Right;
            Assert.IsTrue(circle.Intersects(rect));
            rect.X++;
            Assert.IsFalse(circle.Intersects(rect));

            rect.Center = new Vector2(circle.X, rect.Center.Y);

            //rect.Bottom touches circle.Top
            rect.Bottom = circle.Top;
            Assert.IsTrue(circle.Intersects(rect));
            rect.Y--;
            Assert.IsFalse(circle.Intersects(rect));

            //rect.Top touches circle.Bottom
            rect.Top = circle.Bottom;
            Assert.IsTrue(circle.Intersects(rect));
            rect.Y++;
            Assert.IsFalse(circle.Intersects(rect));

            //rect topleft => circle.bottomright
            rect.Left = circle.Right;
            rect.Top = circle.Bottom;
            Assert.IsFalse(circle.Intersects(rect));

            rect.X--;
            rect.Y--;
            Assert.IsFalse(circle.Intersects(rect));
            rect.X -= 4;
            rect.Y -= 4;
            Assert.IsTrue(circle.Intersects(rect));


            //rect topright => circle.bottomleft
            rect.Right = circle.Left;
            rect.Top = circle.Bottom;
            Assert.IsFalse(circle.Intersects(rect));

            rect.X++;
            rect.Y--;
            Assert.IsFalse(circle.Intersects(rect));
            rect.X += 4;
            rect.Y -= 4;
            Assert.IsTrue(circle.Intersects(rect));


            //rect bottomright => circle topleft
            rect.Right = circle.Left;
            rect.Bottom = circle.Top;
            Assert.IsFalse(circle.Intersects(rect));

            rect.X++;
            rect.Y++;
            Assert.IsFalse(circle.Intersects(rect));
            rect.X += 4;
            rect.Y += 4;
            Assert.IsTrue(circle.Intersects(rect));


            //rect bottomleft => circle topright
            rect.Left = circle.Right;
            rect.Bottom = circle.Top;
            Assert.IsFalse(circle.Intersects(rect));

            rect.X--;
            rect.Y++;
            Assert.IsFalse(circle.Intersects(rect));
            rect.X -= 4;
            rect.Y += 4;
            Assert.IsTrue(circle.Intersects(rect));
        }
    }
}

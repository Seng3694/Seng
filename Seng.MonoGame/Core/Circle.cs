using Microsoft.Xna.Framework;
using System;

namespace Seng.MonoGame.Core
{
    public struct Circle : IEquatable<Circle>
    {
        public float X;
        public float Y;
        public float Radius;

        public float Diameter
        {
            get { return Radius * 2; }
            set { Radius = value / 2; }
        }

        public float CenterX
        {
            get { return X + Radius; }
            set { X = value - Radius; }
        }

        public float CenterY
        {
            get { return Y + Radius; }
            set { Y = value - Radius; }
        }

        public float Left
        {
            get { return X; }
            set { X = value; }
        }

        public float Top
        {
            get { return Y; }
            set { Y = value; }
        }

        public float Right
        {
            get { return X + Radius * 2; }
            set { X = value - Radius * 2; }
        }

        public float Bottom
        {
            get { return Y + Radius * 2; }
            set { Y = value - Radius * 2; }
        }

        public float Width
        {
            get { return Radius * 2; }
            set { Radius = value / 2; }
        }

        public float Height
        {
            get { return Radius * 2; }
            set { Radius = value / 2; }
        }

        public Vector2 TopLeft
        {
            get { return new Vector2(X, Y); }
        }

        public Vector2 TopRight
        {
            get { return new Vector2(Right, Y); }
        }

        public Vector2 BottomRight
        {
            get { return new Vector2(Right, Bottom); }
        }

        public Vector2 BottomLeft
        {
            get { return new Vector2(X, Bottom); }
        }

        public Vector2 Position
        {
            get { return new Vector2(X, Y); }
            set { X = value.X; Y = value.Y; }
        }

        public Vector2 Center
        {
            get { return new Vector2(X + Radius, Y + Radius); }
            set { X = value.X - Radius; Y = value.Y - Radius; }
        }

        public Vector2 Size
        {
            get { return new Vector2(Radius * 2, Radius * 2); }
        }

        public Circle(Vector2 position, float radius)
            : this(position.X, position.Y, radius)
        {
        }

        public Circle(float radius)
            : this(0, 0, radius)
        {
        }

        public Circle(float x, float y, float radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public bool Intersects(Circle other)
        {
            return (Radius + other.Radius) >= Vector2.Distance(Center, other.Center);
        }

        public bool Intersects(Rect rect)
        {
            var circleDistanceX = Math.Abs(CenterX - rect.Center.X);
            var circleDistanceY = Math.Abs(CenterY - rect.Center.Y);

            if (circleDistanceX > (rect.Width / 2 + Radius)) return false;
            if (circleDistanceY > (rect.Height / 2 + Radius)) return false;

            if (circleDistanceX <= (rect.Width / 2)) return true;
            if (circleDistanceY <= (rect.Height / 2)) return true;

            var cornerDistanceSq = Math.Pow(circleDistanceX - rect.Width / 2, 2) +
                                 Math.Pow(circleDistanceY - rect.Height / 2, 2);

            return cornerDistanceSq <= Math.Pow(Radius, 2);
        }

        public bool Equals(Circle other)
        {
            return X == other.X && Y == other.Y && Radius == other.Radius;
        }

        public override bool Equals(object obj)
        {
            if (obj is Circle)
                return this == (Circle)obj;
            return false;
        }

        public override int GetHashCode()
        {
            return 17 * (23 + X.GetHashCode()) * (23 + Y.GetHashCode()) * (23 + Radius.GetHashCode());
        }

        public static bool operator ==(Circle a, Circle b)
        {
            if (a.X == b.X && a.Y == b.Y)
                return a.Radius == b.Radius;
            return false;
        }

        public static bool operator !=(Circle a, Circle b)
        {
            if (a.X != b.X || a.Y != b.Y)
                return a.Radius != b.Radius;
            return false;
        }

        public override string ToString()
        {
            return $"L:{Left.ToString(".00")} T:{Top.ToString(".00")} R:{Right.ToString(".00")} B:{Bottom.ToString(".00")}";
        }
    }
}

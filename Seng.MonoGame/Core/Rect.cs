using Microsoft.Xna.Framework;
using System;

namespace Seng.MonoGame.Core
{
    public struct Rect : IEquatable<Rect>
    {
        public float X;
        public float Y;
        public float Width;
        public float Height;

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
            get { return Left + Width; }
            set { X = value - Width; }
        }

        public float Bottom
        {
            get { return Top + Height; }
            set { Y = value - Height; }
        }

        public Vector2 Position
        {
            get { return new Vector2(X, Y); }
            set { X = value.X; Y = value.Y; }
        }

        public Vector2 Size
        {
            get { return new Vector2(Width, Height); }
            set { Width = value.X; Height = value.Y; }
        }

        public Vector2 Center
        {
            get { return new Vector2(X + Width / 2, Y + Height / 2); }
            set
            {
                X = value.X - Width / 2;
                Y = value.Y - Height / 2;
            }
        }

        public Vector2 TopLeft
        {
            get { return new Vector2(X, Y); }
        }

        public Vector2 TopRight
        {
            get { return new Vector2(X + Width, Y); }
        }

        public Vector2 BottomLeft
        {
            get { return new Vector2(X, Y + Height); }
        }

        public Vector2 BottomRight
        {
            get { return new Vector2(X + Width, Y + Height); }
        }

        public Vector2 TopCenter
        {
            get { return new Vector2(X + Width / 2, Y); }
        }

        public Vector2 CenterLeft
        {
            get { return new Vector2(X, Y + Height / 2); }
        }

        public Vector2 CenterRight
        {
            get { return new Vector2(X + Width, Y + Height / 2); }
        }

        public Vector2 BottomCenter
        {
            get { return new Vector2(X + Width / 2, Y + Height); }
        }

        public Rect TopLeftQuarter => new Rect(X, Y, Width / 2, Height / 2);
        public Rect TopRightQuarter => new Rect(X + Width / 2, Y, Width / 2, Height / 2);
        public Rect BottomLeftQuarter => new Rect(X, Y + Height / 2, Width / 2, Height / 2);
        public Rect BottomRightQuarter => new Rect(X + Width / 2, Y + Height / 2, Width / 2, Height / 2);

        public Rect(Vector2 position, Vector2 size)
            : this(position.X, position.Y, size.X, size.Y)
        {
        }

        public Rect(float size)
            : this(0, 0, size, size)
        {
        }

        public Rect(float x, float y, float size)
            : this(x, y, size, size)
        {
        }

        public Rect(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public bool Contains(Rect rect)
        {
            return Contains(rect.X, rect.Y)
                && Contains(rect.X + rect.Width, rect.Y + rect.Height);
        }

        public bool Contains(Vector2 position)
        {
            return Contains(position.X, position.Y);
        }

        public bool Contains(float x, float y)
        {
            if (X <= x && x <= X + Width && Y <= y)
                return y <= Y + Height;
            return false;
        }

        public void Inflate(float amount)
        {
            Inflate(amount, amount);
        }

        public void Inflate(float horizontalAmount, float verticalAmount)
        {
            X -= horizontalAmount;
            Y -= verticalAmount;
            Width += horizontalAmount * 2;
            Height += verticalAmount * 2;
        }

        public bool Intersects(Rect rect)
        {
            return Right >= rect.Left
                && Left <= rect.Right
                && Bottom >= rect.Top
                && Top <= rect.Bottom;
        }

        public Rect IntersectionArea(Rect other)
        {
            var width = Math.Min(X + Width, other.X + other.Width);
            var height = Math.Min(Y + Height, other.Y + other.Height);
            var x = Math.Max(X, other.X);
            var y = Math.Max(Y, other.Y);
            return new Rect(x, y, width - x, height - y);
        }

        public bool Equals(Rect other)
        {
            return X == other.X && Y == other.Y && Width == other.Width && Height == other.Height;
        }

        public override bool Equals(object obj)
        {
            if (obj is Rect)
                return this == (Rect)obj;
            return false;
        }

        public override int GetHashCode()
        {
            return 17 * (23 + X.GetHashCode()) * (23 + Y.GetHashCode()) * (23 + Width.GetHashCode()) * (23 + Height.GetHashCode());
        }

        public static bool operator ==(Rect a, Rect b)
        {
            if (a.X == b.X && a.Y == b.Y && a.Width == b.Width)
                return a.Height == b.Height;
            return false;
        }

        public static bool operator !=(Rect a, Rect b)
        {
            if (a.X != b.X || a.Y != b.Y || a.Width != b.Width)
                return a.Height != b.Height;
            return false;
        }

        public static Rect operator +(Rect a, Rect b)
        {
            var rect = new Rect();
            rect.Position = Vector2.Min(a.Position, b.Position);
            rect.Size = Vector2.Max(a.Size, b.Size);
            return rect;
        }

        public override string ToString()
        {
            return $"L:{Left.ToString(".00")} T:{Top.ToString(".00")} R:{Right.ToString(".00")} B:{Bottom.ToString(".00")}";
        }
    }
}

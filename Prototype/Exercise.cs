using System;

namespace Coding.Exercise
{
    public class Point
    {
        public int X, Y;
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            var startCopy = new Point { X = Start.X, Y = Start.Y };
            var endCopy = new Point { X = End.X, Y = End.Y };
            return new Line() { Start = startCopy, End = endCopy };
        }
    }
}

using System;
using System.Collections.Generic;

namespace BOOPM3_08_10
{
    class Program
    {
        public enum RectangleColor { Red, Blue, Yellow, White, Pink }

        public class Rectangle : IEquatable<Rectangle>
        {
            public RectangleColor Color { get; set; }
            public decimal Height { get; set; }
            public decimal Width { get; set; }
            public decimal Area => Height * Width;
            public bool Equals(Rectangle other) => (Height, Width, Color) == (other.Height, other.Width, other.Color);

            public override string ToString() => $"{Color} rectangle with height: {Height:N2}, width: {Width:N2} and area: {Area:N2}";

            #region Needed to implement as part of IEquatable
            public override int GetHashCode() => (Width, Height, Color).GetHashCode();
            public override bool Equals(object obj) => Equals(obj as Rectangle);
            #endregion

            public Rectangle()
            {
                //Get the random generator
                var rnd = new Random();

                //Get random color between Red and Pink, explict type casting needed
                Color = (RectangleColor)rnd.Next((int)RectangleColor.Red, (int)RectangleColor.Pink + 1);

                Height = rnd.Next(1, 101);
                Width = rnd.Next(1, 101);
            }
        }

        static void Main(string[] args)
        {
            //Queue<T>
            Queue<Rectangle> queue1 = new Queue<Rectangle>();
            queue1.Enqueue(new Rectangle() { Color = RectangleColor.Red, Height = 10, Width = 20 });
            queue1.Enqueue(new Rectangle() { Color = RectangleColor.Blue, Height = 10, Width = 20 });
            queue1.Enqueue(new Rectangle() { Color = RectangleColor.Yellow, Height = 100, Width = 100 });
            queue1.Enqueue(new Rectangle() { Color = RectangleColor.White, Height = 15, Width = 200 });
            queue1.Enqueue(new Rectangle() { Color = RectangleColor.Pink, Height = 45, Width = 15 });

            Console.WriteLine(queue1.Count); //5

            Rectangle r2 = queue1.Dequeue();
            Console.WriteLine(r2); // red

            r2 = queue1.Peek();
            Console.WriteLine(r2); // blue

            r2 = queue1.Dequeue();
            Console.WriteLine(r2); // blue
        }
    }
}

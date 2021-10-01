using System;
using System.Collections.Generic;

namespace BOOPM3_08_09
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
            //Stack<T>
            Stack<Rectangle> stack1 = new Stack<Rectangle>();
            stack1.Push(new Rectangle() { Color = RectangleColor.Red, Height = 10, Width = 20 });
            stack1.Push(new Rectangle() { Color = RectangleColor.Blue, Height = 10, Width = 20 });
            stack1.Push(new Rectangle() { Color = RectangleColor.Yellow, Height = 100, Width = 100 });
            stack1.Push(new Rectangle() { Color = RectangleColor.White, Height = 15, Width = 200 });
            stack1.Push(new Rectangle() { Color = RectangleColor.Pink, Height = 45, Width = 15 });

            Console.WriteLine(stack1.Count); //5

            Rectangle r2 = stack1.Pop();
            Console.WriteLine(r2); // pink

            r2 = stack1.Peek();
            Console.WriteLine(r2); // white

            r2 = stack1.Pop();
            Console.WriteLine(r2); // white
        }
    }
}
//Exercises:
//1.    Modify the DeckOfCards from BOOPM3_08_07
//      - Implement a Method ReadyToDeal that returns the card deck as a Stack<PlayingCard>. 
//2     In Mains, use ReadyToDeal to deal out the top 5 cards from the deck, printing them out one by one

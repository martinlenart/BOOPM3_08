﻿using System;
using System.Collections.Generic;

namespace BOOPM3_08_07
{
    class Program
    {
        public enum RectangleColor { Red, Blue, Yellow, White, Pink}

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
                Color = (RectangleColor) rnd.Next((int) RectangleColor.Red, (int)RectangleColor.Pink + 1);

                Height = rnd.Next(1, 101);
                Width = rnd.Next(1, 101);
            }
        }
        static void Main(string[] args)
        {
            //List<T>
            List<Rectangle> list1 = new List<Rectangle>() {
                new Rectangle(){ Color = RectangleColor.Red, Height = 10, Width = 20 },
                new Rectangle(){ Color = RectangleColor.Blue, Height = 10, Width = 20 },
                new Rectangle(){ Color = RectangleColor.Yellow, Height = 100, Width = 100 },
                new Rectangle(){ Color = RectangleColor.White, Height = 15, Width = 200 },
                new Rectangle(){ Color = RectangleColor.Pink , Height = 45, Width =15 }};

            //Add two random rectangle using the constructor
            list1.Add(new Rectangle());
            list1.Add(new Rectangle());

            Console.WriteLine($"Rectangles in a {list1.GetType().Name}:");
            foreach (var item in list1)
                Console.WriteLine(item);

            Console.WriteLine($"\nRectangles in a {list1.GetType().Name} with list reversed:");
            list1.Reverse();
            foreach (var item in list1)
                Console.WriteLine(item);

            Console.WriteLine($"\nBig-O speed test:");
            const int HugeNrCreated = 1_000_000;            // takes about 1.6s on my machine
            const int HugeNrInserted = 100_000;             // takes about 26s on my machine!! 
            const int ZeroRectPosition = HugeNrCreated - 1; // takes about 23ms on my machine

            //Lets create HugeNrCreated random rectangles in a fresh list and measure the time
            List<Rectangle> list2 = new List<Rectangle>();
            DateTime starttime = DateTime.Now;

            for (int i = 0; i < HugeNrCreated; i++)
            {
                if (i == ZeroRectPosition)
                {
                    //This is the only Rectangle with width and Height equal to zero
                    list2.Add(new Rectangle { Color = RectangleColor.Red, Height = 0, Width = 0 });
                }
                else
                {
                    list2.Add(new Rectangle());
                }
            }

            var elapsedTime = DateTime.Now - starttime;
            Console.WriteLine($"Created a list with {HugeNrCreated:N0} rectangles in {elapsedTime.TotalMilliseconds:N0} ms. List contains {list2.Count:N0} elemnts");

            //Lets insert HugeNrInserted rectangles in the beginning of the list and measure the time 
            starttime = DateTime.Now;
            for (int i = 0; i < HugeNrInserted; i++)
            {
                list2.Insert(0,new Rectangle());
            }
            elapsedTime = DateTime.Now - starttime;
            Console.WriteLine($"Inserted {HugeNrInserted:N0} rectangles at the beginning in {elapsedTime.TotalMilliseconds:N0} ms. List contains {list2.Count:N0} elemnts");
 
            //Lets search for the special rectangle
            starttime = DateTime.Now;

            var element = list2.Find(x=> x.Area == 0);

            elapsedTime = DateTime.Now - starttime;

            if (element != null)
                Console.WriteLine($"Found the ZERORect in {elapsedTime.TotalMilliseconds:N0} ms. List contains {list2.Count:N0} elemnts");

        }
    }
}
//Exercises
//1.    Use the PlayingCard class from BOOPM3_08_04 and implement a card deck as a List<PlayingCard>. 
//2.    Encapsulate the List<PlayingCard> in a class DeckOfCards
//      - DeckOfCards constructor should create a new fresh deck
//      - Write a Method that shuffles the cards


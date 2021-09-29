using System;

namespace BOOPM3_08_03
{
    public class Rectangle
    {
        public virtual float Width { get; set; }
        public virtual float Height { get; set; }
        public double Area => Width * Height;
        public override string ToString() => $"Width: {Width}  Height: {Height}  Area: {Area}";
        
        public Rectangle() { }
        public Rectangle (float width, float height)
        {
            Width = width;
            Height = height;
        }
    }
    public class SquareFailingLiskov : Rectangle
    {
        public new float Width { set => base.Width = base.Height = value; }
        public new float Height { set => base.Width = base.Height = value; }
        public SquareFailingLiskov(float side)
        {
            Width = Height = side;
        }
    }
    public class SquarePassingLiskov : Rectangle 
    { 
        public override float Width { set => base.Width = base.Height = value; }
        public override float Height { set => base.Width = base.Height = value; }
        public SquarePassingLiskov(float side)
        {
            Width = Height = side;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rectangle with various heights");
            var rc1 = new Rectangle(5, 15);
            VariousHeights(rc1);

            Console.WriteLine();
            Console.WriteLine("Square with various heights: Failing Liskov");
            var sq1 = new SquareFailingLiskov(5);
            VariousHeights(sq1);

            Console.WriteLine();
            Console.WriteLine("Square with various heights: Passing Liskov");
            var sq2 = new SquarePassingLiskov(5);
            VariousHeights(sq2);
        }

        static void VariousHeights(Rectangle rc)
        {
            for (int i  = 1; i  < 4; i ++)
            {
                rc.Height *= i;
                Console.WriteLine(rc);
            }
        }
    }
}

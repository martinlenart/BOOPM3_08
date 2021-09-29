using System;

namespace BOOPM3_08_02b
{
    public class Bird
    {
        public virtual bool ICanFly { get; } = true;
    }
    public class Duck : Bird { }
    public class Ostrich : Bird
    {
        public override bool ICanFly { get; } = false;
    }

    class Program
    {
        static void Main(string[] args)
        {
            CanIFly(new Bird());
            CanIFly(new Duck());
            CanIFly(new Ostrich());

        }
        static void CanIFly(Bird bird)
        {
            if (bird.ICanFly)
            {
                Console.WriteLine($"Hello, I am a {bird.GetType()}. Hurray! I can fly!");
            }
            else
            {
                Console.WriteLine($"Hello, I am a {bird.GetType()}. Sadly, I cannot fly!");
            }
        }
    }
}

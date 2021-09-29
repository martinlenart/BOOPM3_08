using System;

namespace BOOPM3_08_06
{
    class Program
    {
        static void Main(string[] args)
        {
			long size1 = GC.GetTotalMemory(true);

			Globals myGlobals = Globals.GetSingleton();
            Console.WriteLine(myGlobals.config1);

			long size2 = GC.GetTotalMemory(true);

			Console.WriteLine($"Memory allocated by GC:  {size2 - size1:N0} bytes");
			Console.WriteLine();


			Console.WriteLine("Now I access Lazy Data");
			long length = myGlobals.Data.Length;

			long size3 = GC.GetTotalMemory(true);

			Console.WriteLine($"Memory allocated by GC:  {size3 - size2:N0} bytes");
		}
	}
}

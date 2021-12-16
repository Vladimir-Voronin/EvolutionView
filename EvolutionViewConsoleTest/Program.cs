using System;

namespace EvolutionViewConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int a = rand.Next(0, 2);
                Console.WriteLine(a);
            }
        }
    }
}

using System;

namespace WorldDbQuerier
{
    class Program
    {
        static string version = "0.1";

        static void Version()
        {
            Console.WriteLine("WorldDbQuerier {0}", version);
        }

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "-v":
                        Version();
                        break;
                    default:
                        Console.WriteLine("Onbekend argument");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Hello World");
            }
        }
    }
}

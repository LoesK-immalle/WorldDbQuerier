using System;
using MySql.Data.MySqlClient;

namespace WorldDbQuerier
{
    class Program
    {
        static string version = "0.2";

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
        }
    }
}

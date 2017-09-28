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
        static void AmountOfCountries()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server=192.168.56.101;Port=3306;Database=world;Uid=imma;Pwd=ImmaPwd;";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT count(*) FROM world.Country";

            conn.Open();

            int amountOfCountries = Convert.ToInt32(cmd.ExecuteScalar());

            Console.WriteLine("Amount of Countries : {0}", amountOfCountries);
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

            AmountOfCountries();
        }
    }
}

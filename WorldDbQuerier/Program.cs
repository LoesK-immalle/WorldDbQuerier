using System;
using MySql.Data.MySqlClient;

namespace WorldDbQuerier
{
    class Program
    {
        static string version = "0.4";

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

        static void ShowAllCountries()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server=192.168.56.101;Port=3306;Database=world;Uid=imma;Pwd=ImmaPwd;";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM world.Country";

            conn.Open();

            MySqlDataReader rdr = null;
            rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                string name = (string)rdr["Name"];
                Console.WriteLine(name);
            }
            rdr.Dispose();
            conn.Close();
        }
        public static void SearchCountry(string searchParameter)
        {
            MySqlConnection comm = new MySqlConnection();
            comm.ConnectionString = "Server=192.168.56.101;Port=3306;Database=world;Uid=imma;Pwd=ImmaPwd;";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = comm;

            comm.Open();

            cmd.CommandText = "SELECT Code, Name, Continent, Region FROM Country WHERE Name LIKE @searchParameter";
            cmd.Parameters.AddWithValue("@searchParameter", "%" + searchParameter + "%");
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}", reader[1]));

            }
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
            string choice;
            Console.WriteLine("Make a choice");
            Console.WriteLine("1. Show amount of countries in database");
            Console.WriteLine("2. Show all countries in database");
            Console.WriteLine("3. Search for a country");
            choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    AmountOfCountries();
                    break;
                case "2":
                    ShowAllCountries();
                    break;
                case "3":
                    Console.WriteLine("What country are you looking for?");
                    string response2 = Console.ReadLine();
                    Console.WriteLine("This is not the country you were looking for ;)");
                    SearchCountry(response2); break;
            }
        }
    }
}

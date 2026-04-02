using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace BattleshipArifov
{
    internal class Driver
    {
        static void Main(string[] args)
        {

            ShipFactory shipFactory = new ShipFactory();

            string filepath = @"filepath";
            string shipInfo;
            string userInput;
            int xPostion;
            int yPostion;
            bool noDamage = true;

            string pattern = @"^(\d+),\s*(\d+)$";
            Regex newCordMatch = new Regex(pattern);

            //if (args.Length > 0)
            //{
            //    filepath = args[0];
            //}
            //else
            //{
            //    Console.WriteLine("Provide a filepath for Battleship");
            //    filepath = Console.ReadLine();
            //}

            try
            {
                File.Exists(filepath);
            }
            catch (Exception)
            {
                Console.WriteLine("filepath not found");
                Environment.Exit(0);
            }

            Ship[] Ships = shipFactory.ParseShipFile(filepath);

            Console.WriteLine("Welcome to Battleship Game");
            Console.WriteLine("\nCommands to Request Are Following:");
            Console.WriteLine("info");
            Console.WriteLine("x,y");
            Console.WriteLine("exit\n");

            while (true)
            {
                userInput = Console.ReadLine();

                if (userInput == "info")
                {
                    for (int i = 0; i < Ships.Length; i++)
                    {
                        shipInfo = Ships[i].GetInfo();
                        Console.WriteLine(shipInfo);
                    }
                }
                else if (userInput == "exit")
                {
                    Environment.Exit(0);
                } 
                else if (newCordMatch.Match(userInput).Success)
                {
                    xPostion = int.Parse(newCordMatch.Match(userInput).Groups[1].Value);
                    yPostion = int.Parse(newCordMatch.Match(userInput).Groups[2].Value);

                    Coord2D cordDamage = new Coord2D { x = xPostion, y = yPostion };

                    for (int i = 0; i < Ships.Length; i++)
                    {
                        if (Ships[i].CheckIfHit(cordDamage)) 
                        { 
                            Ships[i].TakeDamage(cordDamage);
                            noDamage = false;
                            Console.WriteLine($"{Ships[i].GetName()} has been damaged at ({cordDamage.x}, {cordDamage.y})");
                        }
                    }

                    if (noDamage)
                    {
                        Console.WriteLine("No Ship has been damaged");
                    }

                    noDamage = true;
                }
                else
                {
                    Console.WriteLine("Command not recognized");
                }

                int count = 0;
                for (int i = 0; i < Ships.Length; i++)
                {
                    if (Ships[i].IsDead()) { count++; }
                }
                
                if (count == Ships.Length) 
                {
                    Console.WriteLine("You WIN!");
                    Environment.Exit(0); 
                }

            }
        }
    }
}

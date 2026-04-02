using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BattleshipArifov
{
    public class ShipFactory
    {
        public bool VerifyShipString(string description)
        {
            // regular expression
            // contains name/type, position, and ship's direction
            // ship length is less than 6
            // ship's position and length would not cause a point to be greater than or equal to 10 or less than 0 on either the X or Y axis

            // example string
            // Format: Ship, length, direction, x position, y position
            // Battleship, 4, v, 6, 3
            // Patrol Boat

            string pattern = @"^([\w\s]+),\s*(\d+),\s*([vh]),\s*(\d+),\s*(\d+)$";
            string shipName;
            int length;
            int xPosition;
            int yPosition;
            string direction;
            Regex patternMatch = new Regex(pattern);

            if (patternMatch.Match(description).Success)
            {
                shipName = patternMatch.Match(description).Groups[1].Value;
                length = int.Parse(patternMatch.Match(description).Groups[2].Value);
                direction = patternMatch.Match(description).Groups[3].Value;
                xPosition = int.Parse(patternMatch.Match(description).Groups[4].Value);
                yPosition = int.Parse(patternMatch.Match(description).Groups[5].Value);

                if (length > 6)
                {
                    return false;
                }
                else if (direction == "v")
                {
                    if (yPosition + length >= 10 ||  yPosition + length < 0)
                    {
                        return false;
                    }
                }
                else if (direction == "h")
                {
                    if (xPosition + length >= 10 || yPosition + length < 0)
                    {
                        return false;
                    }
                }

                return true;

            } 
            
            return false;
        }

        public Ship ParseShipString(string description)
        {
            if (VerifyShipString(description) == false)
            {
                throw new Exception();
            }

            string pattern = @"^([\w\s]+),\s*(\d+),\s*([vh]),\s*(\d+),\s*(\d+)$";
            Regex patternMatch = new Regex(pattern);
            patternMatch.Match(description);

            string shipName = patternMatch.Match(description).Groups[1].Value;
            string direction = patternMatch.Match(description).Groups[3].Value;
            int xPosition = int.Parse(patternMatch.Match(description).Groups[4].Value);
            int yPosition = int.Parse(patternMatch.Match(description).Groups[5].Value);
            DirectionType direction1;

            Coord2D shipCoord = new Coord2D { x=xPosition, y=yPosition };
            if (direction == "h")
            {
                direction1 = DirectionType.Horizontal;
            } 
            else
            {
                direction1 = DirectionType.Vertical;
            }

            switch (shipName)
            {
                case "Carrier":
                    Ship ship = new Carrier(shipCoord, direction1);
                    return ship;
                case "Battleship":
                    Ship ship1 = new Battleship(shipCoord, direction1);
                    return ship1;
                case "Destroyer":
                    Ship ship2 = new Destroyer(shipCoord, direction1);
                    return ship2;
                case "Submarine":
                    Ship ship3 = new Submarine(shipCoord, direction1);
                    return ship3;
                case "Patrol Boat":
                    Ship ship4 = new Patrol_Boat(shipCoord, direction1);
                    return ship4;
                default:
                    throw new Exception();
            }
        }

        public Ship[] ParseShipFile(string filePath)
        {
            // parse each ship in given file
            // ignore lines with #

            // open file and get string from each line ignoring the # lines
            // run string to ParseShipString to Get Ship and add to Ship Array

             string[] lines = File.ReadAllLines(filePath);

            Regex lineMatch = new Regex(@"^#.*");
            int count = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                if (!lineMatch.Match(lines[i]).Success)
                {
                    count++;
                }
            }

            Ship[] ships = new Ship[count];
            count = 0;

            for (int i = 0; i < lines.Length; i++)
            {

                if (!lineMatch.Match(lines[i]).Success)
                {
                    Ship ship = ParseShipString(lines[i]);
                    ships[count] = ship;
                    count++;
                }
            }

            return ships;
        }
    }
}

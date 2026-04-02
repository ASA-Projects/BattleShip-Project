using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipArifov
{
    public class Carrier : Ship
    {
        public Carrier(Coord2D position, DirectionType direction) : base(position, direction, 5)
        {
        }


    }

    public class Battleship : Ship
    {

        public Battleship(Coord2D position, DirectionType direction) : base(position, direction, 4)
        {
        }
    }

    public class Destroyer : Ship
    {
        public Destroyer(Coord2D position, DirectionType direction) : base(position, direction, 3)
        {
        }
    }

    public class Submarine : Ship
    {
        public Submarine(Coord2D position, DirectionType direction) : base(position, direction, 3)
        { 
        }
    }

    public class Patrol_Boat : Ship
    {
        public Patrol_Boat(Coord2D position, DirectionType direction) : base(position, direction, 2)
        {
        }
    }
}

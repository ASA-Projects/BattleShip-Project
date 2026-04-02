using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipArifov
{
    public abstract class Ship : IHealth, IInfomatic
    {
        private Coord2D Position;
        private byte Length;
        private DirectionType Direction;
        private Coord2D[] Points;
        private List<Coord2D> DamagedPoints;

        public Ship(Coord2D position, DirectionType direction, byte length)
        {
            Position = position;
            Length = length;
            Direction = direction;

            Points = new Coord2D[Length];
            DamagedPoints = new List<Coord2D>(Length);

            for (int i = 0; i < Length; i++)
            {
                if (Direction == DirectionType.Horizontal)
                {

                    Coord2D newPosition = new Coord2D { x = Position.x+i, y = Position.y };

                    Points[i] = newPosition;
                }
                else if (Direction == DirectionType.Vertical)
                {
                    Coord2D newPosition = new Coord2D { x = Position.x, y = Position.y+i };

                    Points[i] = newPosition;
                }
            }

        }

        public bool CheckIfHit(Coord2D position)
        {
            for (int i = 0; i < Points.Length; i++)
            {
                if (Points[i].Equals(position))
                {
                    return true;
                }
            }
            return false;
        }

        public void TakeDamage(Coord2D point)
        {
            if (!DamagedPoints.Contains(point))
            {
                DamagedPoints.Add(point);
            }
        }

        public string GetName()
        {
            return this.GetType().Name;
        }

        public int GetMaxHealth()
        {
            return Length;
        }

        public int GetCurrentHealth()
        {
            int currentHealth = GetMaxHealth() - DamagedPoints.Count;
            return currentHealth;
        }

        public bool IsDead()
        {
            if (GetCurrentHealth() <= 0) 
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public string GetInfo()
        {
            string info = $"Max Health: {GetMaxHealth()}, Current Health: {GetCurrentHealth()}, Is Dead?: {IsDead()}, " +
                $"Position: ({Position.x},{Position.y}), Length: {Length}, Direction: {Direction}";
            return info;
        }


    }
}

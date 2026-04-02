using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipArifov
{
    internal interface IHealth
    {
        public int GetMaxHealth();
        public int GetCurrentHealth();
        public bool IsDead();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyGame.Units
{
    public class Berserker : Unit
    {
        public int Rage  { get; set; }
        public readonly int unitCost = 4;

        public Berserker(Player p )
        {
            Health = 5;
            Rage = 0;
            Damage = 2;
            Owner = p;  
        }


        protected override bool Attack(Unit unit)
        {
            Rage++;
            unit.Health -= this.Damage;
            if(Rage == 2)
            {
            this.Health += 1;
            }
            return true;
        }

        protected override bool IsAlive()
        {
            return Health > 0;
        }
    }
}

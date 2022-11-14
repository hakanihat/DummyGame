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
        public static readonly int unitCost = 4;

        public Berserker(Player p )
        {
            Health = 5;
            Rage = 0;
            Damage = 2;
            Owner = p;  
            IsRanged = false;
        }


        public override int Attack(Unit unit)
        {
            Rage++;
            unit.Health -= this.Damage;
            if(Rage == 2)
            {
            this.Health += 1;
            Rage = 0;
            }
            return unit.Health;
        }

        public override void DirectAttack(Player p)
        {
            p.Health -= Damage;
        }

        protected override bool IsAlive()
        {
            return Health > 0;
        }

        public override string ToString()
        {
            return this.GetType().Name + " with coordinates [" + (Coordinates.First().Key + 1) + "," + (Coordinates.First().Value + 1) + "]";
        }
    }
}

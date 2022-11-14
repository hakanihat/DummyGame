using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyGame.Units
{
    public class Archer : Unit
    {
        public int Focus { get; set; }
        public static readonly int unitCost = 3;

        public Archer(Player p)
        {
            Health = 3;
            Focus = 0;
            Damage = 3;
            Owner = p;  
            IsRanged = true;
        }


        public override int Attack(Unit unit)
        {
            Focus++;
            unit.Health -= this.Damage;
            if (Focus == 3)
            {
                unit.Health -= this.Damage;
                return unit.Health;
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
            return this.GetType().Name + " with coordinates [" + (Coordinates.First().Key+1) +","+ (Coordinates.First().Value + 1)+"]";
        }

     
    }
}

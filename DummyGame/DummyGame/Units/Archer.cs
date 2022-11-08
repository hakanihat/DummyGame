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
        public readonly int unitCost = 3;

        public Archer()
        {
            Health = 3;
            Focus = 0;
            Damage = 3;
        }


        protected override bool Attack(Unit unit)
        {
            Focus++;
            unit.Health -= this.Damage;
            if (Focus == 3 && unit != null)
            {
                unit.Health -= this.Damage;
                return false;
            }
            else if (Focus == 3 && unit == null)
            {
                return true;
            }
            return false;   
        }

        protected override bool IsAlive()
        {
            return Health > 0;
       
        }
    }
}

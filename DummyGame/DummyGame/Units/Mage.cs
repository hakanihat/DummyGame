using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyGame.Units
{
    public class Mage : Unit
    {
        public int Mana   { get; set; }
        public static readonly int unitCost = 5;

        public Mage(Player p )
        {
            Health = 5;
            Mana = 3;
            Damage = 2;
            Owner = p;
        }

        private void DoubleAtk()
        {
            Damage *= 2;
            Mana = 3;
        }

        protected override bool Attack(Unit unit)
        { 
            unit.Health -= this.Damage;
            return true;
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

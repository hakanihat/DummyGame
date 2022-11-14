using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyGame.Units
{
    public class Priest : Unit
    {
        public int Mana { get; set; }
        public static readonly int unitCost = 5;

        public Priest(Player p)
        {
            Health = 5;
            Mana = 2;
            Damage = 1;
            Owner = p;
            IsRanged = true;
        }

        private bool HealAnAlly(Unit unit)
        {
            if (Mana > 0 && unit.Owner.Name == this.Owner.Name )
            {
                unit.Health += 3;
                this.Mana -= 1;
                return true;
            }
            return false;
        }

        public override int Attack(Unit unit)
        {
            unit.Health -= this.Damage;
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

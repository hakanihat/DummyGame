using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyGame.Units
{
    public class Berserker : Unit
    {
        public int Rage = 0 { get; set; }
        public int readonly unitCost = 4;

        public Berserker()
        {
            Health = 5;
            Mana = 3;
            Damage = 2;
        }


        protected override bool Attack(Unit unit)
        {
            Rage++;
            unit.Health -= this.Damage;
            if(Rage == 2)
            {
            this.Health += 1;
            }
        }

        protected override void Death()
        {
            ~Berserker();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyGame.Units
{
    public class Priest : Unit
    {
        public int Mana { get; set; }
        public int readonly unitCost = 5;

        public Priest()
        {
            Health = 5;
            Mana = 2;
            Damage = 1;
        }

        private bool HealAnAlly(Unit unit)
        {
            if (Mana > 0)
            {
                unit.Health += 2;
                this.Mana -= 1;
                return true;
            }
            return false;
        }

        protected override bool Attack(Unit unit)
        {
            unit.Health -= this.Damage;
        }

        protected override void Death()
        {
            ~Priest();
        }
    }
}

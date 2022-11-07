﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyGame.Units
{
    public class Mage : Unit
    {
        public int Mana   { get; set; }
        public int readonly unitCost = 5;

        public Mage()
        {
            Health = 5;
            Mana = 3;
            Damage = 2;
        }

        private void DoubleAtk()
        {
            Damage *= 2;
            Mana = 3;
        }

        protected override bool Attack(Unit unit)
        { 
            unit.Health -= this.Damage;
        }

        protected override void Death()
        {
            ~Mage();
        }
    }
}

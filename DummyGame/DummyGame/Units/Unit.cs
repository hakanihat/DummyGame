﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyGame.Units
{
    public abstract class Unit
    {
        public int Health { get; set; }
        public int Damage { get; set; }

        protected abstract bool Attack(Unit unit);
        protected abstract void Death();
    }
}

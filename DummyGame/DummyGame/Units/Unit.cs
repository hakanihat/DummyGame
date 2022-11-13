using System;
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
        
        public Player? Owner { get; set; }

        public Dictionary<int, int>? Coordinates  { get; set; } = new Dictionary<int, int>();

        protected abstract bool Attack(Unit unit);
        protected abstract bool IsAlive();

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

using DummyGame.Units;

namespace DummyGame
{
    public class Player
    {
        public String Name { get; set; } = "Player"+playercounter;
        public int Health { get;  set; }

        public static int playercounter = 1;

        public bool turnCheker=false;
        public int Mana { get; private set; }

        public int UnitLimit { get; private set; }

        public List<Unit>? units  =  new List<Unit>(); 

        public Player( )
        {
            Health = 10;
            Mana = 10;
            UnitLimit = 3;
            playercounter++;
        }

        private bool checkUnitLimit()
        {
            return units.Count != 3; 
        }

        public bool IsAlive()
        {
           return Health > 0;
        }





    }
}
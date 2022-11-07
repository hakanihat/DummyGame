using DummyGame.Units;

namespace DummyGame
{
    public class Player
    {

        public int Health { get; private set; }

        public int Mana { get; private set; }

        public int UnitLimit { get; private set; }

        public List<Unit> units  =  new List<Unit>(); 

        Player( )
        {
            Health = 10;
            Mana = 10;
            UnitLimit = 3;
        }

        private bool checkUnitLimit()
        {
            return units.Count != 3; 
        }





    }
}
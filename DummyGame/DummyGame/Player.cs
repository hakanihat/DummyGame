namespace DummyGame
{
    public class Player
    {

        public int Health { get; private set; }

        public int Mana { get; private set; }

        public int UnitLimit { get; private set; }

        Player( )
        {
            Health = 10;
            Mana = 10;
            UnitLimit = 3;
        }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyGame.Units
{
    public interface IGameDisplayer
    {
        public void WelcomeMessage();
        public void SetPlayersName(Player player1,Player player2);
        public void TurnAnnouncer(Player player);
        public void BoardDrawer(Unit[,] units);





    }
}

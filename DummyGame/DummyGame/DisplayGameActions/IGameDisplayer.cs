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
        public void SetPlayersName(Player player1, Player player2);
        public void TurnAnnouncer(GameBoard gameBoard);
        public void BoardDrawer(Unit[,] units);
        public void WinnerAnnouncer(GameBoard gameBoard);

        public Unit? PickAnUnit(GameBoard gameBoard);

        public void SelectPlaceForUnit(GameBoard gameBoard);







    }
}

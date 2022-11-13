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
        public Player TurnAnnouncer(GameBoard gameBoard);
        public Player TurnSwitcher(GameBoard gb);
        public void BoardDrawer(GameBoard gameBoard);
        public void WinnerAnnouncer(GameBoard gameBoard);

        public Unit? PickAnUnit(Player p);

        public void SelectPlaceForUnit(GameBoard gameBoard,Player p);
        public void MoveAUnit(GameBoard gameBoard, Player p);

       







    }
}

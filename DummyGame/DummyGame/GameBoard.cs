using DummyGame.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DummyGame
{
    public class GameBoard
    {
        public readonly static int X = 3;
        public readonly static int Y = 4;
        public Player player1 = new Player();
        public Player player2 = new Player();
        public Unit?[,] board = new Unit[X, Y];
        public bool gameOver;
        public IGameDisplayer? GameDisplayer { get; private set; }

        public GameBoard()
        {
            GameDisplayer = new GameDisplayer();
        }

        public void RunTheGame()
        {
            GameDisplayer.WelcomeMessage();
            GameDisplayer.SetPlayersName(player1,player2);
            GameDisplayer.BoardDrawer(board);

            while (player1.IsAlive() && player2.IsAlive() && !gameOver)
            {
                GameDisplayer.TurnAnnouncer(this);
                GameDisplayer.SelectPlaceForUnit(this);

                GameDisplayer.BoardDrawer(board);


            }

            GameDisplayer.WinnerAnnouncer(this);
        }




       
    }
}

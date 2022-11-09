using DummyGame.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DummyGame
{
    public class GameBoard
    {
        private Player player1 = new Player();
        private Player player2 = new Player();
        public Unit?[,] board = new Unit[3, 4];
        private bool gameOver;
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
                
            }
        }


        private void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine("Hello to the game!");
            Console.ReadLine();

        }

        private void FinalResult()
        {
            Console.WriteLine("Bye!");
            gameOver = true;
            Console.ReadLine();
        }
       
    }
}

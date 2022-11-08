using DummyGame.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DummyGame
{
    public class GameBoard
    {
       private Player player1 = new Player();
       private Player player2 = new Player();
        private Unit[,] board = new Unit[3, 4]; 
       private bool gameOver;



       public void RunTheGame()
        {
            while(player1.IsAlive() && player2.IsAlive() && !gameOver)
            {
                Console.WriteLine("Welcome!!!");
            }
        }
       
    }
}

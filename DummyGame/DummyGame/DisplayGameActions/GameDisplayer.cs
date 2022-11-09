using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyGame.Units
{
    public class GameDisplayer : IGameDisplayer
    {
        public void BoardDrawer(Unit[,] units)
        {
            Console.WriteLine("\n\n");
            
            int m = 5;
            

            int i,j;
            for(i=0; i<units.GetLength(0); i++)
            {
                int k = 5;
                for (j=0; j<units.GetLength(1); j++)
                {
                    
                    Console.SetCursorPosition(k, m);
                    switch (units[i, j])
                    {
                        case null:
                            Console.Write("*\t");
                            break;
                        default:
                            Console.Write("-\t");
                            break;
                    }
                    k += 5;
                }
                Console.WriteLine("\n");
                m += 1;
            }
        }

        public void SetPlayersName(Player player1, Player player2)
        {
            
            try
            {
                Console.WriteLine("\nWhat's your name " + player1.Name);
                player1.Name = Console.ReadLine();
                Console.WriteLine("\nWhat's your name " + player2.Name);
                player2.Name = Console.ReadLine();

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Clear();    
        }

        public void TurnAnnouncer(Player player)
        {
            Console.WriteLine(player.Name + "'s turn:\n");
        }

        public void WelcomeMessage()
        {
           
            Console.WriteLine("Welcome to Dummy Game! ");

        }

        public void WinnerAnnouncer(Player player)
        {
            Console.WriteLine("Congratulation " + player.Name + "!");
        }

       
    }
}

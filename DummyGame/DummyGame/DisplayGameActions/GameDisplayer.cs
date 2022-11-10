﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyGame.Units
{
    public class GameDisplayer : IGameDisplayer
    {

        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Dummy Game! ");
        }
        public void BoardDrawer(Unit[,] units)
        {
            Console.Clear();
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
                            Console.Write("_\t");
                            break;
                        case Archer:
                            Console.Write(">\t");
                            break;
                        case Berserker:
                            Console.Write("#\t");
                            break;
                        case Mage:
                            Console.Write("@\t");
                            break;
                        case Priest:
                            Console.Write("%\t");
                            break;

                    }
                    k += 5;
                }
                Console.WriteLine("\n");
                m += 1;
            }
        }

        public Unit? PickAnUnit(GameBoard gameBoard)
        {
            Console.WriteLine("Summon an unit:\n");
            int ch = 0;
            try
            {
                do
                {
                    Console.WriteLine("1.Archer - 3 mana");
                    Console.WriteLine("2.Berserker - 4 mana");
                    Console.WriteLine("3.Mage - 5 mana");
                    Console.WriteLine("4.Priest - 5 mana");

                    ch = Int32.Parse(Console.ReadLine());

                } while (ch <= 0 && ch > 4);
            }
            catch(Exception )
            {
                Console.WriteLine("Please, choose a number between 1 and 4");
            }

            switch(ch)
            {
                case 1:
                    return new Archer();
                case 2:
                    return new Berserker();
                case 3:
                    return new Mage();
                case 4:
                    return new Priest();
                default:
                    return null;
            }
        }

        public void SelectPlaceForUnit(GameBoard gb)
        {
            int x, y;
            Unit? unit = PickAnUnit(gb);
            Dictionary<int,int> result = new Dictionary<int,int>();
            try
            {
                do
                {
                    Console.WriteLine("Select a row: \n");
                    x = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Select a column: \n");
                    y = Int32.Parse(Console.ReadLine());
                    int[] coordinates = { x, y };
                    gb.board.SetValue(unit, coordinates);
                } while (x < 0 && x > GameBoard.X && y < 0 && y > GameBoard.Y);

            }
            catch (Exception)
            {
                Console.WriteLine("\nPlease, select existing row and column!");
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

        public void TurnAnnouncer(GameBoard gameBoard)
        {
            if(!(gameBoard.player1.turnCheker || gameBoard.player2.turnCheker))
            {
                gameBoard.player1.turnCheker = true;
            }
            if(gameBoard.player1.turnCheker)
            {
                Console.WriteLine(gameBoard.player1.Name + "'s turn:\n");
                gameBoard.player1.turnCheker = false;
                gameBoard.player2.turnCheker = true;

            }
            else
            {
                Console.WriteLine(gameBoard.player2.Name + "'s turn:\n");
                gameBoard.player1.turnCheker = true;
                gameBoard.player2.turnCheker = false;
            }
           
        }

     

        public void WinnerAnnouncer(GameBoard gameBoard)
        {
            if (!gameBoard.player1.IsAlive())
            {
                Console.WriteLine("Congratulation " + gameBoard.player1.Name + "!");
            }
            else if(!gameBoard.player2.IsAlive())
            {
                Console.WriteLine("Congratulation " + gameBoard.player2.Name + "!");
            }
            else
            {
                Console.WriteLine("DRAW!");
            }
        }

       
    }
}

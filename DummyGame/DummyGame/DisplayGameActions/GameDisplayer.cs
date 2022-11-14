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

        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Dummy Game! ");
        }
        public void BoardDrawer(GameBoard gameBoard)
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine(gameBoard.player1.Name+"'s stats: HP - " + gameBoard.player1.Health+"\t Mana - "+ gameBoard.player1.Mana );
            Console.WriteLine(gameBoard.player2.Name + "'s stats: HP - " + gameBoard.player2.Health + "\t Mana - " + gameBoard.player2.Mana);
            int m = 5;
            

            int i,j;
            for(i=0; i<gameBoard.board.GetLength(0); i++)
            {
                int k = 5;
                for (j=0; j< gameBoard.board.GetLength(1); j++)
                {
                    
                    Console.SetCursorPosition(k, m);
                    switch (gameBoard.board[i, j])
                    {
                        case null:
                            Console.ResetColor();
                            Console.Write("_\t");
                            break;
                        case Archer:
                            if(gameBoard.board[i, j].Owner == gameBoard.player1)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }                      
                            Console.Write(">\t");
                            break;
                        case Berserker:
                            if (gameBoard.board[i, j].Owner == gameBoard.player1)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            Console.Write("#\t");
                            break;
                        case Mage:
                            if (gameBoard.board[i, j].Owner == gameBoard.player1)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            Console.Write("@\t");
                            break;
                        case Priest:
                            if (gameBoard.board[i, j].Owner == gameBoard.player1)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            Console.Write("%\t");
                            break;

                    }
                    k += 5;
                }
                Console.WriteLine("\n");
                m += 1;
            }
        }

        public Unit? PickAnUnit(Player p) // TODO: opravi loopa
        {
            bool hasEnoughMana=true;
            Console.WriteLine("Summon an unit:\n");
            int ch = 0;
            do
            {
                try
                {
                    if (!hasEnoughMana)
                    {
                        Console.WriteLine("\nNot enough mana for this unit!\n");
                    }
               
                    Console.WriteLine("1.Archer - 3 mana");
                    Console.WriteLine("2.Berserker - 4 mana");
                    Console.WriteLine("3.Mage - 5 mana");
                    Console.WriteLine("4.Priest - 5 mana");
                    Console.WriteLine("5.Skip");

                    ch = Int32.Parse(Console.ReadLine());

               
                }
            catch(Exception )
            {
                Console.WriteLine("\nPlease, choose a number between 1 and 5\n");
            }
            } while (ch <= 0 || ch > 5 ||  !(hasEnoughMana=ManaChecker(p,ch)));

            hasEnoughMana = true;
            switch (ch)
            {
                case 1:
                        p.Mana -= Archer.unitCost;
                        return new Archer(p);
                case 2:
                        p.Mana -= Berserker.unitCost;
                        return new Berserker(p);
                case 3:
                        p.Mana -= Mage.unitCost;
                        return new Mage(p);
                case 4:
                        p.Mana -= Priest.unitCost;
                        return new Priest(p);
                default:
                        return null;
            }
            

 
        }

        private bool ManaChecker(Player p,int choice)
        {
            switch (choice)
            {
                case 1:
                    return p.Mana >= Archer.unitCost;
                case 2:
                    return p.Mana >= Berserker.unitCost;
                case 3:
                    return p.Mana >= Mage.unitCost;
                case 4:
                    return p.Mana >= Priest.unitCost;
                default:
                    return true;
            }
        }



        public void SelectPlaceForUnit(GameBoard gb,Player p)
        {
            int x=-1, y=-1;
            Unit? unit = PickAnUnit(p);
            if (unit == null)
            {
                return;
            }
            else if (p.Name == gb.player1.Name)
            {
                do
                {
                    try
                    {
                        Console.WriteLine("Select a row: \n");
                        x = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Select a column: \n");
                        y = Int32.Parse(Console.ReadLine());            
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nPlease, select existing place and it must be empty!");
                    }
                } while ((x < 1 || x > GameBoard.X) || (y < 1 || y > 2) || gb.board[x-1,y-1]!=null);

                int[] coordinates = { x - 1, y - 1 };
                unit.Coordinates.Add(coordinates[0], coordinates[1]);
                p.units.Add(unit);
                gb.board.SetValue(unit, coordinates);
            }
            else
            {
                do
                {
                    try
                    {

                        Console.WriteLine("Select a row: \n");
                        x = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Select a column: \n");
                        y = Int32.Parse(Console.ReadLine());

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nPlease, select existing row and column!");
                    }
                } while ((x < 1 || x > GameBoard.X) || (y < 3 || y > GameBoard.Y));

                int[] coordinates = { x - 1, y - 1 };
                unit.Coordinates.Add(coordinates[0], coordinates[1]);
                p.units.Add(unit);
                gb.board.SetValue(unit, coordinates);

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

        public Player TurnAnnouncer(GameBoard gameBoard)
        {
            Player p = TurnSwitcher(gameBoard);
            Console.WriteLine(p.Name + "'s turn:\n");
            //SelectPlaceForUnit(gameBoard,p);
            return p;


        }

        public Player TurnSwitcher(GameBoard gb)
        {
            if (!(gb.player1.turnCheker || gb.player2.turnCheker))
            {
                gb.player1.turnCheker = true;
                return gb.player1;
            }
            else if(gb.player1.turnCheker)
            {
                gb.player1.turnCheker = false;
                gb.player2.turnCheker = true;
                return gb.player2;
            }
            else
            {
                gb.player1.turnCheker= true;
                gb.player2.turnCheker= false;
                return gb.player1;
            }
            
        }

        private bool isSomeoneThere(GameBoard gb,int x, int y)
        {
            if (gb.board[x, y] == null)
                return false;
            return true;
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

        public void MoveAUnit(GameBoard gameBoard, Player p)
        {
            int ch = -1;

            if(p.units == null || p.units.Count < 1)
            {
                return;
            }
            do
            {
                Console.WriteLine("\nSelect a unit:\n");

                for(int i=0; i<p.units.Count; i++)
                {
                    Console.WriteLine(i+1 +". " + p.units[i].ToString() + "\n");
                }
                try
                {
                    ch=Int32.Parse(Console.ReadLine());
                    ch--;
                }
                catch (Exception)
                {
                    Console.WriteLine("Select proper num!\n");
                }


            } while (ch < 0 || ch > p.units.Count );
          

            
            do
            {
                Console.WriteLine("\nChoose a direction (ESC- skip,w - up, s - down, a - left, d - right:\n");
                ConsoleKey pressedKey = Console.ReadKey(true).Key;
                Dictionary<int, int> coor = new Dictionary<int, int>();
                int myKey = p.units[ch].Coordinates.Keys.First();
                int myValue = p.units[ch].Coordinates.Values.First();

                switch (pressedKey)
                {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                       
                        if(myKey-1<0 || myKey-1>GameBoard.X || isSomeoneThere(gameBoard,myKey-1,myValue))
                        {
                            Console.WriteLine("Can't move there!\n");
                            break;
                        }
                        p.units[ch].Coordinates.Remove(myKey);
                        p.units[ch].Coordinates.Add(--myKey, myValue);
                        gameBoard.board.SetValue(p.units[ch], myKey, myValue);
                        gameBoard.board.SetValue(null, ++myKey, myValue);
                        return;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                     
                        if (myKey+1 < 0 || myKey+1 >= GameBoard.X || isSomeoneThere(gameBoard, myKey + 1, myValue)) 
                        {
                            Console.WriteLine("Can't move there!\n");
                            break;
                        }
                        p.units[ch].Coordinates.Remove(myKey);
                        p.units[ch].Coordinates.Add(++myKey, myValue);
                        gameBoard.board.SetValue(p.units[ch], myKey, myValue);
                        gameBoard.board.SetValue(null, --myKey, myValue);
                        return;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                    
                        if (myValue-1 < 0 || myValue-1 > GameBoard.Y || isSomeoneThere(gameBoard, myKey , myValue-1))
                        {
                            Console.WriteLine("Can't move there!\n");
                            break;
                        }
                        p.units[ch].Coordinates.Remove(myKey);
                        p.units[ch].Coordinates.Add(myKey, --myValue);
                        gameBoard.board.SetValue(p.units[ch], myKey, myValue);
                        gameBoard.board.SetValue(null, myKey, ++myValue);
                        return;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                      
                        if (myValue+1 < 0 || myValue+1 > GameBoard.Y || isSomeoneThere(gameBoard, myKey, myValue + 1))
                        {
                            Console.WriteLine("Can't move there!\n");
                            break;
                        }
                        p.units[ch].Coordinates.Remove(myKey);
                        p.units[ch].Coordinates.Add(myKey, ++myValue);
                        gameBoard.board.SetValue(p.units[ch], myKey, myValue);
                        gameBoard.board.SetValue(null, myKey, --myValue);
                        return;
                }
            }while(true);
            
        }


        private Player whichOneTakesDmg(GameBoard gb)
        {
            if (!gb.player1.turnCheker)
                return gb.player1;
            return gb.player2;
        }
        public void AtkPhase(GameBoard gameBoard, Player p)

        {
            Player p2 = whichOneTakesDmg(gameBoard);
            int ch = -1;
            if (p.units == null || p.units.Count < 1)
            {
                return;
            }
            do
            {
                Console.WriteLine("\nSelect a unit:\n");

                for (int i = 0; i < p.units.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + p.units[i].ToString() + "\n");
                }
                try
                {
                    ch = Int32.Parse(Console.ReadLine());
                    ch--;
                }
                catch (Exception)
                {
                    Console.WriteLine("Select proper num!\n");
                }


            } while (ch < 0 || ch > p.units.Count);
            Unit unit = p.units[ch];
            int x = unit.Coordinates.Keys.First();
            int y = unit.Coordinates.Values.First();

            int enemyHp;
            if (p.Name == gameBoard.player1.Name)
            {


                if (unit.IsRanged)
                {
                    if (p.Name == gameBoard.player1.Name && y > 1)
                    {
                        unit.DirectAttack(p2);
                        gameBoard.board[unit.Coordinates.Keys.First(), unit.Coordinates.Values.First()] = null;
                        p.units.Remove(unit);
                    }
                    
                    else if (gameBoard.board[x, y + 2] != null && gameBoard.board[x, y + 1].Owner != unit.Owner)
                    {
                        Unit unit2 = gameBoard.board[x, y + 2];
                        enemyHp = unit.Attack(unit2);
                        if (enemyHp <= 0)
                        {
                            gameBoard.board[unit2.Coordinates.Keys.First(), unit2.Coordinates.Values.First()] = null;
                            p2.units.Remove(unit2);
                            p2.Health += enemyHp;
                        }
                    }
                    else if (gameBoard.board[x, y + 1] != null && gameBoard.board[x, y + 1].Owner != unit.Owner)
                    {
                        Unit unit2 = gameBoard.board[x, y + 1];
                        enemyHp = unit.Attack(unit2);
                        if (enemyHp <= 0)
                        {
                            gameBoard.board[unit2.Coordinates.Keys.First(), unit2.Coordinates.Values.First()] = null;
                            p2.units.Remove(unit2);
                            p2.Health += enemyHp;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n Keep fighting with the air dummy!\n");
                    }
                }
                else
                {
                    if(p.Name == gameBoard.player1.Name && y > 2)
                    {
                        unit.DirectAttack(p2);
                        gameBoard.board[unit.Coordinates.Keys.First(), unit.Coordinates.Values.First()] = null;
                        p.units.Remove(unit);
                    }
                    
                    else if (gameBoard.board[x, y + 1] != null && gameBoard.board[x, y + 1].Owner != unit.Owner)
                    {
                        Unit unit2 = gameBoard.board[x, y + 1];
                        enemyHp = unit.Attack(unit2);
                        if (enemyHp <= 0)
                        {
                            gameBoard.board[unit2.Coordinates.Keys.First(), unit2.Coordinates.Values.First()] = null;
                            p2.units.Remove(unit2);
                            p2.Health += enemyHp;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n Keep fighting with the air dummy!\n");
                    }
                }
            }
            else
            {
                if (unit.IsRanged)
                {
                    if (p.Name == gameBoard.player1.Name && y < 2)
                    {
                        unit.DirectAttack(p2);
                        gameBoard.board[unit.Coordinates.Keys.First(), unit.Coordinates.Values.First()] = null;
                        p.units.Remove(unit);
                    }
                    
                    else if (gameBoard.board[x, y - 2] != null && gameBoard.board[x, y - 1].Owner != unit.Owner)
                    {
                        Unit unit2 = gameBoard.board[x, y - 2];
                        enemyHp = unit.Attack(unit2);
                        if (enemyHp < 0)
                        {
                            gameBoard.board[unit2.Coordinates.Keys.First(), unit2.Coordinates.Values.First()] = null;
                            p2.units.Remove(unit2);
                            p2.Health += enemyHp;
                        }
                    }
                    else if (gameBoard.board[x, y - 1] != null && gameBoard.board[x, y - 1].Owner != unit.Owner)
                    {
                        Unit unit2 = gameBoard.board[x, y - 1];
                        enemyHp = unit.Attack(unit2);
                        if (enemyHp <= 0)
                        {
                            gameBoard.board[unit2.Coordinates.Keys.First(), unit2.Coordinates.Values.First()] = null;
                            p2.units.Remove(unit2);
                            p2.Health += enemyHp;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n Keep fighting with the air dummy!\n");
                    }
                }
                else
                {
                    if (p.Name == gameBoard.player1.Name && y < 1)
                    {
                        unit.DirectAttack(p2);
                        gameBoard.board[unit.Coordinates.Keys.First(), unit.Coordinates.Values.First()] = null;
                        p.units.Remove(unit);
                    }
                    
                    else if (gameBoard.board[x, y + 1] != null && gameBoard.board[x, y - 1].Owner != unit.Owner)
                    {
                        Unit unit2 = gameBoard.board[x, y - 1];
                        enemyHp = unit.Attack(unit2);
                        if (enemyHp <= 0)
                        {
                            gameBoard.board[unit2.Coordinates.Keys.First(), unit2.Coordinates.Values.First()] = null;
                            p2.units.Remove(unit2);
                            p2.Health += enemyHp;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n Keep fighting with the air dummy!\n");
                    }
                }
            }
        }
    }
}

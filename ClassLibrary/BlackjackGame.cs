using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class BlackjackGame
    {
        BlackjackHand _dealer;
        BlackjackHand _player;
        Deck _deck;
        
        public void PlayRound()
        {
            _dealer = new BlackjackHand(true);
            _player = new BlackjackHand();
            _deck = new Deck();
            _player.SetFunds(2000);

            bool exit = false;
            do
            {
                _deck.BlackjackDeckCreator();
                _deck.Shuffle();
                DealInitialCards();
                PlayersTurn();
                if (_player.Score > 21)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    PlayerBusted(15, 20);
                    Console.ResetColor();
                    DeclareWinner();
                }
                DealersTurn();
                if (_dealer.Score > 21)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    PlayerBusted(15, 4);
                    Console.ResetColor();
                }
                DeclareWinner();

                Console.SetCursorPosition((Console.WindowWidth / 2), 13);
                int exitChoice;
                int mainMenuExit;
                string[] options = new string[2];

                Console.SetCursorPosition((Console.WindowWidth / 2), 14);
                Console.WriteLine("                                               ");
                Console.SetCursorPosition((Console.WindowWidth / 2), 15);
                Console.WriteLine("                                               ");
                Console.SetCursorPosition((Console.WindowWidth / 2), 16);
                Console.WriteLine("                                               ");

                Console.SetCursorPosition(Console.WindowWidth / 2 - 9, 14);
                Console.Write("╔══════╗  ╔══════╗");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 9, 15);
                Console.Write("║                ║");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 9, 16);
                Console.Write("╚══════╝  ╚══════╝");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 8, 15);
                Console.Write("1. yes║  ║2. No");
                ReadChoice("Would you like to play againg? ", options, out exitChoice);
                if (exitChoice == 1)
                {
                    if (_player._Money > 0)
                    {
                        Console.Clear();
                        _player.HandReset();
                        _dealer.HandReset();
                        _player.SetBet(0);
                        _player.SetScore(0);
                        _dealer._ShowHand = false;


                    }
                    else
                    {
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 20, 10);
                        Console.WriteLine("Sorry, you seem to have run out of funds");
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 9, 14);
                        Console.Write("╔═══════╗  ╔══════════╗");
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 9, 15);
                        Console.Write("║                     ║");
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 9, 16);
                        Console.Write("╚═══════╝  ╚══════════╝");
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 8, 15);
                        Console.Write("1. exit║  ║2. restart");
                        ReadChoice("Would you like to exit or restart the game? ", options, out mainMenuExit);
                        if (mainMenuExit == 1)
                        {
                            exit = true;
                        }
                        else if (mainMenuExit == 2)
                        {
                            Console.Clear();
                            Console.Clear();
                            _player.HandReset();
                            _dealer.HandReset();
                            _player.SetBet(0);
                            _player.SetScore(0);
                            _dealer._ShowHand = false;
                            _player.SetFunds(2000);
                        }
                    }
                
                }
                else
                {
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 9, 14);
                    Console.Write("╔═══════╗  ╔══════════╗");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 9, 15);
                    Console.Write("║                     ║");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 9, 16);
                    Console.Write("╚═══════╝  ╚══════════╝");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 8, 15);
                    Console.Write("1. exit║  ║2. restart");
                    ReadChoice("Would you like to exit or restart the game? ", options, out mainMenuExit);
                    if (mainMenuExit == 1)
                    {
                        exit = true;
                        mainMenuExit = 0;
                    }
                    else if (mainMenuExit == 2)
                    {
                        Console.Clear();
                        Console.Clear();
                        _player.HandReset();
                        _dealer.HandReset();
                        _player.SetBet(0);
                        _player.SetScore(0);
                        _dealer._ShowHand = false;
                        _player.SetFunds(2000);
                    }
                }
            } while (!exit);
        }

        public void DealInitialCards()
        {
            _player.Draw(Console.WindowWidth / 2 - 18, 17);
            int choice;
            string[] options = new string[_player._Money];
            ReadChoice("How much would you like to bet? $", options, out choice);
            _player.SetBet(choice);

            for (int i = 0; i < 2; i++)
            {
                _player.AddCard(_deck.Deal());
                _player.Draw(Console.WindowWidth / 2 - 18, 17);
                System.Threading.Thread.Sleep(300);

                _dealer.AddCard(_deck.Deal());
                _dealer.Draw(Console.WindowWidth / 2 - 18, 2);
                System.Threading.Thread.Sleep(300);
            }
            _player.SetFunds(_player._Money - choice);
            Console.Clear();
            _player.Draw(Console.WindowWidth / 2 - 18, 17);
            _dealer.Draw(Console.WindowWidth / 2 - 18, 2);
        }

        public void PlayersTurn()
        {
            int choice;
            string[] playOption = new string[2];

            Console.SetCursorPosition(Console.WindowWidth / 2 - 9, 14);
            Console.Write("╔══════╗  ╔════════╗");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 9, 15);
            Console.Write("║                  ║");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 9, 16);
            Console.Write("╚══════╝  ╚════════╝");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 8, 15);
            Console.Write("1. Hit║  ║2. Stand");
            while (_player.Score < 21)
            {

                ReadChoice(" What would you like to do? ", playOption, out choice);
                if (choice == 1)
                {
                    
                    
                    _player.AddCard(_deck.Deal());
                    _player.Draw(Console.WindowWidth / 2 - 18, 17);
                    
                }
                else
                {
                    break;
                }
            }
        }

        public void DealersTurn()
        {
            _dealer._ShowHand = true;
            while (_dealer.Score < 17)
            {
                _dealer.AddCard(_deck.Deal());
                _dealer.Draw(Console.WindowWidth / 2 - 18, 2);
                System.Threading.Thread.Sleep(500);
            }
        }
        
        public void DeclareWinner()
        {
            if (_player.Score > 21)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                PlayerLost();
                Console.ResetColor();
            }
            else if (_dealer.Score > 21)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                PlayerWins();
                Console.ResetColor();
                _player.SetFunds((_player._Bet * 2) + _player._Money);
            }
            else if (_player.Score == _dealer.Score)
            {
                _dealer.Draw(Console.WindowWidth / 2 - 18, 2);
                Console.ForegroundColor = ConsoleColor.Yellow;
                PlayerTied();
                Console.ResetColor();
                _player.SetFunds(_player._Bet + _player._Money);
            }
            else if (_player.Score > _dealer.Score)
            {
                _dealer.Draw(Console.WindowWidth / 2 - 18, 2);
                Console.ForegroundColor = ConsoleColor.Green;
                PlayerWins();
                _player.SetFunds((_player._Bet * 2) + _player._Money);
                Console.ResetColor();
            }
            else
            {
                _dealer.Draw(Console.WindowWidth / 2 - 18, 2);
                Console.ForegroundColor = ConsoleColor.Red;
                PlayerLost();
                Console.ResetColor();
            }
        }
        private static void ReadChoice(string prompt, string[] options, out int selection)
        {
            selection = ReadInteger(prompt, 1, options.Length, options);
        }
        //ReadChoice - reuses the ReadInteger method to get the user’s selection


        private static int ReadInteger(string prompt, int min, int max, string[] options)
        {
            while (true)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2), 12);
                Console.WriteLine("                                               ");
                Console.SetCursorPosition((Console.WindowWidth / 2) - (prompt.Length / 2), 12);
                Console.Write(prompt);
                bool validPick = int.TryParse(Console.ReadLine(), out int pick);
                if (validPick && pick >= min && pick <= max)
                {
                    return pick;
                }
                else
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2), 12);
                    Console.WriteLine("                                               ");
                }
            }

        }
        //ReadInteger - Shows the prompt, read input, return integer

        public void PlayerWins()
        {
            #region Player wins

            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, 9);
            Console.Write("██╗   ██╗ ██████╗ ██╗   ██╗");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, 10);
            Console.Write("╚██╗ ██╔╝██╔═══██╗██║   ██║");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, 11);
            Console.Write(" ╚████╔╝ ██║   ██║██║   ██║");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, 12);
            Console.Write("  ╚██╔╝  ██║   ██║██║   ██║");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, 13);
            Console.Write("   ██║   ╚██████╔╝╚██████╔╝");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, 14);
            Console.Write("   ╚═╝    ╚═════╝  ╚═════╝ ");
            System.Threading.Thread.Sleep(400);
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, 16);
            Console.Write("██╗    ██╗██╗███╗   ██╗");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, 17);
            Console.Write("██║    ██║██║████╗  ██║");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, 18);
            Console.Write("██║ █╗ ██║██║██╔██╗ ██║");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, 19);
            Console.Write("██║███╗██║██║██║╚██╗██║");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, 20);
            Console.Write("╚███╔███╔╝██║██║ ╚████║");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, 21);
            Console.Write(" ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝");
            #endregion
        }
        public void PlayerLost()
        {
            #region Player Lost

            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, 9);
            Console.Write("██╗   ██╗ ██████╗ ██╗   ██╗");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, 10);
            Console.Write("╚██╗ ██╔╝██╔═══██╗██║   ██║");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, 11);
            Console.Write(" ╚████╔╝ ██║   ██║██║   ██║");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, 12);
            Console.Write("  ╚██╔╝  ██║   ██║██║   ██║");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, 13);
            Console.Write("   ██║   ╚██████╔╝╚██████╔╝");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, 14);
            Console.Write("   ╚═╝    ╚═════╝  ╚═════╝ ");
            System.Threading.Thread.Sleep(400);
            Console.SetCursorPosition(Console.WindowWidth / 2 - 58, 16);
            Console.Write("██╗      ██████╗ ███████╗███████╗");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 58, 17);
            Console.Write("██║     ██╔═══██╗██╔════╝██╔════╝");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 58, 18);
            Console.Write("██║     ██║   ██║███████╗█████╗  ");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 58, 19);
            Console.Write("██║     ██║   ██║╚════██║██╔══╝  ");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 58, 20);
            Console.Write("███████╗╚██████╔╝███████║███████╗");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 58, 21);
            Console.Write("╚══════╝ ╚═════╝ ╚══════╝╚══════╝");
            #endregion
        }

        public void PlayerTied()
        {
            #region Player Tied

            Console.SetCursorPosition(Console.WindowWidth / 2 - 58, 9);
            Console.Write(" ██████╗  █████╗ ███╗   ███╗███████╗");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 58, 10);
            Console.Write("██╔════╝ ██╔══██╗████╗ ████║██╔════╝");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 58, 11);
            Console.Write("██║  ███╗███████║██╔████╔██║█████╗  ");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 58, 12);
            Console.Write("██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  ");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 58, 13);
            Console.Write("╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 58, 14);
            Console.Write(" ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝");
            System.Threading.Thread.Sleep(400);
            Console.SetCursorPosition(Console.WindowWidth / 2 - 56, 16);
            Console.Write("████████╗██╗███████╗██████╗ ");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 56, 17);
            Console.Write("╚══██╔══╝██║██╔════╝██╔══██╗");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 56, 18);
            Console.Write("   ██║   ██║█████╗  ██║  ██║");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 56, 19);
            Console.Write("   ██║   ██║██╔══╝  ██║  ██║");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 56, 20);
            Console.Write("   ██║   ██║███████╗██████╔╝");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 56, 21);
            Console.Write("   ╚═╝   ╚═╝╚══════╝╚═════╝ ");
            #endregion
        }

        public void PlayerBusted( int x, int y)
        {
            #region Player Busted
            Console.SetCursorPosition(Console.WindowWidth / 2 - x, y);
            Console.Write(" ______  _     _ _______ _______ _______ ______  ");
            Console.SetCursorPosition(Console.WindowWidth / 2 - x, y + 1);
            Console.Write(@" |_____] |     | |______    |    |______ |     \ ");
            Console.SetCursorPosition(Console.WindowWidth / 2 - x, y + 2);
            Console.Write(" |_____] |_____| ______|    |    |______ |_____/ ");
            Console.SetCursorPosition(Console.WindowWidth / 2 - x, y + 3);
            Console.Write("                                                 ");
            #endregion
        }


    }
}

using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int choice;
            bool notExit = true;
            string[] options = new string[] { "1. Play Blackjack.", "2. Shuffle & Show Deck.", "3. Exit" };
            do
            {
                Console.Clear();
                MainMenuGraphics();
                ReadChoice("Please make your selection: ", options, out choice);

                switch (choice)
                {

                    case 1:
                        Console.Clear();
                        BlackjackGame game = new BlackjackGame();
                        game.PlayRound();

                        break;
                    case 2:
                        Console.Clear();
                        Console.Clear();
                        int x = 2;
                        int y = 2;
                        Deck deck = new Deck();
                        Hand hand = new Hand();
                        deck.BlackjackDeckCreator();
                        deck.Shuffle();
                        for (int i = 0; i < 52; i++)
                        {
                            hand.AddCard(deck.Deal());
                        }
                        hand.Draw(x, y);

                        Console.ReadKey();
                        Console.ResetColor();
                        Console.Clear();
                        break;
                    case 3:
                        notExit = false;
                        break;
                    default:
                        break;

                }

            } while (notExit);

            

            
        }
        private static void MainMenuGraphics()
            {
                #region Blackjack letters 
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 35, 11);
                Console.Write("██████╗ ██╗      █████╗  ██████╗██╗  ██╗     ██╗ █████╗  ██████╗██╗  ██╗");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 35, 12);
                Console.Write("██╔══██╗██║     ██╔══██╗██╔════╝██║ ██╔╝     ██║██╔══██╗██╔════╝██║ ██╔╝");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 35, 13);
                Console.Write("██████╔╝██║     ███████║██║     █████╔╝      ██║███████║██║     █████╔╝ ");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 35, 14);
                Console.Write("██╔══██╗██║     ██╔══██║██║     ██╔═██╗ ██   ██║██╔══██║██║     ██╔═██╗ ");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 35, 15);
                Console.Write("██████╔╝███████╗██║  ██║╚██████╗██║  ██╗╚█████╔╝██║  ██║╚██████╗██║  ██╗");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 35, 16);
                Console.Write("╚═════╝ ╚══════╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝ ╚════╝ ╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 36, 10);
                Console.Write("██████╗ ██╗      █████╗  ██████╗██╗  ██╗     ██╗ █████╗  ██████╗██╗  ██╗");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 36, 11);
                Console.Write("██╔══██╗██║     ██╔══██╗██╔════╝██║ ██╔╝     ██║██╔══██╗██╔════╝██║ ██╔╝");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 36, 12);
                Console.Write("██████╔╝██║     ███████║██║     █████╔╝      ██║███████║██║     █████╔╝ ");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 36, 13);
                Console.Write("██╔══██╗██║     ██╔══██║██║     ██╔═██╗ ██   ██║██╔══██║██║     ██╔═██╗ ");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 36, 14);
                Console.Write("██████╔╝███████╗██║  ██║╚██████╗██║  ██╗╚█████╔╝██║  ██║╚██████╗██║  ██╗");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 36, 15);
                Console.Write("╚═════╝ ╚══════╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝ ╚════╝ ╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝");
                Console.ResetColor();
                #endregion
            }
        private static void ReadString(string prompt, ref string value)
        {
            do
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 17, 9);
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 7, 11);
                    Console.WriteLine("Invalid input.");
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 16);
                    Console.Write("Press any key to try again...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    value = input;
                    break;
                }
            } while (true);
        }
        //ReadString - Shows the prompt, read input, store in ref parameter
        private static void DisplayMenu(string[] options)
        {
            MainMenuGraphics();
            int lineNum = 20;
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 11, 20);
                Console.SetCursorPosition((Console.WindowWidth / 2) - 11, lineNum += 1);
                Console.WriteLine(options[i]);
            }
        }
        //DisplayMenu - displays the main menu inside ReadInteger when the menu input is not valid
        private static void ReadChoice(string prompt, string[] options, out int selection)
        {
            int lineNum = 20;
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 11, lineNum += 1);
                Console.WriteLine(options[i]);
            }
            selection = ReadInteger(prompt, 1, options.Length, options);
        }
        //ReadChoice - reuses the ReadInteger method to get the user’s selection
        private static int ReadInteger(string prompt, int min, int max, string[] options)
        {
            while (true)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - (prompt.Length / 2), 25);
                Console.Write(prompt);
                bool validPick = int.TryParse(Console.ReadLine(), out int pick);
                if (validPick && pick >= min && pick <= max)
                {
                    return pick;
                }
                else
                {
                    Console.Clear();
                    MainMenuGraphics();
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 8, 21);
                    Console.Write("Invalid Selection");
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 17, 22);
                    Console.WriteLine($"Please select a number from {min} to {max}.");
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 13, 25);
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    DisplayMenu(options);
                }
            }

        }
        //ReadInteger - Shows the prompt, read input, return integer
    }
}

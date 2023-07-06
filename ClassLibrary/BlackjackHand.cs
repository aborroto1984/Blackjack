using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class BlackjackHand: Hand
    {
        public int Score { get; private set; }
        public bool _IsDealer { get; set; }
        public bool _ShowHand { get; set; }
        public int _Money { get; private set; }
        public int _Bet { get; private set; }

        public void SetFunds(int money)
        {
            _Money = money;
        }
        public void SetBet(int bet)
        {
            _Bet = bet;
        }
        public void SetScore(int score)
        {
            Score = score;
        }
        public BlackjackHand(bool IsDealer = false)
        {
            if (IsDealer)
            {
                _IsDealer = IsDealer;
            }
        }
        
        override public void AddCard(ICard card)
        {
            base.AddCard(card);
            Score = 0;
            int aceCount = 0;
            foreach (ICard item in _cards)
            {
                BlackjackCard newCard = (BlackjackCard)item;
                if (newCard.Face == CardFace.A)
                {
                    aceCount++;
                }
                else
                {
                    Score += newCard.Value;
                }
            }
            for (int i = 0; i < aceCount; i++)
            {
                if (Score + 11 > 21)
                {
                    Score += 1;
                }
                else
                {
                    Score += 11;
                }
            }
        }
        override public void Draw(int x, int y)
        {
            if (_IsDealer)
            {
                if (_ShowHand == false)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 6, 1);
                    Console.Write("Dealer's Hand");
                    ICard blank = new BlackjackCard(CardFace.Blank, CardSuit.Blank);
                    base.Draw(x, y);
                    blank.Draw(x, y);
                }
                else
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 6, 1);
                    Console.Write("Dealer's Hand");
                    base.Draw(x, y);
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 30, 3);
                    Console.Write("╔═════════╗");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 30, 4);
                    Console.Write("║         ║");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 30, 5);
                    Console.Write("╚═════════╝");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 29, 4);
                    Console.Write($"Score: {Score}");
                }
                
            }
            else
            {
                base.Draw(x, y);
                Console.SetCursorPosition(Console.WindowWidth / 2 - 30, 23);
                Console.Write("╔═════════╗");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 30, 24);
                Console.Write("║         ║");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 30, 25);
                Console.Write("╚═════════╝");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 29, 24);
                Console.Write($"Score: {Score}");

                Console.SetCursorPosition(x + 4, y + 9);
                Console.Write("╔════════════╗   ╔═════════╗");
                Console.SetCursorPosition(x + 4, y + 10);
                Console.Write("║            ║   ║         ║");
                Console.SetCursorPosition(x + 4, y + 11);
                Console.Write("╚════════════╝   ╚═════════╝");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 13, 27);
                Console.Write($"Funds: ${_Money}");
                Console.SetCursorPosition(Console.WindowWidth / 2 + 4, 27);
                Console.Write($"Bet ${_Bet}");

            }

            

            
        }
    }
}

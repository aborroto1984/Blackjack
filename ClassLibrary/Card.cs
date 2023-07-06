using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }
            

        
        public void Draw(int x, int y)
        {
            //shadow 
            Console.BackgroundColor = ConsoleColor.DarkGray;
            int yShadow =  y + 1;
            int xShadow = x + 1;
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(xShadow, yShadow += 1);
                Console.WriteLine("           ");
            }
            Console.ResetColor(); 


            Console.BackgroundColor = ConsoleColor.White;

            Console.SetCursorPosition(x, y);

            if (Suit == CardSuit.Spades || Suit == CardSuit.Clubs)
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (Suit == CardSuit.Hearts || Suit == CardSuit.Diamonds)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }


            string suit = string.Empty;
            switch (Suit)
            {
                case CardSuit.Spades:
                    suit = "♠";
                    break;
                case CardSuit.Hearts:
                    suit = "♥";
                    break;
                case CardSuit.Clubs:
                    suit = "♣";
                    break;
                case CardSuit.Diamonds:
                    suit = "♦";
                    break;
                default:
                    break;
            }

            if (Face == CardFace.A)
            {
                Console.SetCursorPosition(x, y + 1);
                Console.Write($" {Face}{suit}        ");
                Console.SetCursorPosition(x, y + 2);
                Console.Write($"   █████╗  ");
                Console.SetCursorPosition(x, y + 3);
                Console.Write($"  ██╔══██╗ ");
                Console.SetCursorPosition(x, y + 4);
                Console.Write($"  ███████║ ");
                Console.SetCursorPosition(x, y + 5);
                Console.Write($"  ██╔══██║ ");
                Console.SetCursorPosition(x, y + 6);
                Console.Write($"  ██║  ██║ ");
                Console.SetCursorPosition(x, y + 7);
                Console.Write($"  ╚═╝  ╚{Face}{suit} ");
                Console.SetCursorPosition(x, y + 8);

            }
            else if (Face == CardFace.J)
            {
                Console.SetCursorPosition(x, y + 1);
                Console.Write($" {Face}{suit}        ");
                Console.SetCursorPosition(x, y + 2);
                Console.Write($"       ██╗ ");
                Console.SetCursorPosition(x, y + 3);
                Console.Write($"       ██║ ");
                Console.SetCursorPosition(x, y + 4);
                Console.Write($"       ██║ ");
                Console.SetCursorPosition(x, y + 5);
                Console.Write($" ██    ██║ ");
                Console.SetCursorPosition(x, y + 6);
                Console.Write($" ╚██████╔╝ ");
                Console.SetCursorPosition(x, y + 7);
                Console.Write($"  ╚═════{Face}{suit} ");
                Console.SetCursorPosition(x, y + 8);
            }
            else if (Face == CardFace.Q)
            {
                Console.SetCursorPosition(x, y + 1);
                Console.Write($" {Face}{suit}        ");
                Console.SetCursorPosition(x, y + 2);
                Console.Write($"  ██████╗  ");
                Console.SetCursorPosition(x, y + 3);
                Console.Write($" ██╔═══██╗ ");
                Console.SetCursorPosition(x, y + 4);
                Console.Write($" ██║   ██║ ");
                Console.SetCursorPosition(x, y + 5);
                Console.Write($" ██║▄▄ ██║ ");
                Console.SetCursorPosition(x, y + 6);
                Console.Write($" ╚██████╔╝ ");
                Console.SetCursorPosition(x, y + 7);
                Console.Write($"  ╚══▀▀═{Face}{suit} ");
                Console.SetCursorPosition(x, y + 8);
            }
            else if (Face == CardFace.K)
            {
                Console.SetCursorPosition(x, y + 1);
                Console.Write($" {Face}{suit}        ");
                Console.SetCursorPosition(x, y + 2);
                Console.Write($" ██╗   ██╗ ");
                Console.SetCursorPosition(x, y + 3);
                Console.Write($" ██║  ██╔╝ ");
                Console.SetCursorPosition(x, y + 4);
                Console.Write($" ██████╔╝  ");
                Console.SetCursorPosition(x, y + 5);
                Console.Write($" ██╔══██╗  ");
                Console.SetCursorPosition(x, y + 6);
                Console.Write($" ██║   ██╗ ");
                Console.SetCursorPosition(x, y + 7);
                Console.Write($" ╚═╝   ╚{Face}{suit} ");
                Console.SetCursorPosition(x, y + 8);
            }
            else if (Face == CardFace.two)
            {
                Console.SetCursorPosition(x, y + 1);
                Console.Write($" {(int)Face}{suit}        ");
                Console.SetCursorPosition(x, y + 2);
                Console.Write($"           ");
                Console.SetCursorPosition(x, y + 3);
                Console.Write($"     {suit}     ");
                Console.SetCursorPosition(x, y + 4);
                Console.Write($"           ");
                Console.SetCursorPosition(x, y + 5);
                Console.Write($"     {suit}     ");
                Console.SetCursorPosition(x, y + 6);
                Console.Write($"           ");
                Console.SetCursorPosition(x, y + 7);
                Console.Write($"        {(int)Face}{suit} ");
                Console.SetCursorPosition(x, y + 8);
            }
            else if (Face == CardFace.three)
            {
                Console.SetCursorPosition(x, y + 1);
                Console.Write($" {(int)Face}{suit}        ");
                Console.SetCursorPosition(x, y + 2);
                Console.Write($"           ");
                Console.SetCursorPosition(x, y + 3);
                Console.Write($"     {suit}     ");
                Console.SetCursorPosition(x, y + 4);
                Console.Write($"     {suit}     ");
                Console.SetCursorPosition(x, y + 5);
                Console.Write($"     {suit}     ");
                Console.SetCursorPosition(x, y + 6);
                Console.Write($"           ");
                Console.SetCursorPosition(x, y + 7);
                Console.Write($"        {(int)Face}{suit} ");
                Console.SetCursorPosition(x, y + 8);
            }
            else if (Face == CardFace.four)
            {
                Console.SetCursorPosition(x, y + 1);
                Console.Write($" {(int)Face}{suit}        ");
                Console.SetCursorPosition(x, y + 2);
                Console.Write($"           ");
                Console.SetCursorPosition(x, y + 3);
                Console.Write($"    {suit} {suit}    ");
                Console.SetCursorPosition(x, y + 4);
                Console.Write($"           ");
                Console.SetCursorPosition(x, y + 5);
                Console.Write($"    {suit} {suit}    ");
                Console.SetCursorPosition(x, y + 6);
                Console.Write($"           ");
                Console.SetCursorPosition(x, y + 7);
                Console.Write($"        {(int)Face}{suit} ");
                Console.SetCursorPosition(x, y + 8);
            }
            else if (Face == CardFace.five)
            {
                Console.SetCursorPosition(x, y + 1);
                Console.Write($" {(int)Face}{suit}        ");
                Console.SetCursorPosition(x, y + 2);
                Console.Write($"           ");
                Console.SetCursorPosition(x, y + 3);
                Console.Write($"    {suit} {suit}    ");
                Console.SetCursorPosition(x, y + 4);
                Console.Write($"     {suit}     ");
                Console.SetCursorPosition(x, y + 5);
                Console.Write($"    {suit} {suit}    ");
                Console.SetCursorPosition(x, y + 6);
                Console.Write($"           ");
                Console.SetCursorPosition(x, y + 7);
                Console.Write($"        {(int)Face}{suit} ");
                Console.SetCursorPosition(x, y + 8);
            }
            else if (Face == CardFace.six)
            {
                Console.SetCursorPosition(x, y + 1);
                Console.Write($" {(int)Face}{suit}        ");
                Console.SetCursorPosition(x, y + 2);
                Console.Write($"           ");
                Console.SetCursorPosition(x, y + 3);
                Console.Write($"    {suit} {suit}    ");
                Console.SetCursorPosition(x, y + 4);
                Console.Write($"    {suit} {suit}    ");
                Console.SetCursorPosition(x, y + 5);
                Console.Write($"    {suit} {suit}    ");
                Console.SetCursorPosition(x, y + 6);
                Console.Write($"           ");
                Console.SetCursorPosition(x, y + 7);
                Console.Write($"        {(int)Face}{suit} ");
                Console.SetCursorPosition(x, y + 8);
            }
            else if (Face == CardFace.seven)
            {
                Console.SetCursorPosition(x, y + 1);
                Console.Write($" {(int)Face}{suit}        ");
                Console.SetCursorPosition(x, y + 2);
                Console.Write($"           ");
                Console.SetCursorPosition(x, y + 3);
                Console.Write($"    {suit} {suit}    ");
                Console.SetCursorPosition(x, y + 4);
                Console.Write($"   {suit} {suit} {suit}   ");
                Console.SetCursorPosition(x, y + 5);
                Console.Write($"    {suit} {suit}    ");
                Console.SetCursorPosition(x, y + 6);
                Console.Write($"           ");
                Console.SetCursorPosition(x, y + 7);
                Console.Write($"        {(int)Face}{suit} ");
                Console.SetCursorPosition(x, y + 8);
            }
            else if (Face == CardFace.eight)
            {
                Console.SetCursorPosition(x, y + 1);
                Console.Write($" {(int)Face}{suit}        ");
                Console.SetCursorPosition(x, y + 2);
                Console.Write($"           ");
                Console.SetCursorPosition(x, y + 3);
                Console.Write($"   {suit} {suit} {suit}   ");
                Console.SetCursorPosition(x, y + 4);
                Console.Write($"   {suit}   {suit}   ");
                Console.SetCursorPosition(x, y + 5);
                Console.Write($"   {suit} {suit} {suit}   ");
                Console.SetCursorPosition(x, y + 6);
                Console.Write($"           ");
                Console.SetCursorPosition(x, y + 7);
                Console.Write($"        {(int)Face}{suit} ");
                Console.SetCursorPosition(x, y + 8);
            }
            else if (Face == CardFace.nine)
            {
                Console.SetCursorPosition(x, y + 1);
                Console.Write($" {(int)Face}{suit}        ");
                Console.SetCursorPosition(x, y + 2);
                Console.Write($"           ");
                Console.SetCursorPosition(x, y + 3);
                Console.Write($"   {suit} {suit} {suit}   ");
                Console.SetCursorPosition(x, y + 4);
                Console.Write($"   {suit} {suit} {suit}   ");
                Console.SetCursorPosition(x, y + 5);
                Console.Write($"   {suit} {suit} {suit}   ");
                Console.SetCursorPosition(x, y + 6);
                Console.Write($"           ");
                Console.SetCursorPosition(x, y + 7);
                Console.Write($"        {(int)Face}{suit} ");
                Console.SetCursorPosition(x, y + 8);
            }
            else if (Face == CardFace.ten)
            {
                Console.SetCursorPosition(x, y + 1);
                Console.Write($" {(int)Face}{suit}       ");
                Console.SetCursorPosition(x, y + 2);
                Console.Write($"     {suit}     ");
                Console.SetCursorPosition(x, y + 3);
                Console.Write($"   {suit} {suit} {suit}   ");
                Console.SetCursorPosition(x, y + 4);
                Console.Write($"   {suit}   {suit}   ");
                Console.SetCursorPosition(x, y + 5);
                Console.Write($"   {suit} {suit} {suit}   ");
                Console.SetCursorPosition(x, y + 6);
                Console.Write($"     {suit}     ");
                Console.SetCursorPosition(x, y + 7);
                Console.Write($"       {(int)Face}{suit} ");
                Console.SetCursorPosition(x, y + 8);
            }
            else if (Face == CardFace.Blank || Suit == CardSuit.Blank)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(x, y + 1);
                Console.Write($" ╔═══════╗ ");
                Console.SetCursorPosition(x, y + 2);
                Console.Write($" ║█ █ █ █║ ");
                Console.SetCursorPosition(x, y + 3);
                Console.Write($" ║ █ █ █ ║ ");
                Console.SetCursorPosition(x, y + 4);
                Console.Write($" ║█ █ █ █║ ");
                Console.SetCursorPosition(x, y + 5);
                Console.Write($" ║ █ █ █ ║ ");
                Console.SetCursorPosition(x, y + 6);
                Console.Write($" ║█ █ █ █║ ");
                Console.SetCursorPosition(x, y + 7);
                Console.Write($" ╚═══════╝ ");
                Console.SetCursorPosition(x, y + 8);
            }

            Console.ResetColor();
        }

        public Card(CardFace face, CardSuit suit)
        {
            Face = face;
            Suit = suit;
        }
    }
}

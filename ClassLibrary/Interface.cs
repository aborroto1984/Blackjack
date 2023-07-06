using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface ICard
    {
        CardFace Face { get; }
        CardSuit Suit { get; }
        void Draw(int x, int y);
    }
    
}

namespace ClassLibrary
{
    public enum CardFace
    {
        Blank = 0,
        A = 1, 
        two = 2,
        three = 3,
        four = 4,
        five = 5,
        six = 6,
        seven = 7,
        eight = 8,
        nine = 9,
        ten = 10,
        J = 11,
        Q = 12,
        K = 13
    }
    public enum CardSuit
    {
        Spades, Hearts, Clubs, Diamonds, Blank
    }
}
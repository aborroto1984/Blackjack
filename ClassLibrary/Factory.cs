using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class Factory
    {
        public static ICard CreateBlackjackCard(CardFace face, CardSuit suit)
        {
            ICard card = new BlackjackCard(face, suit);
            return card;   
        }
    }
}

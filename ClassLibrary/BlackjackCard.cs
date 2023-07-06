using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class BlackjackCard : Card
    {
        public int Value { get; set; }

        public BlackjackCard(CardFace face, CardSuit suit) : base(face, suit)
        {
            if (face == CardFace.J || face == CardFace.Q || face == CardFace.K)
            {
                Value = 10;
            }
            else
            {
                Value = (int)Face;
            }    
            
        }
    }
}


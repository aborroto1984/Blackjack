using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Hand
    {
        protected List<ICard> _cards = new List<ICard>();
        
        public virtual void AddCard(ICard card)
        {
            _cards.Add(card);
        }


        public virtual void Draw(int x, int y)
        {
            int xReset = x;
            for (int i = 0; i < _cards.Count ; i++)
            {
                if (i % 9 == 0 && i != 0 && i != 1)
                {
                    y += 10;
                    x = xReset;
                }
                _cards[i].Draw(x, y);
                x += 13;

            }


        }

        public void HandReset()
        {
            _cards = new List<ICard>();
        }
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Deck
    {
        private List<ICard> _cards = new List<ICard>(52);

        public void BlackjackDeckCreator()
        {
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardFace face in Enum.GetValues(typeof(CardFace)))
                {
                    if (face != CardFace.Blank && suit != CardSuit.Blank)
                    {
                        _cards.Add(Factory.CreateBlackjackCard(face, suit));
                    }
                    
                }
            }

        }
        public void Shuffle()
        {
            Random rando = new Random();
            for (int i = 0; i < 700; i++)
            {
                for (int j = 0; j < _cards.Count; j++)
                {
                    int ndx = rando.Next(13);
                    ICard temp = _cards[j];
                    _cards[j] = _cards[ndx];
                    _cards[ndx] = temp;
                }
            }

        }
        public ICard Deal()
        {
            ICard card = _cards[0];
            if (_cards.Count == 0)
            {
                BlackjackDeckCreator();
                Shuffle();
            }
            _cards.RemoveAt(0);
            return card;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBall
{
    public class Deck
    {
        private List<Card> cards;
        private Random random = new Random();

        public Deck(int playerCount)
        {
            cards = new List<Card>();

            Rank startRank = Rank.Two;
            if (playerCount == 2)
                startRank = Rank.Nine;
            else if (playerCount == 3)
                startRank = Rank.Six;

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (Rank rank = startRank; rank <= Rank.Ace; rank++)
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }

        public void Shuffle()
        {
            int n = cards.Count;
            for (int i = 0; i < n; i++)
            {
                int r = i + random.Next(n - i);
                Card temp = cards[r];
                cards[r] = cards[i];
                cards[i] = temp;
            }
        }

        public Card Draw()
        {
            if (cards.Count == 0) return null;

            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public int Count => cards.Count;
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBall
{
    public abstract class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; private set; } = new List<Card>();
        public int TricksWon { get; set; }
        public int Bid { get; set; }
        public int Score { get; set; } 

        public abstract int PlaceBid(int maxBid);
        public abstract Card PlayCard(Suit leadSuit, Suit trumpSuit);

        public Player(string name)
        {
            Name = name;
        }

        public void ReceiveCard(Card card)
        {
            Hand.Add(card);
        }

        public void ClearHand()
        {
            Hand.Clear();
        }

        public void AddTrick()
        {
            TricksWon++;
        }
    }
}

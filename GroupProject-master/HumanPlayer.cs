using System;
using System.Collections.Generic;

namespace BlackBall
{
    public class HumanPlayer : Player
    {
        private int pendingBid = -1;
        private Card pendingCard = null;

        public HumanPlayer(string name) : base(name)
        {
        }

        public void SetBid(int bid)
        {
            pendingBid = bid;
        }

        public override int PlaceBid(int maxBid)
        {
            while (pendingBid < 0 || pendingBid > maxBid)
            {
                System.Threading.Thread.Sleep(50); 
            }

            int bid = pendingBid;
            pendingBid = -1;
            return bid;
        }

        // Called from the UI to set the card to play
        public void SetCardToPlay(Card card)
        {
            pendingCard = card;
        }

        public override Card PlayCard(Suit leadSuit, Suit trumpSuit)
        {
            // Wait until card is selected by UI
            while (pendingCard == null)
            {
                System.Threading.Thread.Sleep(50); // wait until UI sets the value
            }

            Card card = pendingCard;
            Hand.Remove(card);
            pendingCard = null;
            return card;
        }
    }
}

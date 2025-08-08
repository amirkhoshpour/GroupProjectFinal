using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackBall
{
    public class AIPlayer : Player
    {
        private Random rng = new Random();

        public AIPlayer(string name) : base(name)
        {
        }

        public override int PlaceBid(int maxBid)
        {
            Suit trump = GameManager.Instance.CurrentTrump;

            // Count trump cards and how strong they are
            int strongTrumps = Hand.Count(c => c.Suit == trump && (int)c.Rank >= (int)Rank.Jack);
            int totalTrumps = Hand.Count(c => c.Suit == trump);

            int estimatedBid = strongTrumps + totalTrumps / 2;

            // Manually clamp between 0 and maxBid
            if (estimatedBid > maxBid)
                estimatedBid = maxBid;
            if (estimatedBid < 0)
                estimatedBid = 0;

            return estimatedBid;
        }

        public override Card PlayCard(Suit leadSuit, Suit trumpSuit)
        {
            List<Card> legalCards = GetLegalCards(leadSuit);

            // Pick highest trump or highest rank card
            Card bestCard = legalCards
                .OrderByDescending(c => c.Suit == trumpSuit)
                .ThenByDescending(c => (int)c.Rank)
                .First();

            Hand.Remove(bestCard);
            return bestCard;
        }

        private List<Card> GetLegalCards(Suit leadSuit)
        {
            var matching = Hand.Where(c => c.Suit == leadSuit).ToList();
            return matching.Any() ? matching : new List<Card>(Hand);
        }
    }
}

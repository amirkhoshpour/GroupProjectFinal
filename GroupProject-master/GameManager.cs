using System;
using System.Collections.Generic;

namespace BlackBall
{
    public class GameManager
    {
        public static GameManager Instance { get; private set; }

        private Deck deck;
        private List<Player> players;
        private GameState gameState;

        private readonly int[] roundCardCounts = {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
            13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1
        };

        private int currentRoundIndex = 0;

        public GameManager(List<Player> players)
        {
            Instance = this;
            this.players = players;
            this.deck = new Deck(players.Count);
            this.gameState = new GameState
            {
                CurrentRound = 1,
                TrumpSuit = "",
                LeadSuit = ""
            };
        }

        public void StartGame()
        {
            foreach (var player in players)
            {
                player.ClearHand();
                player.TricksWon = 0;
                player.Bid = 0;
                player.Score = 0;
            }

            currentRoundIndex = 0;
            deck = new Deck(players.Count);
            deck.Shuffle();
            gameState.CurrentRound = 1;
        }

        public bool HasMoreRounds => currentRoundIndex < roundCardCounts.Length;
        public int CardsThisRound => roundCardCounts[currentRoundIndex];
        public int CurrentRound => gameState.CurrentRound;
        public Suit CurrentTrump => Enum.TryParse(gameState.TrumpSuit, out Suit s) ? s : Suit.Spades;

        public Card DrawTrumpCard()
        {
            Card trumpCard = deck.Draw();
            if (trumpCard != null)
            {
                gameState.TrumpSuit = trumpCard.Suit.ToString();
            }
            return trumpCard;
        }

        public void DealCards(int cardCount)
        {
            foreach (var player in players)
            {
                player.ClearHand();
                for (int i = 0; i < cardCount; i++)
                {
                    Card card = deck.Draw();
                    if (card != null)
                        player.ReceiveCard(card);
                }
            }
        }

        public void CollectBids()
        {
            int totalCards = CardsThisRound;
            int totalBids = 0;

            for (int i = 0; i < players.Count; i++)
            {
                int maxBid = totalCards;
                int bid = players[i].PlaceBid(maxBid);

                if (i == players.Count - 1 && totalBids + bid == totalCards)
                {
                    bid = (bid > 0) ? bid - 1 : bid + 1;
                }

                players[i].Bid = bid;
                totalBids += bid;
            }
        }

        public Player PlayTrick(Card humanCard, Card aiCard)
        {
            Suit trump = (Suit)Enum.Parse(typeof(Suit), gameState.TrumpSuit);
            Suit lead = humanCard.Suit;

            gameState.LeadSuit = lead.ToString();

            Card winningCard = GetWinningCard(humanCard, aiCard, lead, trump);

            if (winningCard == humanCard)
            {
                players[0].AddTrick();
                return players[0];
            }
            else
            {
                players[1].AddTrick();
                return players[1];
            }
        }

        private Card GetWinningCard(Card c1, Card c2, Suit lead, Suit trump)
        {
            bool c1IsTrump = c1.Suit == trump;
            bool c2IsTrump = c2.Suit == trump;

            if (c1IsTrump && !c2IsTrump) return c1;
            if (!c1IsTrump && c2IsTrump) return c2;

            if (c1.Suit == c2.Suit)
                return c1.Rank > c2.Rank ? c1 : c2;

            if (c1.Suit == lead) return c1;
            if (c2.Suit == lead) return c2;

            return c1;
        }

        public void AdvanceRound()
        {
            foreach (var player in players)
            {
                if (player.TricksWon == player.Bid)
                {
                    if (player.Bid == 0)
                        player.Score += CardsThisRound * 10;
                    else
                        player.Score += player.Bid * 11;
                }

                player.TricksWon = 0;
                player.Bid = 0;
            }

            if (HasMoreRounds)
            {
                currentRoundIndex++;
                gameState.CurrentRound = currentRoundIndex + 1;
                deck = new Deck(players.Count);
                deck.Shuffle();
            }
        }

        public string TrumpSuit => gameState.TrumpSuit;
        public string LeadSuit => gameState.LeadSuit;
        public GameState State => gameState;
        public List<Player> Players => players;
    }
}

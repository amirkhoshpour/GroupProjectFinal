using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBall
{
    public class GameState
    {
        public int CurrentRound { get; set; }
        public string TrumpSuit { get; set; }
        public string LeadSuit { get; set; }
        public int CurrentPlayerIndex { get; set; }
        public List<Card> TrickCards { get; set; }
        public bool IsGameOver { get; set; }

        public GameState()
        {
            CurrentRound = 1;
            TrumpSuit = "";
            LeadSuit = "";
            CurrentPlayerIndex = 0;
            TrickCards = new List<Card>();
            IsGameOver = false;
        }

        public void ResetForNewRound()
        {
            LeadSuit = "";
            TrickCards.Clear();
        }
    }
}

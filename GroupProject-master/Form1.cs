using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BlackBall
{
    public partial class Form1 : Form
    {
        private GameManager gameManager;
        private HumanPlayer humanPlayer;
        private AIPlayer aiPlayer;
        private int cardsPlayed = 0;
        private Card trumpCard;

        public Form1()
        {
            InitializeComponent();
            btnNextRound.Click += BtnNextRound_Click;
            btnStartGame.Click += btnStartGame_Click_1;
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void btnStartGame_Click_1(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void StartNewGame()
        {
            humanPlayer = new HumanPlayer("You");
            aiPlayer = new AIPlayer("Computer");
            List<Player> players = new List<Player> { humanPlayer, aiPlayer };

            gameManager = new GameManager(players);

            txtLog.Clear();
            lblStatus.Text = "Game started. Dealing cards...";
            btnNextRound.Visible = false;
            btnStartGame.Visible = false;

            SetupNewRound();
        }

        private void SetupNewRound()
        {
            txtLog.AppendText($"\r\n--- Round {gameManager.CurrentRound} ---\r\n");
            lblStatus.Text = "Dealing cards...";
            btnNextRound.Enabled = false;

            gameManager.DealCards(gameManager.CardsThisRound);
            trumpCard = gameManager.DrawTrumpCard();

            lblTrump.Text = $"Trump: {trumpCard.Suit}";
            flpTrumpCard.Controls.Clear();
            flpTrumpCard.Controls.Add(new CustomCardControl(trumpCard));

            flpPlayerHand.Controls.Clear();
            foreach (Card card in humanPlayer.Hand)
            {
                var cardControl = new CustomCardControl(card);
                cardControl.CardClicked += CardControl_CardClicked;
                flpPlayerHand.Controls.Add(cardControl);
            }

            int maxBid = gameManager.CardsThisRound;
            int bid = PromptForBid(maxBid);
            humanPlayer.SetBid(bid);
            gameManager.CollectBids();

            txtLog.AppendText($"Trump Suit: {trumpCard.Suit}\r\n");
            txtLog.AppendText($"Your Bid: {humanPlayer.Bid} | AI Bid: {aiPlayer.Bid}\r\n");

            cardsPlayed = 0;
            flpAIPlayed.Controls.Clear();
            lblStatus.Text = "Play your first card.";

            UpdateScores();
        }

        private int PromptForBid(int maxBid)
        {
            using (Form bidForm = new Form())
            {
                bidForm.Text = $"Enter your bid (0–{maxBid})";
                NumericUpDown numericUpDown = new NumericUpDown
                {
                    Minimum = 0,
                    Maximum = maxBid,
                    Location = new Point(10, 10),
                    Width = 100
                };

                Button okButton = new Button
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    Location = new Point(10, 40)
                };

                bidForm.Controls.Add(numericUpDown);
                bidForm.Controls.Add(okButton);
                bidForm.AcceptButton = okButton;
                bidForm.StartPosition = FormStartPosition.CenterParent;
                bidForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                bidForm.MinimizeBox = false;
                bidForm.MaximizeBox = false;
                bidForm.ClientSize = new Size(130, 80);

                return bidForm.ShowDialog() == DialogResult.OK
                    ? (int)numericUpDown.Value
                    : 0;
            }
        }

        private void CardControl_CardClicked(object sender, EventArgs e)
        {
            if (!(sender is CustomCardControl control)) return;

            Card playedCard = control.Card;
            humanPlayer.Hand.Remove(playedCard);
            flpPlayerHand.Controls.Remove(control);

            txtLog.AppendText($"You played: {playedCard}\r\n");

            Card aiCard = aiPlayer.PlayCard(playedCard.Suit, gameManager.CurrentTrump);
            txtLog.AppendText($"AI played: {aiCard}\r\n");

            flpAIPlayed.Controls.Clear();
            flpAIPlayed.Controls.Add(new CustomCardControl(aiCard));

            var winner = gameManager.PlayTrick(playedCard, aiCard);
            txtLog.AppendText($"{winner.Name} won the trick!\r\n");

            cardsPlayed++;

            if (cardsPlayed == gameManager.CardsThisRound)
            {
                gameManager.AdvanceRound();
                UpdateScores();

                if (gameManager.HasMoreRounds)
                {
                    lblStatus.Text = "Round complete. Click 'Next Round'";
                    btnNextRound.Visible = true;
                    btnNextRound.Enabled = true;
                }
                else
                {
                    lblStatus.Text = "Game over!";
                    txtLog.AppendText("\r\n=== Game Over ===\r\n");

                    string Gamewinner;
                    if (humanPlayer.Score > aiPlayer.Score)
                        Gamewinner = "You win!";
                    else if (aiPlayer.Score > humanPlayer.Score)
                        Gamewinner = "AI wins!";
                    else
                        Gamewinner = "It's a tie!";

                    MessageBox.Show($"Final Scores:\nYou: {humanPlayer.Score}\nAI: {aiPlayer.Score}\n\n{Gamewinner}",
                                    "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnStartGame.Visible = true;
                    btnNextRound.Visible = false;
                }
            }

        }

        private void BtnNextRound_Click(object sender, EventArgs e)
        {
            SetupNewRound();
            btnNextRound.Enabled = false;
        }

        private void UpdateScores()
        {
            lblHumanScore.Text = $"Your Score: {humanPlayer.Score}";
            lblAIScore.Text = $"AI Score: {aiPlayer.Score}";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Objective:\n" +
                "Predict how many tricks you'll win. Match your bid exactly to score points.\n\n" +
                " Scoring:\n" +
                "- Exact match: 11 points per trick.\n" +
                "- Bid 0 and win 0: 10×cards in round.\n" +
                "- Else: 0 points.\n\n" +
                " Winning:\n" +
                "- Highest score after all 25 rounds wins.\n" +
                "- Or set a custom point limit (e.g., 500 or 1000).",
                "BlackBall Rules",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}

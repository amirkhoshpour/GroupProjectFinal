using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BlackBall
{
    public class CustomCardControl : UserControl
    {
        private PictureBox pictureBox;
        public Card Card { get; private set; }

        public CustomCardControl(Card card)
        {
            this.Card = card;
            this.Width = 80;
            this.Height = 120;
            this.BackColor = Color.Transparent;

            pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = LoadCardImage(card)
            };

            this.Controls.Add(pictureBox);
            this.Cursor = Cursors.Hand;
            this.Click += (s, e) => CardClicked?.Invoke(this, EventArgs.Empty);
            pictureBox.Click += (s, e) => CardClicked?.Invoke(this, EventArgs.Empty); // propagate click
        }

        private Image LoadCardImage(Card card)
        {
            string suit = card.Suit.ToString().ToLower(); // hearts, clubs, spades, diamonds
            if (suit == "diamonds") suit = "diamonts";    // handle filename typo

            string rank = GetRankCode(card.Rank);         // 2–9, T, J, Q, K, A
            string filename = $"{suit}{rank}.png";        // e.g., heartsQ.png

            string path = Path.Combine(Application.StartupPath, "Assets", "Cards", filename);

            return File.Exists(path) ? Image.FromFile(path) : GetFallbackImage();
        }

        private string GetRankCode(Rank rank)
        {
            switch (rank)
            {
                case Rank.Ten: return "T";
                case Rank.Jack: return "J";
                case Rank.Queen: return "Q";
                case Rank.King: return "K";
                case Rank.Ace: return "A";
                default: return ((int)rank).ToString(); // 2–9
            }
        }

        private Image GetFallbackImage()
        {
            // Optional: return a default "card missing" image or null
            Bitmap bmp = new Bitmap(80, 120);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightGray);
                g.DrawString("?", new Font("Arial", 24), Brushes.Black, new PointF(25, 40));
            }
            return bmp;
        }

        public event EventHandler CardClicked;
    }
}

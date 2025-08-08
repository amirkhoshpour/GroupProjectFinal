namespace BlackBall
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTrump = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.flpPlayerHand = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAIPlayed = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.lblHumanScore = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAIScore = new System.Windows.Forms.Label();
            this.btnNextRound = new System.Windows.Forms.Button();
            this.flpTrumpCard = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTrump
            // 
            this.lblTrump.AutoSize = true;
            this.lblTrump.Location = new System.Drawing.Point(36, 536);
            this.lblTrump.Name = "lblTrump";
            this.lblTrump.Size = new System.Drawing.Size(85, 25);
            this.lblTrump.TabIndex = 0;
            this.lblTrump.Text = "Trump: ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(206, 536);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(79, 25);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status:";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(546, 326);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(352, 148);
            this.txtLog.TabIndex = 2;
            // 
            // flpPlayerHand
            // 
            this.flpPlayerHand.Location = new System.Drawing.Point(41, 674);
            this.flpPlayerHand.Name = "flpPlayerHand";
            this.flpPlayerHand.Size = new System.Drawing.Size(1931, 229);
            this.flpPlayerHand.TabIndex = 3;
            // 
            // flpAIPlayed
            // 
            this.flpAIPlayed.Location = new System.Drawing.Point(45, 43);
            this.flpAIPlayed.Name = "flpAIPlayed";
            this.flpAIPlayed.Size = new System.Drawing.Size(240, 215);
            this.flpAIPlayed.TabIndex = 4;
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(326, 326);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(180, 46);
            this.btnStartGame.TabIndex = 5;
            this.btnStartGame.Text = "Start Game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click_1);
            // 
            // lblHumanScore
            // 
            this.lblHumanScore.AutoSize = true;
            this.lblHumanScore.Location = new System.Drawing.Point(40, 646);
            this.lblHumanScore.Name = "lblHumanScore";
            this.lblHumanScore.Size = new System.Drawing.Size(144, 25);
            this.lblHumanScore.TabIndex = 6;
            this.lblHumanScore.Text = "Your Score: 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 784);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 7;
            // 
            // lblAIScore
            // 
            this.lblAIScore.AutoSize = true;
            this.lblAIScore.Location = new System.Drawing.Point(321, 233);
            this.lblAIScore.Name = "lblAIScore";
            this.lblAIScore.Size = new System.Drawing.Size(117, 25);
            this.lblAIScore.TabIndex = 8;
            this.lblAIScore.Text = "AI Score: 0";
            // 
            // btnNextRound
            // 
            this.btnNextRound.Location = new System.Drawing.Point(326, 428);
            this.btnNextRound.Name = "btnNextRound";
            this.btnNextRound.Size = new System.Drawing.Size(180, 46);
            this.btnNextRound.TabIndex = 9;
            this.btnNextRound.Text = "Next Round";
            this.btnNextRound.UseVisualStyleBackColor = true;
            this.btnNextRound.Visible = false;
            // 
            // flpTrumpCard
            // 
            this.flpTrumpCard.Location = new System.Drawing.Point(45, 280);
            this.flpTrumpCard.Name = "flpTrumpCard";
            this.flpTrumpCard.Size = new System.Drawing.Size(240, 253);
            this.flpTrumpCard.TabIndex = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2018, 40);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(84, 44);
            this.toolStripMenuItem1.Text = "Help";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2018, 1241);
            this.Controls.Add(this.flpTrumpCard);
            this.Controls.Add(this.btnNextRound);
            this.Controls.Add(this.lblAIScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHumanScore);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.flpAIPlayed);
            this.Controls.Add(this.flpPlayerHand);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTrump);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Blackball Card Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTrump;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.FlowLayoutPanel flpPlayerHand;
        private System.Windows.Forms.FlowLayoutPanel flpAIPlayed;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Label lblHumanScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAIScore;
        private System.Windows.Forms.Button btnNextRound;
        private System.Windows.Forms.FlowLayoutPanel flpTrumpCard;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}


namespace FlapJack
{
    partial class GameRoom
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
            this.lblPlayers = new System.Windows.Forms.Label();
            this.gbxCards = new System.Windows.Forms.GroupBox();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.plsRoom = new FlapJack.PlayersList();
            this.SuspendLayout();
            // 
            // lblPlayers
            // 
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.Location = new System.Drawing.Point(12, 9);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(95, 13);
            this.lblPlayers.TabIndex = 6;
            this.lblPlayers.Text = "Jogadores na Sala";
            // 
            // gbxCards
            // 
            this.gbxCards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
<<<<<<< Updated upstream
            this.gbxCards.Location = new System.Drawing.Point(15, 291);
=======
            this.gbxCards.BackColor = System.Drawing.Color.DarkRed;
            this.gbxCards.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbxCards.Location = new System.Drawing.Point(15, 437);
>>>>>>> Stashed changes
            this.gbxCards.Name = "gbxCards";
            this.gbxCards.Size = new System.Drawing.Size(898, 340);
            this.gbxCards.TabIndex = 11;
            this.gbxCards.TabStop = false;
            this.gbxCards.Text = "Cartas na mão";
            // 
            // pnlCards
            // 
            this.pnlCards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCards.AutoScroll = true;
            this.pnlCards.Location = new System.Drawing.Point(21, 310);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(886, 315);
            this.pnlCards.TabIndex = 0;
            // 
            // plsRoom
            // 
            this.plsRoom.BackColor = System.Drawing.Color.DarkRed;
            this.plsRoom.Location = new System.Drawing.Point(12, 25);
            this.plsRoom.Name = "plsRoom";
            this.plsRoom.Players = null;
            this.plsRoom.Size = new System.Drawing.Size(172, 260);
            this.plsRoom.TabIndex = 7;
            this.plsRoom.Load += new System.EventHandler(this.plsRoom_Load);
            // 
            // GameRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< Updated upstream
            this.ClientSize = new System.Drawing.Size(925, 643);
=======
            this.BackgroundImage = global::FlapJack.Properties.Resources.bg_menus;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 643);
>>>>>>> Stashed changes
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.gbxCards);
            this.Controls.Add(this.plsRoom);
            this.Controls.Add(this.lblPlayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameRoom";
            this.Text = "Match";
            this.Load += new System.EventHandler(this.GameMatch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayers;
        private PlayersList plsRoom;
        private System.Windows.Forms.GroupBox gbxCards;
        private System.Windows.Forms.Panel pnlCards;
    }
}
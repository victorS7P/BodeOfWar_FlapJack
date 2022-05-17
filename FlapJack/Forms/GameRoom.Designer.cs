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
            this.components = new System.ComponentModel.Container();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.tmrSelect = new System.Windows.Forms.Timer(this.components);
            this.plsRoom = new FlapJack.PlayersList();
            this.gbxCards = new System.Windows.Forms.GroupBox();
            this.gbxCards.SuspendLayout();
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
            // pnlCards
            // 
            this.pnlCards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCards.AutoScroll = true;
            this.pnlCards.Location = new System.Drawing.Point(9, 19);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1070, 299);
            this.pnlCards.TabIndex = 0;
            // 
            // tmrSelect
            // 
            this.tmrSelect.Enabled = true;
            this.tmrSelect.Interval = 2000;
            this.tmrSelect.Tick += new System.EventHandler(this.tmrSelect_Tick);
            // 
            // plsRoom
            // 
            this.plsRoom.BackColor = System.Drawing.Color.DarkRed;
            this.plsRoom.Location = new System.Drawing.Point(12, 25);
            this.plsRoom.Name = "plsRoom";
            this.plsRoom.Players = null;
            this.plsRoom.Size = new System.Drawing.Size(172, 260);
            this.plsRoom.TabIndex = 7;
            // 
            // gbxCards
            // 
            this.gbxCards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxCards.BackColor = System.Drawing.Color.DarkRed;
            this.gbxCards.Controls.Add(this.pnlCards);
            this.gbxCards.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbxCards.Location = new System.Drawing.Point(12, 307);
            this.gbxCards.Name = "gbxCards";
            this.gbxCards.Size = new System.Drawing.Size(1085, 324);
            this.gbxCards.TabIndex = 11;
            this.gbxCards.TabStop = false;
            this.gbxCards.Text = "Cartas na mão";
            // 
            // GameRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FlapJack.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1109, 643);
            this.Controls.Add(this.gbxCards);
            this.Controls.Add(this.plsRoom);
            this.Controls.Add(this.lblPlayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameRoom";
            this.Text = "Match";
            this.Load += new System.EventHandler(this.GameMatch_Load);
            this.gbxCards.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayers;
        private PlayersList plsRoom;
        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.Timer tmrSelect;
        private System.Windows.Forms.GroupBox gbxCards;
    }
}
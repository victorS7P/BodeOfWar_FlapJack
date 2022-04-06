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
            this.tmrPlayersList = new System.Windows.Forms.Timer(this.components);
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
            // plsRoom
            // 
            this.plsRoom.Location = new System.Drawing.Point(12, 25);
            this.plsRoom.Name = "plsRoom";
            this.plsRoom.Players = null;
            this.plsRoom.Size = new System.Drawing.Size(172, 226);
            this.plsRoom.TabIndex = 7;
            // 
            // GameMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.plsRoom);
            this.Controls.Add(this.lblPlayers);
            this.Name = "GameMatch";
            this.Text = "Match";
            this.Load += new System.EventHandler(this.GameMatch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.Timer tmrPlayersList;
        private PlayersList plsRoom;
    }
}
namespace FlapJack
{
    partial class GameMatch
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
            this.lbxPlayers = new System.Windows.Forms.ListBox();
            this.tmrPlayersList = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblPlayers
            // 
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.Location = new System.Drawing.Point(12, 11);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(95, 13);
            this.lblPlayers.TabIndex = 6;
            this.lblPlayers.Text = "Jogadores na Sala";
            // 
            // lbxPlayers
            // 
            this.lbxPlayers.FormattingEnabled = true;
            this.lbxPlayers.Location = new System.Drawing.Point(12, 30);
            this.lbxPlayers.Name = "lbxPlayers";
            this.lbxPlayers.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbxPlayers.Size = new System.Drawing.Size(210, 160);
            this.lbxPlayers.TabIndex = 5;
            // 
            // Match
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblPlayers);
            this.Controls.Add(this.lbxPlayers);
            this.Name = "Match";
            this.Text = "Match";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.ListBox lbxPlayers;
        private System.Windows.Forms.Timer tmrPlayersList;
    }
}
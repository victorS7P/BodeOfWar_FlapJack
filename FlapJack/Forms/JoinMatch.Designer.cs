namespace FlapJack
{
    partial class JoinMatch
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
            this.lbxPlayers = new System.Windows.Forms.ListBox();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.eBtnJoin = new FlapJack.ErrorButton();
            this.eTxtPassword = new FlapJack.ErrorTextBox();
            this.eTxtPlayer = new FlapJack.ErrorTextBox();
            this.SuspendLayout();
            // 
            // lbxPlayers
            // 
            this.lbxPlayers.FormattingEnabled = true;
            this.lbxPlayers.Location = new System.Drawing.Point(12, 32);
            this.lbxPlayers.Name = "lbxPlayers";
            this.lbxPlayers.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbxPlayers.Size = new System.Drawing.Size(210, 160);
            this.lbxPlayers.TabIndex = 3;
            // 
            // lblPlayers
            // 
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.Location = new System.Drawing.Point(12, 13);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(95, 13);
            this.lblPlayers.TabIndex = 4;
            this.lblPlayers.Text = "Jogadores na Sala";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // eBtnJoin
            // 
            this.eBtnJoin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eBtnJoin.Error = "";
            this.eBtnJoin.Label = "Entrar";
            this.eBtnJoin.Location = new System.Drawing.Point(228, 152);
            this.eBtnJoin.Name = "eBtnJoin";
            this.eBtnJoin.Size = new System.Drawing.Size(325, 50);
            this.eBtnJoin.TabIndex = 2;
            this.eBtnJoin.OnClick += new System.EventHandler(this.eBtnJoin_OnClick);
            // 
            // eTxtPassword
            // 
            this.eTxtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eTxtPassword.AutoSize = true;
            this.eTxtPassword.EnableEmpty = false;
            this.eTxtPassword.Error = "";
            this.eTxtPassword.Label = "Senha da Partida";
            this.eTxtPassword.Location = new System.Drawing.Point(228, 79);
            this.eTxtPassword.Name = "eTxtPassword";
            this.eTxtPassword.PasswordChar = '*';
            this.eTxtPassword.Pure = true;
            this.eTxtPassword.Size = new System.Drawing.Size(325, 57);
            this.eTxtPassword.TabIndex = 1;
            this.eTxtPassword.Value = "";
            // 
            // eTxtPlayer
            // 
            this.eTxtPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eTxtPlayer.AutoSize = true;
            this.eTxtPlayer.EnableEmpty = false;
            this.eTxtPlayer.Error = "";
            this.eTxtPlayer.Label = "Nome do Jogador";
            this.eTxtPlayer.Location = new System.Drawing.Point(227, 16);
            this.eTxtPlayer.Name = "eTxtPlayer";
            this.eTxtPlayer.PasswordChar = '\0';
            this.eTxtPlayer.Pure = true;
            this.eTxtPlayer.Size = new System.Drawing.Size(325, 57);
            this.eTxtPlayer.TabIndex = 0;
            this.eTxtPlayer.Value = "";
            // 
            // JoinMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 208);
            this.Controls.Add(this.lblPlayers);
            this.Controls.Add(this.lbxPlayers);
            this.Controls.Add(this.eBtnJoin);
            this.Controls.Add(this.eTxtPassword);
            this.Controls.Add(this.eTxtPlayer);
            this.Name = "JoinMatch";
            this.Text = "JoinMatch";
            this.Load += new System.EventHandler(this.JoinMatch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ErrorTextBox eTxtPlayer;
        private ErrorTextBox eTxtPassword;
        private ErrorButton eBtnJoin;
        private System.Windows.Forms.ListBox lbxPlayers;
        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.Timer timer1;
    }
}
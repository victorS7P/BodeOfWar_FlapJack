namespace FlapJack
{
    partial class Hall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hall));
            this.dgvMatches = new System.Windows.Forms.DataGridView();
            this.btnCreateMatch = new System.Windows.Forms.Button();
            this.tmrMatches = new System.Windows.Forms.Timer(this.components);
            this.cmbTypes = new System.Windows.Forms.ComboBox();
            this.lblTypes = new System.Windows.Forms.Label();
            this.gbxMatch = new System.Windows.Forms.GroupBox();
            this.tmrPlayersList = new System.Windows.Forms.Timer(this.components);
            this.pltHall = new FlapJack.PlayersList();
            this.eTxtPassword = new FlapJack.ErrorTextBox();
            this.eTxtPlayer = new FlapJack.ErrorTextBox();
            this.eBtnJoin = new FlapJack.ErrorButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatches)).BeginInit();
            this.gbxMatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMatches
            // 
            this.dgvMatches.AllowUserToAddRows = false;
            this.dgvMatches.AllowUserToDeleteRows = false;
            this.dgvMatches.AllowUserToResizeColumns = false;
            this.dgvMatches.AllowUserToResizeRows = false;
            this.dgvMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatches.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMatches.Location = new System.Drawing.Point(12, 12);
            this.dgvMatches.MultiSelect = false;
            this.dgvMatches.Name = "dgvMatches";
            this.dgvMatches.RowTemplate.Height = 25;
            this.dgvMatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMatches.ShowEditingIcon = false;
            this.dgvMatches.Size = new System.Drawing.Size(540, 484);
            this.dgvMatches.TabIndex = 1;
            this.dgvMatches.SelectionChanged += new System.EventHandler(this.dgvMatches_SelectionChanged);
            // 
            // btnCreateMatch
            // 
            this.btnCreateMatch.BackColor = System.Drawing.Color.DarkRed;
            this.btnCreateMatch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCreateMatch.Location = new System.Drawing.Point(567, 53);
            this.btnCreateMatch.Name = "btnCreateMatch";
            this.btnCreateMatch.Size = new System.Drawing.Size(249, 20);
            this.btnCreateMatch.TabIndex = 2;
            this.btnCreateMatch.Text = "Criar Nova Partida";
            this.btnCreateMatch.UseVisualStyleBackColor = true;
            this.btnCreateMatch.Click += new System.EventHandler(this.btnCreateMatch_Click);
            // 
            // tmrMatches
            // 
            this.tmrMatches.Interval = 1000;
            this.tmrMatches.Tick += new System.EventHandler(this.tmrMatches_Tick);
            // 
            // cmbTypes
            // 
            this.cmbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypes.FormattingEnabled = true;
            this.cmbTypes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbTypes.Items.AddRange(new object[] {
            "(T) Todas",
            "(A) Abertas",
            "(J) Jogando",
            "(E) Encerradas"});
            this.cmbTypes.Location = new System.Drawing.Point(567, 26);
            this.cmbTypes.Name = "cmbTypes";
            this.cmbTypes.Size = new System.Drawing.Size(249, 21);
            this.cmbTypes.TabIndex = 4;
            this.cmbTypes.SelectedIndexChanged += new System.EventHandler(this.cmbTypes_SelectedIndexChanged);
            // 
            // lblTypes
            // 
            this.lblTypes.AutoSize = true;
            this.lblTypes.Location = new System.Drawing.Point(564, 10);
            this.lblTypes.Name = "lblTypes";
            this.lblTypes.Size = new System.Drawing.Size(76, 13);
            this.lblTypes.TabIndex = 5;
            this.lblTypes.Text = "Exibir Partidas:";
            // 
            // gbxMatch
            // 
            this.gbxMatch.BackColor = System.Drawing.Color.DarkRed;
            this.gbxMatch.Controls.Add(this.pltHall);
            this.gbxMatch.Controls.Add(this.eTxtPassword);
            this.gbxMatch.Controls.Add(this.eTxtPlayer);
            this.gbxMatch.Controls.Add(this.eBtnJoin);
            this.gbxMatch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbxMatch.Location = new System.Drawing.Point(567, 79);
            this.gbxMatch.Name = "gbxMatch";
            this.gbxMatch.Size = new System.Drawing.Size(249, 417);
            this.gbxMatch.TabIndex = 8;
            this.gbxMatch.TabStop = false;
            this.gbxMatch.Visible = false;
            // 
            // tmrPlayersList
            // 
            this.tmrPlayersList.Tick += new System.EventHandler(this.tmrPlayersList_Tick);
            // 
            // pltHall
            // 
            this.pltHall.BackColor = System.Drawing.Color.DarkRed;
            this.pltHall.Location = new System.Drawing.Point(6, 19);
            this.pltHall.Name = "pltHall";
            this.pltHall.Players = null;
            this.pltHall.Size = new System.Drawing.Size(237, 217);
            this.pltHall.TabIndex = 10;
            // 
            // eTxtPassword
            // 
            this.eTxtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eTxtPassword.EnableEmpty = false;
            this.eTxtPassword.Error = "";
            this.eTxtPassword.Label = "Senha da Partida";
            this.eTxtPassword.Location = new System.Drawing.Point(6, 297);
            this.eTxtPassword.Name = "eTxtPassword";
            this.eTxtPassword.PasswordChar = '*';
            this.eTxtPassword.Pure = true;
            this.eTxtPassword.Size = new System.Drawing.Size(237, 58);
            this.eTxtPassword.TabIndex = 9;
            this.eTxtPassword.Value = "";
            // 
            // eTxtPlayer
            // 
            this.eTxtPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eTxtPlayer.EnableEmpty = false;
            this.eTxtPlayer.Error = "";
            this.eTxtPlayer.Label = "Nome do Jogador";
            this.eTxtPlayer.Location = new System.Drawing.Point(5, 234);
            this.eTxtPlayer.Name = "eTxtPlayer";
            this.eTxtPlayer.PasswordChar = '\0';
            this.eTxtPlayer.Pure = true;
            this.eTxtPlayer.Size = new System.Drawing.Size(238, 57);
            this.eTxtPlayer.TabIndex = 8;
            this.eTxtPlayer.Value = "";
            // 
            // eBtnJoin
            // 
            this.eBtnJoin.Error = "";
            this.eBtnJoin.Label = "Entrar";
            this.eBtnJoin.Location = new System.Drawing.Point(6, 361);
            this.eBtnJoin.Name = "eBtnJoin";
            this.eBtnJoin.Size = new System.Drawing.Size(237, 50);
            this.eBtnJoin.TabIndex = 6;
            this.eBtnJoin.OnClick += new System.EventHandler(this.eBtnJoin_OnClick);
            // 
            // Hall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::FlapJack.Properties.Resources.bg_menus;
            this.ClientSize = new System.Drawing.Size(825, 508);
            this.Controls.Add(this.gbxMatch);
            this.Controls.Add(this.lblTypes);
            this.Controls.Add(this.cmbTypes);
            this.Controls.Add(this.btnCreateMatch);
            this.Controls.Add(this.dgvMatches);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Hall";
            this.ShowInTaskbar = false;
            this.Text = "Hall";
            this.Load += new System.EventHandler(this.Hall_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatches)).EndInit();
            this.gbxMatch.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvMatches;
        private System.Windows.Forms.Button btnCreateMatch;
        private System.Windows.Forms.Timer tmrMatches;
        private System.Windows.Forms.ComboBox cmbTypes;
        private System.Windows.Forms.Label lblTypes;
        private ErrorButton eBtnJoin;
        private System.Windows.Forms.GroupBox gbxMatch;
        private ErrorTextBox eTxtPassword;
        private ErrorTextBox eTxtPlayer;
        private System.Windows.Forms.Timer tmrPlayersList;
        private PlayersList pltHall;
    }
}
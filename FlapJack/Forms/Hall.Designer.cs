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
            this.lblMatches = new System.Windows.Forms.Label();
            this.dgvMatches = new System.Windows.Forms.DataGridView();
            this.btnCreateMatch = new System.Windows.Forms.Button();
            this.tmrMatches = new System.Windows.Forms.Timer(this.components);
            this.cmbTypes = new System.Windows.Forms.ComboBox();
            this.lblTypes = new System.Windows.Forms.Label();
            this.eBtnJoin = new FlapJack.ErrorButton();
            this.eBtnUpdate = new FlapJack.ErrorButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatches)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMatches
            // 
            this.lblMatches.AutoSize = true;
            this.lblMatches.Location = new System.Drawing.Point(12, 28);
            this.lblMatches.Name = "lblMatches";
            this.lblMatches.Size = new System.Drawing.Size(45, 13);
            this.lblMatches.TabIndex = 0;
            this.lblMatches.Text = "Partidas";
            // 
            // dgvMatches
            // 
            this.dgvMatches.AllowUserToAddRows = false;
            this.dgvMatches.AllowUserToDeleteRows = false;
            this.dgvMatches.AllowUserToResizeColumns = false;
            this.dgvMatches.AllowUserToResizeRows = false;
            this.dgvMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatches.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMatches.Location = new System.Drawing.Point(15, 52);
            this.dgvMatches.MultiSelect = false;
            this.dgvMatches.Name = "dgvMatches";
            this.dgvMatches.RowTemplate.Height = 25;
            this.dgvMatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMatches.ShowEditingIcon = false;
            this.dgvMatches.Size = new System.Drawing.Size(540, 419);
            this.dgvMatches.TabIndex = 1;
            this.dgvMatches.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMatches_CellDoubleClick);
            this.dgvMatches.SelectionChanged += new System.EventHandler(this.dgvMatches_SelectionChanged);
            // 
            // btnCreateMatch
            // 
            this.btnCreateMatch.Location = new System.Drawing.Point(570, 451);
            this.btnCreateMatch.Name = "btnCreateMatch";
            this.btnCreateMatch.Size = new System.Drawing.Size(249, 20);
            this.btnCreateMatch.TabIndex = 2;
            this.btnCreateMatch.Text = "Criar Partida";
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
            this.cmbTypes.Location = new System.Drawing.Point(570, 66);
            this.cmbTypes.Name = "cmbTypes";
            this.cmbTypes.Size = new System.Drawing.Size(249, 21);
            this.cmbTypes.TabIndex = 4;
            this.cmbTypes.SelectedIndexChanged += new System.EventHandler(this.cmbTypes_SelectedIndexChanged);
            // 
            // lblTypes
            // 
            this.lblTypes.AutoSize = true;
            this.lblTypes.Location = new System.Drawing.Point(567, 50);
            this.lblTypes.Name = "lblTypes";
            this.lblTypes.Size = new System.Drawing.Size(76, 13);
            this.lblTypes.TabIndex = 5;
            this.lblTypes.Text = "Exibir Partidas:";
            // 
            // eBtnJoin
            // 
            this.eBtnJoin.Error = "";
            this.eBtnJoin.Label = "Entrar";
            this.eBtnJoin.Location = new System.Drawing.Point(570, 121);
            this.eBtnJoin.Name = "eBtnJoin";
            this.eBtnJoin.Size = new System.Drawing.Size(249, 50);
            this.eBtnJoin.TabIndex = 6;
            this.eBtnJoin.OnClick += new System.EventHandler(this.eBtnJoin_OnClick);
            // 
            // eBtnUpdate
            // 
            this.eBtnUpdate.Error = "";
            this.eBtnUpdate.Label = "Atualizar Lista";
            this.eBtnUpdate.Location = new System.Drawing.Point(570, 93);
            this.eBtnUpdate.Name = "eBtnUpdate";
            this.eBtnUpdate.Size = new System.Drawing.Size(249, 50);
            this.eBtnUpdate.TabIndex = 7;
            this.eBtnUpdate.OnClick += new System.EventHandler(this.eBtnUpdate_OnClick);
            // 
            // Hall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 483);
            this.Controls.Add(this.eBtnJoin);
            this.Controls.Add(this.eBtnUpdate);
            this.Controls.Add(this.lblTypes);
            this.Controls.Add(this.cmbTypes);
            this.Controls.Add(this.btnCreateMatch);
            this.Controls.Add(this.dgvMatches);
            this.Controls.Add(this.lblMatches);
            this.Name = "Hall";
            this.ShowInTaskbar = false;
            this.Text = "Hall";
            this.Load += new System.EventHandler(this.Hall_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatches)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMatches;
        private System.Windows.Forms.DataGridView dgvMatches;
        private System.Windows.Forms.Button btnCreateMatch;
        private System.Windows.Forms.Timer tmrMatches;
        private System.Windows.Forms.ComboBox cmbTypes;
        private System.Windows.Forms.Label lblTypes;
        private ErrorButton eBtnJoin;
        private ErrorButton eBtnUpdate;
    }
}
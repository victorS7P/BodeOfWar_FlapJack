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
            this.lblMatches = new System.Windows.Forms.Label();
            this.dgvMatches = new System.Windows.Forms.DataGridView();
            this.btnCreateMatch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatches)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMatches
            // 
            this.lblMatches.AutoSize = true;
            this.lblMatches.Location = new System.Drawing.Point(29, 37);
            this.lblMatches.Name = "lblMatches";
            this.lblMatches.Size = new System.Drawing.Size(45, 13);
            this.lblMatches.TabIndex = 0;
            this.lblMatches.Text = "Partidas";
            // 
            // dgvMatches
            // 
            this.dgvMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatches.Location = new System.Drawing.Point(29, 62);
            this.dgvMatches.Name = "dgvMatches";
            this.dgvMatches.RowTemplate.Height = 25;
            this.dgvMatches.Size = new System.Drawing.Size(206, 130);
            this.dgvMatches.TabIndex = 1;
            // 
            // btnCreateMatch
            // 
            this.btnCreateMatch.Location = new System.Drawing.Point(369, 124);
            this.btnCreateMatch.Name = "btnCreateMatch";
            this.btnCreateMatch.Size = new System.Drawing.Size(126, 20);
            this.btnCreateMatch.TabIndex = 2;
            this.btnCreateMatch.Text = "Criar Partida";
            this.btnCreateMatch.UseVisualStyleBackColor = true;
            // 
            // Hall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
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
    }
}
namespace FlapJack
{
    partial class GoatCardControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblGoats = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlCard.Controls.Add(this.lblGoats);
            this.pnlCard.Controls.Add(this.lblId);
            this.pnlCard.Location = new System.Drawing.Point(0, 0);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(241, 343);
            this.pnlCard.TabIndex = 0;
            this.pnlCard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlCard_MouseClick);
            // 
            // lblGoats
            // 
            this.lblGoats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGoats.AutoSize = true;
            this.lblGoats.BackColor = System.Drawing.Color.Black;
            this.lblGoats.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoats.ForeColor = System.Drawing.Color.White;
            this.lblGoats.Location = new System.Drawing.Point(22, 289);
            this.lblGoats.Name = "lblGoats";
            this.lblGoats.Size = new System.Drawing.Size(30, 31);
            this.lblGoats.TabIndex = 1;
            this.lblGoats.Text = "0";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.BackColor = System.Drawing.Color.Black;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.ForeColor = System.Drawing.Color.White;
            this.lblId.Location = new System.Drawing.Point(22, 19);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(30, 31);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "0";
            // 
            // GoatCardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlCard);
            this.Name = "GoatCardControl";
            this.Size = new System.Drawing.Size(241, 343);
            this.Load += new System.EventHandler(this.Card_Load);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblGoats;
        private System.Windows.Forms.Label lblId;
    }
}

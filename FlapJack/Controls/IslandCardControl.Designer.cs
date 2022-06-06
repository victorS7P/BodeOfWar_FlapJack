namespace FlapJack
{
    partial class IslandCardControl
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
            this.lblValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblValue
            // 
            this.lblValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValue.BackColor = System.Drawing.Color.Transparent;
            this.lblValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.ForeColor = System.Drawing.Color.Black;
            this.lblValue.Location = new System.Drawing.Point(56, 56);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(52, 55);
            this.lblValue.TabIndex = 0;
            this.lblValue.Text = "0";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblValue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblValue_MouseClick);
            this.lblValue.MouseEnter += new System.EventHandler(this.lblValue_MouseEnter);
            this.lblValue.MouseLeave += new System.EventHandler(this.lblValue_MouseLeave);
            // 
            // IslandCardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblValue);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "IslandCardControl";
            this.Size = new System.Drawing.Size(168, 170);
            this.MouseEnter += new System.EventHandler(this.IslandCardControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.IslandCardControl_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblValue;
    }
}

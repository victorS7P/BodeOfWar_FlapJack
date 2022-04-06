namespace FlapJack
{
    partial class PlayersList
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
            this.lbxPlayers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbxPlayers
            // 
            this.lbxPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxPlayers.FormattingEnabled = true;
            this.lbxPlayers.Location = new System.Drawing.Point(3, 3);
            this.lbxPlayers.Name = "lbxPlayers";
            this.lbxPlayers.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbxPlayers.Size = new System.Drawing.Size(522, 407);
            this.lbxPlayers.TabIndex = 8;
            // 
            // PlayersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbxPlayers);
            this.Name = "PlayersList";
            this.Size = new System.Drawing.Size(528, 413);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxPlayers;
    }
}

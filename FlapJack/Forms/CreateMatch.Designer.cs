namespace FlapJack
{
    partial class CreateMatch
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.eTxtPassword = new FlapJack.ErrorTextBox();
            this.eTxtConfirm = new FlapJack.ErrorTextBox();
            this.eTxtName = new FlapJack.ErrorTextBox();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCreate.Location = new System.Drawing.Point(221, 286);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Criar";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.IndianRed;
            this.lblError.Location = new System.Drawing.Point(12, 291);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 7;
            // 
            // eTxtPassword
            // 
            this.eTxtPassword.AutoSize = true;
            this.eTxtPassword.EnableEmpty = false;
            this.eTxtPassword.Error = "";
            this.eTxtPassword.Label = "Senha";
            this.eTxtPassword.Location = new System.Drawing.Point(12, 84);
            this.eTxtPassword.Name = "eTxtPassword";
            this.eTxtPassword.PasswordChar = '*';
            this.eTxtPassword.Pure = true;
            this.eTxtPassword.Size = new System.Drawing.Size(284, 57);
            this.eTxtPassword.TabIndex = 2;
            this.eTxtPassword.Value = "";
            this.eTxtPassword.OnValidate += new System.EventHandler(this.ToggleButtonEnable);
            // 
            // eTxtConfirm
            // 
            this.eTxtConfirm.AutoSize = true;
            this.eTxtConfirm.EnableEmpty = false;
            this.eTxtConfirm.Error = "";
            this.eTxtConfirm.Label = "Confirmar Senha";
            this.eTxtConfirm.Location = new System.Drawing.Point(12, 157);
            this.eTxtConfirm.Name = "eTxtConfirm";
            this.eTxtConfirm.PasswordChar = '*';
            this.eTxtConfirm.Pure = true;
            this.eTxtConfirm.Size = new System.Drawing.Size(284, 57);
            this.eTxtConfirm.TabIndex = 3;
            this.eTxtConfirm.Value = "";
            this.eTxtConfirm.OnValidate += new System.EventHandler(this.ToggleButtonEnable);
            // 
            // eTxtName
            // 
            this.eTxtName.AutoSize = true;
            this.eTxtName.EnableEmpty = false;
            this.eTxtName.Error = "";
            this.eTxtName.Label = "Nome";
            this.eTxtName.Location = new System.Drawing.Point(12, 12);
            this.eTxtName.Name = "eTxtName";
            this.eTxtName.PasswordChar = '\0';
            this.eTxtName.Pure = true;
            this.eTxtName.Size = new System.Drawing.Size(284, 57);
            this.eTxtName.TabIndex = 1;
            this.eTxtName.Value = "";
            this.eTxtName.OnValidate += new System.EventHandler(this.ToggleButtonEnable);
            this.eTxtName.OnType += new System.EventHandler(this.eTxtName_OnType);
            // 
            // CreateMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(308, 321);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.eTxtPassword);
            this.Controls.Add(this.eTxtConfirm);
            this.Controls.Add(this.eTxtName);
            this.Controls.Add(this.btnCreate);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "CreateMatch";
            this.Text = "CreateMatch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateMatch_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCreate;
        private ErrorTextBox eTxtName;
        private ErrorTextBox eTxtConfirm;
        private ErrorTextBox eTxtPassword;
        private System.Windows.Forms.Label lblError;
    }
}
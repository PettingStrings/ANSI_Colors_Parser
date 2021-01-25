
namespace ANSIParser
{
    partial class FrmMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtxtBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtxtBox
            // 
            this.rtxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBox.BackColor = System.Drawing.SystemColors.MenuText;
            this.rtxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtBox.ForeColor = System.Drawing.Color.GreenYellow;
            this.rtxtBox.Location = new System.Drawing.Point(12, 12);
            this.rtxtBox.Name = "rtxtBox";
            this.rtxtBox.ReadOnly = true;
            this.rtxtBox.Size = new System.Drawing.Size(481, 326);
            this.rtxtBox.TabIndex = 0;
            this.rtxtBox.Text = "TO DO: finish this form";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(507, 350);
            this.Controls.Add(this.rtxtBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMain";
            this.Text = "ANSI Parser test strings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtBox;
    }
}


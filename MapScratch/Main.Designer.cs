namespace MapScratch
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.pBGrabImage = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pBGrabImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pBGrabImage
            // 
            this.pBGrabImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBGrabImage.Location = new System.Drawing.Point(0, 0);
            this.pBGrabImage.Name = "pBGrabImage";
            this.pBGrabImage.Size = new System.Drawing.Size(390, 397);
            this.pBGrabImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBGrabImage.TabIndex = 0;
            this.pBGrabImage.TabStop = false;
            this.pBGrabImage.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "png";
            this.saveFileDialog1.FileName = "image.png";
            this.saveFileDialog1.Filter = "PNG Files|*.png";
            this.saveFileDialog1.Title = "Save Image";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 397);
            this.Controls.Add(this.pBGrabImage);
            this.Name = "Main";
            this.Text = "Press F2 to set Rectangle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pBGrabImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pBGrabImage;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}


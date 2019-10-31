namespace EmlakOtomasyonu
{
    partial class SecenekEkrani
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
            this.btnEvEkleme = new System.Windows.Forms.Button();
            this.btnSorgulama = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEvEkleme
            // 
            this.btnEvEkleme.AutoSize = true;
            this.btnEvEkleme.Location = new System.Drawing.Point(290, 173);
            this.btnEvEkleme.Name = "btnEvEkleme";
            this.btnEvEkleme.Size = new System.Drawing.Size(292, 58);
            this.btnEvEkleme.TabIndex = 0;
            this.btnEvEkleme.Text = "Yeni Ev Ekleme";
            this.btnEvEkleme.UseVisualStyleBackColor = true;
            this.btnEvEkleme.Click += new System.EventHandler(this.btnEvEkleme_Click);
            // 
            // btnSorgulama
            // 
            this.btnSorgulama.AutoSize = true;
            this.btnSorgulama.Location = new System.Drawing.Point(290, 261);
            this.btnSorgulama.Name = "btnSorgulama";
            this.btnSorgulama.Size = new System.Drawing.Size(292, 58);
            this.btnSorgulama.TabIndex = 3;
            this.btnSorgulama.Text = "Sorgulama Listeleme";
            this.btnSorgulama.UseVisualStyleBackColor = true;
            this.btnSorgulama.Click += new System.EventHandler(this.btnSorgulama_Click);
            // 
            // SecenekEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 515);
            this.Controls.Add(this.btnSorgulama);
            this.Controls.Add(this.btnEvEkleme);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "SecenekEkrani";
            this.Text = "SecenekEkrani";
            this.Load += new System.EventHandler(this.SecenekEkrani_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEvEkleme;
        private System.Windows.Forms.Button btnSorgulama;
    }
}
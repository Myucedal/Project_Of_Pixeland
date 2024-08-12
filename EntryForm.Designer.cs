namespace Project_of_Pixeland
{
    partial class EntryForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryForm));
            this.sec_btn = new System.Windows.Forms.Button();
            this.yukle_btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sec_btn
            // 
            this.sec_btn.BackColor = System.Drawing.Color.LightCyan;
            this.sec_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sec_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sec_btn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.sec_btn.Location = new System.Drawing.Point(408, 389);
            this.sec_btn.Name = "sec_btn";
            this.sec_btn.Size = new System.Drawing.Size(311, 36);
            this.sec_btn.TabIndex = 5;
            this.sec_btn.Text = "Hazırlardan Seç";
            this.sec_btn.UseVisualStyleBackColor = false;
            this.sec_btn.Click += new System.EventHandler(this.sec_btn_Click_1);
            // 
            // yukle_btn
            // 
            this.yukle_btn.BackColor = System.Drawing.Color.Black;
            this.yukle_btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.yukle_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.yukle_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.yukle_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.yukle_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yukle_btn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.yukle_btn.Location = new System.Drawing.Point(408, 328);
            this.yukle_btn.Name = "yukle_btn";
            this.yukle_btn.Size = new System.Drawing.Size(311, 36);
            this.yukle_btn.TabIndex = 4;
            this.yukle_btn.Text = "Yükle";
            this.yukle_btn.UseVisualStyleBackColor = false;
            this.yukle_btn.Click += new System.EventHandler(this.yukle_btn_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(482, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 173);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = global::Project_of_Pixeland.Properties.Resources._2;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(404, 324);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 44);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImage = global::Project_of_Pixeland.Properties.Resources._2;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(404, 385);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 44);
            this.panel2.TabIndex = 7;
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1132, 541);
            this.Controls.Add(this.sec_btn);
            this.Controls.Add(this.yukle_btn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.Gray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "EntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pixeland";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sec_btn;
        private System.Windows.Forms.Button yukle_btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}


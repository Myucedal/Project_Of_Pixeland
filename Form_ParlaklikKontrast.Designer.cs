namespace Project_of_Pixeland
{
    partial class Form_ParlaklikKontrast
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kontrastDegeri_lbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.kontrast_tbar = new System.Windows.Forms.TrackBar();
            this.parlaklik_tbar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.parlaklikDegeri_lbl = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kontrast_tbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parlaklik_tbar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1111, 379);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // kontrastDegeri_lbl
            // 
            this.kontrastDegeri_lbl.AutoSize = true;
            this.kontrastDegeri_lbl.BackColor = System.Drawing.Color.Transparent;
            this.kontrastDegeri_lbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kontrastDegeri_lbl.ForeColor = System.Drawing.Color.White;
            this.kontrastDegeri_lbl.Location = new System.Drawing.Point(595, 468);
            this.kontrastDegeri_lbl.Name = "kontrastDegeri_lbl";
            this.kontrastDegeri_lbl.Size = new System.Drawing.Size(18, 18);
            this.kontrastDegeri_lbl.TabIndex = 37;
            this.kontrastDegeri_lbl.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(511, 468);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 18);
            this.label3.TabIndex = 38;
            this.label3.Text = "Kontrast :";
            // 
            // kontrast_tbar
            // 
            this.kontrast_tbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kontrast_tbar.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.kontrast_tbar.LargeChange = 0;
            this.kontrast_tbar.Location = new System.Drawing.Point(12, 490);
            this.kontrast_tbar.Maximum = 100;
            this.kontrast_tbar.Minimum = -100;
            this.kontrast_tbar.Name = "kontrast_tbar";
            this.kontrast_tbar.Size = new System.Drawing.Size(1108, 45);
            this.kontrast_tbar.SmallChange = 0;
            this.kontrast_tbar.TabIndex = 35;
            this.kontrast_tbar.TickFrequency = 4;
            this.kontrast_tbar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.kontrast_tbar.ValueChanged += new System.EventHandler(this.kontrast_tbar_ValueChanged);
            // 
            // parlaklik_tbar
            // 
            this.parlaklik_tbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.parlaklik_tbar.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.parlaklik_tbar.LargeChange = 0;
            this.parlaklik_tbar.Location = new System.Drawing.Point(12, 420);
            this.parlaklik_tbar.Maximum = 255;
            this.parlaklik_tbar.Minimum = -255;
            this.parlaklik_tbar.Name = "parlaklik_tbar";
            this.parlaklik_tbar.Size = new System.Drawing.Size(1108, 45);
            this.parlaklik_tbar.SmallChange = 0;
            this.parlaklik_tbar.TabIndex = 35;
            this.parlaklik_tbar.TickFrequency = 15;
            this.parlaklik_tbar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.parlaklik_tbar.Scroll += new System.EventHandler(this.parlaklik_tbar_Scroll);
            this.parlaklik_tbar.ValueChanged += new System.EventHandler(this.parlaklik_tbar_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(511, 399);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 38;
            this.label1.Text = "Parlaklık :";
            // 
            // parlaklikDegeri_lbl
            // 
            this.parlaklikDegeri_lbl.AutoSize = true;
            this.parlaklikDegeri_lbl.BackColor = System.Drawing.Color.Transparent;
            this.parlaklikDegeri_lbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parlaklikDegeri_lbl.ForeColor = System.Drawing.Color.White;
            this.parlaklikDegeri_lbl.Location = new System.Drawing.Point(595, 399);
            this.parlaklikDegeri_lbl.Name = "parlaklikDegeri_lbl";
            this.parlaklikDegeri_lbl.Size = new System.Drawing.Size(18, 18);
            this.parlaklikDegeri_lbl.TabIndex = 37;
            this.parlaklikDegeri_lbl.Text = "0";
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button9.Location = new System.Drawing.Point(461, 550);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(204, 36);
            this.button9.TabIndex = 115;
            this.button9.Text = "Kaydet";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.kaydet_btn_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BackgroundImage = global::Project_of_Pixeland.Properties.Resources._2;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Location = new System.Drawing.Point(458, 547);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(210, 42);
            this.panel6.TabIndex = 116;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(461, 658);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 36);
            this.button1.TabIndex = 113;
            this.button1.Text = "Yeni Görsel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.yeniGorsel_btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = global::Project_of_Pixeland.Properties.Resources._2;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(458, 655);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 42);
            this.panel1.TabIndex = 114;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button4.Location = new System.Drawing.Point(916, 658);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(204, 36);
            this.button4.TabIndex = 107;
            this.button4.Text = "Iptal";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.iptal_btn_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button3.Location = new System.Drawing.Point(12, 661);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(204, 36);
            this.button3.TabIndex = 108;
            this.button3.Text = "Sıfırla";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.sifirla_btn_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button2.Location = new System.Drawing.Point(461, 604);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(204, 36);
            this.button2.TabIndex = 109;
            this.button2.Text = "Indir";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.indir_btn_Click);
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.White;
            this.panel17.BackgroundImage = global::Project_of_Pixeland.Properties.Resources._2;
            this.panel17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel17.Location = new System.Drawing.Point(913, 655);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(210, 42);
            this.panel17.TabIndex = 110;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.White;
            this.panel16.BackgroundImage = global::Project_of_Pixeland.Properties.Resources._2;
            this.panel16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel16.Location = new System.Drawing.Point(9, 658);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(210, 42);
            this.panel16.TabIndex = 111;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.White;
            this.panel15.BackgroundImage = global::Project_of_Pixeland.Properties.Resources._2;
            this.panel15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel15.Location = new System.Drawing.Point(458, 601);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(210, 42);
            this.panel15.TabIndex = 112;
            // 
            // Form_ParlaklikKontrast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BackgroundImage = global::Project_of_Pixeland.Properties.Resources.xyz;
            this.ClientSize = new System.Drawing.Size(1132, 706);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel17);
            this.Controls.Add(this.panel16);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.parlaklikDegeri_lbl);
            this.Controls.Add(this.kontrastDegeri_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.parlaklik_tbar);
            this.Controls.Add(this.kontrast_tbar);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Form_ParlaklikKontrast";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parlaklik ve Kontrast";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kontrast_tbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parlaklik_tbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label kontrastDegeri_lbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar kontrast_tbar;
        private System.Windows.Forms.TrackBar parlaklik_tbar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label parlaklikDegeri_lbl;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel15;
    }
}
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Project_of_Pixeland
{
    public partial class EntryForm : Form
    {
        int r = 40; // Kırmızı değeri
        int g = 8; // Yeşil değeri
        int b = 14; // Mavi değeri
        public EntryForm()
        {
            InitializeComponent();
            //int r = 67; // Kırmızı değeri
            //int g = 14; // Yeşil değeri
            //int b = 24; // Mavi değeri
    
            Color newColor = Color.FromArgb(r, g, b);

            yukle_btn.BackColor = newColor;
            sec_btn.BackColor = newColor;

            sec_btn.MouseEnter += new EventHandler(Button_MouseEnter);
            yukle_btn.MouseEnter += new EventHandler(Button_MouseEnter);
            sec_btn.MouseLeave += new EventHandler(Button_MouseLeave);
            yukle_btn.MouseLeave += new EventHandler(Button_MouseLeave);

        }

        private void yukle_btn_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;
                Image image = Image.FromFile(selectedImagePath);
                MainForm mainForm = new MainForm(image);
                mainForm.Show();
                this.Hide();
            }
        }

        private void sec_btn_Click_1(object sender, EventArgs e)
        {
            string hazirGorselDizini = Path.Combine(Application.StartupPath, "HazirGorseller");
            if (!Directory.Exists(hazirGorselDizini) || Directory.GetFiles(hazirGorselDizini).Length == 0)
            {
                MessageBox.Show("Hazır görseller bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = hazirGorselDizini;
            openFileDialog.Filter = "Resim Dosyaları (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;
                Image image = Image.FromFile(selectedImagePath);
                MainForm mainForm = new MainForm(image);
                mainForm.Show();
                this.Hide();
            }
        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                if (btn == yukle_btn)
                {
                    int r = 50; // Kırmızı değeri
                    int g = 14; // Yeşil değeri
                    int b = 24; // Mavi değeri
                    Color newColor = Color.FromArgb(r, g, b);

                    yukle_btn.BackColor = newColor;
                }
                if (btn == sec_btn)
                {
                    int r = 50; // Kırmızı değeri
                    int g = 14; // Yeşil değeri
                    int b = 24; // Mavi değeri
                    Color newColor = Color.FromArgb(r, g, b);

                    sec_btn.BackColor = newColor;
                }
            }
        }

        // MouseLeave olayı için işleyici
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                if (btn == yukle_btn)
                {
                    Color newColor = Color.FromArgb(r, g, b);

                    yukle_btn.BackColor = newColor;
                }
                if (btn == sec_btn)
                {
                    Color newColor = Color.FromArgb(r, g, b);

                    sec_btn.BackColor = newColor;
                }
            }
        }


    }
}

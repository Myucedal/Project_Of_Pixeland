using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project_of_Pixeland
{
    public partial class Form_ParlaklikKontrast : Form
    {
        Bitmap originImage;
        public Form_ParlaklikKontrast(Bitmap image)
        {
            InitializeComponent();
            originImage = image;
            pictureBox1.Image = image;
        }
        private void parlaklik_tbar_ValueChanged(object sender, EventArgs e)
        {
            parlaklikDegeri_lbl.Text = parlaklik_tbar.Value.ToString();
            Bitmap newImage = new Bitmap(originImage);
            pictureBox1.Image = parlaklikAyarla(newImage, parlaklik_tbar.Value);
        }
        private Bitmap parlaklikAyarla(Bitmap image, int brightnessValue)
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color originalColor = image.GetPixel(x, y);

                    int r = ParlaklikUygunDeger(originalColor.R + brightnessValue);
                    int g = ParlaklikUygunDeger(originalColor.G + brightnessValue);
                    int b = ParlaklikUygunDeger(originalColor.B + brightnessValue);

                    Color adjustedColor = Color.FromArgb(originalColor.A, r, g, b);
                    image.SetPixel(x, y, adjustedColor);
                }
            }
            return image;
        }
        private int ParlaklikUygunDeger(int value)
        {
            return Math.Max(0, Math.Min(value, 255));
        }
        private void kontrast_tbar_ValueChanged(object sender, EventArgs e)
        {
            kontrastDegeri_lbl.Text = kontrast_tbar.Value.ToString();
            Bitmap newImage = new Bitmap(originImage);
            pictureBox1.Image = kontrastAyarla(newImage, kontrast_tbar.Value);
        }
        private Bitmap kontrastAyarla(Bitmap newImage, float contrastValue)
        {
            if (contrastValue == 1)
            {
                return newImage;
            }
            else
            {
                for (int y = 0; y < originImage.Height; y++)
                {
                    for (int x = 0; x < originImage.Width; x++)
                    {
                        Color originalColor = originImage.GetPixel(x, y);

                        float adjustedRed = KontrastUygunDeger((originalColor.R / 255.0f - 0.5f) * contrastValue + 0.5f) * 255;
                        float adjustedGreen = KontrastUygunDeger((originalColor.G / 255.0f - 0.5f) * contrastValue + 0.5f) * 255;
                        float adjustedBlue = KontrastUygunDeger((originalColor.B / 255.0f - 0.5f) * contrastValue + 0.5f) * 255;

                        Color adjustedColor = Color.FromArgb((int)adjustedRed, (int)adjustedGreen, (int)adjustedBlue);
                        newImage.SetPixel(x, y, adjustedColor);
                    }
                }
                return newImage;
            }
        }
        private float KontrastUygunDeger(float value)
        {
            return Math.Max(0, Math.Min(1, value));
        }
        private void kaydet_btn_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(pictureBox1.Image);
            mainForm.Show();
            Close();
        }
        private void indir_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Resim Dosyaları|*.png;*.jpg;*.jpeg;*.gif;*.bmp";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string dosyaAdi = saveFileDialog.FileName;
                pictureBox1.Image.Save(dosyaAdi);
                MessageBox.Show("Görsel başarıyla indirildi! Elinize Sağlık", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void yeniGorsel_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;
                System.Drawing.Image image = System.Drawing.Image.FromFile(selectedImagePath);
                originImage = (Bitmap)image;
                Bitmap newImage = new Bitmap(originImage);
                pictureBox1.Image = newImage;
            }
        }
        private void iptal_btn_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(originImage);
            mainForm.Show();
            Close();
        }
        private void sifirla_btn_Click(object sender, EventArgs e)
        {
            parlaklik_tbar.Value = 0;
            kontrast_tbar.Value = 0;
            pictureBox1.Image = originImage;
        }

        private void parlaklik_tbar_Scroll(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project_of_Pixeland
{
    public partial class Form_AritmetikIslemler : Form
    {
        Bitmap originImage1;
        Bitmap originImage2;

        public Form_AritmetikIslemler(Bitmap image)
        {
            InitializeComponent();
            originImage1 = image;
            originImage2 = image;
            pictureBox1.Image = originImage1;
            pictureBox2.Image = originImage1;
        }
        private Color GetPixelSafe(Bitmap image, int x, int y)
        {
            if (x < 0 || x >= image.Width || y < 0 || y >= image.Height)
                return Color.Black; 

            return image.GetPixel(x, y);
        }
        private Bitmap AddImages(Bitmap image1, Bitmap image2)
        {
                int width = Math.Min(image1.Width, image2.Width);
                int height = Math.Min(image1.Height, image2.Height);

                Bitmap resultImage = new Bitmap(width, height);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color color1 = GetPixelSafe(image1, x, y);
                        Color color2 = GetPixelSafe(image2, x, y);

                        int r = Math.Min(color1.R + color2.R, 255);
                        int g = Math.Min(color1.G + color2.G, 255);
                        int b = Math.Min(color1.B + color2.B, 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
                return resultImage;
        }
        private void ekle_btn_Click(object sender, EventArgs e)
        {
            Bitmap resultImage = AddImages((Bitmap)originImage1, (Bitmap)originImage2);
            pictureBox3.Image = resultImage;
        }
        private Bitmap MultiplyImages(Bitmap image1, Bitmap image2)
        { 
                int width = Math.Min(image1.Width, image2.Width);
                int height = Math.Min(image1.Height, image2.Height);

                Bitmap resultImage = new Bitmap(width, height);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color color1 = image1.GetPixel(x, y);
                        Color color2 = image2.GetPixel(x, y);

                        int r = Math.Min(color1.R * color2.R / 255, 255);
                        int g = Math.Min(color1.G * color2.G / 255, 255);
                        int b = Math.Min(color1.B * color2.B / 255, 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
                return resultImage;
        }
        private void carp_btn_Click(object sender, EventArgs e)
        {
            Bitmap resultImage = MultiplyImages((Bitmap)originImage1, (Bitmap)originImage2);
            pictureBox3.Image = resultImage;
        }
        private void yeniGorsel1_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;
                System.Drawing.Image image = System.Drawing.Image.FromFile(selectedImagePath);
                originImage1 = (Bitmap)image;
                Bitmap newImage = new Bitmap(originImage1);
                pictureBox1.Image = newImage;
            }
        }
        private void yeniGorsel2_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;
                System.Drawing.Image image = System.Drawing.Image.FromFile(selectedImagePath);
                originImage2 = (Bitmap)image;
                Bitmap newImage = new Bitmap(originImage2);
                pictureBox2.Image = newImage;
            }
        }
        private void kaydet_btn_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Image == null)
            {
                MessageBox.Show("Kaydedilecek bir görsel bulunmamakta.");
            }
            else
            {
                MainForm mainForm = new MainForm(pictureBox3.Image);
                mainForm.Show();
                Close();
            }
        }
        private void indir_btn_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Image == null)
            {
                MessageBox.Show("İndirelecek bir görsel bulunmamakta.");
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Resim Dosyaları|.png;.jpg;.jpeg;.gif;*.bmp";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string dosyaAdi = saveFileDialog.FileName;
                    pictureBox3.Image.Save(dosyaAdi);
                    MessageBox.Show("Görsel başarıyla indirildi! Elinize Sağlık", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void iptal_btn_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(originImage1);
            mainForm.Show();
            Close();
        }
        private void sifirla_btn_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = null;
        }
    }
}
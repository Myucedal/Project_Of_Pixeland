using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Project_of_Pixeland
{
    public partial class Form_GurultuEkleKaldir : Form
    {
        Bitmap originImage;
        public Form_GurultuEkleKaldir(Bitmap image)
        {
            InitializeComponent();
            originImage = image;
            pictureBox1.Image = image;
        }
        private void kaldirMean_btn_Click(object sender, EventArgs e)
        {
            Bitmap filteredBitmap = ApplyMeanFilter((Bitmap)pictureBox1.Image);
            pictureBox1.Image = filteredBitmap;
        }
        private void kaldirMedian_btn_Click(object sender, EventArgs e)
        {
            Bitmap filteredBitmap = ApplyMedianFilter((Bitmap)pictureBox1.Image);
            pictureBox1.Image = filteredBitmap;
        }
        private void gurultu_tbar_Scroll(object sender, EventArgs e)
        {
            int gurultuDegeri = gurultu_tbar.Value;
            gurultuDegeri_lbl.Text = gurultuDegeri.ToString();
            pictureBox1.Image = AddNoiseToImage(originImage, gurultuDegeri);
        }
        private Bitmap AddNoiseToImage(Bitmap originalImage, int noiseLevel)
        {
            Random rnd = new Random();
            Bitmap noisyImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int i = 0; i < originalImage.Width; i++)
            {
                for (int j = 0; j < originalImage.Height; j++)
                {
                    Color originalColor = originalImage.GetPixel(i, j);

                    int r = originalColor.R + rnd.Next(-noiseLevel, noiseLevel + 1);
                    int g = originalColor.G + rnd.Next(-noiseLevel, noiseLevel + 1);
                    int b = originalColor.B + rnd.Next(-noiseLevel, noiseLevel + 1);

                    r = Math.Max(0, Math.Min(255, r));
                    g = Math.Max(0, Math.Min(255, g));
                    b = Math.Max(0, Math.Min(255, b));

                    Color noisyColor = Color.FromArgb(originalColor.A, r, g, b);
                    noisyImage.SetPixel(i, j, noisyColor);
                }
            }
            return noisyImage;
        }
        private Bitmap ApplyMeanFilter(Bitmap sourceBitmap)
        {
            int width = sourceBitmap.Width;
            int height = sourceBitmap.Height;
            Bitmap resultBitmap = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color[] neighborhoodPixels = GetNeighborhoodPixels(sourceBitmap, x, y);
                    Color averageColor = CalculateAverageColor(neighborhoodPixels);
                    resultBitmap.SetPixel(x, y, averageColor);
                }
            }

            return resultBitmap;
        }

        private Color[] GetNeighborhoodPixels(Bitmap bitmap, int x, int y)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            Color[] neighborhoodPixels = new Color[9]; // 3x3 kernel

            int index = 0;
            for (int offsetY = -1; offsetY <= 1; offsetY++)
            {
                for (int offsetX = -1; offsetX <= 1; offsetX++)
                {
                    int neighborX = x + offsetX;
                    int neighborY = y + offsetY;

                    if (neighborX >= 0 && neighborX < width && neighborY >= 0 && neighborY < height)
                    {
                        neighborhoodPixels[index++] = bitmap.GetPixel(neighborX, neighborY);
                    }
                }
            }

            return neighborhoodPixels;
        }

        private Color CalculateAverageColor(Color[] pixels)
        {
            int totalRed = 0, totalGreen = 0, totalBlue = 0;

            foreach (Color pixel in pixels)
            {
                totalRed += pixel.R;
                totalGreen += pixel.G;
                totalBlue += pixel.B;
            }

            int averageRed = totalRed / pixels.Length;
            int averageGreen = totalGreen / pixels.Length;
            int averageBlue = totalBlue / pixels.Length;

            return Color.FromArgb(averageRed, averageGreen, averageBlue);
        }
        private Bitmap ApplyMedianFilter(Bitmap sourceBitmap) // 3x3 filtre
        {
            int width = sourceBitmap.Width;
            int height = sourceBitmap.Height;

            Bitmap resultBitmap = new Bitmap(width, height);

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    Color[] pixelColors = new Color[9];
                    int k = 0;

                    for (int fy = -1; fy <= 1; fy++)
                    {
                        for (int fx = -1; fx <= 1; fx++)
                        {
                            pixelColors[k++] = sourceBitmap.GetPixel(x + fx, y + fy);
                        }
                    }

                    Array.Sort(pixelColors, (c1, c2) => (c1.R + c1.G + c1.B).CompareTo(c2.R + c2.G + c2.B));
                    Color medianColor = pixelColors[4];

                    resultBitmap.SetPixel(x, y, medianColor);
                }
            }
            return resultBitmap;
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
                Image image = Image.FromFile(selectedImagePath);
                originImage = (Bitmap)image;
                Bitmap newImage = new Bitmap(originImage);
                pictureBox1.Image = newImage;
            }
        }
        private void sifirla_btn_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = originImage;
            gurultu_tbar.Value = 0;
            gurultuDegeri_lbl.Text = "0";
        }
        private void iptal_btn_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(originImage);
            mainForm.Show();
            Close();
        }
    }
}
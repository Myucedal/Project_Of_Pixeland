using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Image = System.Drawing.Image;

namespace Project_of_Pixeland
{
    public partial class Form_HistogramIslemleri : Form
    {
        Bitmap originImage;
        public Form_HistogramIslemleri(Bitmap image)
        {
            InitializeComponent();
            originImage = image;
            pictureBox1.Image = originImage;
            renkliHistogram(image);
            griTon(image);
            griHistogram(image);
        }
        private void ger_btn_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = renkliGerme(originImage);
            pictureBox2.Image = griGerme(originImage);
            renkliHistogram((Bitmap)pictureBox1.Image);
            griHistogram((Bitmap)pictureBox2.Image);
        }
        public Bitmap griGerme(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;

            byte min = 255, max = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte pixelValue = image.GetPixel(x, y).R;
                    if (pixelValue < min) min = pixelValue;
                    if (pixelValue > max) max = pixelValue;
                }
            }

            Bitmap result = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte pixelValue = image.GetPixel(x, y).R;
                    byte newPixelValue = (byte)((pixelValue - min) * 255 / (max - min));
                    result.SetPixel(x, y, Color.FromArgb(newPixelValue, newPixelValue, newPixelValue));
                }
            }

            return result;
        }
        public Bitmap renkliGerme(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;

            byte minR = 255, maxR = 0;
            byte minG = 255, maxG = 0;
            byte minB = 255, maxB = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    if (pixelColor.R < minR) minR = pixelColor.R;
                    if (pixelColor.R > maxR) maxR = pixelColor.R;
                    if (pixelColor.G < minG) minG = pixelColor.G;
                    if (pixelColor.G > maxG) maxG = pixelColor.G;
                    if (pixelColor.B < minB) minB = pixelColor.B;
                    if (pixelColor.B > maxB) maxB = pixelColor.B;
                }
            }

            Bitmap result = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    byte newR = (byte)((pixelColor.R - minR) * 255 / (maxR - minR));
                    byte newG = (byte)((pixelColor.G - minG) * 255 / (maxG - minG));
                    byte newB = (byte)((pixelColor.B - minB) * 255 / (maxB - minB));
                    result.SetPixel(x, y, Color.FromArgb(newR, newG, newB));
                }
            }

            return result;
        }
        private void griTon(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap griTonlanmisImage = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int grayValue = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11); // Gri tonlama formülü
                    Color newPixel = Color.FromArgb(grayValue, grayValue, grayValue);
                    griTonlanmisImage.SetPixel(x, y, newPixel);
                }
            }
            pictureBox2.Image = griTonlanmisImage;
        }
        private void renkliHistogram(Bitmap image)
        {
            int[] histogramR = new int[256];
            int[] histogramG = new int[256];
            int[] histogramB = new int[256];

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color pixel = image.GetPixel(i, j);
                    histogramR[pixel.R]++;
                    histogramG[pixel.G]++;
                    histogramB[pixel.B]++;
                }
            }

            chart1.Series.Clear();

            Series seriesR = new Series("R");
            Series seriesG = new Series("G");
            Series seriesB = new Series("B");

            for (int i = 0; i < 256; i++)
            {
                seriesR.Points.AddXY(i, histogramR[i]);
                seriesG.Points.AddXY(i, histogramG[i]);
                seriesB.Points.AddXY(i, histogramB[i]);
            }

            chart1.Series.Add(seriesR);
            chart1.Series.Add(seriesG);
            chart1.Series.Add(seriesB);
            chart1.Invalidate();
        }
        private void griHistogram(Bitmap image)
        {
            int[] histogram = new int[256];

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color pixel = image.GetPixel(i, j);
                    int grayValue = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11); // Gri tonlama formülü
                    histogram[grayValue]++;
                }
            }

            chart2.Series.Clear();
            Series series = new Series("Gri Tonlama");
            for (int i = 0; i < 256; i++)
            {
                series.Points.AddXY(i, histogram[i]);
            }
            chart2.Series.Add(series);
            chart2.Invalidate();
        }
        private void kaydet_btn_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(pictureBox2.Image);
            mainForm.Show();
            Close();
        }
        private void indir_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Resim Dosyaları|.png;.jpg;.jpeg;.gif;*.bmp";
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
            openFileDialog.Filter = "Resim Dosyaları (.jpg;.jpeg;.png;.gif)|.jpg;.jpeg;.png;.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;
                Image image = Image.FromFile(selectedImagePath);
                originImage = (Bitmap)image;
                Bitmap newImage = new Bitmap(originImage);
                pictureBox1.Image = newImage;
                renkliHistogram(newImage);
                griTon(newImage);
                griHistogram(newImage);
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
            pictureBox1.Image = originImage;
            renkliHistogram(originImage);
            griTon(originImage);
            griHistogram(originImage);
        }
    }
}
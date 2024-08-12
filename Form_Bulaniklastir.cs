using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Project_of_Pixeland
{
    public partial class Form_Bulaniklastir : Form
    {
        Bitmap originImage;
        public Form_Bulaniklastir(Bitmap image)
        {
            InitializeComponent();
            originImage = image;
            pictureBox1.Image = image;
        }
        private void bulaniklik_tbar_ValueChanged(object sender, EventArgs e)
        {
            int bulaniklikDegeri = bulaniklik_tbar.Value;
            bulaniklikDegeri_lbl.Text = bulaniklikDegeri.ToString();
            if (bulaniklikDegeri == 0)
            {
                pictureBox1 .Image = originImage;
            }
            else
            {
                Bitmap bulanikResim = GaussBulaniklastir(originImage, bulaniklikDegeri);
                pictureBox1.Image = bulanikResim;
            }
        }
        private Bitmap GaussBulaniklastir(Bitmap image, int sigma)
        {
            int size = sigma * 2 + 1;
            double[,] kernel = CalculateGaussianKernel(sigma, size);
            Bitmap blurredImage = new Bitmap(image.Width, image.Height);

            BitmapData srcData = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            BitmapData dstData = blurredImage.LockBits(
                new Rectangle(0, 0, blurredImage.Width, blurredImage.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);

            int bytes = srcData.Stride * srcData.Height;
            byte[] pixelBuffer = new byte[bytes];
            byte[] resultBuffer = new byte[bytes];

            Marshal.Copy(srcData.Scan0, pixelBuffer, 0, bytes);
            image.UnlockBits(srcData);

            int filterOffset = (size - 1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY <
                image.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    image.Width - filterOffset; offsetX++)
                {
                    double blue = 0.0;
                    double green = 0.0;
                    double red = 0.0;

                    byteOffset = offsetY *
                                 srcData.Stride +
                                 offsetX * 3;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {

                            calcOffset = byteOffset +
                                         (filterX * 3) +
                                         (filterY * srcData.Stride);

                            blue += (double)(pixelBuffer[calcOffset]) *
                                    kernel[filterY + filterOffset,
                                           filterX + filterOffset];

                            green += (double)(pixelBuffer[calcOffset + 1]) *
                                     kernel[filterY + filterOffset,
                                            filterX + filterOffset];

                            red += (double)(pixelBuffer[calcOffset + 2]) *
                                   kernel[filterY + filterOffset,
                                          filterX + filterOffset];
                        }
                    }

                    resultBuffer[byteOffset] = ClipByte(blue);
                    resultBuffer[byteOffset + 1] = ClipByte(green);
                    resultBuffer[byteOffset + 2] = ClipByte(red);
                }
            }

            Marshal.Copy(resultBuffer, 0, dstData.Scan0, bytes);
            blurredImage.UnlockBits(dstData);

            return blurredImage;
        }

        private double[,] CalculateGaussianKernel(int sigma, int size)
        {
            double[,] kernel = new double[size, size];
            double kernelSum = 0;
            int foff = size / 2;
            double distance = 0;
            double calculatedEuler = 1.0 /
                (2.0 * Math.PI * Math.Pow(sigma, 2));

            for (int filterY = -foff;
                filterY <= foff; filterY++)
            {
                for (int filterX = -foff;
                    filterX <= foff; filterX++)
                {
                    distance = ((filterX * filterX) +
                                (filterY * filterY)) /
                               (2 * (sigma * sigma));

                    kernel[filterY + foff,
                           filterX + foff] = calculatedEuler *
                                             Math.Exp(-distance);

                    kernelSum += kernel[filterY + foff,
                                        filterX + foff];
                }
            }

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    kernel[y, x] = kernel[y, x] *
                                   (1.0 / kernelSum);
                }
            }

            return kernel;
        }

        private byte ClipByte(double color)
        {
            return (byte)Math.Max(Math.Min(color, 255), 0);
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
            bulaniklik_tbar.Value = 0;
            pictureBox1.Image = originImage;
        }
        private void iptal_btn_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(originImage);
            mainForm.Show();
            Close();
        }
    }
}
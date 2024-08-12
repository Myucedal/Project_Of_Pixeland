using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project_of_Pixeland
{
    public partial class Form_RenkDonusumu : Form
    {
        private Bitmap originImage;
        public Form_RenkDonusumu(Bitmap image)
        {
            InitializeComponent();
            originImage = image;
            pictureBox1.Image = originImage;
        }
        private void donustur_btn_Click(object sender, EventArgs e)
        {
            string selectedTransformation = comboBox1.Text;
            switch (selectedTransformation)
            {
                case "HSV":

                    int width = originImage.Width;
                    int height = originImage.Height;

                    Color[,] hsvImage = new Color[width, height];

                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            Color rgbColor = originImage.GetPixel(x, y);
                            double r = rgbColor.R / 255.0;
                            double g = rgbColor.G / 255.0;
                            double b = rgbColor.B / 255.0;

                            double cmax = Math.Max(r, Math.Max(g, b));
                            double cmin = Math.Min(r, Math.Min(g, b));
                            double delta = cmax - cmin;

                            double h = 0;
                            if (delta == 0)
                                h = 0;
                            else if (cmax == r)
                                h = 60 * (((g - b) / delta) % 6);
                            else if (cmax == g)
                                h = 60 * (((b - r) / delta) + 2);
                            else
                                h = 60 * (((r - g) / delta) + 4);

                            double s = (cmax == 0) ? 0 : (delta / cmax);
                            double v = cmax;
                            hsvImage[x, y] = Color.FromArgb((int)Math.Max(0, Math.Min((h / 360) * 255, 255)), (int)Math.Max(0, Math.Min(s * 255, 255)), (int)Math.Max(0, Math.Min(v * 255, 255)));
                        }
                    }
                    ShowHSVImage(hsvImage);
                    break;

                case "CMYK":

                    int width2 = originImage.Width;
                    int height2 = originImage.Height;

                    Bitmap newImage2 = new Bitmap(width2, height2);

                    for (int y = 0; y < height2; y++)
                    {
                        for (int x = 0; x < width2; x++)
                        {
                            Color pixelColor = originImage.GetPixel(x, y);
                            int red = pixelColor.R;
                            int green = pixelColor.G;
                            int blue = pixelColor.B;

                            double C = 1 - (red / 255.0);
                            double M = 1 - (green / 255.0);
                            double Y = 1 - (blue / 255.0);
                            double K = Math.Min(C, Math.Min(M, Y));

                            C = Math.Max(0, C - K);
                            M = Math.Max(0, M - K);
                            Y = Math.Max(0, Y - K);

                            Color newPixelColor = Color.FromArgb((int)(255 * C), (int)(255 * M), (int)(255 * Y), (int)(255 * K));

                            newImage2.SetPixel(x, y, newPixelColor);
                        }
                    }
                    pictureBox1.Image = newImage2;
                    break;

                case "Lab":
                    if (pictureBox1.Image != null)
                    {
                        Bitmap originalBitmap = new Bitmap(pictureBox1.Image);
                        Bitmap labBitmap = ConvertRGBToLab(originalBitmap);
                        pictureBox1.Image = labBitmap;
                    }
                    else
                    {
                        MessageBox.Show("Lütfen bir görüntü yükleyin.");
                    }
                    break;

                case "XYZ":
                    if (pictureBox1.Image != null)
                    {

                        int en1 = originImage.Width;
                        int boy1 = originImage.Height;

                        Bitmap newImage1 = new Bitmap(en1, boy1);

                        for (int y = 0; y < boy1; y++)
                        {
                            for (int x = 0; x < en1; x++)
                            {
                                Color pixelColor = originImage.GetPixel(x, y);
                                int red = pixelColor.R;
                                int green = pixelColor.G;
                                int blue = pixelColor.B;

                                double X = 0.65625 * red + 0.0722 * green + 0.00655 * blue;
                                double Y = 0.25543 * red + 0.7152 * green + 0.03622 * blue;
                                double Z = 0.0036 * red + 0.0707 * green + 0.9257 * blue;

                                double clampedY = Math.Min(255, Y);

                                Color newPixelColor = Color.FromArgb((int)X, (int)clampedY, (int)Z);

                                newImage1.SetPixel(x, y, newPixelColor);
                            }
                        }

                        pictureBox1.Image = newImage1;
                    }
                    else
                    {
                        MessageBox.Show("Lütfen bir görüntü yükleyin.");
                    }
                    break;
                case "YCbCr":

                    int en = originImage.Width;
                    int boy = originImage.Height;

                    Bitmap newImage = new Bitmap(en, boy);

                    for (int y = 0; y < boy; y++)
                    {
                        for (int x = 0; x < en; x++)
                        {
                            Color pixelColor = originImage.GetPixel(x, y);
                            int red = pixelColor.R;
                            int green = pixelColor.G;
                            int blue = pixelColor.B;

                            double Y = 0.299 * red + 0.587 * green + 0.114 * blue;
                            double Cb = 0.564 * (blue - Y);
                            double Cr = 0.715 * (red - Y);

                            Y = Math.Max(0, Math.Min(255, Y));
                            Cb = Math.Max(0, Math.Min(255, Cb));
                            Cr = Math.Max(0, Math.Min(255, Cr));

                            Color newPixelColor = Color.FromArgb((int)Y, (int)Cb, (int)Cr);

                            newImage.SetPixel(x, y, newPixelColor);
                        }
                    }

                    pictureBox1.Image = newImage;
                    break;
                default:
                    MessageBox.Show("Lütfen bir dönüşüm türü seçin.");
                    break;
            }

        }
        public void ShowHSVImage(Color[,] image)
        {
            int width = image.GetLength(0);
            int height = image.GetLength(1);
            Bitmap bitmap = new Bitmap(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    bitmap.SetPixel(x, y, image[x, y]);
                }
            }

            pictureBox1.Image = bitmap;

        }
        private Bitmap ConvertRGBToLab(Bitmap bmp)
        {
            Bitmap labBitmap = new Bitmap(bmp.Width, bmp.Height);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color color = bmp.GetPixel(x, y);
                    LabColor labColor = RgbToLab(color);
                    labBitmap.SetPixel(x, y, labColor.ToColor());
                }
            }

            return labBitmap;
        }
        public class LabColor
        {
            public double L { get; }
            public double A { get; }
            public double B { get; }

            public LabColor(double l, double a, double b)
            {
                L = l;
                A = a;
                B = b;
            }

            public Color ToColor()
            {
                int l = (int)(L / 100.0 * 255);
                int a = (int)((A + 128) / 256.0 * 255);
                int b = (int)((B + 128) / 256.0 * 255);
                return Color.FromArgb(255, l, a, b);
            }
        }
        private LabColor RgbToLab(Color color)
        {
            double r = color.R / 255.0;
            double g = color.G / 255.0;
            double b = color.B / 255.0;

            r = (r > 0.04045) ? Math.Pow((r + 0.055) / 1.055, 2.4) : r / 12.92;
            g = (g > 0.04045) ? Math.Pow((g + 0.055) / 1.055, 2.4) : g / 12.92;
            b = (b > 0.04045) ? Math.Pow((b + 0.055) / 1.055, 2.4) : b / 12.92;

            double x = r * 0.4124 + g * 0.3576 + b * 0.1805;
            double y = r * 0.2126 + g * 0.7152 + b * 0.0722;
            double z = r * 0.0193 + g * 0.1192 + b * 0.9505;

            x /= 0.95047;
            y /= 1.00000;
            z /= 1.08883;

            x = (x > 0.008856) ? Math.Pow(x, 1.0 / 3.0) : (7.787 * x) + (16.0 / 116.0);
            y = (y > 0.008856) ? Math.Pow(y, 1.0 / 3.0) : (7.787 * y) + (16.0 / 116.0);
            z = (z > 0.008856) ? Math.Pow(z, 1.0 / 3.0) : (7.787 * z) + (16.0 / 116.0);

            double l = (116.0 * y) - 16.0;
            double a = 500.0 * (x - y);
            double b1 = 200.0 * (y - z);

            return new LabColor(l, a, b1);
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
        private void iptal_btn_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(originImage);
            mainForm.Show();
            Close();
        }
        private void sifirla_btn_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = originImage;
        }
    }
}
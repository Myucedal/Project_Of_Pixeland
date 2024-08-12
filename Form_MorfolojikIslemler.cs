using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project_of_Pixeland
{
    public partial class Form_MorfolojikIslemler : Form
    {
        Bitmap originImage;
        public Form_MorfolojikIslemler(Bitmap image)
        {
            InitializeComponent();
            originImage = image;
            pictureBox1.Image = image;
        }
        private Bitmap ApplyErosion(Bitmap image)
        {
            Bitmap bwImage = ToBlackAndWhite(image);

            Bitmap erodedImage = new Bitmap(image.Width, image.Height);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    bool isBlack = ErodePixel(bwImage, x, y);
                    Color newColor = isBlack ? Color.Black : Color.White;
                    erodedImage.SetPixel(x, y, newColor);
                }
            }
            return erodedImage;
        }
        private Bitmap ToBlackAndWhite(Bitmap image)
        {
            Bitmap bwImage = new Bitmap(image.Width, image.Height);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color color = image.GetPixel(x, y);
                    int intensity = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    Color newColor = intensity < 128 ? Color.Black : Color.White;
                    bwImage.SetPixel(x, y, newColor);
                }
            }
            return bwImage;
        }

        private bool ErodePixel(Bitmap image, int x, int y)
        {
            int structuringElementSize = 3;

            for (int i = -structuringElementSize / 2; i <= structuringElementSize / 2; i++)
            {
                for (int j = -structuringElementSize / 2; j <= structuringElementSize / 2; j++)
                {
                    int neighborX = x + i;
                    int neighborY = y + j;

                    if (neighborX < 0 || neighborX >= image.Width || neighborY < 0 || neighborY >= image.Height)
                    {
                        continue;
                    }
                    if (image.GetPixel(neighborX, neighborY).ToArgb() == Color.Black.ToArgb())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private Bitmap Genisleme(Bitmap inputImage, int structuringElementSize)
        {
            inputImage = ToBlackAndWhite(inputImage);
            Bitmap outputImage = new Bitmap(inputImage.Width, inputImage.Height);

            int seSize = structuringElementSize;
            int seOffset = (seSize - 1) / 2;

            for (int x = seOffset; x < inputImage.Width - seOffset; x++)
            {
                for (int y = seOffset; y < inputImage.Height - seOffset; y++)
                {
                    bool flag = true;
                    for (int i = -seOffset; i <= seOffset; i++)
                    {
                        for (int j = -seOffset; j <= seOffset; j++)
                        {
                            if (inputImage.GetPixel(x + i, y + j).R != 0)
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            break;
                        }
                    }
                    outputImage.SetPixel(x, y, flag ? Color.FromArgb(0, 0, 0) : Color.FromArgb(255, 255, 255));
                }
            }

            return outputImage;
        }
        private void genisleme_btn_Click(object sender, EventArgs e)
        {
            Bitmap inputImage = new Bitmap(pictureBox1.Image);
            Bitmap outputImage = Genisleme(inputImage, 3);
            pictureBox1.Image = outputImage;
        }
        private void asinma_btn_Click(object sender, EventArgs e)
        {
            Bitmap originalImage = new Bitmap(pictureBox1.Image);
            pictureBox1.Image = originalImage;

            Bitmap erodedImage = ApplyErosion(originalImage);
            pictureBox1.Image = erodedImage;
        }
        private void acma_btn_Click(object sender, EventArgs e)
        {
            Bitmap resim1 = new Bitmap(pictureBox1.Image);
            Bitmap erozyon = ApplyErosion(resim1);
            Bitmap resim2 = Genisleme(erozyon, 3);
            pictureBox1.Image = resim2;
        }
        private void kapama_btn_Click(object sender, EventArgs e)
        {
            Bitmap resim1 = new Bitmap(pictureBox1.Image);
            Bitmap genisleme = Genisleme(resim1, 3);
            Bitmap resim2 = ApplyErosion(genisleme);
            pictureBox1.Image = resim2;
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
        private void sifirla_btn_Click(object sender, EventArgs e)
        {
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
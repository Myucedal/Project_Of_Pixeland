using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Project_of_Pixeland
{
    public partial class MainForm : Form
    {
        System.Drawing.Image originImage;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragPictureBoxPoint;
        private Point zoomCenter;
        private float zoomFactor = 1.1f;
        public MainForm(System.Drawing.Image image)
        {
            InitializeComponent();
            pictureBox1.Image = image;
            originImage = image;
            this.MouseWheel += new MouseEventHandler(MouseWheelZoom);
        }
        private void MouseWheelZoom(object sender, MouseEventArgs e)
        {
            zoomCenter = e.Location;
            if (e.Delta > 0)
            {
                ZoomIn(zoomCenter);
            }
            else if (e.Delta < 0)
            {
                ZoomOut(zoomCenter);
            }
        }
        private void ZoomIn(Point zoomCenter)
        {
            int newWidth = (int)(pictureBox1.Width * zoomFactor);
            int newHeight = (int)(pictureBox1.Height * zoomFactor);

            int newX = pictureBox1.Left - (int)((zoomCenter.X - pictureBox1.Left) * (zoomFactor - 1));
            int newY = pictureBox1.Top - (int)((zoomCenter.Y - pictureBox1.Top) * (zoomFactor - 1));

            pictureBox1.Size = new Size(newWidth, newHeight);
            pictureBox1.Location = new Point(newX, newY);
        }

        private void ZoomOut(Point zoomCenter)
        {
            int newWidth = (int)(pictureBox1.Width / zoomFactor);
            int newHeight = (int)(pictureBox1.Height / zoomFactor);

            int newX = pictureBox1.Left + (int)((zoomCenter.X - pictureBox1.Left) * (1 - 1 / zoomFactor));
            int newY = pictureBox1.Top + (int)((zoomCenter.Y - pictureBox1.Top) * (1 - 1 / zoomFactor));

            pictureBox1.Size = new Size(newWidth, newHeight);
            pictureBox1.Location = new Point(newX, newY);
        }
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragPictureBoxPoint = pictureBox1.Location;
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            zoomCenter = e.Location;

            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                pictureBox1.Location = Point.Add(dragPictureBoxPoint, new Size(diff));
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        private void griTonlama_btn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    int griTon = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    Color yeniRenk = Color.FromArgb(griTon, griTon, griTon);
                    bmp.SetPixel(x, y, yeniRenk);
                }
            }
            pictureBox1.Image = bmp;
            Cursor = Cursors.Default;
        }
        private void siyahbeyaz_btn_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Form_SiyahBeyaz form_SiyahBeyaz = new Form_SiyahBeyaz(bmp);
            form_SiyahBeyaz.Show();
            Hide();
        }
        private void kirp_btn_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Form_Kirpma form_Kirpma = new Form_Kirpma(bmp);
            form_Kirpma.Show();
            Hide();
        }
        private void dondur_btn_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Form_Dondurme form_Dondur = new Form_Dondurme(bmp);
            form_Dondur.Show();
            Hide();
        }
        private void renkleriDonustur_btn_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Form_RenkDonusumu form_renkDonusum = new Form_RenkDonusumu(bmp);
            form_renkDonusum.Show();
            Hide();
        }
        private void histogramIslemleri_btn_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Form_HistogramIslemleri form_histogramIslemleri = new Form_HistogramIslemleri(bmp);
            form_histogramIslemleri.Show();
            Hide();
        }
        private void aritmetikIslemler_btn_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Form_AritmetikIslemler form_AritmetikIslemler = new Form_AritmetikIslemler(bmp);
            form_AritmetikIslemler.Show();
            Hide();
        }
        private void parlaklikKontrast_btn_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Form_ParlaklikKontrast form_ParlaklikKontrast = new Form_ParlaklikKontrast(bmp);
            form_ParlaklikKontrast.Show();
            Hide();
        }
        private void bulaniklastir_btn_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Form_Bulaniklastir form_Bulaniklastir = new Form_Bulaniklastir(bmp);
            form_Bulaniklastir.Show();
            Hide();
        }
        private void kenarBulma_btn_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            for (int i = 0; i < image.Height - 1; i++)
            {
                for (int j = 0; j < image.Width - 1; j++)
                {
                    int deger = (image.GetPixel(j, i).R + image.GetPixel(j, i).G + image.GetPixel(j, i).B) / 3;
                    Color yeniRenk = Color.FromArgb(deger, deger, deger);

                    image.SetPixel(j, i, yeniRenk);
                }
            }
            Bitmap gri = image;
            Bitmap buffer = new Bitmap(gri.Width, gri.Height);
            Color renk;
            int valx, valy, gradient;
            int[,] GX = new int[3, 3];
            int[,] GY = new int[3, 3];
            GX[0, 0] = -1; GX[0, 1] = 0; GX[0, 2] = 1;
            GX[1, 0] = -2; GX[1, 1] = 0; GX[1, 2] = 2;
            GX[2, 0] = -1; GX[2, 1] = 0; GX[2, 2] = 1;

            GY[0, 0] = -1; GY[0, 1] = -2; GY[0, 2] = -1;
            GY[1, 0] = 0; GY[1, 1] = 0; GY[1, 2] = 0;
            GY[2, 0] = 1; GY[2, 1] = 2; GY[2, 2] = 1;

            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    if (i == 0 || i == gri.Height - 1 || j == 0 || j == gri.Width - 1)
                    {
                        renk = Color.FromArgb(255, 255, 255);
                        buffer.SetPixel(j, i, renk);
                        valx = 0;
                        valy = 0;
                    }
                    else
                    {
                        valx = gri.GetPixel(j - 1, i - 1).R * GX[0, 0]
                            + gri.GetPixel(j, i - 1).R * GX[0, 1]
                            + gri.GetPixel(j + 1, i - 1).R * GX[0, 2]
                            + gri.GetPixel(j - 1, i).R * GX[1, 0]
                            + gri.GetPixel(j, i).R * GX[1, 1]
                            + gri.GetPixel(j + 1, i).R * GX[1, 2]
                            + gri.GetPixel(j - 1, i + 1).R * GX[2, 0]
                            + gri.GetPixel(j, i + 1).R * GX[2, 1]
                            + gri.GetPixel(j + 1, i + 1).R * GX[2, 2];

                        valy = gri.GetPixel(j - 1, i - 1).R * GY[0, 0]
                             + gri.GetPixel(j, i - 1).R * GY[0, 1]
                             + gri.GetPixel(j + 1, i - 1).R * GY[0, 2]
                             + gri.GetPixel(j - 1, i).R * GY[1, 0]
                             + gri.GetPixel(j, i).R * GY[1, 1]
                             + gri.GetPixel(j + 1, i).R * GY[1, 2]
                             + gri.GetPixel(j - 1, i + 1).R * GY[2, 0]
                             + gri.GetPixel(j, i + 1).R * GY[2, 1]
                             + gri.GetPixel(j + 1, i + 1).R * GY[2, 2];

                        gradient = (int)(Math.Abs(valx) + Math.Abs(valy));

                        if (gradient < 0)
                            gradient = 0;
                        if (gradient > 255)
                            gradient = 255;

                        renk = Color.FromArgb(gradient, gradient, gradient);
                        buffer.SetPixel(j, i, renk);
                    }
                }
            }
            Bitmap sobel = buffer;
            pictureBox1.Image = sobel;
        }
        private void gurultuEkleKaldir_btn_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Form_GurultuEkleKaldir form_GurultuEkleKaldir = new Form_GurultuEkleKaldir(bmp);
            form_GurultuEkleKaldir.Show();
            Hide();
        }
        private void morfolojikIslemler_btn_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Form_MorfolojikIslemler form_MorfolojikIslemler = new Form_MorfolojikIslemler(bmp);
            form_MorfolojikIslemler.Show();
            Hide();
        }
        private void yeniGorsel_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;
                pictureBox1.Image = System.Drawing.Image.FromFile(selectedImagePath);
                originImage = pictureBox1.Image;
            }
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
        private void sifirla_btn_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = originImage;
        }
        private void iptal_btn_Click(object sender, EventArgs e)
        {
            Hide();
            EntryForm entryForm = new EntryForm();
            entryForm.Show();
        }
        private void kirp_btn_MouseEnter(object sender, EventArgs e)
        {
            label1.Visible = true;
        }

        private void kirp_btn_MouseLeave(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void dondur_btn_MouseEnter(object sender, EventArgs e)
        {
            label7.Visible = true;
        }

        private void dondur_btn_MouseLeave(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void griTonlama_btn_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void griTonlama_btn_MouseEnter(object sender, EventArgs e)
        {
            label2.Visible = true;
        }

        private void siyahbeyaz_btn_MouseEnter(object sender, EventArgs e)
        {
            label3.Visible = true;
        }

        private void siyahbeyaz_btn_MouseLeave(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void parlaklikKontrast_btn_MouseEnter(object sender, EventArgs e)
        {
            label8.Visible = true;
        }

        private void parlaklikKontrast_btn_MouseLeave(object sender, EventArgs e)
        {
            label8.Visible = false;
        }

        private void bulaniklastir_btn_MouseLeave(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void bulaniklastir_btn_MouseEnter(object sender, EventArgs e)
        {
            label4.Visible = true;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            label5.Visible = true;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void morfolojikIslemler_btn_MouseLeave(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void morfolojikIslemler_btn_MouseEnter(object sender, EventArgs e)
        {
            label9.Visible = true;
        }

        private void aritmetikIslemler_btn_MouseEnter(object sender, EventArgs e)
        {
            label10.Visible = true;
        }

        private void aritmetikIslemler_btn_MouseLeave(object sender, EventArgs e)
        {
            label10.Visible = false;
        }

        private void histogramIslemleri_btn_MouseLeave(object sender, EventArgs e)
        {
            label6.Visible = false;
        }

        private void histogramIslemleri_btn_MouseEnter(object sender, EventArgs e)
        {
            label6.Visible = true;
        }

        private void kenarBulma_btn_MouseEnter(object sender, EventArgs e)
        {
            label11.Visible = true;
        }

        private void kenarBulma_btn_MouseLeave(object sender, EventArgs e)
        {
            label11.Visible = false;
        }

        private void gurultuEkleKaldir_btn_MouseEnter(object sender, EventArgs e)
        {
            label12.Visible = true;
        }

        private void gurultuEkleKaldir_btn_MouseLeave(object sender, EventArgs e)
        {
            label12.Visible = false;
        }

        private void kapat_btn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void asagiAl_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

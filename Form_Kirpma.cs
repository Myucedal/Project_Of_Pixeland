using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Project_of_Pixeland
{
    public partial class Form_Kirpma : Form
    {
        Bitmap originImage;
        private Bitmap croppedImage;
        private Point startPoint;
        private Rectangle selectionRectangle;
        private bool isSelecting = false;
        Bitmap mask;

        public Form_Kirpma(Bitmap image)
        {
            InitializeComponent();
            originImage = image;
            pictureBox_kirpma.Image = image;
        }

        private void pictureBox_kirpma_MouseDown(object sender, MouseEventArgs e)
        {
            selectionRectangle = Rectangle.Empty;
            startPoint = e.Location;
            isSelecting = true;
        }

        private void pictureBox_kirpma_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSelecting)
            {
                int x = Math.Min(startPoint.X, e.X);
                int y = Math.Min(startPoint.Y, e.Y);
                int width = Math.Abs(startPoint.X - e.X);
                int height = Math.Abs(startPoint.Y - e.Y);

                selectionRectangle = new Rectangle(x, y, width, height);

                pictureBox_kirpma.Refresh();
            }
        }

        private void pictureBox_kirpma_MouseUp(object sender, MouseEventArgs e)
        {
            isSelecting = false;

            Rectangle iR = ImageArea(pictureBox_kirpma);
            selectionRectangle = new Rectangle(startPoint.X - iR.X, startPoint.Y - iR.Y,
                                 e.X - startPoint.X, e.Y - startPoint.Y);
            Rectangle rectSrc = Scaled(selectionRectangle, pictureBox_kirpma, true);
            Rectangle rectDest = new Rectangle(Point.Empty, rectSrc.Size);

            croppedImage = new Bitmap(rectDest.Width, rectDest.Height);
            using (Graphics g = Graphics.FromImage(croppedImage))
            {
                g.DrawImage(pictureBox_kirpma.Image, rectDest, rectSrc, GraphicsUnit.Pixel);
            }
        }
        private void pictureBox_kirpma_Paint(object sender, PaintEventArgs e)
        {
            if (isSelecting)
            {
                using (Pen pen = new Pen(Color.Red, 3))
                {
                    e.Graphics.DrawRectangle(pen, selectionRectangle);
                }
                using (Pen pen = new Pen(Color.White, 2))
                {
                    e.Graphics.DrawRectangle(pen, selectionRectangle);
                }
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    e.Graphics.DrawRectangle(pen, selectionRectangle);
                }
            }
        }

        private void kirp_btn_Click(object sender, EventArgs e)
        {
            if (!selectionRectangle.IsEmpty)
            {
                pictureBox_kirpma.Image = croppedImage;
            }
            else
            {
                MessageBox.Show("Lütfen önce bir alan seçin.");
            }
        }
        Rectangle ImageArea(PictureBox pbox)
        {
            Size si = pbox.Image.Size;
            Size sp = pbox.ClientSize;

            if (pbox.SizeMode == PictureBoxSizeMode.StretchImage)
                return pbox.ClientRectangle;
            if (pbox.SizeMode == PictureBoxSizeMode.Normal ||
                pbox.SizeMode == PictureBoxSizeMode.AutoSize)
                return new Rectangle(Point.Empty, si);
            if (pbox.SizeMode == PictureBoxSizeMode.CenterImage)
                return new Rectangle(new Point((sp.Width - si.Width) / 2,
                                    (sp.Height - si.Height) / 2), si);

            float ri = 1f * si.Width / si.Height;
            float rp = 1f * sp.Width / sp.Height;
            if (rp > ri)
            {
                int width = si.Width * sp.Height / si.Height;
                int left = (sp.Width - width) / 2;
                return new Rectangle(left, 0, width, sp.Height);
            }
            else
            {
                int height = si.Height * sp.Width / si.Width;
                int top = (sp.Height - height) / 2;
                return new Rectangle(0, top, sp.Width, height);
            }
        }
        Rectangle Scaled(Rectangle rect, PictureBox pbox, bool scale)
        {
            float factor = GetFactor(pbox);
            if (!scale) factor = 1f / factor;
            return Rectangle.Round(new RectangleF(rect.X * factor, rect.Y * factor,
                                       rect.Width * factor, rect.Height * factor));
        }
        float GetFactor(PictureBox pBox)
        {
            if (pBox.Image == null) return 0;
            Size si = pBox.Image.Size;
            Size sp = pBox.ClientSize;
            float ri = 1f * si.Width / si.Height;
            float rp = 1f * sp.Width / sp.Height;
            float factor = 1f * pBox.Image.Width / pBox.ClientSize.Width;
            if (rp > ri) factor = 1f * pBox.Image.Height / pBox.ClientSize.Height;
            return factor;
        }
        private void kaydet_btn_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(pictureBox_kirpma.Image);
            mainForm.Show();
            this.Close();
        }
        private void indir_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Resim Dosyaları|*.png;*.jpg;*.jpeg;*.gif;*.bmp";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string dosyaAdi = saveFileDialog.FileName;
                pictureBox_kirpma.Image.Save(dosyaAdi);
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
                pictureBox_kirpma.Image = newImage;
            }
        }
        private void iptal_btn_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(originImage);
            mainForm.Show();
            this.Close();
        }
        private void sifirla_btn_Click(object sender, EventArgs e)
        {
            pictureBox_kirpma.Image = originImage;
            selectionRectangle = Rectangle.Empty;
        }
    }
}

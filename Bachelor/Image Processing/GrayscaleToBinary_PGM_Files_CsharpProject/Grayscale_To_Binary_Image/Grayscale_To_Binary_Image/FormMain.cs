namespace Grayscale_To_Binary_Image
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    public partial class FormMain : Form
    {
        private string inputFileName;
        private string outputFileName;
        private PgmImage pgmOriginalImage;

        public FormMain()
        {
            InitializeComponent();
        }

        public Bitmap PgmToBitmap(PgmImage pgmImage)
        {
            if (pgmImage != null && pgmImage.MagicNumber == "P2")
            {
                int width = pgmImage.Width;
                int height = pgmImage.Height;
                Bitmap result = new Bitmap(width, height);

                Graphics gr = Graphics.FromImage(result);

                int pixel = 0;
                for (int i = 0; i < pgmImage.Height; ++i)
                {
                    for (int j = 0; j < pgmImage.Width; ++j)
                    {
                        int pixelColor = pgmImage.Data[pixel++];
                        Color c = Color.FromArgb(pixelColor, pixelColor, pixelColor);
                        SolidBrush sb = new SolidBrush(c);
                        gr.FillRectangle(sb, j, i, 1, 1);
                    }
                }

                return result;
            }
            return null;
        }

        public PgmImage BitmapToPgm(Bitmap monoBmpImage, string magicNumber)
        {
            if (monoBmpImage != null)
            {
                PgmImage result = new PgmImage(monoBmpImage.Width, monoBmpImage.Height, magicNumber, null, 255);
                int pixel = 0;
                for (int i = 0; i < monoBmpImage.Height; ++i)
                {
                    for (int j = 0; j < monoBmpImage.Width; ++j)
                    {
                        // the image is monochromatic
                        result.Data[pixel++] = monoBmpImage.GetPixel(j, i).R;
                    }
                }

                return result;
            }

            return null;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = openFileDialog1.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                try {
                    pgmOriginalImage = new PgmImage(openFileDialog1.FileName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                pictureBoxOriginalImage.Image = PgmToBitmap(pgmOriginalImage);

                if (pictureBoxOriginalImage.Image != null)
                {
                    inputFileName = openFileDialog1.FileName;

                    trackBarThreshold.Maximum = pgmOriginalImage.MaxVal;
                    trackBarThreshold.Value = trackBarThreshold.Minimum;
                    trackBarThreshold.Enabled = true;

                    outputFileName = null;
                    pictureBoxResultImage.Visible = true;
                    pictureBoxResultImage.Image = null;                  

                    labelMagicNumber.Text = "Magic Number: " + pgmOriginalImage.MagicNumber;
                    labelWidth.Text = "Width: " + pgmOriginalImage.Width + " px";
                    labelHieght.Text = "Height: " + pgmOriginalImage.Height + " px";
                    labelMaxVal.Text = "Maximum Gray Value: " + pgmOriginalImage.MaxVal;
                }
                else
                {
                    inputFileName = null;
                    outputFileName = null;
                    pictureBoxResultImage.Visible = false;                  

                    pictureBoxOriginalImage.Image = pictureBoxOriginalImage.ErrorImage;
                    trackBarThreshold.Value = trackBarThreshold.Minimum;
                    trackBarThreshold.Enabled = false;

                    labelMagicNumber.Text = "Magic Number:";
                    labelWidth.Text = "Width:";
                    labelHieght.Text = "Height:";
                    labelMaxVal.Text = "Maximum Gray Value:";
                    labelThreshold.Text = "Threshold:";
                }
            }
        }

        private void trackBarThreshold_ValueChanged(object sender, EventArgs e)
        {
            labelThreshold.Text = "Threshold: " + trackBarThreshold.Value;

            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetThreshold((float)trackBarThreshold.Value);

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(pictureBoxOriginalImage.Image);
            Graphics g = System.Drawing.Graphics.FromImage(bmp);
            g.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0,
                                bmp.Width, bmp.Height, GraphicsUnit.Pixel, imageAttr);
            pictureBoxResultImage.Image = bmp;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.outputFileName))
            {
                saveAsToolStripMenuItem.PerformClick();
            }
            else
            {
                try
                {
                    BitmapToPgm((Bitmap)pictureBoxResultImage.Image, pgmOriginalImage.MagicNumber).Save(outputFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = saveFileDialog1.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                outputFileName = saveFileDialog1.FileName;
                try
                {
                    BitmapToPgm((Bitmap)pictureBoxResultImage.Image, pgmOriginalImage.MagicNumber).Save(outputFileName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

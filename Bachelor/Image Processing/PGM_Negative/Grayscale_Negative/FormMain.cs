namespace Grayscale_Negative
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class FormMain : Form
    {
        private string inputFileName;
        private string outputFileName;
        private PgmImage pgmOriginalImage, negativePgm;
        private const int maxValue = 255; // PGM MaxValue ???;

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

        public PgmImage Negative(PgmImage img, ImagePart imgPart)
        {
            if (img != null)
            {      
                PgmImage result = new PgmImage(img.Width, img.Height, img.MagicNumber, null, img.MaxVal);
                Array.Copy(img.Data, result.Data, img.Data.Length);

                switch (imgPart)
                {
                    case ImagePart.Full:
                        for (int i = 0; i < img.Data.Length; i++)
                        {
                            result.Data[i] = (byte)(maxValue - result.Data[i]);
                        }
                        break;
                    case ImagePart.Right:
                        for (int i = img.Width / 2; i < img.Data.Length; i += img.Width)
                        {
                            int innerLen = (img.Width / 2) + i;
                            for (int j = i; j < innerLen; j++)
                            {
                                result.Data[j] = (byte)(maxValue - result.Data[j]);
                            }
                        }
                        break;
                    case ImagePart.Left:
                        for (int i = 0; i < img.Data.Length; i += img.Width)
                        {
                            int innerLen = (img.Width / 2) + i;
                            for (int j = i; j < innerLen; j++)
                            {
                                result.Data[j] = (byte)(maxValue - result.Data[j]);
                            }
                        }
                        break;
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

                    tableLayoutPanelEffect.Enabled = true;

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

                    tableLayoutPanelEffect.Enabled = false;

                    labelMagicNumber.Text = "Magic Number:";
                    labelWidth.Text = "Width:";
                    labelHieght.Text = "Height:";
                    labelMaxVal.Text = "Maximum Gray Value:";
                    labelThreshold.Text = "Threshold:";
                }
            }
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
                   negativePgm.Save(outputFileName);
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
                    negativePgm.Save(outputFileName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void radioButtonLeft_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            negativePgm = Negative(pgmOriginalImage, ImagePart.Left);
            pictureBoxResultImage.Image = PgmToBitmap(negativePgm);

            Cursor.Current = Cursors.Default;
        }

        private void radioButtonRight_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            negativePgm = Negative(pgmOriginalImage, ImagePart.Right);
            pictureBoxResultImage.Image = PgmToBitmap(negativePgm);

            Cursor.Current = Cursors.Default;
        }

        private void radioButtonFull_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            negativePgm = Negative(pgmOriginalImage, ImagePart.Full);
            pictureBoxResultImage.Image = PgmToBitmap(negativePgm);

            Cursor.Current = Cursors.Default;
        }
    }
}

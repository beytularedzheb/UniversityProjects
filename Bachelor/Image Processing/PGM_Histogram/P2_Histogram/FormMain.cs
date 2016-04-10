namespace P2_Histogram
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class FormMain : Form
    {
        private string inputFileName, outputFileName;
        private PgmImage pgmOriginalImage, pgmHistogramImage;

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

                using (Graphics gr = Graphics.FromImage(result))
                {
                    for (int i = 0; i < pgmImage.Height; ++i)
                    {
                        for (int j = 0; j < pgmImage.Width; ++j)
                        {
                            int pixelColor = pgmImage.Data[i][j];
                            Color c = Color.FromArgb(pixelColor, pixelColor, pixelColor);
                            SolidBrush sb = new SolidBrush(c);
                            gr.FillRectangle(sb, j, i, 1, 1);
                        }
                    }
                    return result;
                }
             }
             return null;
        }

        public int[] Scale(int[] values, int scaledMin, int scaledMax)
        {
            int minValue = values.Min();
            int maxValue = values.Max();

            float scale = (float)(scaledMax - scaledMin) / (float)(maxValue - minValue);
            float offset = minValue * scale - scaledMin;

            int[] output = new int[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                output[i] = (int)Math.Round(values[i] * scale - offset, 0);
            }

            return output;
        }

        public PgmImage CalculateHistogramOf(PgmImage originalImage)
        {
            PgmImage result = null;

            if (originalImage != null)
            {
                int[] histogramArr = new int[256];

                int max = 0;
                for (int i = 0; i < originalImage.Height; i++)
                {
                    for (int j = 0; j < originalImage.Width; j++)
                    {
                        int curr = ++histogramArr[originalImage.Data[i][j]];
                        if (max < curr)
                        {
                            max = curr;
                        }
                    }
                }

                // скалираме масива, т.к понякога се получават много големи числа и изхвърля изключение 
                histogramArr = Scale(histogramArr, 0, 1024);
                result = new PgmImage(histogramArr.Length, histogramArr.Max(), "P2", null, histogramArr.Max());

                int ind = 0;
                bool drawBar;
                for (int i = 0; i < result.Width; i++)
                {
                    drawBar = true;
                    for (int j = result.Height - 1; j >= 0; j--)
                    {
                        if (drawBar)
                        {
                            for (int k = 0; k < histogramArr[ind]; k++, j--)
                            {
                                result.Data[j][i] = 0;
                            }
                            ind++;
                            drawBar = false;
                        }
                        else
                        {
                            result.Data[j][i] = 155;
                        }
                    }
                }
            }

            return result;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = openFileDialog1.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                try
                {
                    pgmOriginalImage = new PgmImage(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                pictureBoxOriginalImage.Image = PgmToBitmap(pgmOriginalImage);

                if (pictureBoxOriginalImage.Image != null)
                {
                    inputFileName = openFileDialog1.FileName;

                    outputFileName = null;
                    pictureBoxHistogram.Visible = true;
                    pictureBoxHistogram.Image = null;
                    saveAsToolStripMenuItem.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;

                    labelMagicNumber.Text = "Magic Number: " + pgmOriginalImage.MagicNumber;
                    labelWidth.Text = "Width: " + pgmOriginalImage.Width + " px";
                    labelHieght.Text = "Height: " + pgmOriginalImage.Height + " px";
                    labelMaxVal.Text = "Maximum Gray Value: " + pgmOriginalImage.MaxVal;

                    Cursor.Current = Cursors.WaitCursor;
                    pgmHistogramImage = CalculateHistogramOf(pgmOriginalImage);
                    pictureBoxHistogram.Image = PgmToBitmap(pgmHistogramImage);
                    checkBoxOriginalSize.Enabled = true;
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    inputFileName = null;
                    outputFileName = null;
                    pictureBoxHistogram.Visible = false;
                    checkBoxOriginalSize.Enabled = false;
                    saveAsToolStripMenuItem.Enabled = false;
                    saveToolStripMenuItem.Enabled = false;

                    pictureBoxOriginalImage.Image = pictureBoxOriginalImage.ErrorImage;

                    labelMagicNumber.Text = "Magic Number:";
                    labelWidth.Text = "Width:";
                    labelHieght.Text = "Height:";
                    labelMaxVal.Text = "Maximum Gray Value:";
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBoxOriginalSize_Click(object sender, EventArgs e)
        {
            if (checkBoxOriginalSize.Checked)
            {
                pictureBoxHistogram.SizeMode = PictureBoxSizeMode.AutoSize;
            }
            else
            {
                pictureBoxHistogram.Width = 550;
                pictureBoxHistogram.Height = 245;
                pictureBoxHistogram.SizeMode = PictureBoxSizeMode.StretchImage;
            }
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
                    pgmHistogramImage.Save(outputFileName);
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
                    pgmHistogramImage.Save(outputFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

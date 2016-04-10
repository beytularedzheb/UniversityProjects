namespace NegativeRotationP2
{
    using System;
    using System.Drawing;
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
            return null;
        }

        public PgmImage Negative(PgmImage pgmImage)
        {
            if (pgmImage != null)
            {
                PgmImage result = new PgmImage(pgmImage.Width, pgmImage.Height, pgmImage.MagicNumber, null, Byte.MinValue);
                Array.Copy(pgmImage.Data, result.Data, pgmImage.Data.Length);

                for (int i = 0; i < pgmImage.Height; i++)
                {
                    for (int j = 0; j < pgmImage.Width; j++)
                    {
                        result.Data[i][j] = (byte)(255 - result.Data[i][j]);
                        if (result.MaxVal < result.Data[i][j])
                        {
                            result.MaxVal = result.Data[i][j];
                        }
                    }

                }

                return result;
            }
            return null;
        }

        public PgmImage Rotate(PgmImage pgmImage, EnumRotationAngles angle)
        {
            if (pgmImage != null)
            {
                int width, height;
                PgmImage result = null;

                switch (angle)
                {
                    case EnumRotationAngles.D_180:
                        width = pgmImage.Width;
                        height = pgmImage.Height;
                        result = new PgmImage(width, height, pgmImage.MagicNumber, pgmImage.Comment, pgmImage.MaxVal);

                        for (int i = pgmImage.Height - 1; i >= 0; i--)
                        {
                            for (int j = pgmImage.Width - 1; j >= 0; j--)
                            {
                                result.Data[pgmImage.Height - 1 - i][pgmImage.Width - 1 - j] = pgmImage.Data[i][j];
                            }
                        }

                        break;
                    case EnumRotationAngles.MINUS_90:
                        width = pgmImage.Height;
                        height = pgmImage.Width;
                        result = new PgmImage(width, height, pgmImage.MagicNumber, pgmImage.Comment, pgmImage.MaxVal);

                        for (int i = 0; i < pgmImage.Width; i++)
                        {
                            for (int j = pgmImage.Height - 1; j >= 0; j--)
                            {
                                result.Data[i][pgmImage.Height - 1 - j] = pgmImage.Data[j][i];
                            }
                        }

                        break;
                    case EnumRotationAngles.PLUS_90:
                        width = pgmImage.Height;
                        height = pgmImage.Width;
                        result = new PgmImage(width, height, pgmImage.MagicNumber, pgmImage.Comment, pgmImage.MaxVal);

                        for (int i = pgmImage.Width - 1; i >= 0; i--)
                        {
                            for (int j = 0; j < pgmImage.Height; j++)
                            {
                                result.Data[pgmImage.Width - 1 - i][j] = pgmImage.Data[j][i];
                            }
                        }

                        break;
                    default: return null;
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
                try
                {
                    pgmOriginalImage = new PgmImage(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                pbImage.Image = PgmToBitmap(pgmOriginalImage);

                if (pbImage.Image != null)
                {
                    inputFileName = openFileDialog1.FileName;
                    tlpActions.Enabled = true;
                }
                else
                {
                    tlpActions.Enabled = false;
                    inputFileName = null;
                    pbImage.Image = pbImage.ErrorImage;
                }

                chbNegative.Checked = false;

                outputFileName = null;

                fileToolStripMenuItem.PerformClick();
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(inputFileName))
            {
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
            }
            else
            {
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
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
                var confirmResult = MessageBox.Show("Are you sure you want to rewrite the original file?", 
                    "Confirmation",
                    MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    outputFileName = inputFileName;
                    try
                    {
                        pgmOriginalImage.Save(outputFileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    saveAsToolStripMenuItem.PerformClick();
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
                    pgmOriginalImage.Save(outputFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnMinus90_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            pgmOriginalImage = Rotate(pgmOriginalImage, EnumRotationAngles.MINUS_90);
            pbImage.Image = PgmToBitmap(pgmOriginalImage);

            Cursor.Current = Cursors.Default;
        }

        private void btnPlus90_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            pgmOriginalImage = Rotate(pgmOriginalImage, EnumRotationAngles.PLUS_90);
            pbImage.Image = PgmToBitmap(pgmOriginalImage);

            Cursor.Current = Cursors.Default;
        }

        private void btn180_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            pgmOriginalImage = Rotate(pgmOriginalImage, EnumRotationAngles.D_180);
            pbImage.Image = PgmToBitmap(pgmOriginalImage);

            Cursor.Current = Cursors.Default;
        }

        private void chbNegative_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            chbNegative.Text = chbNegative.Checked ? "On" : "Off";
            pgmOriginalImage = Negative(pgmOriginalImage);
            pbImage.Image = PgmToBitmap(pgmOriginalImage);

            Cursor.Current = Cursors.Default;
        }
    }
}

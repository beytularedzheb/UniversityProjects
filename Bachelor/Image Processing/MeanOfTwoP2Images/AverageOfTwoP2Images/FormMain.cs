namespace AverageOfTwoP2Images
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class FormMain : Form
    {
        private string inputFileNameOne, inputFileNameTwo;
        private string outputFileName;
        private PgmImage pgmOriginalImageOne, pgmOriginalImageTwo;
        private PgmImage pgmResultImage;

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

        private void btnShowResult_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            pgmResultImage = null;
            int width = pgmOriginalImageOne.Width;
            int height = pgmOriginalImageOne.Height;

            if (width > pgmOriginalImageTwo.Width)
            {
                width = pgmOriginalImageTwo.Width;
            }

            if (height > pgmOriginalImageTwo.Height)
            {
                height = pgmOriginalImageTwo.Height;
            }

            pgmResultImage = new PgmImage(width, height, "P2", "", Int32.MinValue);

            int rCounter = 0;
            int fCounter = 0;
            int sCounter = 0;

            for (int i = 0; i < pgmResultImage.Height; i++)
            {
                for (int j = 0; j < pgmResultImage.Width; j++)
                {
                    pgmResultImage.Data[rCounter] = (byte)((pgmOriginalImageOne.Data[fCounter] + pgmOriginalImageTwo.Data[sCounter]) / 2);
                    if (pgmResultImage.MaxVal < pgmResultImage.Data[rCounter])
                    {
                        pgmResultImage.MaxVal = pgmResultImage.Data[rCounter];
                    }
                    rCounter++;
                    fCounter++;
                    sCounter++;
                }

                fCounter += (pgmOriginalImageOne.Width - pgmResultImage.Width);
                sCounter += (pgmOriginalImageTwo.Width - pgmResultImage.Width);
            }
            pbResultImage.Image = PgmToBitmap(pgmResultImage);
            btnSave.Enabled = true;

            Cursor.Current = Cursors.Default;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = saveFileDialog1.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                outputFileName = saveFileDialog1.FileName;
                try
                {
                    pgmResultImage.Save(outputFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnLoadFirstImage_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = openFileDialog1.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                try
                {
                    pgmOriginalImageOne = new PgmImage(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                pbFirstImage.Image = PgmToBitmap(pgmOriginalImageOne);

                if (pbFirstImage.Image != null)
                {
                    inputFileNameOne = openFileDialog1.FileName;
                    pbFirstImage.Visible = true;
                    outputFileName = null;

                    if (inputFileNameTwo != null)
                    {
                        btnShowResult.Enabled = true;
                    }
                    else
                    {
                        btnShowResult.Enabled = false;
                    }
                }
                else
                {
                    inputFileNameOne = null;
                    pbFirstImage.Visible = false;
                }
            }
        }

        private void btnLoadSecondImage_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = openFileDialog1.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                try
                {
                    pgmOriginalImageTwo = new PgmImage(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                pbSecondImage.Image = PgmToBitmap(pgmOriginalImageTwo);

                if (pbSecondImage.Image != null)
                {
                    inputFileNameTwo = openFileDialog1.FileName;
                    if (inputFileNameOne != null)
                    {
                        btnShowResult.Enabled = true;
                    }
                    else
                    {
                        btnShowResult.Enabled = false;
                    }
                }
                else
                {
                    inputFileNameTwo = null;
                }
            }
        }
    }
}

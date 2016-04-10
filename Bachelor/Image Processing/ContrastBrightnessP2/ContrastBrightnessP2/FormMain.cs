namespace ContrastBrightnessP2
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class FormMain : Form
    {
        private string inputFileName;
        private string outputFileName;
        private PgmImage pgmOriginalImage, pgmResultImage;
        private decimal brightness, contrast;

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
                pbImage.Image = PgmToBitmap(pgmOriginalImage);

                if (pbImage.Image != null)
                {
                    inputFileName = openFileDialog1.FileName;

                    outputFileName = null;              

                    labelMagicNumber.Text = "Magic Number: " + pgmOriginalImage.MagicNumber;
                    labelWidth.Text = "Width: " + pgmOriginalImage.Width + " px";
                    labelHieght.Text = "Height: " + pgmOriginalImage.Height + " px";
                    labelMaxVal.Text = "Maximum Gray Value: " + pgmOriginalImage.MaxVal;

                    this.btnOpenInput.Enabled = true;
                    pgmResultImage = new PgmImage(pgmOriginalImage.Width, pgmOriginalImage.Height, pgmOriginalImage.MagicNumber, "", 0);
                }
                else
                {
                    inputFileName = null;
                    outputFileName = null;         

                    pbImage.Image = pbImage.ErrorImage;

                    labelMagicNumber.Text = "Magic Number:";
                    labelWidth.Text = "Width:";
                    labelHieght.Text = "Height:";
                    labelMaxVal.Text = "Maximum Gray Value:";

                    this.btnOpenInput.Enabled = false;

                    pgmResultImage = null;
                }

                fileToolStripMenuItem.PerformClick();
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
                    pgmResultImage.Save(outputFileName);
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
                    pgmResultImage.Save(outputFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void Calculate(double brightness, double contrast)
        {
            byte max = Byte.MinValue;

            for (int i = 0; i < pgmOriginalImage.Data.Length; i++)
            {
                // brightness
                double currentValue = (pgmOriginalImage.Data[i] / 255.0 + brightness);

                // contrast
                currentValue *= (contrast + 1) * 255.0;

                if (currentValue > 255)
                {
                    pgmResultImage.Data[i] = 255;
                }
                else if (currentValue < 0)
                {
                    pgmResultImage.Data[i] = 0;
                }
                else
                {
                    pgmResultImage.Data[i] = (byte)currentValue;
                }

                if (pgmResultImage.Data[i] > max)
                {
                    max = pgmResultImage.Data[i];
                }
            }

            pgmResultImage.MaxVal = max;
            labelMaxVal.Text = "Maximum Gray Value: " + pgmResultImage.MaxVal;

            pbImage.Image = PgmToBitmap(pgmResultImage);
        }

        private void btnOpenInput_Click(object sender, EventArgs e)
        {
            MyPrompt.ShowDialog(ref brightness, ref contrast, "");
            Calculate((double)brightness, (double)contrast);
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
    }

    public static class MyPrompt
    {
        public static void ShowDialog(ref decimal brightness, ref decimal contrast, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 160,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                ControlBox = false
            };

            Label lblBrightness = new Label() { Left = 50, Top = 10, Text = "Brightness" };
            Label lblContrast = new Label() { Left = 50, Top = 60, Text = "Contrast" };

            NumericUpDown nudBrightness = new NumericUpDown() { Left = 50, Top = 30, Width = 300, Minimum = -1, Maximum = 1, Value = brightness, DecimalPlaces = 2, Increment = 0.05m };
            NumericUpDown nudContrast = new NumericUpDown() { Left = 50, Top = 80, Width = 300, Minimum = -1, Maximum = 1, Value = contrast, DecimalPlaces = 2, Increment = 0.05m };

            Button confirmation = new Button() { Text = "OK", Left = 150, Width = 100, Top = 120, DialogResult = DialogResult.OK };

            confirmation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(nudBrightness);
            prompt.Controls.Add(nudContrast);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(lblContrast);
            prompt.Controls.Add(lblBrightness);
            prompt.AcceptButton = confirmation;

            prompt.ShowDialog();

            brightness = nudBrightness.Value;
            contrast = nudContrast.Value;
        }
    }
}

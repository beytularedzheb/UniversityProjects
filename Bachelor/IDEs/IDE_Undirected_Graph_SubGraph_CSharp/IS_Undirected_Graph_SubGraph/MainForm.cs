namespace IS_Undirected_Graph_SubGraph
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private String fileName;

        private DrawingElementEnum currentElementForDrawing;
        private DrawingUtils dutils;

        private Point startPosition;
        private Point endPosition;

        private Bitmap bmp;
        private Graphics gr;

        private bool paint;

        public MainForm()
        {
            InitializeComponent();

            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(
               fontFamily,
               12,
               FontStyle.Regular,
               GraphicsUnit.Pixel);

            bmp = new Bitmap(panelCanvas.Width, panelCanvas.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            gr = panelCanvas.CreateGraphics();

            Pen pen = new Pen(panelPenColor.BackColor, 3);
            HatchBrush brush = new HatchBrush(HatchStyle.BackwardDiagonal, panelPenColor.BackColor, panelBrushColor.BackColor);

            dutils = new DrawingUtils(g, pen, brush, font);
            panelCanvas.Image = bmp;

            startPosition = new Point();
            endPosition = new Point();
            comboBoxBrushStyle.Items.Add("SolidBrush");
            foreach (string styleName in Enum.GetNames(typeof(HatchStyle)))
            {
                comboBoxBrushStyle.Items.Add(styleName);
            }
            comboBoxBrushStyle.SelectedIndex = 0;

            foreach (string styleName in Enum.GetNames(typeof(DashStyle)))
            {
                comboBoxPenStyles.Items.Add(styleName);
            }
            comboBoxPenStyles.Items.Remove("Custom");
            comboBoxPenStyles.SelectedIndex = 0;
        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            startPosition.X = e.X;
            startPosition.Y = e.Y;

            startToolStripStatusLabel.Text = e.X + " x " + e.Y;
            paint = true;
        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                endPosition.X = e.X;
                endPosition.Y = e.Y;

                endToolStripStatusLabel.Text = e.X + " x " + e.Y;

                dutils.Draw(currentElementForDrawing, startPosition, endPosition);
                VectorUtils.AddElement(currentElementForDrawing, startPosition,
                    endPosition, dutils.Font, dutils.Pen.Color, dutils.Pen.Width, dutils.Pen.DashStyle,
                    dutils.Brush.BackgroundColor, dutils.Brush.HatchStyle,
                    dutils.Brush.ForegroundColor, null);
                gr.DrawImage(bmp, Point.Empty);
                paint = false;
            }
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            currentToolStripStatusLabel.Text = e.X + " x " + e.Y;
        }

        private void buttonNode_Click(object sender, EventArgs e)
        {
            this.currentElementForDrawing = DrawingElementEnum.NODE;
            tableLayoutPanel3.Enabled = false;
        }

        private void buttonLineFromBorder_Click(object sender, EventArgs e)
        {
            this.currentElementForDrawing = DrawingElementEnum.LINE_FROM_BORDER;
            tableLayoutPanel3.Enabled = false;
        }

        private void buttonSubGraph_Click(object sender, EventArgs e)
        {
            this.currentElementForDrawing = DrawingElementEnum.SUB;
            tableLayoutPanel3.Enabled = false;
        }

        private void buttonText_Click(object sender, EventArgs e)
        {
            this.currentElementForDrawing = DrawingElementEnum.TEXT;
            tableLayoutPanel3.Enabled = true;
        }

        private void panelPenColor_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = colorDialog1.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if (comboBoxBrushStyle.SelectedIndex != 0)
                {
                    dutils.Brush = new HatchBrush(dutils.Brush.HatchStyle, colorDialog1.Color, dutils.Brush.BackgroundColor);
                }

                dutils.Pen = new Pen(colorDialog1.Color, dutils.Pen.Width);
                panelPenColor.BackColor = colorDialog1.Color;
            }
        }

        private void panelBrushColor_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = colorDialog1.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if (comboBoxBrushStyle.SelectedIndex == 0)
                {
                    dutils.Brush = new HatchBrush(dutils.Brush.HatchStyle, colorDialog1.Color, colorDialog1.Color);
                }
                else
                {
                    dutils.Brush = new HatchBrush(dutils.Brush.HatchStyle, dutils.Brush.ForegroundColor, colorDialog1.Color);
                }
                panelBrushColor.BackColor = colorDialog1.Color;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = fontDialog1.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                dutils.Font = fontDialog1.Font;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileName = null;
            dutils.Graphics.Clear(Color.White);
            gr.DrawImage(bmp, Point.Empty);
            gr.Clear(Color.White);
            VectorUtils.ClearElements();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.fileName))
            {
                saveAsToolStripMenuItem.PerformClick();
            }
            else
            {
                int indexOfLastDot = fileName.LastIndexOf('.');
                string extension = fileName.Substring(indexOfLastDot + 1);

                if (extension == "vec")
                {
                    VectorUtils.SaveVector(fileName);
                }
                else
                {
                    bmp.Save(fileName);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = saveFileDialog1.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
                int indexOfLastDot = fileName.LastIndexOf('.');
                string extension = fileName.Substring(indexOfLastDot + 1);

                switch (extension)
                {
                    case "bmp":
                        bmp.Save(fileName, ImageFormat.Bmp);
                        break;
                    case "jpeg":
                        bmp.Save(fileName, ImageFormat.Jpeg);
                        break;
                    case "vec":
                        VectorUtils.SaveVector(fileName);
                        break;
                } 
                
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            dutils.Draw(currentElementForDrawing, startPosition, endPosition, textBoxMessage.Text);
            gr.DrawImage(bmp, Point.Empty);
            VectorUtils.AddElement(currentElementForDrawing, startPosition, Point.Empty,
                dutils.Font, dutils.Pen.Color, dutils.Pen.Width, dutils.Pen.DashStyle, dutils.Brush.BackgroundColor,
                dutils.Brush.HatchStyle, dutils.Brush.ForegroundColor, textBoxMessage.Text);
            textBoxMessage.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = openFileDialog1.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                dutils.Graphics.Clear(Color.White);
                gr.Clear(Color.White);

                fileName = openFileDialog1.FileName;
                List<Element> list = VectorUtils.OpenVector(fileName);
                Color penColor = dutils.Pen.Color;
                float penWidth = dutils.Pen.Width;
                HatchStyle hs = dutils.Brush.HatchStyle;
                Color brushColor = dutils.Brush.BackgroundColor;
                Color brushForeColor = dutils.Brush.ForegroundColor;
                Font font = dutils.Font;

                for (int i = 0; i < list.Count; i++)
                {
                    dutils.Pen = new Pen(list[i].PenColor, list[i].PenWidth);
                    dutils.Pen.DashStyle = list[i].PenStyle;
                    dutils.Brush = new HatchBrush(list[i].HatchStyle, list[i].BrushForeColor, list[i].BrushColor);
                    dutils.Font = list[i].TextFont;
                    dutils.Draw(list[i].ElementType, list[i].StartPoint, list[i].EndPoint, list[i].Text);
                }
                gr.DrawImage(bmp, Point.Empty);

                dutils.Pen = new Pen(penColor, penWidth);
                dutils.Brush = new HatchBrush(hs, brushForeColor, brushColor);
                dutils.Font = font;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void comboBoxBrushStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBrushStyle.SelectedIndex == 0)
            {
                dutils.Brush = new HatchBrush(dutils.Brush.HatchStyle, dutils.Brush.BackgroundColor, dutils.Brush.BackgroundColor);
            }
            else
            {
                HatchStyle hs = (HatchStyle)Enum.Parse(typeof(HatchStyle),
                         comboBoxBrushStyle.SelectedItem.ToString(), true);
                dutils.Brush = new HatchBrush(hs, panelPenColor.BackColor, dutils.Brush.BackgroundColor);
            }
        }

        private void comboBoxPenStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            dutils.Pen.DashStyle = (DashStyle)Enum.Parse(typeof(DashStyle),
                comboBoxPenStyles.SelectedItem.ToString(), true);
        }
    }
}

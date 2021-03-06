﻿namespace IS_2D
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
        private bool line;

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

            Pen pen = new Pen(panelPenColor.BackColor, trackBarPenStroke.Value);
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
        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentElementForDrawing == DrawingElementEnum.LINE)
            {
                if (e.Button == MouseButtons.Right)
                {
                    line = false;
                    return;
                }
                if (!line)
                {
                    startPosition.X = e.X;
                    startPosition.Y = e.Y;
                }
            }
            else
            {
                startPosition.X = e.X;
                startPosition.Y = e.Y;
            }

            startToolStripStatusLabel.Text = e.X + " x " + e.Y;
            paint = true;
        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                bool jmp = false;
                if (currentElementForDrawing == DrawingElementEnum.LINE)
                {
                    if (!line)
                    {
                        endPosition.X = e.X;
                        endPosition.Y = e.Y;
                        line = true;
                    }
                    else
                    {
                        startPosition = endPosition;
                    }
                }
                else if (currentElementForDrawing == DrawingElementEnum.RECTANGLE || 
                    currentElementForDrawing == DrawingElementEnum.ELLIPSE)
                {
                    jmp = (Control.ModifierKeys & Keys.Control) == Keys.Control;
                    if (jmp)
                    { // ако е натиснат Ctrl изчертай квадрат/окръжност
                        endPosition.X = e.X;
                        endPosition.Y = e.Y;

                        dutils.HandleCoordinates(ref startPosition, ref endPosition);
                        int width = Math.Abs(endPosition.X - startPosition.X);
                        int height = Math.Abs(endPosition.Y - startPosition.Y);
                        if (width > height)
                        {
                            endPosition.X = startPosition.X + height;
                        }
                        else
                        {
                            endPosition.Y = startPosition.Y + width;
                        }
                    }
                }
                if (!jmp)
                {
                    endPosition.X = e.X;
                    endPosition.Y = e.Y;
                }

                endToolStripStatusLabel.Text = e.X + " x " + e.Y;

                dutils.Draw(currentElementForDrawing, startPosition, endPosition);
                VectorUtils.AddElement(currentElementForDrawing, startPosition,
                    endPosition, dutils.Font, dutils.Pen.Color, dutils.Pen.Width,
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

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            this.currentElementForDrawing = DrawingElementEnum.RECTANGLE;
            tableLayoutPanel3.Enabled = false;
        }

        private void buttonEllipse_Click(object sender, EventArgs e)
        {
            this.currentElementForDrawing = DrawingElementEnum.ELLIPSE;
            tableLayoutPanel3.Enabled = false;
        }

        private void buttonHorizontalLine_Click(object sender, EventArgs e)
        {
            this.currentElementForDrawing = DrawingElementEnum.HORIZONTAL_LINE;
            tableLayoutPanel3.Enabled = false;
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            this.currentElementForDrawing = DrawingElementEnum.LINE;
            tableLayoutPanel3.Enabled = false;
            line = false;
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

        private void trackBarPenStroke_Scroll(object sender, EventArgs e)
        {
            dutils.Pen = new Pen(dutils.Pen.Color, trackBarPenStroke.Value);
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
            //TODO: логика за проверка дали потребителят иска да запази направените промени
            fileName = null;
            dutils.Graphics.Clear(Color.White);
            gr.DrawImage(bmp, Point.Empty);
            gr.Clear(Color.White);
            VectorUtils.ClearElements();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: логика за проверка дали потребителят иска да запази направените промени
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
                dutils.Font, dutils.Pen.Color, dutils.Pen.Width, dutils.Brush.BackgroundColor,
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
    }
}

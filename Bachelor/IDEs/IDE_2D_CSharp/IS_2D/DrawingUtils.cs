namespace IS_2D
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    class DrawingUtils
    {
        private const int IOLineLenght = 20;
        private const int IOCircleRadius = 5;

        private readonly FontFamily fontFamily = new FontFamily("Arial");
        private Font innerTextFont;

        private Graphics graphics;
        private Pen pen;
        private HatchBrush brush;
        private Font font;

        public Pen Pen
        {
            get
            {
                return pen;
            }

            set
            {
                pen = value;
            }
        }

        public HatchBrush Brush
        {
            get
            {
                return brush;
            }

            set
            {
                brush = value;
            }
        }

        public Font Font
        {
            get
            {
                return font;
            }

            set
            {
                font = value;
            }
        }

        public Graphics Graphics
        {
            get
            {
                return graphics;
            }

            set
            {
                graphics = value;
            }
        }

        public DrawingUtils(Graphics graphics, Pen pen, HatchBrush brush, Font font)
        {
            this.graphics = graphics;
            this.pen = pen;
            this.brush = brush;
            this.font = font;
        }

        public void HandleCoordinates(ref Point start, ref Point end)
        {
            if (start.X > end.X)
            {
                int swap = start.X;
                start.X = end.X;
                end.X = swap;
            }
            if (start.Y > end.Y)
            {
                int swap = start.Y;
                start.Y = end.Y;
                end.Y = swap;
            }
        }

        public void Draw(DrawingElementEnum element, Point start, Point end, String text = null)
        {
            switch (element)
            {
                case DrawingElementEnum.RECTANGLE:
                    DrawRectangle(start, end);
                    break;
                case DrawingElementEnum.ELLIPSE:
                    DrawEllipse(start, end);
                    break;
                case DrawingElementEnum.HORIZONTAL_LINE:
                    DrawHorizontalLine(start, end);
                    break;
                case DrawingElementEnum.LINE:
                    DrawLine(start, end);
                    break;
                case DrawingElementEnum.TEXT:
                    DrawText(text, start);
                    break;
            }
        }

        private void DrawLine(Point start, Point end)
        {
            this.Graphics.DrawLine(this.pen, start, end);
        }

        private void DrawText(string text, Point start)
        {
            SolidBrush b = new SolidBrush(this.pen.Color);
            this.Graphics.DrawString(text, this.font, b, start);
        }

        private void DrawHorizontalLine(Point start, Point end)
        {
            Point endPoint = new Point(end.X, start.Y);
            this.Graphics.DrawLine(this.pen, start, endPoint);
        }

        private void DrawEllipse(Point start, Point end)
        {
            HandleCoordinates(ref start, ref end);
            this.Graphics.FillEllipse(this.Brush, start.X, start.Y, Math.Abs(end.X - start.X), Math.Abs(end.Y - start.Y));
            this.Graphics.DrawEllipse(this.Pen, start.X, start.Y, Math.Abs(end.X - start.X), Math.Abs(end.Y - start.Y));
        }

        private void DrawRectangle(Point start, Point end)
        {
            HandleCoordinates(ref start, ref end);
            this.Graphics.FillRectangle(this.Brush, start.X, start.Y, Math.Abs(end.X - start.X), Math.Abs(end.Y - start.Y));
            this.Graphics.DrawRectangle(this.Pen, start.X, start.Y, Math.Abs(end.X - start.X), Math.Abs(end.Y - start.Y));
        }
    }

}


namespace IS_UseCase
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    class DrawingUtils
    {
        private const int IOLineLenght = 20;
        private const int IOCircleRadius = 5;

        private readonly FontFamily fontFamily = new FontFamily("Arial");

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

        private void HandleCoordinates(ref Point start, ref Point end)
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
                case DrawingElementEnum.USER:
                    DrawUser(start, end);
                    break;
                case DrawingElementEnum.CASE:
                    DrawCase(start, end);
                    break;
                case DrawingElementEnum.INCLUDES:
                    DrawIncludes(start, end);
                    break;
                case DrawingElementEnum.EXTENDS:
                    DrawExtends(start, end);
                    break;
                case DrawingElementEnum.LINE:
                    DrawLine(start, end);
                    break;
                case DrawingElementEnum.TEXT:
                    DrawText(text, start);
                    break;
                default:
                    break;
            }
        }

        private void DrawLine(Point start, Point end)
        {
            this.Graphics.DrawLine(this.Pen, start, end);
        }

        private void DrawText(string text, Point start)
        {
            SolidBrush b = new SolidBrush(this.Pen.Color);
            this.Graphics.DrawString(text, this.Font, b, start);
        }

        private void DrawUser(Point start, Point end)
        {
            HandleCoordinates(ref start, ref end);
            int width = Math.Abs(end.X - start.X);
            int height = Math.Abs(end.Y - start.Y);
            int headHeight = (int)Math.Round(1.0 / 4.0 * height);
            int headWidth = (int)Math.Round(2.0 / 3.0 * width) - (int)Math.Round((1.0 / 3.0) * width);
            // head
            this.Graphics.FillEllipse(this.Brush, start.X + (int)Math.Round((1.0/3.0) * width), start.Y, headWidth, headHeight);
            this.Graphics.DrawEllipse(this.Pen, start.X + (int)Math.Round((1.0 / 3.0) * width), start.Y, headWidth, headHeight);
            // body
            this.Graphics.DrawLine(this.Pen, (int)Math.Round(start.X + width / 2.0), (int)Math.Round(start.Y + 1.0 / 4.0 * height), (int)Math.Round(start.X + width / 2.0), (int)Math.Round(start.Y + 5.0 / 8.0 * height));
            // arms
            this.Graphics.DrawLine(this.Pen, start.X, (int)Math.Round((start.Y + 1.0 / 4.0 * height) + 1 / 12.0 * height), end.X, (int)Math.Round((start.Y + 1.0 / 4.0 * height) + 1 / 12.0 * height));
            // left leg
            this.Graphics.DrawLine(this.Pen, (int)Math.Round(start.X + width / 2.0), (int)Math.Round(start.Y + 5.0 / 8.0 * height), (int)Math.Round(start.X + 1.0 / 5 * width), end.Y);
            // right leg
            this.Graphics.DrawLine(this.Pen, (int)Math.Round(start.X + width / 2.0), (int)Math.Round(start.Y + 5.0 / 8.0 * height), (int)Math.Round(start.X + 4.0 / 5 * width), end.Y);
        }

        private void DrawCase(Point start, Point end)
        {
            HandleCoordinates(ref start, ref end);
            int width = Math.Abs(end.X - start.X);
            int height = Math.Abs(end.Y - start.Y);
            this.Graphics.FillEllipse(this.Brush, start.X, start.Y, width, height);
            this.Graphics.DrawEllipse(this.Pen, start.X, start.Y, width, height);
        }

        private void DrawIncludes(Point start, Point end)
        {
            GraphicsPath hPath = new GraphicsPath();

            hPath.AddLine(0, 0, -2, -2);
            hPath.AddLine(0, 0, 2, -2);
            CustomLineCap HookCap = new CustomLineCap(null, hPath);
            HookCap.SetStrokeCaps(LineCap.Round, LineCap.Round);
            HookCap.WidthScale = 1.7f;
            float[] dashValues = { 2, 2, 2, 2 };
            Pen arrowPen = new Pen(this.Pen.Color, this.Pen.Width);
            arrowPen.DashPattern = dashValues;
            arrowPen.CustomEndCap = HookCap;
            this.Graphics.DrawLine(arrowPen, start, end);
        }

        private void DrawExtends(Point start, Point end)
        {
            GraphicsPath hPath = new GraphicsPath();
            hPath.AddLine(0, 0, -2, -2);
            hPath.AddLine(-2, -2, 2, -2);
            hPath.AddLine(2, -2, 0, 0);
            CustomLineCap HookCap = new CustomLineCap(hPath, null);
            HookCap.SetStrokeCaps(LineCap.Round, LineCap.Round);
            HookCap.WidthScale = 1.7f;
            
            float[] dashValues = { 2, 2, 2, 2 };
            
            Pen arrowPen = new Pen(this.Pen.Color, this.Pen.Width);
            arrowPen.DashPattern = dashValues;
            arrowPen.CustomEndCap = HookCap;
            this.Graphics.DrawLine(arrowPen, start, end);
        }
    }

}


namespace IS_Undirected_Graph_SubGraph
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    class DrawingUtils
    {
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

        public double GetAngleOfLineBetweenTwoPoints(PointF p1, PointF p2)
        {
            double xDiff = p2.X - p1.X;
            double yDiff = p2.Y - p1.Y;

            return Math.Atan2(yDiff, xDiff) * (180 / Math.PI);
        }

        public Element getNodeBy(Point p, List<Element> nodes)
        {
            Element result = null;
            foreach (var item in nodes)
            {
                int r = (item.EndPoint.X - item.StartPoint.X) / 2;
                Point center = new Point(item.StartPoint.X + r, item.StartPoint.Y + r);
                double d = Math.Sqrt(Math.Pow((p.X - center.X), 2) + Math.Pow((p.Y - center.Y), 2));

                if (d <= r)
                {
                    result = item;
                    break;
                }
            }

            return result;
        }

        public void Draw(DrawingElementEnum element, Point start, Point end, String text = null)
        {
            switch (element)
            {
                case DrawingElementEnum.LINE_FROM_BORDER:
                    DrawLineFromBorder(start, end);
                    break;
                case DrawingElementEnum.NODE:
                    DrawNode(start, end);
                    break;
                case DrawingElementEnum.SUB:
                    DrawSubGraph(start, end);
                    break;
                case DrawingElementEnum.TEXT:
                    DrawText(text, start);
                    break;
            }
        }

        private void DrawNode(Point start, Point end)
        {
            this.HandleCoordinates(ref start, ref end);
            int d = end.X - start.X;
            this.Graphics.FillEllipse(this.Brush, start.X, start.Y, d, d);
            this.Graphics.DrawEllipse(this.Pen, start.X, start.Y, d, d);
        }

        private void DrawText(string text, Point start)
        {
            SolidBrush b = new SolidBrush(this.pen.Color);
            this.Graphics.DrawString(text, this.font, b, start);
        }

        private void DrawLineFromBorder(Point start, Point end)
        {
            List<Element> nodes = VectorUtils.findElementBy(new List<DrawingElementEnum> { DrawingElementEnum.NODE, DrawingElementEnum.SUB });
            if (nodes != null)
            {
                Element firstNode = getNodeBy(start, nodes);
                if (firstNode != null)
                {
                    int rf = (firstNode.EndPoint.X - firstNode.StartPoint.X) / 2;
                    Point centerF = new Point(firstNode.StartPoint.X + rf, firstNode.StartPoint.Y + rf);

                    Element secondNode = getNodeBy(end, nodes);
                    if (secondNode != null && secondNode != firstNode)
                    {
                        double xf = centerF.X + rf * Math.Cos(GetAngleOfLineBetweenTwoPoints(start, end) * (Math.PI / 180));
                        double yf = centerF.Y + rf * Math.Sin(GetAngleOfLineBetweenTwoPoints(start, end) * (Math.PI / 180));

                        int rs = (secondNode.EndPoint.X - secondNode.StartPoint.X) / 2;
                        Point centerS = new Point(secondNode.StartPoint.X + rs, secondNode.StartPoint.Y + rs);

                        double xs = centerS.X - rs * Math.Cos(GetAngleOfLineBetweenTwoPoints(start, end) * (Math.PI / 180));
                        double ys = centerS.Y - rs * Math.Sin(GetAngleOfLineBetweenTwoPoints(start, end) * (Math.PI / 180));

                        Point sp = new Point((int)xf, (int)yf);
                        Point ep = new Point((int)xs, (int)ys);
                        if (firstNode.ElementType == DrawingElementEnum.NODE)
                        {
                            sp = centerF;
                        }

                        if (secondNode.ElementType == DrawingElementEnum.NODE)
                        {
                            ep = centerS;
                        }
                        this.Graphics.DrawLine(this.Pen, sp, ep);
                    }
                }
            }
        }

        private void DrawSubGraph(Point start, Point end)
        {
            this.HandleCoordinates(ref start, ref end);
            int d = end.X - start.X;
            this.Graphics.FillEllipse(this.Brush, start.X, start.Y, d, d);
            this.Graphics.DrawEllipse(this.Pen, start.X, start.Y, d, d);

            float p = 2 * this.Pen.Width;
            int dInner = (int)((end.X - start.X) - 2 * p);
            
            this.Graphics.DrawEllipse(this.Pen, start.X + p, start.Y + p, dInner, dInner);
        }
    }

}


namespace IS_UseCase
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    [Serializable()]
    public class Element
    {
        private DrawingElementEnum elementType;
        private Point startPoint;
        private Point endPoint;
        private Font textFont;
        private Color penColor;
        private float penWidth;
        private Color brushColor;
        private string text;
        private HatchStyle hatchStyle;
        private Color brushForeColor;

        public DrawingElementEnum ElementType
        {
            get
            {
                return elementType;
            }

            set
            {
                elementType = value;
            }
        }

        public Point StartPoint
        {
            get
            {
                return startPoint;
            }

            set
            {
                startPoint = value;
            }
        }

        public Point EndPoint
        {
            get
            {
                return endPoint;
            }

            set
            {
                endPoint = value;
            }
        }

        public Font TextFont
        {
            get
            {
                return textFont;
            }

            set
            {
                textFont = value;
            }
        }

        public Color PenColor
        {
            get
            {
                return penColor;
            }

            set
            {
                penColor = value;
            }
        }

        public float PenWidth
        {
            get
            {
                return penWidth;
            }

            set
            {
                penWidth = value;
            }
        }

        public Color BrushColor
        {
            get
            {
                return brushColor;
            }

            set
            {
                brushColor = value;
            }
        }

        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
            }
        }

        public HatchStyle HatchStyle
        {
            get
            {
                return hatchStyle;
            }

            set
            {
                hatchStyle = value;
            }
        }

        public Color BrushForeColor
        {
            get
            {
                return brushForeColor;
            }

            set
            {
                brushForeColor = value;
            }
        }

        public Element(DrawingElementEnum elementType, Point startPoint, Point endPoint, Font textFont, Color penColor, float penWidth, Color brushColor, HatchStyle hatchStyle, Color brushForeColor, String text)
        {
            this.ElementType = elementType;
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            this.TextFont = textFont;
            this.PenColor = penColor;
            this.PenWidth = penWidth;
            this.BrushColor = brushColor;
            this.HatchStyle = hatchStyle;
            this.BrushForeColor = brushForeColor;
            this.Text = text;
        }
    }
}

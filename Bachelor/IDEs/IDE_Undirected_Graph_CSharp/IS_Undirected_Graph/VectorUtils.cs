namespace IS_Undirected_Graph
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;

    class VectorUtils
    {
        private static List<Element> elements = new List<Element>();

        public static List<Element> Elements
        {
            get
            {
                return elements;
            }
        }

        public static void AddElement(DrawingElementEnum elementType, Point startPoint, Point endPoint, Font font, Color penColor, float penWidth, Color brushColor, HatchStyle hatchStyle, Color brushForeColor, String text)
        {
            if (elementType == DrawingElementEnum.TEXT)
            {
                Element el = new Element(elementType, startPoint, Point.Empty, font, penColor, penWidth, brushColor, hatchStyle, brushForeColor, text);
                elements.Add(el);
            }
            else
            {
                Element el = new Element(elementType, startPoint, endPoint, null, penColor, penWidth, brushColor, hatchStyle, brushForeColor, null);
                elements.Add(el);
            }
        }

        public static void SaveVector(String fileName)
        {
            using (Stream stream = File.Open(fileName, FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, elements);
            }
        }

        public static List<Element> OpenVector(String fileName)
        {
            using (Stream stream = File.Open(fileName, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                elements = (List<Element>)binaryFormatter.Deserialize(stream);
                return elements;
            }
        }

        public static void ClearElements()
        {
            elements.Clear();
        }

        public static List<Element> findElementByType(DrawingElementEnum type)
        {
            List<Element> result = new List<Element>();
            foreach (var item in elements)
            {
                if (item.ElementType == type)
                {
                    result.Add(item);
                }
            }

            return result.Count > 0 ? result : null;
        }
    }
}

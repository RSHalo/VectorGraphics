using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using VectorGraphics.Drawables;

namespace VectorGraphics.Loader
{
    class FileLoader : IFileLoader
    {
        private const string fileFilter = "Shape Files(*.xml)|*.xml";

        public void Load(CanvasControl canvas)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = fileFilter
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                IEnumerable<LoadedShape> loadedShapes = ReadShapes(openFileDialog.FileName);
                LoadShapesToCanvas(canvas, loadedShapes);
            }
        }

        private IEnumerable<LoadedShape> ReadShapes(string filePath)
        {
            using (XmlReader xmlReader = XmlReader.Create(filePath, new XmlReaderSettings { IgnoreWhitespace = true }))
            {
                xmlReader.ReadToFollowing("Shapes");
                XmlReader innerReader = xmlReader.ReadSubtree();
                // Read past the Shapes element so that we get to it's child elements.
                innerReader.Read();

                List<LoadedShape> loadedShapes = new List<LoadedShape>();
                while (innerReader.Read())
                {
                    if (innerReader.NodeType != XmlNodeType.EndElement)
                    {
                        // Reached a shape child of the Shapes element.
                        
                        string shapeType = innerReader.LocalName;
                        Dictionary<string, string> attributes = GetAllAttributes(innerReader);
                        LoadedShape loadedShape = new LoadedShape(shapeType, attributes);
                        loadedShapes.Add(loadedShape);
                    }
                }

                return loadedShapes;
            }
        }

        private Dictionary<string, string> GetAllAttributes(XmlReader reader)
        {
            Dictionary<string, string> attributes = new Dictionary<string, string>();

            while (reader.MoveToNextAttribute())
            {
                string attributeName = reader.Name;
                string attributeValue = reader.Value;
                attributes.Add(attributeName, attributeValue);
            }
            
            return attributes;
        }

        private void LoadShapesToCanvas(CanvasControl canvas, IEnumerable<LoadedShape> shapes)
        {
            foreach (LoadedShape shape in shapes)
            {
                Pen pen = CreatePen(shape);

                string shapeTypeUpper = shape.ShapeType.ToUpperInvariant();
                switch (shapeTypeUpper)
                {
                    case "LINE":
                        DrawableLine line = CreateDrawableLine(shape, pen);
                        canvas.AddLine(line);
                        break;
                }
            }

            canvas.MakeReady();
        }

        private Pen CreatePen(LoadedShape shape)
        {
            // Mixing up colour vs color spellings here. A bit annoying.
            string colourName = shape.Attributes["Colour"];
            Color colour = Color.FromName(colourName);
            return new Pen(colour);
        }

        private DrawableLine CreateDrawableLine(LoadedShape loadedLine, Pen pen)
        {
            // Get the start and end coords from the value loaded from the file.
            int startX = Convert.ToInt32(loadedLine.Attributes["StartX"]);
            int startY = Convert.ToInt32(loadedLine.Attributes["StartY"]);
            int endX = Convert.ToInt32(loadedLine.Attributes["EndX"]);
            int endY = Convert.ToInt32(loadedLine.Attributes["EndY"]);

            // Create Points from these values.
            Point startPoint = new Point(startX, startY);
            Point endPoint = new Point(endX, endY);
            
            return new DrawableLine(pen, startPoint, endPoint);
        }
    }
}

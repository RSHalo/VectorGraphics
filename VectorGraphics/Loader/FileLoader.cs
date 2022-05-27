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
        private readonly string _fileFilter = string.Empty;

        public string LoadedFilePath { get; private set; }
        public bool Loaded { get; private set; }

        public FileLoader(string fileFilter)
        {
            _fileFilter = fileFilter;
        }

        public void Load(CanvasControl canvas)
        {
            StartLoad();

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = _fileFilter
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                IEnumerable<LoadedShape> loadedShapes = ReadShapes(openFileDialog.FileName);
                LoadShapesToCanvas(canvas, loadedShapes);
                
                Loaded = true;
                LoadedFilePath = openFileDialog.FileName;
            }
        }

        private void StartLoad()
        {
            Loaded = false;
            LoadedFilePath = null;
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
            canvas.PreLoad();

            foreach (LoadedShape loadedShape in shapes)
            {
                Pen pen = CreatePen(loadedShape);

                IDrawable shape = null;
                string shapeTypeUpper = loadedShape.ShapeType.ToUpperInvariant();
                switch (shapeTypeUpper)
                {
                    case "LINE":
                        shape = CreateDrawableLine(loadedShape, pen);
                        break;

                    case "RECTANGLE":
                        shape = CreateDrawableRectangle(loadedShape, pen);
                        break;

                    case "ELLIPSE":
                        shape = CreateDrawableEllipse(loadedShape, pen);
                        break;
                }

                if (shape != null)
                {
                    canvas.AddShape(shape);
                }
            }

            canvas.ResetView();
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

        private DrawableRectangle CreateDrawableRectangle(LoadedShape loadedRectangle, Pen pen)
        {
            Rectangle rectangle = ExtractRectangleDataFromLoadedShape(loadedRectangle);
            return new DrawableRectangle(pen, rectangle);
        }

        private DrawableEllipse CreateDrawableEllipse(LoadedShape loadedEllipse, Pen pen)
        {
            Rectangle boundingRectangle = ExtractRectangleDataFromLoadedShape(loadedEllipse);
            return new DrawableEllipse(pen, boundingRectangle); ;
        }

        private Rectangle ExtractRectangleDataFromLoadedShape(LoadedShape shape)
        {
            int x = Convert.ToInt32(shape.Attributes["X"]);
            int y = Convert.ToInt32(shape.Attributes["Y"]);
            int width = Convert.ToInt32(shape.Attributes["W"]);
            int height = Convert.ToInt32(shape.Attributes["H"]);

            return new Rectangle(x, y, width, height);
        }
    }
}

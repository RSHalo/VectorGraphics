using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using VectorGraphics.Drawables;

namespace VectorGraphics.Saving
{
    /// <summary>Saves a canvas drawing to disk.</summary>
    class FileSaver : IFileSaver
    {
        private readonly string _fileFilter = string.Empty;
        private string _activeFilePath = string.Empty;

        public FileSaver(string fileFilter)
        {
            _fileFilter = fileFilter;
        }

        public void SetActiveFilePath(string newActiveFilePath)
        {
            _activeFilePath = newActiveFilePath;
        }

        public void Save(IEnumerable<IDrawable> drawables)
        {
            if (string.IsNullOrEmpty(_activeFilePath))
            {
                throw new Exception("Can't save. No active file path is set.");
            }
            Save(drawables, _activeFilePath);
        }

        public void SaveAsNewFile(IEnumerable<IDrawable> drawables)
        {
            string newFilePath = GetFilePath();
            if (newFilePath != null)
            {
                Save(drawables, newFilePath);
                SetActiveFilePath(newFilePath);
            }
        }

        private void Save(IEnumerable<IDrawable> drawables, string filePath)
        {
            using (XmlWriter writer = XmlWriter.Create(filePath))
            {
                writer.WriteStartElement("Shapes");
                foreach (IDrawable drawable in drawables)
                {
                    ShapeSaveData shapeSaveData = drawable.SaveBehaviour.GetSaveData();
                    SaveShape(shapeSaveData, writer);
                }
                writer.WriteEndElement();
            }
        }

        private string GetFilePath()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = _fileFilter,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }
            return null;
        }

        private void SaveShape(ShapeSaveData saveData, XmlWriter writer)
        {
            writer.WriteStartElement(saveData.ShapeType);
            writer.WriteAttributeString("Id", saveData.ShapeId);
            writer.WriteAttributeString("Colour", saveData.Colour);
            foreach (var attribute in saveData.ShapeData)
            {
                writer.WriteAttributeString(attribute.Key, attribute.Value);
            }
            writer.WriteEndElement();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using VectorGraphics.Drawables;

namespace VectorGraphics.Saving
{
    /// <summary>Saves a canvas drawing to disk.</summary>
    class CanvasSaver
    {
        public void Save(IEnumerable<IDrawable> drawables)
        {
            using (XmlWriter writer = XmlWriter.Create(@"C:\Users\rolli\Desktop\shapes.xml"))
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

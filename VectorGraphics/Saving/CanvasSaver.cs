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
                    ShapeSaverResult saverResult = drawable.SaveBehaviour.Save();
                    SaveShape(saverResult, writer);
                }
                writer.WriteEndElement();
            }
        }

        private void SaveShape(ShapeSaverResult result, XmlWriter writer)
        {
            writer.WriteStartElement(result.ShapeType);
            writer.WriteAttributeString("Id", result.ShapeId);
            writer.WriteAttributeString("Colour", result.Colour);
            foreach (var attribute in result.ShapeData)
            {
                writer.WriteAttributeString(attribute.Key, attribute.Value);
            }
            writer.WriteEndElement();
        }
    }
}

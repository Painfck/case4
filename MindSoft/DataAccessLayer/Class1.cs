using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using BussinesLayer;
using BussinesLayer.Mindmap;
using System.Drawing;

namespace DataAccessLayer
{
    public class XMLStreamreader
    {
        public void SerializeToXML(MindMap mind, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Knoop));
            TextWriter textWriter = new StreamWriter(path);
            serializer.Serialize(textWriter, mind.knopenlist);
            textWriter.Close();
        }
        public void LoadXML()
        {
            
        }
        public void SaveXML(string docname)
        {
            XmlTextWriter xwriter = new XmlTextWriter(docname, Encoding.Unicode);
            xwriter.WriteStartDocument();
            xwriter.WriteStartElement("XMLFile");
            xwriter.WriteStartElement("Knoop");
            MindMap mind = new MindMap("hier moet een naam voor de mindmap komen josh");
            foreach (Knoop knoop in mind.knopenlist)
            {
                xwriter.WriteStartElement("Knoop");
                xwriter.WriteString(Convert.ToString(knoop));
                xwriter.WriteEndElement();
            }
            
        }
    }
}

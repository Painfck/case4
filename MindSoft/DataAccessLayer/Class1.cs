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

namespace DataAccessLayer
{
    public class XMLStreamreader
    {
        public void LoadXML()
        {
            
        }
        public void SaveXML(string docname)
        {
            XmlTextWriter xwriter = new XmlTextWriter(docname, Encoding.Unicode);
            xwriter.WriteStartDocument();
            xwriter.WriteStartElement("XMLFile");
            xwriter.WriteStartElement("Knoop");
           MindMap mind = new MindMap();
            foreach (Knoop knoop in mind.knopenlist)
            {
                xwriter.WriteStartElement("Knoop");
                xwriter.WriteString(knoop);
                xwriter.WriteEndElement();
            }
        }
    }
}

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
        //public void SerializeToXML(MindMap mind, string path)
        //{
        //    XmlSerializer serializer = new XmlSerializer(typeof(Knoop));
        //    TextWriter textWriter = new StreamWriter(path);
        //    serializer.Serialize(textWriter, mind.knopenlist);
        //    textWriter.Close();
        //}
        public void LoadXML()
        {
            
        }
        public void SaveXML(string docname)
        {
            XmlTextWriter xwriter = new XmlTextWriter(docname, Encoding.Unicode);
            xwriter.WriteStartDocument();
            Project project = new Project();
            MindMap mind = project.mindmaplist.ElementAt<MindMap>(0);
            foreach (Knoop knoop in mind.knopenlist)
            {
                xwriter.WriteStartElement("Knoop");
                xwriter.WriteString(Convert.ToString(knoop));
                xwriter.WriteEndElement();
            }
            foreach (Relatie relatie in mind.relatieslist)
            {
                xwriter.WriteStartElement("Relatie");
                xwriter.WriteString(Convert.ToString(relatie));
                xwriter.WriteEndElement();
            }
            xwriter.WriteEndDocument();
            xwriter.Flush();
        }
    }
}

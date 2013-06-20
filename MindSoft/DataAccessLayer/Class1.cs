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
        private Project project;
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
        public void SaveXML(string docname, Project project)
        {
            XmlTextWriter xwriter = new XmlTextWriter(docname, Encoding.Unicode);
            xwriter.WriteStartDocument();
            this.project = project;
            xwriter.WriteStartElement("Knooppositie");
            foreach (Knoop knoop in project.activeMindmap.knopenlist)
            {
                xwriter.WriteString(Convert.ToString(knoop.positie));
            }
            xwriter.WriteEndElement();

            //xwriter.WriteStartElement("Relatie");
            //foreach (Relatie relatie in project.activeMindmap.relatieslist)
            //{
            //    xwriter.WriteString(Convert.ToString(relatie));
            //}
            //xwriter.WriteEndElement();
            xwriter.WriteEndDocument();
            xwriter.Flush();
            project.saved = true;
        }
    }
}

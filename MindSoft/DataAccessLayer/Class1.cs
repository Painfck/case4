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
            this.project = project;
            XmlTextWriter writer = new XmlTextWriter(docname, Encoding.Unicode);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("table");
            int i = 1;
            foreach (Knoop knoop in project.activeMindmap.knopenlist)
            {
                createNodeKnoop(i, Convert.ToString(knoop.size), Convert.ToString(knoop.positie), Convert.ToString(knoop.inhoudlist), Convert.ToString(knoop.opmaak), writer);
                i++;
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();

        }


            private void createNodeKnoop(int kID, string kSize, string kPosition, string kInhoud, string kOpmaak, XmlTextWriter writer)
            {        
                writer.WriteStartElement("Knoop");
                writer.WriteStartElement("knoop_id");
                writer.WriteString(Convert.ToString(kID));
                writer.WriteEndElement();
                writer.WriteStartElement("knoopsize");
                writer.WriteString(kSize);
                writer.WriteEndElement();
                writer.WriteStartElement("knoopposition");
                writer.WriteString(kPosition);
                writer.WriteEndElement();
                writer.WriteStartElement("knoopinhoud");
                writer.WriteString(kInhoud);
                writer.WriteEndElement();
                writer.WriteStartElement("knoopopmaak");
                writer.WriteString(kOpmaak);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }
    }


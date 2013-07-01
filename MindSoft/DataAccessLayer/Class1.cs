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
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 3;

            writer.WriteStartDocument();

                writer.WriteStartElement("mindsoft");
                writer.WriteStartElement("knopen");
                
                    int i = 1;
                    foreach (Knoop knoop in project.activeMindmap.knopenlist)
                    {
                        createNodeKnoop(i, knoop, writer);
                        i++;
                    }
                writer.WriteEndElement();
                writer.WriteStartElement("relaties");
                    foreach (Relatie relatie in project.activeMindmap.relatieslist)
                    {
                        createNodeRelatie(relatie, writer);
                    }
                writer.WriteEndElement();
                writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();

        }

        private void createNodeRelatie(Relatie relatie, XmlTextWriter writer)
        {
            writer.WriteStartElement("relatie");

                writer.WriteStartElement("knoop1");
                    writer.WriteStartElement("X");
                        writer.WriteString(Convert.ToString(relatie.Knoop1.positie.X));
                    writer.WriteEndElement();
                    writer.WriteStartElement("Y");
                        writer.WriteString(Convert.ToString(relatie.Knoop1.positie.Y));
                    writer.WriteEndElement();
               writer.WriteEndElement();

               writer.WriteStartElement("knoop2");
                    writer.WriteStartElement("X");
                        writer.WriteString(Convert.ToString(relatie.Knoop2.positie.X));
                    writer.WriteEndElement();
                    writer.WriteStartElement("Y");
                        writer.WriteString(Convert.ToString(relatie.Knoop2.positie.Y));
                    writer.WriteEndElement();
               writer.WriteEndElement();

           writer.WriteEndElement();
        }


            private void createNodeKnoop(int kID, Knoop knoop, XmlTextWriter writer)
            {        
                writer.WriteStartElement("Knoop");

                    writer.WriteStartElement("id");
                        writer.WriteString(Convert.ToString(kID));
                    writer.WriteEndElement();

                    writer.WriteStartElement("size");
                        writer.WriteStartElement("width");
                            writer.WriteString(Convert.ToString(knoop.rect.Width));
                        writer.WriteEndElement();
                        
                        writer.WriteStartElement("height");
                            writer.WriteString(Convert.ToString(knoop.rect.Height));
                        writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.WriteStartElement("position");
                        writer.WriteStartElement("X");
                            writer.WriteString(Convert.ToString(knoop.positie.X));
                        writer.WriteEndElement();

                        writer.WriteStartElement("Y");
                            writer.WriteString(Convert.ToString(knoop.positie.Y));
                        writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.WriteStartElement("inhoud");
                            foreach (Text text in knoop.inhoudlist)
                            {
                                int id = 1;
                                writer.WriteStartElement(Convert.ToString(id));
                                writer.WriteString(Convert.ToString(text.textInhoud));
                                writer.WriteEndElement();
                                id+=1;
                            }
                     writer.WriteEndElement();                  
                    //writer.WriteStartElement("knoopposition");
                    //    writer.WriteString(kPosition);
                    //writer.WriteEndElement();
                
                    //writer.WriteStartElement("knoopinhoud");
                    //    writer.WriteString(kInhoud);
                    //writer.WriteEndElement();
                
                    //writer.WriteStartElement("knoopopmaak");
                    //    writer.WriteString(kOpmaak);
                    //writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }
    }


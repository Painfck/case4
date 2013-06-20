﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesLayer;
using BussinesLayer.Mindmap;
using System.IO;
using DataAccessLayer;

namespace MindSoft
{
    public partial class MindSoft : Form
    {
        private Graphics canvas;
        private Project project;

        private int originalKnoopHeight = 20;
        private int originalKnoopWidth = 200;
        private string zoom;

        private bool selected = false;

        private string initialDir;
        private string currentFile = "";

        public MindSoft()
        {
            InitializeComponent();
            pbView.Height = this.Height;
            PnlPlayer.Hide();
            canvas = pbView.CreateGraphics();
            project = new Project();
            initialDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoForm Help = new InfoForm("Help");
            Help.Show();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InfoForm About = new InfoForm("About");
            About.Show();
        }

        private void bteditknoop_Click(object sender, EventArgs e)
        {

        }

        private void btopmaakknoop_Click(object sender, EventArgs e)
        {

        }

        private void btcontentknoop_Click(object sender, EventArgs e)
        {

        }

        private void bteditrelatie_Click(object sender, EventArgs e)
        {

        }

        private void btnewrelatie_Click(object sender, EventArgs e)
        {

        }

        private void btnewknoop_Click(object sender, EventArgs e)
        {
            
        }

        private void MindSoft_Resize(object sender, EventArgs e)
        {
            PnlPlayer.Width = pbView.Width;
            trbartimebar.Width = PnlPlayer.Width;
        }

        private void playerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PnlPlayer.Show();
            PnlEdit.Hide();
            pbView.Width = this.Width;
            PnlPlayer.Width = this.Width;
        }

        private void mindmapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PnlPlayer.Hide();
            PnlEdit.Show();
            pbView.Width = (this.Width - PnlEdit.Width);
        }

        private void pbView_MouseClick(object sender, MouseEventArgs e)
        {
  
        }

        private void pbView_MouseDown(object sender, MouseEventArgs e)
        {
            if (project.activeMindmap != null && e.Button == MouseButtons.Left)
            {
                selected = project.activeMindmap.SearchObject(e.X, e.Y);
            }
        }

        private void pbView_MouseMove(object sender, MouseEventArgs e)
        {
            if (selected)
            {
                project.activeMindmap.MoveKnoop(e.X, e.Y);
                project.activeMindmap.TekenObjecten(canvas);
            }
        }


        private void pbView_MouseUp(object sender, MouseEventArgs e)
        {
            selected = false;
        }

        private void pbView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Knoop knoop = new Knoop(e.X, e.Y);
            project.activeMindmap.knopenlist.Add(knoop);
            project.activeMindmap.TekenObjecten(canvas);
        }
        
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader inputStream;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = initialDir;
            dialog.Filter = "xml files (*.xml)|*.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                currentFile = dialog.FileName;
                inputStream = File.OpenText(currentFile);
                //hier komt het laden van de xml in het project

                inputStream.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // deze even eruit gecomment
            /*
            StreamWriter outputStream = File.CreateText(currentFile);
            if (currentFile == "")
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.InitialDirectory = initialDir;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    currentFile = dialog.FileName;
                    XMLStreamreader streamreader = new XMLStreamreader();
                    streamreader.SaveXML(dialog.FileName);
                }
            }
            

            outputStream.Close();
             */
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //StreamWriter outputStream = File.CreateText(currentFile);
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = initialDir;
            dialog.Filter = "xml files (*.xml)|*.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                currentFile = dialog.FileName;
                XMLStreamreader streamreader = new XMLStreamreader();
                streamreader.SaveXML(dialog.FileName, project);
                //outputStream.Close();
            }
        }



        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mindmapToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            project.activeMindmap = project.createMindmap();
            canvas.Clear(Color.White);
        }

        private void presentatieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            project.activeMindmap.CreatePresentatie();
        }

        private void tsmpresentation_Click(object sender, EventArgs e)
        {
            // nog te reviseren door leon van de broek
            project.activeMindmap.presentatie.Display(canvas);
        }

        private void zoomCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            zoom = zoomCB.Text;

            switch (zoom)
            {
                case "25%":
                    foreach (Knoop knoop in project.activeMindmap.knopenlist)
                    {
                        knoop.size.Height = Convert.ToInt32(originalKnoopHeight * 0.25);
                        knoop.size.Width = Convert.ToInt32(originalKnoopWidth * 0.25);
                    }
                    project.activeMindmap.TekenObjecten(canvas);
                    break;
                case "50%":
                    foreach (Knoop knoop in project.activeMindmap.knopenlist)
                    {
                        knoop.size.Height = Convert.ToInt32(originalKnoopHeight * 0.50);
                        knoop.size.Width = Convert.ToInt32(originalKnoopWidth * 0.50);
                    }
                    project.activeMindmap.TekenObjecten(canvas);
                    break;
                case "75%":
                    foreach (Knoop knoop in project.activeMindmap.knopenlist)
                    {
                        knoop.size.Height = Convert.ToInt32(originalKnoopHeight * 0.75);
                        knoop.size.Width = Convert.ToInt32(originalKnoopWidth * 0.75);
                    }
                    project.activeMindmap.TekenObjecten(canvas);
                    break;
                case "100%":
                    foreach (Knoop knoop in project.activeMindmap.knopenlist)
                    {
                        knoop.size.Height = Convert.ToInt32(originalKnoopHeight * 1.00);
                        knoop.size.Width = Convert.ToInt32(originalKnoopWidth * 1.00);
                    }
                    project.activeMindmap.TekenObjecten(canvas);
                    break;
                case "150%":
                    foreach (Knoop knoop in project.activeMindmap.knopenlist)
                    {
                        knoop.size.Height = Convert.ToInt32(originalKnoopHeight * 1.50);
                        knoop.size.Width = Convert.ToInt32(originalKnoopWidth * 1.50);
                    }
                    project.activeMindmap.TekenObjecten(canvas);
                    break;
                case "200%":
                    foreach (Knoop knoop in project.activeMindmap.knopenlist)
                    {
                        knoop.size.Height = Convert.ToInt32(originalKnoopHeight * 2.00);
                        knoop.size.Width = Convert.ToInt32(originalKnoopWidth * 2.00);
                    }
                    project.activeMindmap.TekenObjecten(canvas);
                    break;
                case "250%":
                    foreach (Knoop knoop in project.activeMindmap.knopenlist)
                    {
                        knoop.size.Height = Convert.ToInt32(originalKnoopHeight * 2.50);
                        knoop.size.Width = Convert.ToInt32(originalKnoopWidth * 2.50);
                    }
                    project.activeMindmap.TekenObjecten(canvas);
                    break;
            }
        }





    }
}

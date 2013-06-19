using System;
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

namespace MindSoft
{
    public partial class MindSoft : Form
    {
        private Knoop knoop;
        private Graphics canvas;
        private Project project;
        private MindMap activeMindmap;

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
            activeMindmap = project.mindmaplist.ElementAt<MindMap>(0);
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
            if (activeMindmap != null && e.Button == MouseButtons.Left)
            {
                selected = activeMindmap.SearchObject(e.X, e.Y);
            }
        }

        private void pbView_MouseMove(object sender, MouseEventArgs e)
        {
            if (selected)
            {
                activeMindmap.MoveKnoop(e.X, e.Y);
                activeMindmap.TekenObjecten(canvas);
            }
        }


        private void pbView_MouseUp(object sender, MouseEventArgs e)
        {
            selected = false;
        }

        private void pbView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Knoop knoop = new Knoop(e.X, e.Y);
            activeMindmap.knopenlist.Add(knoop);
            activeMindmap.TekenObjecten(canvas);
        }
        
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader inputStream;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = initialDir;
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
            StreamWriter outputStream = File.CreateText(currentFile);
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = initialDir;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                currentFile = dialog.FileName;
                XMLStreamreader streamreader = new XMLStreamreader();
                streamreader.SaveXML(dialog.FileName);
                outputStream.Close();
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
            activeMindmap = project.createMindmap();
            canvas.Clear(Color.White);
        }

        private void presentatieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeMindmap.CreatePresentatie();
        }

        private void tsmpresentation_Click(object sender, EventArgs e)
        {
            // nog te reviseren door leon van de broek
            activeMindmap.presentatie.Display(canvas);
        }





    }
}

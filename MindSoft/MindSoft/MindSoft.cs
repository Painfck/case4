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
using DataAccessLayer;

namespace MindSoft
{

    /// <summary>
    /// eerste opzet van dit form door wesley (aangevuld met events door rob, aangevuld met player en presentatie door leon, aangevuld met xml deels door josh)
    /// </summary>
    public partial class MindSoft : Form
    {
        
        private Knoop knoop;
        private Graphics canvas;
        private Project project;
        private System.Threading.Thread playerthread;
        private int zoomedKnoopHeight = 20;
        private int zoomedKnoopWidth = 200;
        private int originalKnoopHeight = 20;
        private int originalKnoopWidth = 200;
        private string zoom;
        private EditKnoop editknoop;
        private bool selected = false;
        private bool isFileSaved = false;
        private List<string> mindmapnames;
        
        private string initialDir;
        private string currentFile = "";

        public MindSoft()
        {
            InitializeComponent();
            project = Project.projectInstance();
            pbView.Height = this.Height;
            PnlPlayer.Hide();
            canvas = pbView.CreateGraphics();
            Project.project.activeMindmap = project.mindmaplist.First();
            initialDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Project.project.activeMindmap.player.drawField = canvas;
            mindmapnames = new List<string>();
            foreach (BussinesLayer.Mindmap.MindMap mindmap in Project.project.mindmaplist)
            {
                mindmapnames.Add(mindmap.name);
            }
            lbminmapselect.DataSource = mindmapnames;
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


        private void MindSoft_Resize(object sender, EventArgs e)
        {
            try
            {
                PnlPlayer.Width = pbView.Width;
                trbartimebar.Width = PnlPlayer.Width;
                canvas.Dispose();
                canvas = pbView.CreateGraphics();
                Project.project.activeMindmap.TekenObjecten(canvas);
                Project.project.activeMindmap.player.drawField = canvas;
            }
            catch (NullReferenceException)
            {

            }
        }

        private void playerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Project.project.activeMindmap.relatieslist.Count() < 1)
            {
                MessageBox.Show("Er zijn geen relaties aanwezig in deze mindmap, \r\nmaak een relatie aan en probeer opnieuw");
            }
            else
            {
                PnlPlayer.Show();
                PnlEdit.Hide();
                pbView.Width = this.Width;
                PnlPlayer.Width = this.Width;
                Project.project.activeMindmap.player.mindmap = Project.project.activeMindmap;
                Project.project.activeMindmap.player.updateAttributes();
                Project.project.activeMindmap.player.drawField = canvas;
                playerthread = new System.Threading.Thread(Project.project.activeMindmap.player.play);
            }
        }

        private void mindmapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PnlPlayer.Hide();
            PnlEdit.Show();
            pbView.Width = (this.Width - PnlEdit.Width);
        }

        private void pbView_MouseClick(object sender, MouseEventArgs e)
        {
            if (Project.project.activeMindmap != null)
            {
                Project.project.activeMindmap.TekenObjecten(canvas);
            }
        }

        private void pbView_MouseDown(object sender, MouseEventArgs e)
        {
           
            //Verplaats knoop
            if (Project.project.activeMindmap != null && e.Button == MouseButtons.Left)
            {
                selected = Project.project.activeMindmap.SearchObject(e.X, e.Y);
                if (selected)
                {
                    Project.project.activeMindmap.selectedKnoop.oldX = e.X;
                    Project.project.activeMindmap.selectedKnoop.oldY = e.Y;
                    Project.project.activeMindmap.SearchAnchor(e.X, e.Y);
                }

            }
            //Relatie leggen kies knoop 1.
            if (Project.project.activeMindmap != null && e.Button == MouseButtons.Right)
            {
                selectedkn1 = Project.project.activeMindmap.Search(e.X, e.Y);
            }
        }
        
        private void pbView_MouseMove(object sender, MouseEventArgs e)
        {
            //Knoop bewegen
            if (selected)
            {
                Project.project.activeMindmap.MoveKnoop(e.X, e.Y);
                Project.project.activeMindmap.TekenObjecten(canvas);
            }
        }


        private void pbView_MouseUp(object sender, MouseEventArgs e)
        {
            // Relatie leggen
            if (Project.project.activeMindmap != null && e.Button == MouseButtons.Right)
            {
                selectedkn2 = Project.project.activeMindmap.Search(e.X, e.Y);
                if (selectedkn1 != null && selectedkn2 != null)
                {
                    Project.project.activeMindmap.CreateRelationship(selectedkn1, selectedkn2);
                }
                Project.project.activeMindmap.TekenObjecten(canvas);
            }
            //Knoop move
            selected = false;

            isFileSaved = false;
        }

        private void pbView_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (Project.project.activeMindmap != null && e.Button == MouseButtons.Left)
            {
                selected = Project.project.activeMindmap.SearchObject(e.X, e.Y);
            }
            if (selected)
            {
                editknoop = new EditKnoop(Project.project.activeMindmap.selectedKnoop);
                editknoop.Owner = this;
                editknoop.Show();
                //Project.project.activeMindmap.selectedKnoop.EditKnoop("edit");
                //Project.project.activeMindmap.TekenObjecten(canvas);
            }
            else
            {
                knoop = new Knoop(e.X, e.Y, new Size(zoomedKnoopWidth, zoomedKnoopHeight));

                Project.project.activeMindmap.knopenlist.Add(knoop);
                Project.project.activeMindmap.TekenObjecten(canvas);
            }
            isFileSaved = false;

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
            isFileSaved = true;
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mindmapToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Project.project.activeMindmap = project.createMindmap();
            canvas.Clear(Color.White);
            mindmapnames.Clear();
            foreach (BussinesLayer.Mindmap.MindMap mindmap in Project.project.mindmaplist)
            {
                mindmapnames.Add(mindmap.name);
            }
            lbminmapselect.DataSource = null;
            lbminmapselect.DataSource = mindmapnames;
        }

        private void presentatieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Project.project.activeMindmap.knopenlist.Count() < 1)
            {
                MessageBox.Show("Voeg eerst knopen toe aan deze mindmap \r\nvoordat je de presentatie probeert te genereren!");
            }
            else
            {
                EditPresentatie settings = new EditPresentatie(Project.project.activeMindmap);
                settings.Show();
            }
        }

        private void tsmpresentation_Click(object sender, EventArgs e)
        {
            if (Project.project.activeMindmap.knopenlist.Count() < 1)
            {
                MessageBox.Show("Voeg eerst knopen toe aan deze mindmap \r\nvoordat je de presentatie probeert te genereren!");
            }
            else
            {
                EditPresentatie settings = new EditPresentatie(Project.project.activeMindmap);
                settings.Show();
            }
        }

        private void zoomCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Comment by R.Hiensch
            // Je moet hier nog even een check uitvoeren! Want als je knoop al 50% verkleind is
            // en je dan op 25 duwt, blijft die kleiner worden, en als je een aantal keer op verkleinen duwt
            // dan blijft hij ook kleiner worden. Dus even een slimme methode hiervoor maken en deze
            // in een Class(!!!!) zetten! 
            zoom = zoomCB.Text;

            switch (zoom)
            {
                case "25%":

                    foreach (Knoop knoop in Project.project.activeMindmap.knopenlist)
                    {
                        knoop.rect.Height = Convert.ToInt32(originalKnoopHeight * 0.25);
                        knoop.rect.Width = Convert.ToInt32(originalKnoopWidth * 0.25);

                    }
                    Project.project.activeMindmap.TekenObjecten(canvas);

                    zoomedKnoopHeight = Convert.ToInt32(originalKnoopHeight * 0.25);
                    zoomedKnoopWidth = Convert.ToInt32(originalKnoopWidth * 0.25);
                    break;
                case "50%":
                    foreach (Knoop knoop in Project.project.activeMindmap.knopenlist)
                    {
                        knoop.rect.Height = Convert.ToInt32(originalKnoopHeight * 0.50);
                        knoop.rect.Width = Convert.ToInt32(originalKnoopWidth * 0.50);
                    }
                    Project.project.activeMindmap.TekenObjecten(canvas);
                    zoomedKnoopHeight = Convert.ToInt32(originalKnoopHeight * 0.50);
                    zoomedKnoopWidth = Convert.ToInt32(originalKnoopWidth * 0.50);
                    break;
                case "75%":
                    foreach (Knoop knoop in Project.project.activeMindmap.knopenlist)
                    {
                        knoop.rect.Height = Convert.ToInt32(originalKnoopHeight * 0.75);
                        knoop.rect.Width = Convert.ToInt32(originalKnoopWidth * 0.75);
                    }
                    Project.project.activeMindmap.TekenObjecten(canvas);
                    zoomedKnoopHeight = Convert.ToInt32(originalKnoopHeight * 0.75);
                    zoomedKnoopWidth = Convert.ToInt32(originalKnoopWidth * 0.75);
                    break;
                case "100%":
                    foreach (Knoop knoop in Project.project.activeMindmap.knopenlist)
                    {
                        knoop.rect.Height = Convert.ToInt32(originalKnoopHeight * 1.00);
                        knoop.rect.Width = Convert.ToInt32(originalKnoopWidth * 1.00);
                    }
                    Project.project.activeMindmap.TekenObjecten(canvas);
                    zoomedKnoopHeight = Convert.ToInt32(originalKnoopHeight * 1.00);
                    zoomedKnoopWidth = Convert.ToInt32(originalKnoopWidth * 1.00);
                    break;
                case "150%":
                    foreach (Knoop knoop in Project.project.activeMindmap.knopenlist)
                    {
                        knoop.rect.Height = Convert.ToInt32(originalKnoopHeight * 1.50);
                        knoop.rect.Width = Convert.ToInt32(originalKnoopWidth * 1.50);
                    }
                    Project.project.activeMindmap.TekenObjecten(canvas);
                    zoomedKnoopHeight = Convert.ToInt32(originalKnoopHeight * 1.50);
                    zoomedKnoopWidth = Convert.ToInt32(originalKnoopWidth * 1.50);
                    break;
                case "200%":
                    foreach (Knoop knoop in Project.project.activeMindmap.knopenlist)
                    {
                        knoop.rect.Height = Convert.ToInt32(originalKnoopHeight * 2.00);
                        knoop.rect.Width = Convert.ToInt32(originalKnoopWidth * 2.00);
                    }
                    Project.project.activeMindmap.TekenObjecten(canvas);
                    zoomedKnoopHeight = Convert.ToInt32(originalKnoopHeight * 2.00);
                    zoomedKnoopWidth = Convert.ToInt32(originalKnoopWidth * 2.00);
                    break;
                case "250%":
                    foreach (Knoop knoop in Project.project.activeMindmap.knopenlist)
                    {
                        knoop.rect.Height = Convert.ToInt32(originalKnoopHeight * 2.50);
                        knoop.rect.Width = Convert.ToInt32(originalKnoopWidth * 2.50);
                    }
                    Project.project.activeMindmap.TekenObjecten(canvas);
                    zoomedKnoopHeight = Convert.ToInt32(originalKnoopHeight * 2.50);
                    zoomedKnoopWidth = Convert.ToInt32(originalKnoopWidth * 2.50);
                    break;
            }
        }
        /// <summary>
        /// in deze onderstaande methode wordt de thread nagekeken die speciaal voro de player is aangemaak, in deze thread wordt de play() methode van de player
        /// gedelegeerd. hieronder zijn alle mogelijke stata van de diverse threadstates te vinden en de afhandeling door de playknop. leon
        /// </summary>
        private void btplay_Click(object sender, EventArgs e)
        {
            Project.project.activeMindmap.player.drawField = canvas;
            try
            {
                if (playerthread.ThreadState == System.Threading.ThreadState.Unstarted)
                {
                    playerthread.Start();
                }
                if (playerthread.ThreadState == System.Threading.ThreadState.Suspended)
                {
                    playerthread.Resume();
                }
                if (playerthread.ThreadState == System.Threading.ThreadState.Aborted)
                {
                    playerthread = new System.Threading.Thread(Project.project.activeMindmap.player.play);
                    playerthread.Start();
                }
            }
            catch (System.Threading.ThreadStateException)
            { 
            
            }
        }


        /// <summary>
        /// als er op pauze wordt geklikt in de player wordt de thread ook op pauze gezet, hierdoor lijkt het alsof alles op pauze staat (op het canvas) leon
        /// </summary>
        private void btpauze_Click(object sender, EventArgs e)
        {
            Project.project.activeMindmap.player.drawField = canvas;
            try
            {
                playerthread.Suspend();
            }
            catch (System.Threading.ThreadStateException)
            {

            }
        }



        /// <summary>
        /// hier worden de stopacties voor de player gedefinieerd. de thread wordt afgebroken en de player krijgt het sein dat hij moet stoppen (alle objecten 
        /// opnieuw op het canvas tekenen die zijn aangemaakt zodat het lijkt of de gebruiker verder gaat waar hij gebleven was in de editor). leon
        /// </summary>
        private void btstop_Click(object sender, EventArgs e)
        {
            Project.project.activeMindmap.player.drawField = canvas;
            Project.project.activeMindmap.player.stop();
            try
            {
            playerthread.Abort();
            }
            catch (System.Threading.ThreadStateException)
            {

            }
        }


        /// <summary>
        /// hier wordt het rewind knopje afgehandeld. er wordt niets gedaan met de thread (wanneer abbort aanroepen doet de thread niets, fout),
        /// door de rewind methdoe van de player aan te roepen wordt het canvas geleegd en wordt gewacht tot de player op "play" klikt.
        /// </summary>
        private void btrewind_Click(object sender, EventArgs e)
        {
            Project.project.activeMindmap.player.drawField = canvas;
            Project.project.activeMindmap.player.rewind();
        }

        /// <summary>
        /// geselecteerde knopen voor het afhandelen van het leggen van relaties.
        /// </summary>
        private Knoop selectedkn1 { get; set; }
        private Knoop selectedkn2 { get; set; }

        private void MindSoft_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isFileSaved)
            {
                if (MessageBox.Show("This file has not been saved yet. \r\n Do you want to save it now?", "Save Project", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.InitialDirectory = initialDir;
                    dialog.Filter = "xml files (*.xml)|*.xml";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        currentFile = dialog.FileName;
                        XMLStreamreader streamreader = new XMLStreamreader();
                        streamreader.SaveXML(dialog.FileName, project);
                    }
                }
            }
        }

        private void btverwijder_Click(object sender, EventArgs e)
        {
            Project.project.activeMindmap.RemoveActiveKnoop();
            Project.project.activeMindmap.TekenObjecten(canvas);
        }

        private void mindmapToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SelectMindmap selectbox = new SelectMindmap();
            selectbox.Show();
        }

        private void projectToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void lbminmapselect_Click(object sender, EventArgs e)
        {
            Project.project.SetActiveMindmap(Project.project.searchMindmap(Convert.ToString(lbminmapselect.SelectedValue)));
            canvas.Clear(Color.White);
            Project.project.activeMindmap.TekenObjecten(canvas);
        }
    }
}

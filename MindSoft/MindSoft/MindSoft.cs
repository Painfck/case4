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
        private MindMap activeMindmap;
        private System.Threading.Thread playerthread;
        private int zoomedKnoopHeight = 20;
        private int zoomedKnoopWidth = 200;
        private int originalKnoopHeight = 20;
        private int originalKnoopWidth = 200;
        private string zoom;
        private EditKnoop editknoop;
        private bool selected = false;
        private bool toDelete = true;
        private bool isFileSaved = false;

        private string initialDir;
        private string currentFile = "";

        public MindSoft()
        {
            InitializeComponent();
            project = Project.projectInstance();
            pbView.Height = this.Height;
            PnlPlayer.Hide();
            canvas = pbView.CreateGraphics();
            activeMindmap = project.mindmaplist.First();
            initialDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            activeMindmap.player.drawField = canvas;
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
            try
            {
                PnlPlayer.Width = pbView.Width;
                trbartimebar.Width = PnlPlayer.Width;
                canvas.Dispose();
                canvas = pbView.CreateGraphics();
                activeMindmap.TekenObjecten(canvas);
                activeMindmap.player.drawField = canvas;
            }
            catch (NullReferenceException)
            {

            }
        }

        private void playerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeMindmap.relatieslist.Count() < 1)
            {
                MessageBox.Show("Er zijn geen relaties aanwezig in deze mindmap, \r\nmaak een relatie aan en probeer opnieuw");
            }
            else
            {
                PnlPlayer.Show();
                PnlEdit.Hide();
                pbView.Width = this.Width;
                PnlPlayer.Width = this.Width;
                activeMindmap.player.mindmap = activeMindmap;
                activeMindmap.player.updateAttributes();
                activeMindmap.player.drawField = canvas;
                playerthread = new System.Threading.Thread(activeMindmap.player.play);
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
            if (activeMindmap != null)
            {
                activeMindmap.TekenObjecten(canvas);
            }
            if (selected && toDelete)
            {
                activeMindmap.RemoveActiveKnoop();
                toDelete = false;
            }
        }

        private void pbView_MouseDown(object sender, MouseEventArgs e)
        {
           
            //Verplaats knoop
            if (activeMindmap != null && e.Button == MouseButtons.Left)
            {
                selected = activeMindmap.SearchObject(e.X, e.Y);
                if (selected)
                {
                    activeMindmap.selectedKnoop.oldX = e.X;
                    activeMindmap.selectedKnoop.oldY = e.Y;
                    activeMindmap.SearchAnchor(e.X, e.Y);
                }

            }
            //Relatie leggen kies knoop 1.
            if (activeMindmap != null && e.Button == MouseButtons.Right)
            {
                selectedkn1 = activeMindmap.Search(e.X, e.Y);
            }
        }
        
        private void pbView_MouseMove(object sender, MouseEventArgs e)
        {
            //Knoop bewegen
            if (selected)
            {
                activeMindmap.MoveKnoop(e.X, e.Y);
                activeMindmap.TekenObjecten(canvas);
            }
            
          
        }


        private void pbView_MouseUp(object sender, MouseEventArgs e)
        {
            Relatie candidate = new Relatie(selectedkn1, selectedkn2);
            // Relatie leggen
            if (activeMindmap != null && e.Button == MouseButtons.Right)
            {
                selectedkn2 = activeMindmap.Search(e.X, e.Y);
                if (!activeMindmap.checkIfRelatieExist(candidate))
                {
                    activeMindmap.relatieslist.Add(candidate);
                }
                activeMindmap.TekenObjecten(canvas);
            }
            //Knoop move
            selected = false;

            isFileSaved = false;
        }

        private void pbView_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (activeMindmap != null && e.Button == MouseButtons.Left)
            {
                selected = activeMindmap.SearchObject(e.X, e.Y);
            }
            if (selected)
            {
                editknoop = new EditKnoop(activeMindmap.selectedKnoop);
                editknoop.Show();
                //activeMindmap.selectedKnoop.EditKnoop("edit");
                //activeMindmap.TekenObjecten(canvas);
            }
            else
            {
                knoop = new Knoop(e.X, e.Y, new Size(zoomedKnoopWidth, zoomedKnoopHeight));

                activeMindmap.knopenlist.Add(knoop);
                activeMindmap.TekenObjecten(canvas);
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
            activeMindmap = project.createMindmap();
            canvas.Clear(Color.White);
        }

        private void presentatieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeMindmap.knopenlist.Count() < 1)
            {
                MessageBox.Show("Voeg eerst knopen toe aan deze mindmap \r\nvoordat je de presentatie probeert te genereren!");
            }
            else
            {
                EditPresentatie settings = new EditPresentatie(activeMindmap);
                settings.Show();
            }
        }

        private void tsmpresentation_Click(object sender, EventArgs e)
        {
            if (activeMindmap.knopenlist.Count() < 1)
            {
                MessageBox.Show("Voeg eerst knopen toe aan deze mindmap \r\nvoordat je de presentatie probeert te genereren!");
            }
            else
            {
                EditPresentatie settings = new EditPresentatie(activeMindmap);
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
                    foreach (Knoop knoop in activeMindmap.knopenlist)
                    {
                        knoop.size.Height = Convert.ToInt32(originalKnoopHeight * 0.25);
                        knoop.size.Width = Convert.ToInt32(originalKnoopWidth * 0.25);
                    }
                    activeMindmap.TekenObjecten(canvas);
                    zoomedKnoopHeight = Convert.ToInt32(originalKnoopHeight * 0.25);
                    zoomedKnoopWidth = Convert.ToInt32(originalKnoopWidth * 0.25);
                    break;
                case "50%":
                    foreach (Knoop knoop in activeMindmap.knopenlist)
                    {
                        knoop.size.Height = Convert.ToInt32(originalKnoopHeight * 0.50);
                        knoop.size.Width = Convert.ToInt32(originalKnoopWidth * 0.50);
                    }
                    activeMindmap.TekenObjecten(canvas);
                    zoomedKnoopHeight = Convert.ToInt32(originalKnoopHeight * 0.50);
                    zoomedKnoopWidth = Convert.ToInt32(originalKnoopWidth * 0.50);
                    break;
                case "75%":
                    foreach (Knoop knoop in activeMindmap.knopenlist)
                    {
                        knoop.size.Height = Convert.ToInt32(originalKnoopHeight * 0.75);
                        knoop.size.Width = Convert.ToInt32(originalKnoopWidth * 0.75);
                    }
                    activeMindmap.TekenObjecten(canvas);
                    zoomedKnoopHeight = Convert.ToInt32(originalKnoopHeight * 0.75);
                    zoomedKnoopWidth = Convert.ToInt32(originalKnoopWidth * 0.75);
                    break;
                case "100%":
                    foreach (Knoop knoop in activeMindmap.knopenlist)
                    {
                        knoop.size.Height = Convert.ToInt32(originalKnoopHeight * 1.00);
                        knoop.size.Width = Convert.ToInt32(originalKnoopWidth * 1.00);
                    }
                    activeMindmap.TekenObjecten(canvas);
                    zoomedKnoopHeight = Convert.ToInt32(originalKnoopHeight * 1.00);
                    zoomedKnoopWidth = Convert.ToInt32(originalKnoopWidth * 1.00);
                    break;
                case "150%":
                    foreach (Knoop knoop in activeMindmap.knopenlist)
                    {
                        knoop.size.Height = Convert.ToInt32(originalKnoopHeight * 1.50);
                        knoop.size.Width = Convert.ToInt32(originalKnoopWidth * 1.50);
                    }
                    activeMindmap.TekenObjecten(canvas);
                    zoomedKnoopHeight = Convert.ToInt32(originalKnoopHeight * 1.50);
                    zoomedKnoopWidth = Convert.ToInt32(originalKnoopWidth * 1.50);
                    break;
                case "200%":
                    foreach (Knoop knoop in activeMindmap.knopenlist)
                    {
                        knoop.size.Height = Convert.ToInt32(originalKnoopHeight * 2.00);
                        knoop.size.Width = Convert.ToInt32(originalKnoopWidth * 2.00);
                    }
                    activeMindmap.TekenObjecten(canvas);
                    zoomedKnoopHeight = Convert.ToInt32(originalKnoopHeight * 2.00);
                    zoomedKnoopWidth = Convert.ToInt32(originalKnoopWidth * 2.00);
                    break;
                case "250%":
                    foreach (Knoop knoop in activeMindmap.knopenlist)
                    {
                        knoop.size.Height = Convert.ToInt32(originalKnoopHeight * 2.50);
                        knoop.size.Width = Convert.ToInt32(originalKnoopWidth * 2.50);
                    }
                    activeMindmap.TekenObjecten(canvas);
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
            activeMindmap.player.drawField = canvas;
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
                    playerthread = new System.Threading.Thread(activeMindmap.player.play);
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
            activeMindmap.player.drawField = canvas;
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
            activeMindmap.player.drawField = canvas;
            activeMindmap.player.stop();
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
            activeMindmap.player.drawField = canvas;
            activeMindmap.player.rewind();
        }

        /// <summary>
        /// geselecteerde knopen voor het afhandelen van het leggen van relaties.
        /// </summary>
        private Knoop selectedkn1 { get; set; }
        private Knoop selectedkn2 { get; set; }

        private void MindSoft_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!isFileSaved)
            //{
            //    if (MessageBox.Show("This file has not been saved yet. \r\n Do you want to save it now?", "Save Project", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            //    {
            //        SaveFileDialog dialog = new SaveFileDialog();
            //        dialog.InitialDirectory = initialDir;
            //        dialog.Filter = "xml files (*.xml)|*.xml";
            //        if (dialog.ShowDialog() == DialogResult.OK)
            //        {
            //            currentFile = dialog.FileName;
            //            XMLStreamreader streamreader = new XMLStreamreader();
            //            streamreader.SaveXML(dialog.FileName, project);
            //        }
            //    }
            //}
        }

        private void btverwijder_Click(object sender, EventArgs e)
        {
            activeMindmap.RemoveActiveKnoop();
            activeMindmap.TekenObjecten(canvas);
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
    }
}

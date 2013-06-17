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

namespace MindSoft
{
    public partial class MindSoft : Form
    {
        private Knoop knoop;
        private Graphics canvas;
        private MindMap mindMap;
        public MindSoft()
        {
            InitializeComponent();
            pbView.Height = this.Height;
            PnlPlayer.Hide();
            canvas = pbView.CreateGraphics();
            mindMap = new MindMap();
            
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

        private void pbView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Knoop knoop = new Knoop(e.X, e.Y);
            mindMap.knopenlist.Add(knoop);
            mindMap.Teken(canvas);
        }

        private void MindSoft_Load(object sender, EventArgs e)
        {
        }
    }
}

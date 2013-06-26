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

namespace MindSoft
{
    public partial class EditKnoop : Form
    {
        private List<Text> inhoudlist;
        public EditKnoop(Knoop knoop)
        {
            InitializeComponent();
            inhoudlist = new List<Text>();
            foreach (Inhoud inhoud in knoop.inhoudlist)
            {
                if (inhoud is Text)
                {
                    inhoudlist.Add((BussinesLayer.Text) inhoud);
                }
            }
            tbtextinhoud.Text = inhoudlist.First().textInhoud;

        }

        private void btconfirm_Click(object sender, EventArgs e)
        {
            inhoudlist.First().textInhoud = tbtextinhoud.Text;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MindSoft
{
    public partial class InfoForm : Form
    {
        private string Insert_Name;

        public InfoForm(string Insert_Name)
        {
            this.Insert_Name = Insert_Name;
            InitializeComponent();
            
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            if (Insert_Name == "Help")
            {
                this.Name = "Help";
                label1.Text = "Help";
                infoTB.Text = File.ReadAllText("Help.MST");
            }
            if (Insert_Name == "About")
            {
                this.Name = "About";
                infoTB.Text = File.ReadAllText("About.MST");
            }
        }
    }
}

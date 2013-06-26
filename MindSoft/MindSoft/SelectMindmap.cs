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
    public partial class SelectMindmap : Form
    {

        private List<string> mindmapnames;
        public SelectMindmap()
        {
            InitializeComponent();
            mindmapnames = new List<string>();
            foreach (BussinesLayer.Mindmap.MindMap mindmap in Project.project.mindmaplist)
            {
                mindmapnames.Add(mindmap.name);
            }
            listBox1.DataSource = mindmapnames;
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Project.project.activeMindmap = Project.project.searchMindmap(Convert.ToString(listBox1.SelectedValue));
            this.Close();
        }
    }
}

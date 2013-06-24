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
    public partial class Settings : Form
    {
        private Graphics graphics;
        BussinesLayer.Mindmap.MindMap mindmap;
        private IList<string> dianame;
        private Dia selected;


        public Settings(BussinesLayer.Mindmap.MindMap mindmap)
        {
            InitializeComponent();
            this.mindmap = mindmap;
            mindmap.presentatie = new Presentatie(mindmap);
            graphics = pbdiapreview.CreateGraphics();
            updateForm();
        }

        private void updateForm()
        {
            dianame = mindmap.presentatie.getDiaName();
            lbdialist.DataSource = dianame;
            lbdialist.ClearSelected();
        }
        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void lbdialist_MouseClick(object sender, MouseEventArgs e)
        {
            if (selected == null)
            {
                selected = mindmap.presentatie.searchDia(lbdialist.SelectedIndex);

            }
            else
            {

            }
            
        }

        private void btomhoog_Click(object sender, EventArgs e)
        {
            mindmap.presentatie.reArrangeup(selected);
            updateForm();
            selected = null;
        }

        private void btomlaag_Click(object sender, EventArgs e)
        {
            mindmap.presentatie.reArrangedown(selected);
            updateForm();
            selected = null;
        }
    }
}

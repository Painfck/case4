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
            mindmap.CreatePresentatie();
            this.mindmap = mindmap;
            graphics = pbdiapreview.CreateGraphics();
            updateForm();
        }

        private void updateForm()
        {
            dianame = mindmap.presentatie.getDiaName();
            lbdialist.DataSource = dianame;
            lbdialist.ClearSelected();
            graphics.Clear(Color.White);
            textBox1.Text = "";
            if (selected != null)
            {
                selected.Draw(graphics);
                if (selected.Notitie != null)
                {
                    textBox1.Text = selected.Notitie.tekst;
                }
            }
        }
        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void lbdialist_MouseClick(object sender, MouseEventArgs e)
        {
                selected = mindmap.presentatie.searchDia(lbdialist.SelectedIndex);
                updateForm();
                
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

        private void generateBtn_Click(object sender, EventArgs e)
        {
             Presenter presenter = new Presenter(mindmap.presentatie);
             presenter.Show();
             this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnoteconfirm_Click(object sender, EventArgs e)
        {
            selected.updateNotitie(textBox1.Text);
            textBox1.Text = selected.Notitie.tekst;
        }
    }
}

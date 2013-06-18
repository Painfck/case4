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
    public partial class Presenter : Form
    {
        private Presentatie presentation;
        private Graphics graphics;

        public Presenter(Presentatie presentation)
        {
            InitializeComponent();
            this.presentation = presentation;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            graphics = pbdiaview.CreateGraphics();
        }

        private void pbdiaview_Click(object sender, EventArgs e)
        {
            presentation.nextDia();
            presentation.Display(graphics);
        }


    }
}

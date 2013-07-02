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
    /// <summary>
    /// Deze klasse is gemaakt door: Léon van de Broek, in deze klasse wordt een form gegenereert dat de primaire presenter is. 
    /// De presenter is het canvas waarop de diverse dia's worden getoond. Het is een full-screen form. 
    /// </summary>
    public partial class Presenter : Form
    {
        private Presentatie presentation;
        private Graphics graphics;

        /// <summary>
        /// dit is de constructor waarin de diverse settings worden geset voro de diverse properties die te maken hebben met 
        /// het maximaliseren van het form en het ervoor zorgen dat er geen rand / bar boven en aan de zijkanten van het form
        /// zichtbaar zijn. Daarnaast wordt er een canvas gecreerd met het CreateGraphics() statement.
        /// </summary>
        public Presenter(Presentatie presentation)
        {
            InitializeComponent();
            this.presentation = presentation;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            graphics = pbdiaview.CreateGraphics();
        }

        //Dit event wordt afgevuurd wanneer er op het form wordt geklikt, hierdoor wordt er 
        //er gekeken naar de nextdia() deze wordt dan aangeroepen en de presentatieklasse doet zijn werk
        //wnaneer deze methode true aangeeft wordt het form gesloten, als het false aangeeft wordt de graphics
        //leeggemaakt en wordt er een display() commando gegeen aan de presentatieklasse waarbij de betreffende
        //dia wordt weergegeven.
        private void pbdiaview_Click(object sender, EventArgs e)
        {
            if (!presentation.nextDia())
            {
                this.Dispose();
            }
            else
            {
                graphics.Clear(Color.White);
                presentation.Display(graphics);
            }

        }


    }
}

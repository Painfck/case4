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
    /// Dit form is ontworpen en geimplementeerd door: Léon van de Broek.
    /// Dit form beschrijft een settings-form dat wordt getoond wanneer de gebruiker klikt op "presentatie maken" in het hoofdform.
    /// Hier worden de event-handlers gedefinieerd en worden de events ook afgehandeld. Er is getracht zo min mogelijk intelligentie
    /// in het form te brengen. En ben van mening dat dit ook aardig gelukt is.
    /// </summary>
    public partial class EditPresentatie : Form
    {
        /// <summary>
        /// hieronder de attributen voor het form
        /// </summary>
        private Graphics graphics;
        BussinesLayer.Mindmap.MindMap mindmap;
        private IList<string> dianame;
        private Dia selected;

        /// <summary>
        /// de constructor waarin een mindmap wordt aangereikt. In deze mindmap wordt vervolgens middels de methode: CreatePresentatie() gekeken
        /// of de presentatie al bestaat of dat er een nieuwe aangemaakt moet worden (een soort SingleTon implementatie) maar dan per mindmap.
        /// Zo kan  1 mindmap slechts 1 en minimaal 0 presentaties bevatten.
        /// </summary>
        /// <param name="mindmap"></param>
        public EditPresentatie(BussinesLayer.Mindmap.MindMap mindmap)
        {
            InitializeComponent();
            mindmap.CreatePresentatie();
            this.mindmap = mindmap;
            graphics = pbdiapreview.CreateGraphics();
            updateForm();
        }
        /// <summary>
        /// hieronder staat een method ebeschreven die ervoro zorgt dat het form wordt geupdate. Dit betekend dat diverse aspecten van het form worden
        /// gerefreshed zoals de textbox (naar de inhoud van bijv. een andere dia). etc..
        /// </summary>
        private void updateForm()
        {
            dianame = mindmap.presentatie.getDiaName();
            lbdialist.DataSource = dianame;
            lbdialist.ClearSelected();
            graphics.Clear(Color.White);
            tbnotitietekst.Text = "";
            if (selected != null)
            {
                selected.SmallDisplay(graphics);
                if (selected.Notitie != null)
                {
                    tbnotitietekst.Text = selected.Notitie.tekst;
                }
            }
        }

            /// <summary>
            /// dit onderstaande event wordt afgehandeld wanneer op het dialist wordt geklikt. Er wordt dan meteen 
            /// gekeken welke dia geselecteerd is en dee wordt als de "selected" dia opgeslagen. Hierna wordt het 
            /// form geupdate waardoor alle informatie van het selected-dia wordt weergegeven.
            /// </summary>
        private void lbdialist_MouseClick(object sender, MouseEventArgs e)
        {
                selected = mindmap.presentatie.searchDia(lbdialist.SelectedIndex);
                updateForm();
                
        }


        /// <summary>
        /// wanneer op het knopje: "omhoog" wordt geklitk wordt de geselecteerde dia een plaats
        /// omhoog geschoven in de lijst. (nog niet werkend!)
        /// </summary>
        private void btomhoog_Click(object sender, EventArgs e)
        {
            mindmap.presentatie.reArrangeup(selected);
            updateForm();
            selected = null;
        }

        /// <summary>
        /// wanneer op het knopje: "omlaag" wordt geklitk wordt de geselecteerde dia een plaats
        /// omlaag geschoven in de lijst. (nog niet werkend!)
        /// </summary>
        private void btomlaag_Click(object sender, EventArgs e)
        {
            mindmap.presentatie.reArrangedown(selected);
            updateForm();
            selected = null;
        }


        /// <summary>
        /// wanneer dit event wordt afgehandeld wordt de presentatie daadwerkelijk aangemaakt. er wordt een presenter-form aangemaakt en deze krijgt
        /// de huidige mindmap.presentatie mee. Hierop kan de presenter actie ondernemen en de relevante commando's om de data weer te geven afvuren.
        /// </summary>
        private void generateBtn_Click(object sender, EventArgs e)
        {
             Presenter presenter = new Presenter(mindmap.presentatie);
             presenter.Show();
             this.Close();
        }


        /// <summary>
        /// wanneer op Cancel wordt geklikt in het form wordt het form gesloten (verwijderd uit geheugen).
        /// </summary>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        /// <summary>
        /// wanneer op het confirmknopje wordt geklikt wordt er een sein gegeven (middels een methode) aan de geselecteerde
        /// dia dat de notitie van die dia moet worden geupdate met de tekst die in de textbox is ingetypt.
        /// </summary>
        private void btnoteconfirm_Click(object sender, EventArgs e)
        {
            selected.updateNotitie(tbnotitietekst.Text);
            tbnotitietekst.Text = selected.Notitie.tekst;
        }
    }
}

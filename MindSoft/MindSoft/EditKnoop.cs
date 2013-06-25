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
        Knoop knoop;
        private List<string> hyperlinknames;
        private List<string> tekstennames;
        private List<string> plaatjesnames;

        private List<BussinesLayer.Hyperlink> hyperlinks;
        private List<BussinesLayer.Text> teksten;
        private List<BussinesLayer.Media> plaatjes;

        private Text selectedText;
        private Hyperlink selectedHyperlink;
        private Media selectedMedia;

        private Graphics canvas;

        public EditKnoop(Knoop knoop)
        {
            try
            {
                InitializeComponent();
                this.knoop = knoop;

                teksten = new List<Text>();
                hyperlinks = new List<Hyperlink>();
                plaatjes = new List<Media>();

                plaatjesnames = new List<string>();
                hyperlinknames = new List<string>();
                tekstennames = new List<string>();

                foreach (Inhoud inhoud in knoop.inhoudlist)
                {

                    if (inhoud is BussinesLayer.Text)
                    {
                        tekstennames.Add(inhoud.name);
                        teksten.Add((BussinesLayer.Text)inhoud);
                    }
                    else if (inhoud is BussinesLayer.Hyperlink)
                    {
                        hyperlinknames.Add(inhoud.name);
                        hyperlinks.Add((BussinesLayer.Hyperlink)inhoud);
                    }
                    else if (inhoud is BussinesLayer.Media)
                    {
                        plaatjesnames.Add(inhoud.name);
                        plaatjes.Add((BussinesLayer.Media)inhoud);
                    }
                    else { }

                }
                // vul alle formelementen zoals (eerste blok: de textboxen, tweede blok: de comboboxen, 
                // derde blok: selectedindex van de cb's, canvas, webview etc..)

                tbhyperlink.Text = hyperlinks.First().url;
                tbplaatjepad.Text = plaatjes.First().path;
                tbtextinhoud.Text = teksten.First().textInhoud;

                cbhyperlinklist.DataSource = hyperlinknames;
                cbplaatjeslist.DataSource = plaatjesnames;
                cbtextitems.DataSource = tekstennames;

                cbhyperlinklist.SelectedIndex = 0;
                cbplaatjeslist.SelectedIndex = 0;
                cbtextitems.SelectedIndex = 0;

                canvas = pbplaatje.CreateGraphics();
                canvas.DrawImage(plaatjes.First().content, plaatjes.First().content.Width, plaatjes.First().content.Height);

                wbhyperlinkcontent.Navigate(hyperlinks.First().url);

            }
            catch (NullReferenceException)
            { }
            catch (InvalidOperationException) 
            { }
        }
        //event handlers voor als er op confirmknop wordt geklikt in de 3 tabs, bijbehorende object wordt gezocht en gevonden, 
        // hierop wordt de update aangeroepen die de interface instelt met de properties van het geselecteerde object.
        private void btconfirmplaatje_Click(object sender, EventArgs e)
        {
            foreach (Media media in plaatjes)
            {
                if (media.name == cbtextitems.SelectedText)
                {
                    updatePlaatje(media);
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        private void btconfirmhyperlink_Click(object sender, EventArgs e)
        {
            foreach (Hyperlink hyperlink in hyperlinks)
            {
                if (hyperlink.name == cbtextitems.SelectedText)
                {
                    updateHyperlink(hyperlink);
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        private void btconfirmselectedtext_Click(object sender, EventArgs e)
        {
            foreach (Text text in teksten)
            {
                if (text.name == cbtextitems.SelectedText)
                {
                    updateTekst(text);
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        // deze methoden zijn bedoeld om de interface op de hoogte te brengen van de inhoud van een plaatje, hyperlink of tekst
        private void updatePlaatje(Media media)
        {
            selectedMedia = media;
            canvas = pbplaatje.CreateGraphics();
            selectedMedia.Draw(canvas);
            tbplaatjepad.Text = selectedMedia.path;
            cbplaatjeslist.SelectedText = selectedMedia.name;
        }
        private void updateHyperlink(Hyperlink hyperlink)
        {
            selectedHyperlink = hyperlink;
            wbhyperlinkcontent.Navigate(selectedHyperlink.url);
            tbhyperlink.Text = selectedHyperlink.url;
        }
        private void updateTekst(Text text)
        {
            selectedText = text;
            tbtextinhoud.Text = selectedText.textInhoud;
            cbtextitems.DataSource = tekstennames;
        }
        

        // hier wordt de knoop van dit form geupdate met de nieuwste wijzigingen die zijn aangebracht in de tijdelijke lists van dit form.
        // wanneer het form gesloten wordt dient door de bovenliggende forms de waarden doorgespeeld te worden aan de mindmap klasse zodat de 
        // knoop in de list terecht komt en kan worden aangepast.
        private Knoop UpdatedKnoop()
        {
            knoop.inhoudlist.Clear();
            foreach (Inhoud inhoud in teksten)
            {
                knoop.inhoudlist.Add(inhoud);
            }
            foreach (Inhoud inhoud in plaatjes)
            {
                knoop.inhoudlist.Add(inhoud);
            }
            foreach (Inhoud inhoud in hyperlinks)
            {
                knoop.inhoudlist.Add(inhoud);
            }
            return knoop;
        }




        private void EditKnoop_Load(object sender, EventArgs e)
        {
            
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            tbtextinhoud.Text = "";
            btconfirm.Show();
        }

        private void btconfirm_Click(object sender, EventArgs e)
        {
            Text text = new Text(tbtextinhoud.Text, new Point(0,0));
            teksten.Insert(0,text);
            tekstennames.Insert(0, text.name);
            updateTekst(text);
            btconfirm.Hide();
        }

    }
}

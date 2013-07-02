using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace BussinesLayer
{
    /// <summary>
    /// deze klasse is gemaakt en ontworpen door Léon van de Broek, in deze klasse wordt een Dia omschreven. Er zijn diverse attributen aanwezig die ervoor zorgen
    /// dat de dia de benodigde informatie bevat. Zo wordt in deze klasse de inhoud van de knoop gescheiden in 3 verschillende lijsten waardoor het tekenen van de 
    /// diverse inhoud-objecten een stuk gemakkelijker wordt.
    /// </summary>
    public class Dia
    {
        #region attributen
        private IList<Text> bullets;
        public Font diafont = new Font("Arial", 24);
        public Font dianotefont = new Font("Arial", 20);
        public Font smalldisplayfont = new Font("Arial", 9);
        public Notitie Notitie;
        public int diaid;
        #endregion

        #region constructors
        /// <summary>
        /// hieronder vind men de constructor. Deze constructor krijgt een knoop en een id aangeleverd. het id wordt bewaard in het dia-object
        /// de knoop wordt opgedeeld. de knoop heeft een inhoudlist. Alle tekst uit deze inhoudlist wordt appart in de lijst: bullets geplaatst.
        /// hierna kan gemakkelijk door de drawmethode de bulletlijst worden afgelopen. Dit kan worden uitgebreid met een extra loop voor bijv. alle
        /// Bitmaps in de inhoudlist van de knoop.
        /// </summary>
        public Dia(Knoop knoop, int diaid)
        {
            this.diaid = diaid;
            bullets = new List<Text>();
                foreach (Text text in knoop.inhoudlist)
                {
                    bullets.Add(text);
                }
        }
        #endregion 

        #region displaymethods
        //hieronder wordt de drawmethode gedeclareerd. Hierbij worden de diverse "bullets" uit de lijst op een mooie manier (onder elkaaR) 
        //weergegeven.
        public void Draw(Graphics graphics)
        {
            float x, y;
            x = 100;
            y = 100;

            foreach(Text text in bullets)
            {
                if (y < 600)
                {
                    graphics.DrawString(text.textInhoud, diafont, text.brush, new PointF(x, y));
                    if (Notitie != null)
                    {
                        graphics.DrawString(Notitie.tekst, dianotefont, text.brush, new PointF(x, (y + 30)));
                    }
                    y += 30;
                }
                else
                {
                    y = 50;
                    x += 100;
                    graphics.DrawString(text.textInhoud, diafont, text.brush, new PointF(x, y));
                    if (Notitie != null)
                    {
                        graphics.DrawString(Notitie.tekst, dianotefont, text.brush, new PointF(x, (y + 30)));
                    }
                }
            }
            //foreach (string obj in medialist)
            //{
            //    graphics.DrawImage(null/*obj.content*/, new Point(Convert.ToInt32(x), Convert.ToInt32(y)));
            //    y += 10 /* obj.content.length */;
            //}

            //foreach(string obj in hyperlist)
            //{
            //    if (y < 600)
            //    {
            //        graphics.DrawString(obj, diafont, new SolidBrush(Color.Black), new PointF(x, y));
            //    }
            //    else
            //    {
            //        y = 10;
            //        x += 100;
            //        graphics.DrawString(obj, diafont, new SolidBrush(Color.Black), new PointF(x, y));
            //    }
            //}
        }
        public void SmallDisplay(Graphics graphics)
        {
            float x, y;
            x = 10;
            y = 10;

            foreach (Text text in bullets)
            {
                if (y < 300)
                {
                    graphics.DrawString(text.textInhoud, smalldisplayfont, text.brush, new PointF(x, y));
                    y += 12;
                }
                else
                {
                    y = 30;
                    x += 30;
                    graphics.DrawString(text.textInhoud, smalldisplayfont, text.brush, new PointF(x, y));
                }
            }
        }
        #endregion

        /// <summary>
        /// in deze methode wordt de notitie geupdate met een string tekst. hierbij wordt gekeken
        /// of de notitie ooit al is aangemaakt, wanneer de notitie al is aangemaakt wordt alleen de 
        /// tekst veranderd. als de notitie nog niet is aangemaakt wordt een nieuwe notitie aangemaakt met
        /// de string tekst.
        /// </summary>
        public void updateNotitie(string tekst)
        {
            if (Notitie == null)
            {
                Notitie = new Notitie(tekst);
            }
            else
            {
                Notitie.tekst = tekst;
            }
        }
    }
}

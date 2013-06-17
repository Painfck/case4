using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BussinesLayer
{

    public class Knoop
    {
        #region attributen

        protected Pen pen;
        protected Color kleur;
        
        //List voor het bijhouden van de inhoud.
        public IList<Inhoud> inhoudlist;

        //Opmaak van de knoop
        public Opmaak opmaak;
        public Opmaak Opmaak
        {
            get { return opmaak; }
            set { opmaak = value; }
        }

        //Positie van de knoop
        public Point positie;
        public Point Positie
        {
            get { return positie; }
            set { positie = value; }

        }

        #endregion
        public Knoop()
        {
            kleur = Color.Black;
            pen = new Pen(kleur);
            positie = new Point(10, 10);

        }

        public void Teken(Graphics canvas)
        {
            canvas.DrawRectangle(pen, positie.X, positie.Y, 200, 200);
        }

        public Size size { get; set; }
    }
}

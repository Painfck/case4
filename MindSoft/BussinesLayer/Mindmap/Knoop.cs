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

        // Kenmerken van de knoop
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

        //Grootte van de knoop
        public Size size;
        public Size Size
        {
            get { return size; }
            set { size = value; }
        }
        #endregion

        public Knoop()
        {
            kleur = Color.Black;
            pen = new Pen(kleur);
            positie = new Point(10, 10);

        }

        public Knoop(int positieX, int positieY)
        {
            kleur = Color.Black;
            pen = new Pen(kleur);
            this.positie.X = positieX;
            this.positie.Y = positieY;
            this.size.Width = 200;
            this.size.Height = 20;
        }

        public void Teken(Graphics canvas)
        {
            canvas.DrawRectangle(pen, positie.X, positie.Y, size.Width, size.Height);
        }

        public bool Selected(int posX, int posY)
        {
            return (posX >= positie.X && posX < positie.X + size.Width && posY >= positie.Y && posY < positie.Y + size.Height);
        }

    
    }
}

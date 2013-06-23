using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using BussinesLayer.Mindmap;

namespace BussinesLayer
{

    public class Knoop
    {

        private enum PosSizableRect
        {
            UpMiddle,
            LeftMiddle,
            LeftBottom,
            LeftUp,
            RightUp,
            RightMiddle,
            RightBottom,
            BottomMiddle,
            None

        }

        #region Attributen

        // Kenmerken van de knoop
        protected Pen pen;
        protected Color kleur;
        public MindMapDelegate.Toon ToonDelegate;
        private int sizeNodeRect = 5;
        public Rectangle rect;
        
        //List voor het bijhouden van de inhoud & maak hem gelijk aan zodra de class wordt aangeroepen.
        public IList<Inhoud> inhoudlist = new List<Inhoud>();


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
        public Size zoomedsize;
        public Size zoomedSize
        {
            get { return zoomedSize; }
            set { zoomedSize = value; }
        }
        #endregion


        #region Methoden
        public Knoop()
        {
            kleur = Color.Black;
            pen = new Pen(kleur);
            positie = new Point(10, 10);
        }

        //Constructer
        public Knoop(int positieX, int positieY, Size size)
        {
            kleur = Color.Black;
            pen = new Pen(kleur);
            rect = new Rectangle(positieX, positieY, size.Width, size.Height);
            this.positie.X = positieX;
            this.positie.Y = positieY;
            this.size = size;
            Inhoud inhoudKnoop = new Text("Lorem ipsum", positie);
            inhoudlist.Add(inhoudKnoop);
        }

        //Teken methode om de knoop met al zijn attributen te tekenen op de canvas.
        public virtual void Teken(Graphics canvas)
        {
            canvas.DrawRectangle(pen, rect);
            foreach (PosSizableRect pos in Enum.GetValues(typeof(PosSizableRect)))
            {
                canvas.DrawRectangle(pen, GetRect(pos));
            }
            foreach (Inhoud inhoud in inhoudlist)
            {
                inhoud.Draw(canvas);

            }
        }

        //Return de waarde van de geselecteerde knoop
        public bool Selected(int posX, int posY)
        {
            return (posX >= positie.X && posX < positie.X + size.Width && posY >= positie.Y && posY < positie.Y + size.Height);
        }

        //Draw methode voor aanmaken van anchor points
        private Rectangle CreateRectSizableNode(int x, int y)
        {
            return new Rectangle(x - sizeNodeRect / 2, y - sizeNodeRect / 2, sizeNodeRect, sizeNodeRect);
        }

        //Maak de anchor points aan voor het resizen van de knoop
        private Rectangle GetRect(PosSizableRect p)
        {
            switch (p)
            {
                case PosSizableRect.LeftUp:
                    return CreateRectSizableNode(rect.X, rect.Y);

                case PosSizableRect.LeftMiddle:
                    return CreateRectSizableNode(rect.X, rect.Y + +rect.Height / 2);

                case PosSizableRect.LeftBottom:
                    return CreateRectSizableNode(rect.X, rect.Y + rect.Height);

                case PosSizableRect.BottomMiddle:
                    return CreateRectSizableNode(rect.X + rect.Width / 2, rect.Y + rect.Height);

                case PosSizableRect.RightUp:
                    return CreateRectSizableNode(rect.X + rect.Width, rect.Y);

                case PosSizableRect.RightBottom:
                    return CreateRectSizableNode(rect.X + rect.Width, rect.Y + rect.Height);

                case PosSizableRect.RightMiddle:
                    return CreateRectSizableNode(rect.X + rect.Width, rect.Y + rect.Height / 2);

                case PosSizableRect.UpMiddle:
                    return CreateRectSizableNode(rect.X + rect.Width / 2, rect.Y);
                default:
                    return new Rectangle();
            }
        }

        //Verplaats de knopen en zijn attributen
        public void MoveKnoop(int posX, int posY)
        {
            positie.X = posX;
            positie.Y = posY;
            rect.X = posX;
            rect.Y = posY;
            foreach (Inhoud inhoud in inhoudlist)
            {
                inhoud.Move(posX, posY);
            }
        }

        #endregion
    }
}

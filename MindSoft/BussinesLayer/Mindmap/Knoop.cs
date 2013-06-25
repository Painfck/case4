using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using BussinesLayer.Mindmap;

namespace BussinesLayer
{

    public class Knoop
    {

        public enum KnoopAnchor
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

        public enum KnoopStatus
        {
            Selected,
            Edit,
            None
        }

        #region Attributen
        // Kenmerken van de knoop
        protected Pen pen;
        protected Color kleur;

        private int sizeKnoopAnchor = 8;
        public KnoopAnchor activeAnchor = KnoopAnchor.None;
        public KnoopStatus knoopStatus = KnoopStatus.None;
        public int oldY, oldX;

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
            this.positie.X = positieX;
            this.positie.Y = positieY;
            rect = new Rectangle(positieX, positieY, size.Width, size.Height);
            this.size = size;
            Inhoud inhoudKnoop = new Text("Lorem ipsum", positie);
            inhoudlist.Add(inhoudKnoop);
        }

        //Teken methode om de knoop met al zijn attributen te tekenen op de canvas.
        public virtual void Teken(Graphics canvas)
        {
            rect.X = this.positie.X;
            rect.Y = this.positie.Y;
            if (knoopStatus == KnoopStatus.Selected)
            {
                
                foreach (KnoopAnchor pos in Enum.GetValues(typeof(KnoopAnchor)))
                {
                    canvas.DrawRectangle(pen, GetRect(pos));
                }

            }
            
            foreach (Inhoud inhoud in inhoudlist)
            {
                inhoud.Draw(canvas);

            }
            canvas.DrawRectangle(pen, rect);
        }

        //Return de waarde van de geselecteerde knoop
        public bool isKnoopSelected(int posX, int posY)
        {
            return (rect.Contains(new Point(posX, posY)));
        }

        //Draw methode voor aanmaken van anchor points
        private Rectangle CreateAnchor (int x, int y)
        {
            return new Rectangle(x - sizeKnoopAnchor / 2, y - sizeKnoopAnchor / 2, sizeKnoopAnchor, sizeKnoopAnchor);
        }

        //Maak de anchor points aan voor het resizen van de knoop
        private Rectangle GetRect(KnoopAnchor anchor)
        {
            switch (anchor)
            {
                case KnoopAnchor.LeftUp:
                    return CreateAnchor(rect.X, rect.Y);

                case KnoopAnchor.LeftMiddle:
                    return CreateAnchor(rect.X, rect.Y + rect.Height / 2);

                case KnoopAnchor.LeftBottom:
                    return CreateAnchor(rect.X, rect.Y + rect.Height);

                case KnoopAnchor.BottomMiddle:
                    return CreateAnchor(rect.X + rect.Width / 2, rect.Y + rect.Height);

                case KnoopAnchor.RightUp:
                    return CreateAnchor(rect.X + rect.Width, rect.Y);

                case KnoopAnchor.RightBottom:
                    return CreateAnchor(rect.X + rect.Width, rect.Y + rect.Height);

                case KnoopAnchor.RightMiddle:
                    return CreateAnchor(rect.X + rect.Width, rect.Y + rect.Height / 2);

                case KnoopAnchor.UpMiddle:
                    return CreateAnchor(rect.X + rect.Width / 2, rect.Y);
                default:
                    return new Rectangle();
            }
        }

        //Set de Anchorpoint
        public void AnchorSelected(int posX, int posY)
        {
            this.activeAnchor = KnoopAnchor.None;
            Point p = new Point(posX,posY);
            foreach (KnoopAnchor anchor in Enum.GetValues(typeof(KnoopAnchor)))
            {
                if (GetRect(anchor).Contains(p))
                {
                    this.activeAnchor = anchor;
                }
            }
            
        }
       
        //Bewerk de knopen en zijn attributen
        public void MoveKnoop(int posX, int posY)
        {
           Rectangle backupRect = rect;

            switch (activeAnchor)
            {
                case KnoopAnchor.LeftUp:
                    this.positie.X += posX - oldX;
                    rect.Width -= posX - oldX;
                    this.positie.Y += posY - oldY;
                    rect.Height -= posY - oldY;
                    break;
                case KnoopAnchor.LeftMiddle:
                    this.positie.X += posX - oldX;
                    rect.Width -= posX - oldX;
                    break;
                case KnoopAnchor.LeftBottom:
                    rect.Width -= posX - oldX;
                    this.positie.X += posX - oldX;
                    rect.Height += posY - oldY;
                    break;
                case KnoopAnchor.BottomMiddle:
                    rect.Height += posY - oldY;
                    break;
                case KnoopAnchor.RightUp:
                    rect.Width += posX - oldX;
                    this.positie.Y += posY - oldY;
                    rect.Height -= posY - oldY;
                    break;
                case KnoopAnchor.RightBottom:
                    rect.Width += posX - oldX;
                    rect.Height += posY - oldY;
                    break;
                case KnoopAnchor.RightMiddle:
                    rect.Width += posX - oldX;
                    break;

                case KnoopAnchor.UpMiddle:
                    this.positie.Y += posY - oldY;
                    rect.Height -= posY - oldY;
                    break;
                default:
                    
                    {
                        this.positie.X = rect.X + posX - oldX;
                        this.positie.Y = rect.Y + posY - oldY;
                        //Verplaats de inhoud
                        foreach (Inhoud inhoud in inhoudlist)
                        {
                            inhoud.Move(rect.X + posX - oldX, rect.Y + posY - oldY);
                        }
                    }
                    break;
            }
            oldX = posX;
            oldY = posY;
        }

        //Edit de inhoud van een knoop
        public void EditKnoop(string text)
        {
            
        }
        #endregion
    }
}

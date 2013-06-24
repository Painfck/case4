﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using BussinesLayer.Mindmap;

namespace BussinesLayer
{

    public class Knoop
    {

        private enum KnoopAnchor
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
        // public MindMapDelegate.Toon ToonDelegate;
        // Kenmerken van de knoop
        protected Pen pen;
        protected Color kleur;

        private int sizeKnoopAnchor = 5;
        private KnoopAnchor activeAnchor = KnoopAnchor.None;
        public KnoopStatus knoopStatus = KnoopStatus.None;

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
        }

        //Return de waarde van de geselecteerde knoop
        public bool isKnoopSelected(int posX, int posY)
        {
            return (posX >= positie.X && posX < positie.X + size.Width && posY >= positie.Y && posY < positie.Y + size.Height);
        }

        //Draw methode voor aanmaken van anchor points
        private Rectangle CreateAnchor (int x, int y)
        {
            return new Rectangle(x - sizeKnoopAnchor / 2, y - sizeKnoopAnchor / 2, sizeKnoopAnchor, sizeKnoopAnchor);
        }

        //Maak de anchor points aan voor het resizen van de knoop
        private Rectangle GetRect(KnoopAnchor p)
        {
            switch (p)
            {
                case KnoopAnchor.LeftUp:
                    return CreateAnchor(rect.X, rect.Y);

                case KnoopAnchor.LeftMiddle:
                    return CreateAnchor(rect.X, rect.Y + +rect.Height / 2);

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

        //Verplaats de knopen en zijn attributen
        public void MoveKnoop(int posX, int posY)
        {
            //String
            positie.X = posX;
            positie.Y = posY;
            //Rectangle
            rect.X = rect.Width - posX;
            rect.Y = posY;
            foreach (Inhoud inhoud in inhoudlist)
            {
                inhoud.Move(posX, posY);
            }
        }

        public void ResizeKnoop(int posX, int posY)
        {
            Rectangle backupRect = rect;

            //switch (nodeSelected)
            //{
            //    case KnoopNodes.LeftUp:
            //        rect.X += e.X - oldX;
            //        rect.Width -= e.X - oldX;
            //        rect.Y += e.Y - oldY;
            //        rect.Height -= e.Y - oldY;
            //        break;
            //    case KnoopNodes.LeftMiddle:
            //        rect.X += e.X - oldX;
            //        rect.Width -= e.X - oldX;
            //        break;
            //    case KnoopNodes.LeftBottom:
            //        rect.Width -= e.X - oldX;
            //        rect.X += e.X - oldX;
            //        rect.Height += e.Y - oldY;
            //        break;
            //    case KnoopNodes.BottomMiddle:
            //        rect.Height += e.Y - oldY;
            //        break;
            //    case KnoopNodes.RightUp:
            //        rect.Width += e.X - oldX;
            //        rect.Y += e.Y - oldY;
            //        rect.Height -= e.Y - oldY;
            //        break;
            //    case KnoopNodes.RightBottom:
            //        rect.Width += e.X - oldX;
            //        rect.Height += e.Y - oldY;
            //        break;
            //    case KnoopNodes.RightMiddle:
            //        rect.Width += e.X - oldX;
            //        break;

            //    case KnoopNodes.UpMiddle:
            //        rect.Y += e.Y - oldY;
            //        rect.Height -= e.Y - oldY;
            //        break;
            //}
        }

        #endregion
    }
}

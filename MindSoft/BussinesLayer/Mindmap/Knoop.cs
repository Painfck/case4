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

        #region attributen

        // Kenmerken van de knoop
        protected Pen pen;
        protected Color kleur;
        protected Font font = new Font("Times New Roman", 12.0f);
        protected Brush brush = new SolidBrush(Color.Black);
        public MindMapDelegate.Toon ToonDelegate;
        private int sizeNodeRect = 5;
        public Rectangle rect;
        
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
        public Size zoomedsize;
        public Size zoomedSize
        {
            get { return zoomedSize; }
            set { zoomedSize = value; }
        }
        #endregion

        public Knoop()
        {
            kleur = Color.Black;
            pen = new Pen(kleur);
            positie = new Point(10, 10);
        }

        public Knoop(int positieX, int positieY, Size size)
        {
            kleur = Color.Black;
            pen = new Pen(kleur);
            rect = new Rectangle(positieX, positieY, size.Width, size.Height);
            this.positie.X = positieX;
            this.positie.Y = positieY;
        }

        public virtual void Teken(Graphics canvas)
        {
            canvas.DrawRectangle(pen, rect);
            foreach (PosSizableRect pos in Enum.GetValues(typeof(PosSizableRect)))
            {
                canvas.DrawRectangle(new Pen(Color.Red), GetRect(pos));
            }
            canvas.DrawString("Ik ben een knoop ", font, brush, positie.X, positie.Y);
      
  
        }

        public bool Selected(int posX, int posY)
        {
            return (posX >= positie.X && posX < positie.X + size.Width && posY >= positie.Y && posY < positie.Y + size.Height);
        }

        private Rectangle CreateRectSizableNode(int x, int y)
        {
            return new Rectangle(x - sizeNodeRect / 2, y - sizeNodeRect / 2, sizeNodeRect, sizeNodeRect);
        }

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
    
    }
}

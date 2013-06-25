using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BussinesLayer
{
    public class Text : Inhoud
    {

        #region Attributen

        public Font font = new Font("Times New Roman", 12.0f);
        public Brush brush = new SolidBrush(Color.Black);
        public string textInhoud;
        public string name;
        public Point positie;

        //Textinhoud
        public string TextInhoud
        {
            get { return textInhoud; }
            set { textInhoud = value; }
        }
        
        //Positie van de knoop
        public Point Positie
        {
            get { return positie; }
            set { positie = value; }

        }

        #endregion

        #region Methoden
        public Text(string text, Point positie)
        {
            this.textInhoud = text;
            this.positie = positie;
            this.name = text;
        }
        public override void Draw(Graphics canvas)
        {
            canvas.DrawString(textInhoud,font, brush,positie.X, positie.Y);
        }

        public override void Move(int posX, int posY)
        {
            this.positie.X = posX;
            this.positie.Y = posY;
        }

        #endregion
    }
}

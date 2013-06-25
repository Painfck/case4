using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace BussinesLayer
{
    public class Relatie
    {
        public Knoop Knoop2;
        public Knoop Knoop1;

        private static Color kleur = Color.Red;
        private static Brush brush = new SolidBrush(kleur);
        private static Pen pen = new Pen(brush);

        public Relatie(Knoop knoop1, Knoop knoop2)
        {
            this.Knoop1 = knoop1;
            this.Knoop2 = knoop2;
        }
        public void draw(Graphics graphics)
        {
            try
            {//Als knoop 1 precies boven knoop 2 staat
                if (Knoop1.positie.X == Knoop2.positie.X && Knoop1.positie.Y > Knoop2.positie.Y)
                {
                    graphics.DrawLine(pen, Knoop1.positie.X + (Knoop1.rect.Width / 2), Knoop1.positie.Y, Knoop2.positie.X + (Knoop2.rect.Width / 2), Knoop2.positie.Y + Knoop2.rect.Height);
                }

                //Als knoop 1 links van knoop 2 staat
                else if (Knoop1.positie.X > Knoop2.positie.X && Knoop1.positie.Y == Knoop2.positie.Y)
                {
                    int lineHeight = Knoop2.rect.Height/2;
                    if (lineHeight >= Knoop1.rect.Height)
                    {
                        lineHeight = Knoop1.rect.Height/2;
                    }
                    graphics.DrawLine(pen, Knoop1.positie.X, Knoop1.positie.Y + lineHeight, Knoop2.positie.X + Knoop2.rect.Width, Knoop2.positie.Y + lineHeight);
                }

                //Als knoop 1 rechts van knoop 2 staat
                else if (Knoop1.positie.X < Knoop2.positie.X && Knoop1.positie.Y == Knoop2.positie.Y)
                {
                    int lineHeight = Knoop2.rect.Height / 2;
                    if (lineHeight >= Knoop1.rect.Height)
                    {
                        lineHeight = Knoop1.rect.Height / 2;
                    }
                    graphics.DrawLine(pen, Knoop1.positie.X + Knoop1.rect.Width, Knoop1.positie.Y + lineHeight, Knoop2.positie.X, Knoop2.positie.Y + lineHeight);
                }
                // Als knoop 1 links onder van knoop 2 staat
                else if (Knoop1.positie.X <= Knoop2.positie.X && Knoop1.positie.Y >= Knoop2.positie.Y)
                {
                    graphics.DrawLine(pen, Knoop1.positie.X + Knoop1.rect.Width, Knoop1.positie.Y, Knoop2.positie.X, Knoop2.positie.Y + Knoop2.rect.Height);
                }
                //Als knoop 1 precies onder knoop 2 staat
                else if (Knoop1.positie.X == Knoop2.positie.X && Knoop1.positie.Y < Knoop2.positie.Y)
                {
                    graphics.DrawLine(pen, Knoop1.positie.X + (Knoop1.rect.Width / 2), Knoop1.positie.Y + Knoop1.rect.Height, Knoop2.positie.X + (Knoop2.rect.Width / 2), Knoop2.positie.Y);
                }

                

                //Als knoop 1 linksboven knoop2 staat
                else if (Knoop1.positie.X <= Knoop2.positie.X && Knoop1.positie.Y <= Knoop2.positie.Y)
                {
                    graphics.DrawLine(pen, Knoop1.positie.X + Knoop1.rect.Width, Knoop1.positie.Y + Knoop1.rect.Height, Knoop2.positie.X, Knoop2.positie.Y);
                }

                //Als knoop 1 rechtsboven knoop2 staat
                else if (Knoop1.positie.X >= Knoop2.positie.X && Knoop1.positie.Y <= Knoop2.positie.Y)
                {
                    graphics.DrawLine(pen, Knoop1.positie.X, Knoop1.positie.Y + Knoop1.rect.Height, Knoop2.positie.X + Knoop2.rect.Width, Knoop2.positie.Y);
                }

                //Als knoop 1 rechts onder knoop 2 staat
                else if (Knoop1.positie.X >= Knoop2.positie.X && Knoop1.positie.Y >= Knoop2.positie.Y)
                {
                    graphics.DrawLine(pen, Knoop1.positie.X, Knoop1.positie.Y, Knoop2.positie.X + Knoop2.rect.Width, Knoop2.positie.Y + Knoop2.rect.Height);
                }
                

               
            }
            catch (NullReferenceException)
            { }
        }

    }
}
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

        public Relatie(Knoop knoop1, Knoop knoop2)
        {
            this.Knoop1 = knoop1;
            this.Knoop2 = knoop2;
        }
        public void draw(Graphics graphics)
        {
            graphics.DrawLine(new Pen(Color.Black), Knoop1.positie, Knoop2.positie);
        }
        
    }
}
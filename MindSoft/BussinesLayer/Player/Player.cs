using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BussinesLayer
{
    public class Player
    {
        #region attributen

        DateTime time;
        Mindmap.MindMap mindmap;
        IList<Knoop> knopen;
        IList<Relatie> relaties;

        IList<Knoop> knopengetekend = new List<Knoop>();
        IList<Relatie> relatiesgetekend = new List<Relatie>();

        #endregion

        #region constructors

        public Player(Mindmap.MindMap mindmap)
        {
            this.mindmap = mindmap;
            knopen = mindmap.knopenlist;
            relaties = mindmap.relatieslist;
        }

        #endregion

        #region methods

        public void play(Graphics graphics)
        {
            foreach (Knoop knoop in knopen)
            {
                foreach (Relatie relatie in relaties)
                {
                        graphics.DrawEllipse(new Pen(Color.Black), new Rectangle(relatie.Knoop1.Positie, relatie.Knoop1.));
                        graphics.DrawLine(new Pen(Color.Black), relatie.Knoop1.Positie, relatie.Knoop2.Positie);
                        graphics.DrawEllipse(new Pen(Color.Black), new Rectangle(relatie.Knoop2.Positie, relatie.Knoop2.size));
                        //knopen toevoegen in juiste lijst en verwijderen uit andere lijst
                        knopengetekend.Add(relatie.Knoop1);
                        knopengetekend.Add(relatie.Knoop2);
                        knopen.Remove(relatie.Knoop1);
                        knopen.Remove(relatie.Knoop2);
                        //relatie toevoegen in juiste lijst en verwijderen uit andere lijst
                        relatiesgetekend.Add(relatie);
                        relaties.Remove(relatie);
                }
            }
        }

        #endregion
    }
}

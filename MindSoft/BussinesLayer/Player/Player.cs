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
                foreach (Relatie relatie in relaties)
                {
                        relatie.Knoop1.Teken(graphics);
                        relatie.draw(graphics);
                        relatie.Knoop2.Teken(graphics);
                    
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
        public void rewind(Graphics graphics)
        {
            graphics.Clear(Color.White);
            knopen.Clear();
            relaties.Clear();
            knopen = mindmap.knopenlist;
            relaties = mindmap.relatieslist;
            knopengetekend.Clear();
            relatiesgetekend.Clear();
        }
        public void stop(Graphics graphics)
        {
            knopen.Clear();
            relaties.Clear();

            knopengetekend.Clear();
            relatiesgetekend.Clear();

            knopen = mindmap.knopenlist;
            relaties = mindmap.relatieslist;
                foreach (Relatie relatie in relaties)
                {
                    relatie.Knoop1.Teken(graphics);
                    knopengetekend.Add(relatie.Knoop1);

                    relatie.draw(graphics);
                    relatiesgetekend.Add(relatie);

                    relatie.Knoop2.Teken(graphics);
                    knopengetekend.Add(relatie.Knoop2);
                }
        }
        #endregion
    }
}

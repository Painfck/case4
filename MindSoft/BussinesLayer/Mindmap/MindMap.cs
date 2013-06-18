using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Mindmap
{
    public class MindMap
    {
        //Object lijsten
        public IList<Knoop> knopenlist;
        public IList<Relatie> relatieslist;

        //Voor het bepalen van welk object geselecteerd is.
        private Knoop selected;
        
        //Constructer
        public MindMap()
        {
            knopenlist = new List<Knoop>();
            relatieslist = new List<Relatie>();
        }

        //Teken de objecten op het canvas
        public void TekenObjecten(Graphics canvas)
        {
           canvas.Clear(Color.White);
            foreach (Knoop knoop in knopenlist)
            {
                knoop.Teken(canvas);
            }
        }

        //Zoek of de X en Y positie gelijk is aan een van de objecten om
        // te kunnen bepalen of het object geselecteerd is.
        public bool SearchObject(int posX, int posY)
        {
            selected = Search(posX, posY);
            if (selected != null)
            {
                
                return true;
            }

            return false;
        }

        private Knoop Search(int posX, int posY)
        {
            Knoop knoopFound = null;
            foreach (Knoop knoop in knopenlist)
            {
                if (knoop.Selected(posX,posY))
                {
                    knoopFound = knoop;
                    break;
                }
                
            }
            return knoopFound;
        }

        public void MoveKnoop(int posX, int posY)
        {
            selected.positie.X = posX;
            selected.positie.Y = posY;
        }

    }
}

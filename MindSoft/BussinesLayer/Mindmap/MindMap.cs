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
        public Presentatie presentatie;
        public Player player;
        //Voor het bepalen van welk object geselecteerd is.
        private Knoop selected;
        public string name;

        //Constructer
        public MindMap(string name)
        {
            knopenlist = new List<Knoop>();
            relatieslist = new List<Relatie>();
            this.name = name;
        }

        //Teken de objecten op het canvas
        public void TekenObjecten(Graphics canvas)
        {
            canvas.Clear(Color.White);
            foreach (Knoop knoop in knopenlist)
            {
                knoop.Teken(canvas);
            }
            foreach (Relatie relatie in relatieslist)
            {
                relatie.draw(canvas);
            }
        }

        //Controlleert of er een knoop is geselecteerd of niet.
        public bool SearchObject(int posX, int posY)
        {
            selected = Search(posX, posY);
            if (selected != null)
            {
                
                return true;
            }

            return false;
        }

        // zoekt aan de hand van de coordinaten of er een knoop staat op de
        // desbetreffende plek.
        public Knoop Search(int posX, int posY)
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

        public void CreatePresentatie()
        {
            if (presentatie == null)
            {
                presentatie = new Presentatie(this);
            }
            else
            {

            }
        }
    }
}

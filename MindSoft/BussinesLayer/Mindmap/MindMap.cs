﻿using System;
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
        public Knoop selectedKnoop;
        public string name;

        //Constructer
        public MindMap(string name)
        {
            knopenlist = new List<Knoop>();
            relatieslist = new List<Relatie>();
            this.name = name;
            player = new Player(this);
        }
        //controleer of een relatie al is aangemaakt
     
        //Teken de objecten op het canvas
        public void TekenObjecten(Graphics canvas)
        {
            canvas.Clear(Color.White);
            foreach (Knoop knoop in knopenlist)
            {
                if (knoop == selectedKnoop)
                {
                    knoop.knoopStatus = Knoop.KnoopStatus.Selected;
                }
                else
                {
                    knoop.knoopStatus = Knoop.KnoopStatus.None;
                }
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
            selectedKnoop = Search(posX, posY);
            if (selectedKnoop != null)
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
                if (knoop.isKnoopSelected(posX,posY))
                {
                    knoopFound = knoop;
                    break;
                }
            }
            return knoopFound;
        }

        //Verplaats de knoop
        public void MoveKnoop(int posX, int posY)
        {
            selectedKnoop.MoveKnoop(posX, posY);
        }

        public void SearchAnchor(int posX, int posY)
        {
            
            selectedKnoop.AnchorSelected(posX, posY);
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

        public void RemoveActiveKnoop()
        {
            List<Relatie> toDelete = new List<Relatie>();

            foreach (Relatie relatie in relatieslist)
            {
                if (relatie.Knoop1 == selectedKnoop || relatie.Knoop2 == selectedKnoop)
                {
                    toDelete.Add(relatie);
                }
            }

            foreach (Relatie relatie in toDelete)
            {
                relatieslist.Remove(relatie);
            }
            knopenlist.Remove(selectedKnoop);

        }

        public void CreateRelationship(Knoop knoop1, Knoop knoop2)
        {
            if (CheckRelationship(knoop1, knoop2))
            {
                relatieslist.Add(new Relatie(knoop1, knoop2));
            }
        }

        private bool CheckRelationship(Knoop knoop1, Knoop knoop2)
        {

            if (knoop1 != knoop2)
            {
                foreach (Relatie relatie in relatieslist)
                {
                    if ((relatie.Knoop1 == knoop1 && relatie.Knoop2 == knoop2)
                        ||( relatie.Knoop2 == knoop1 && relatie.Knoop1 == knoop2))
                    {
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

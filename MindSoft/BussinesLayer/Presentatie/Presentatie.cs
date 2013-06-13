using BussinesLayer.Mindmap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace BussinesLayer
{
    public class Presentatie
    {
        private Dia currentDia;
        private IList<Dia> dialist;
        public Presentatie(MindMap mindmap)
        {
            foreach (Knoop knoop in mindmap.knopenlist)
            {
                dialist.Add(new Dia(knoop));
            }
        }
        public void reArrange(Dia originalDia, Dia NewDia)
        {
            int originaldiaindex = 0;
            int newdiaindex = 0;
            for (int i = 0; i < dialist.Count(); i++)
            {
                if (dialist.ElementAt<Dia>(i) == NewDia)
                {
                    newdiaindex = i;
                }
                else if (dialist.ElementAt<Dia>(i) == originalDia)
                {
                    originaldiaindex = i;
                }
                else
                {
                    continue;
                }
            }
            dialist.Insert(newdiaindex, originalDia);
            dialist.Insert(originaldiaindex, NewDia);
        }
        public void Display(Graphics graphics)
        {
            currentDia.Draw(graphics);
        }
        public void nextDia()
        {
            if (dialist.IndexOf(currentDia) == dialist.Count())
            {
                currentDia = dialist.ElementAt<Dia>(0);
            }

            else
            {
                for (int i = 0; i < dialist.Count(); i++)
                {

                    if (dialist.ElementAt<Dia>(i) == currentDia)
                    {
                        currentDia = dialist.ElementAt<Dia>(i + 1);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}

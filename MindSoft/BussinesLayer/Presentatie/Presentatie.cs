using BussinesLayer.Mindmap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BussinesLayer
{
    public class Presentatie
    {
        #region attributen
        private Dia currentDia;
        public IList<Dia> dialist;

        #endregion

        #region constructors
        public Presentatie(MindMap mindmap)
        {
            int index = 0;
            dialist = new List<Dia>();
            foreach (Knoop knoop in mindmap.knopenlist)
            {
                dialist.Add(new Dia(knoop, index));
                index++;
            }
        }


        #endregion



        #region arrangemethods
        public void reArrangeup(Dia dia)
        {
            {
                bool found = false;
                int i = 0;
                while (!found)
                {
                    if (dialist.ElementAt(i) == dialist.First<Dia>())
                    {
                        return;
                    }
                    else if (dialist.ElementAt(i) == dia)
                    {
                        found = true;

                        dialist[i] = dialist[(i + 1)];
                        dialist.RemoveAt(i);
                        //dialist.RemoveAt(i);
                        break;
                    }

                    i++;
                }

            }
        }
        public void reArrangedown(Dia dia)
        {
            bool found = false;
            int i = 0;
            while (!found)
            {
                if (dialist.ElementAt(i) == dialist.Last<Dia>())
                {
                    return;
                }
                else if (dialist.ElementAt(i) == dia)
                    {
                        found = true;

                        dialist[i] = dialist[(i + 1)];
                        dialist.RemoveAt(i);
                        //dialist.RemoveAt(i);
                        break;
                    }
                
                i++;
            }

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



        //public Dia searchDia(int diaid)
        //{
        //    foreach (Dia dia in dialist)
        //    {
        //        if (dia.diaid == diaid)
        //        {
        //            return dia;
        //        }
        //        else
        //        {
        //            continue;
        //        }
        //        return null;
        //    }
        //    return null;
        //}
        public Dia searchDia(int diaid)
        {
            foreach (Dia dia in dialist)
            {
                if (dia.diaid == diaid)
                {
                    return dia;
                }
            }
            return null;
        }


        public List<string> getDiaName()
        {
            List<string> tempdialist = new List<string>();

            foreach (Dia dia in dialist)
            {
                tempdialist.Add(String.Format("dia: {0}", dia.diaid));
            }
            return tempdialist;
        }


        #endregion

        #region displaymethods
        public void Display(Graphics graphics)
        {
            currentDia.Draw(graphics);
        }
        #endregion
    }
}

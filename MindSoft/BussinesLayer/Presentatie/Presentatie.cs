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
        public List<Relatie> opvolgendeRelaties;
        private Dia endDia;
        #endregion

        #region constructors
        public Presentatie(MindMap mindmap)
        {
            int index = 0;
            opvolgendeRelaties = new List<Relatie>();
            dialist = new List<Dia>();
            for (int i = 0; i < mindmap.relatieslist.Count(); i++)
            {
                for (int j = 1; j < mindmap.relatieslist.Count(); j++)
                {
                    if (mindmap.relatieslist.ElementAt(i).Knoop2
                        == mindmap.relatieslist.ElementAt(j).Knoop1)
                    {
                        opvolgendeRelaties.Add(mindmap.relatieslist.ElementAt(i));
                        opvolgendeRelaties.Add(mindmap.relatieslist.ElementAt(j));
                    }
                    else if (mindmap.relatieslist.ElementAt(i).Knoop1
                        == mindmap.relatieslist.ElementAt(j).Knoop2)
                    {
                        opvolgendeRelaties.Add(mindmap.relatieslist.ElementAt(j));
                        opvolgendeRelaties.Add(mindmap.relatieslist.ElementAt(i));
                    }
                    else
                    {
                        dialist.Add(new Dia(opvolgendeRelaties, index));
                        index++;
                        opvolgendeRelaties = new List<Relatie>();
                    }
                }
            }
            currentDia = dialist.First<Dia>();
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
        public bool nextDia()
        {
            if (dialist.IndexOf(currentDia) == (dialist.Count()-1))
            {
                Knoop knoop = new Knoop();
                knoop.inhoudlist.Add(new Text("End of the Diashow", new Point(50, 50)));
                return false;
            }
            if (currentDia == endDia)
            {
                currentDia = dialist.First<Dia>();
                return true;
            }
            else
            {
                for (int i = 0; i < (dialist.Count()); i++)
                {

                    if (dialist.ElementAt<Dia>(i) == currentDia)
                    {
                        currentDia = dialist.ElementAt<Dia>(i + 1);
                        break;
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return false;
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

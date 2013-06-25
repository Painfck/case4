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

        private static Presentatie _presentatie;
        private Dia currentDia;
        public IList<Dia> dialist;
        private Dia endDia;
        public MindMap mindmap;
        #endregion

        #region constructors
        private Presentatie()
        {
            
        }
        public void prepareAllContent(MindMap mindmap)
        {
            this.mindmap = mindmap;
            int index = -1;
            dialist = new List<Dia>();
            foreach (Knoop knoop in mindmap.knopenlist)
            {
                dialist.Add(new Dia(knoop, index));
                index++;
            }
            currentDia = dialist.First<Dia>();
        }
        public static Presentatie getPresentatie()
        {
            if (_presentatie == null)
            {
                _presentatie = new Presentatie();
            }
            return _presentatie;
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
                knoop.inhoudlist.Add(new Text("End of the Diashow", new Point(150, 150)));
                endDia = new Dia(knoop, 999);
                currentDia = endDia;
                
                return true;
            }
            if (currentDia == endDia)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < (dialist.Count()); i++)
                {

                    if (dialist.ElementAt<Dia>(i) == currentDia)
                    {
                            currentDia = dialist.ElementAt<Dia>(i + 1);
                            break;
                            return true;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return true;
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

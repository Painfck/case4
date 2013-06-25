using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;
using System.Threading;

namespace BussinesLayer
{
    public class Player
    {
        #region attributen
        public Mindmap.MindMap mindmap;
        IList<Knoop> knopen;
        IList<Relatie> relaties;

        public Graphics drawField { get; set; }
        private int listIndex = 0;
        int relatieCount;
        int knopencount;
        
        Relatie HuidigeRelatie;
        Relatie vorigeRelatie;

        private int playspeed;
        #endregion

        #region constructors

        public Player(Mindmap.MindMap mindmap)
        {
            this.mindmap = mindmap;
            knopen = mindmap.knopenlist;
            relaties = mindmap.relatieslist;
            relatieCount = relaties.Count();
            knopencount = knopen.Count();
        }
        public void updateAttributes()
        {
            knopen = mindmap.knopenlist;
            relaties = mindmap.relatieslist;
            HuidigeRelatie = relaties.First<Relatie>();
        }
        public int getElementCount()
        {
            return knopencount;
        }
        public int getRleatieCount()
        {
            return knopencount;
        }
        public int getCurrentIndex()
        {
            return listIndex;
        }
        #endregion

        #region methods

        public void Draw()
        {
            try
            {
                //if (volgendeRelatie.Knoop1 == HuidigeRelatie.Knoop1)
                //{
                //  
                //    HuidigeRelatie.draw(drawField);
                //    System.Threading.Thread.Sleep(1000);
                //    HuidigeRelatie.Knoop2.Teken(drawField);
                //    
                //}
                //else if (volgendeRelatie.Knoop1 == HuidigeRelatie.Knoop2)
                //{
                //    System.Threading.Thread.Sleep(1000);
                //    HuidigeRelatie.Knoop2.Teken(drawField);
                //}
                //else
                //{
                //
                //}

                    HuidigeRelatie.Knoop1.Teken(drawField);
                    System.Threading.Thread.Sleep(playspeed);
                    HuidigeRelatie.draw(drawField);
                    System.Threading.Thread.Sleep(playspeed);
                    HuidigeRelatie.Knoop2.Teken(drawField);
                    System.Threading.Thread.Sleep(playspeed);
            }
            catch (NullReferenceException exc1)
            { }
        }

        public void play()
        {
            playspeed = 200;

            for (listIndex = 0; listIndex < relaties.Count(); listIndex++)
            {
                if (listIndex == 0)
                {
                    HuidigeRelatie = relaties.ElementAt<Relatie>(listIndex);
                    Draw();
                }
                else if (listIndex > 0)
                {
                    vorigeRelatie = relaties.ElementAt<Relatie>((listIndex - 1));
                    HuidigeRelatie = relaties.ElementAt<Relatie>(listIndex);
                    Draw();
                }
            }
        }
        public void rewind()
        {
            drawField.Clear(Color.White);
        }
        public void stop()
        {
            mindmap.TekenObjecten(drawField);
        }


        #endregion
    }
}

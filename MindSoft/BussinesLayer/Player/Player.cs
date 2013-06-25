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
                foreach (Relatie relatie in relaties)
                {
                    relatie.Knoop1.Teken(drawField);
                    System.Threading.Thread.Sleep(200);
                    relatie.draw(drawField);
                    System.Threading.Thread.Sleep(200);
                    relatie.Knoop2.Teken(drawField);
                }
            }
            catch (NullReferenceException exc1)
            { }
        }

        public void play()
        {
            HuidigeRelatie = relaties.ElementAt<Relatie>(listIndex);

            Draw();
            
            listIndex++;
        }
        public void rewind()
        {
            drawField.Clear(Color.White);
            listIndex = 0;
        }
        public void stop()
        {
            mindmap.TekenObjecten(drawField);
        }


        #endregion
    }
}

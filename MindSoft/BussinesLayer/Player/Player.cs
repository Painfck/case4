using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;
namespace BussinesLayer
{
    public enum playerState
    {
        play,
        stop,
        rewind,
        pauze
    }
    public class Player
    {
        #region attributen

        public Mindmap.MindMap mindmap;
        IList<Knoop> knopen;
        IList<Relatie> relaties;
        Timer timeBetweenDraw;
        public Graphics drawField { get; set; }
        playerState state = playerState.stop;
        private int listIndex = 1;
        int relatieCount;
        int knopencount;
        Relatie HuidigeRelatie;

        #endregion

        #region constructors

        public Player(Mindmap.MindMap mindmap)
        {
            state = playerState.rewind;
            this.mindmap = mindmap;
            knopen = mindmap.knopenlist;
            relaties = mindmap.relatieslist;
            relatieCount = relaties.Count();
            knopencount = knopen.Count();
            //timeBetweenDraw = new Timer();
            //timeBetweenDraw.Interval = 1000;
            //timeBetweenDraw.Elapsed += new ElapsedEventHandler(timeBetweenDraw_Tick);
            //timeBetweenDraw.Start();
        }
        public void updateAttributes()
        {
            knopen = mindmap.knopenlist;
            relaties = mindmap.relatieslist;
            HuidigeRelatie = relaties.First<Relatie>();
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
                    System.Threading.Thread.Sleep(500);
                    relatie.draw(drawField);
                    System.Threading.Thread.Sleep(500);
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
            foreach (Relatie relatie in relaties)
            {
                relatie.Knoop1.Teken(drawField);
                relatie.Knoop2.Teken(drawField);
                relatie.draw(drawField);
            }
        }


        #endregion
    }
}

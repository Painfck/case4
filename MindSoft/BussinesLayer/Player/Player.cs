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

        Mindmap.MindMap mindmap;
        IList<Knoop> knopen;
        IList<Relatie> relaties;
        Timer timeBetweenDraw;
        Graphics drawField;
        playerState state = playerState.stop;
        private int listIndex;
        int relatieCount;
        int knopencount;
        Relatie HuidigeRelatie;
        Relatie VolgendeRelatie;
        Relatie VorigeRelatie;

        #endregion

        #region constructors

        public Player(Mindmap.MindMap mindmap, Graphics drawField)
        {
            this.mindmap = mindmap;
            knopen = mindmap.knopenlist;
            relaties = mindmap.relatieslist;
            relatieCount = relaties.Count();
            knopencount = knopen.Count();
            timeBetweenDraw = new Timer();
            timeBetweenDraw.Interval = 1000;
            timeBetweenDraw.Elapsed += new ElapsedEventHandler(timeBetweenDraw_Tick);
            timeBetweenDraw.Start();
            this.drawField = drawField;
        }


        #endregion

        #region methods


        private void timeBetweenDraw_Tick(object sender, ElapsedEventArgs e)
        {
            if (state == playerState.play)
            {
                play();
                Draw();
            }
            else if (state == playerState.pauze)
            {
                Draw();
            }
            else if (state == playerState.stop)
            {
                stop();
                Draw();
            }
            else if (state == playerState.rewind)
            {
                rewind();
            }
        }

        public void Draw()
        {
                HuidigeRelatie.Knoop1.Teken(drawField);
                HuidigeRelatie.draw(drawField);
                HuidigeRelatie.Knoop2.Teken(drawField);
        }

        public void play()
        {
            HuidigeRelatie = relaties.ElementAt<Relatie>(listIndex);
            VorigeRelatie = relaties.ElementAt<Relatie>(listIndex - 1);
            VolgendeRelatie = relaties.ElementAt<Relatie>(listIndex + 1);

            Draw();
            
            listIndex++;
            timeBetweenDraw.Start();
        }
        public void rewind()
        {
            drawField.Clear(Color.White);
            knopen.Clear();
            relaties.Clear();
            knopen = mindmap.knopenlist;
            relaties = mindmap.relatieslist;
            listIndex = 0;
            timeBetweenDraw.Stop();
        }
        public void stop()
        {
            foreach (Relatie relatie in relaties)
            {
                relatie.Knoop1.Teken(drawField);
                relatie.Knoop2.Teken(drawField);
                relatie.draw(drawField);
            }
            timeBetweenDraw.Stop();
        }


        #endregion
    }
}

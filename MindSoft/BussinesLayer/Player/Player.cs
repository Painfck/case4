using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;
using System.Threading;

namespace BussinesLayer
{
    /// <summary>
    /// deze klasse is ontworpen en gemaakt door: Léon van de Broek
    /// de bedoeling van deze klasse is het afhandelen van alle zaken gerelateerd aan het afspelen van de mindmap in de volgorde waarin
    /// het gecreerd is. (alleen alle huidige relaties en knopen worden getoond, dus niet ALLE wijzigingen aan het form worden weergeven)
    /// Dit geeft de gebruiker wel de mogelijkheid de onstaansgeschiedenis te bekijken van zijn eigen mindmap.
    /// </summary>
    public class Player
    {
        #region attributen
        /// <summary>
        /// hieronder alle attributen die nodig zijn om deze klasse optimaal te laten functioneren
        /// </summary>
        public Mindmap.MindMap mindmap;
        IList<Knoop> knopen;
        IList<Relatie> relaties;

        public Graphics drawField { get; set; }
        private int listIndex = 0;
        int relatieCount;
        int knopencount;
        
        Relatie HuidigeRelatie;

        private int playspeed;
        #endregion

        #region constructor

        public Player(Mindmap.MindMap mindmap)
        {
            this.mindmap = mindmap;
            knopen = mindmap.knopenlist;
            relaties = mindmap.relatieslist;
            relatieCount = relaties.Count();
            knopencount = knopen.Count();
        }
        
        #endregion

        #region methods

        /// <summary>
        /// hieronder alle methodes die nodig zijn voor de player.
        /// </summary>


      /* 
       * hier staat de methode updateAttributen, deze methode zorgt ervoro dat de knopen en relaties van de mindmaplijsten gelijk zijn
       * aan de lijsten die de player heeft bijgehouden. Daarnaast wordt de huidige relatie op de eerste relatie gezet.
      */
        public void updateAttributes()
        {
            knopen = mindmap.knopenlist;
            relaties = mindmap.relatieslist;
            HuidigeRelatie = relaties.First<Relatie>();
        }

        /// <summary>
        /// hieronder wordt de count van de knopenlijst gereturned
        /// </summary>
        /// <returns></returns>
        public int getElementCount()
        {
            return knopencount;
        }

        /// <summary>
        /// hieronder wordt de count van de relatielijst gereturned
        /// </summary>
        /// <returns></returns>
        public int getRleatieCount()
        {
            return knopencount;
        }

        /// <summary>
        /// hieronder wordt de huidige index van de relaties gereturned (bij welke relatie we zijn, zeg maaR)
        /// </summary>
        /// <returns></returns>
        public int getCurrentIndex()
        {
            return listIndex;
        }

        /// <summary>
        /// hieronder de draw-methode van de player. Deze maakt gebruik van system.threading.thread.sleep(playspeed) hiermee wordt de thread
        /// waarin de methode zich beweegt op pauze gezetzonder dat andere threads daar hinder van ondervinden (knopen die niet reageren omdat
        /// de thread op pauze staat etc...)
        /// </summary>
        public void Draw()
        {
            try
            {
                    HuidigeRelatie.Knoop1.Teken(drawField);
                    System.Threading.Thread.Sleep(playspeed);
                    HuidigeRelatie.draw(drawField);
                    System.Threading.Thread.Sleep(playspeed);
                    HuidigeRelatie.Knoop2.Teken(drawField);
                    System.Threading.Thread.Sleep(playspeed);
            }
            catch (NullReferenceException)
            { }
        }


        /// <summary>
        /// hieronder wordt de playmethode weergegeven. Er wordt in een for-loop steeds een nieuwe relatie toegekend aan 
        /// huidigerelatie, dit betreft steeds een VOLGENDE relatie. wanneer de huidigerelatie is geupdate wordt het Draw() methode
        /// aangeroepen. Deze bevat een thread.sleep(playspeed) waardoor de for loop in de play() methode automatisch ook in sleep() gaat.
        /// Hierdoor gaat de loop langzamer en lijkt het alsof een flimpje afspeeld.
        /// </summary>
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
                    HuidigeRelatie = relaties.ElementAt<Relatie>(listIndex);
                    Draw();
                }
            }
        }


        /// <summary>
        /// in de onderstaande methode wordt slechts de rewind-methode afgewerkt, dit wilt zeggen dat het canvas wordt geleegd zodat alle 
        /// objecten verdwenen lijken en dat je terug bent bij af. (rewinded dus).
        /// </summary>
        public void rewind()
        {
            drawField.Clear(Color.White);
        }


        /// <summary>
        /// hier worden alle objecten op de mindmap getekend aangezien op stop is geklikt. zo lijkt het alsof de gebruiker
        /// is teruggekeerd naar het punt waar hij was gebleven in de eidtor
        /// </summary>
        public void stop()
        {
            mindmap.TekenObjecten(drawField);
        }


        #endregion
    }
}

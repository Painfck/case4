using BussinesLayer.Mindmap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BussinesLayer
{
    /// <summary>
    /// deze klasse is gemaakt door Léon van de Broek ITI2A.
    /// het doel van deze klasse is het object presentatie. Dit object regelt alle communicatie tussen de forms en de diverse dia's
    /// ook houdt de presentatie een lijst bij van alle dia's evenals de huidige dia die getoond moet worden. Ook bevat de dia een 
    /// tekenfunctie waarmee de huidige dia het seintje krijgt om zichzelf te tekenen.
    /// </summary>
    /// 
    public class Presentatie
    {
        /// <summary>
        /// alle benodigde attributen zijn hieronder in de regio opgenomen.
        /// </summary>
        #region attributen
        public Dia currentDia;
        public IList<Dia> dialist;
        private Dia endDia;
        public MindMap mindmap;
        public int indexdia = 0;
        #endregion

        #region constructors
        /// <summary>
        /// in deze constructor worden de knopen uit de mindmap allemaal toegewezen aan een apparte dia. 
        /// De dia krijgt een knoop mee, waarmee de dia aan de slag gaat en alle noodzakelijke data uit de knoop
        /// scheidt van de rest. (zie klasse: Dia). Ook wordt hier de eerste dia als huidigedia gezet. Zodat wanneer
        /// de presentatie begint, meteen de eerste dia wordt weergegeven.
        /// </summary>
        public Presentatie(MindMap mindmap)
        {
            this.mindmap = mindmap;
            int index = 0;
            dialist = new List<Dia>();
            foreach (Knoop knoop in mindmap.knopenlist)
            {
                dialist.Add(new Dia(knoop, index));
                index++;
            }
            currentDia = dialist.First();
        }
        #endregion



        #region arrangemethods
        /// <summary>
        /// deze onderstaande reArrangeup en reArrangedown functies zijn deels af. Dit komt doordat het wijzigen van een object
        /// naar een andere plaats in de list lastiger is dan het lijkt. Door tijdgebrek ben ik hier niet/nauwelijks aan toe gekomen.
        /// </summary>
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




        /// <summary>
        /// deze methdoe returned een dia die geselecteerd is aan de hand van het diaid
        /// </summary>
        public Dia searchDia(int diaid)
        {
            foreach (Dia dia in dialist)
            {
                if (dia.diaid == diaid)
                {
                    return dia;
                }
                else
                {
                    continue;
                }
                
            }
            return null;
        }




        /// <summary>
        /// deze onderstaande nextDia methode zorgt ervoro dat de volgende dia in de dialist wordt weergegeven. Daarbij wordt gekeken of 
        /// de dia de een-na-laatste dia betreft (ja: dan wordt een nieuwe dia aangemaakt als EINDDIA met de text End of the diashow. Nee:
        /// dan wordt de volgende dia uit de lijst weergegeven). Ook returned deze methode een true of false waarde waardoor het form weet
        /// of deze zichzelf moet sluiten of niet (wanneer de enddia is weergegeven).
        /// </summary>
        /// <returns></returns>
        public bool nextDia()
        {
            if (indexdia == 0)
            {
                currentDia = dialist.First();
                indexdia++;
                return true;
            }
            else
            {
                if (dialist.IndexOf(currentDia) == (dialist.Count() - 1))
                {
                    //enddia wordt aangemaakt en klaargezet
                    Knoop knoop = new Knoop();
                    knoop.inhoudlist.Add(new Text("End of the Diashow", new Point(150, 150)));
                    endDia = new Dia(knoop, 999);
                    endDia.Notitie = new Notitie("thanks for listening!");
                    currentDia = endDia;

                    return true;
                }
                if (currentDia == endDia)
                {
                    //presentatie wordt gereset en form krijgt het sein dat er geen volgende dia's zijn.
                    currentDia = dialist.First();
                    return false;
                }
                else
                {
                    // volgende dia wordt opgezocht uit de lijst.
                    for (int i = 0; i < (dialist.Count()); i++)
                    {

                        if (dialist.ElementAt<Dia>(i) == currentDia)
                        {
                            currentDia = dialist.ElementAt<Dia>(i + 1);
                            return true;

                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            return true;

        }




        /// <summary>
        /// deze methode wordt gebruikt om een list van dia-namen aan het form mee te geven. 
        /// Dit gebeurt in dezelfde volgorde als hoe de dialist is opgebouwd zodat de volgorde
        /// van de namen en de onderliggende dia's hetzelfde is. Voor nu is ervoor gekozen om 
        /// de dianaam met een getal te laten oplopen (in de release-versie zal dit zijn aangepast,
        /// zodat de dianaam de echte naam van de dia is en geen oplopend getal).
        /// </summary>
        /// <returns></returns>
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



        /// <summary>
        /// hier wordt een methode beschreven die de huidigedia de opdracht geeft om zichzelf te tekenen
        /// </summary>
        /// <param name="graphics"></param>
        public void Display(Graphics graphics)
        {
                currentDia.Draw(graphics);
        }
        #endregion
    }
}

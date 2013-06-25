using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinesLayer
{
    /// <summary>
    /// deze klasse is ontworpen en gemaakt door: Léon van de broek. 
    /// In deze klasse wordt een notitie beschreven. iedere Dia kan 1 notitie bevatten.
    /// Deze notitie wordt dan weergegeven op de dia maar niet in de mindmap. De notitieklasse
    /// is vrij simpel te volgen en gemakkelijk opgebouwd. Zo bevat de notitie 1 attribuut genaamd Tekst.
    /// En heeft de notitie een constructor waarbij de tekst wordt aangeleverd en wordt ingesteld op het 
    /// attribuut.
    /// </summary>
    public class Notitie
    {
        public string tekst;

        public Notitie(string tekst)
        {
            // TODO: Complete member initialization
            this.tekst = tekst;
        }
    }
}

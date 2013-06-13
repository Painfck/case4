using BussinesLayer.Mindmap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinesLayer
{
    public class Presentatie
    {
        private IList<Dia> dialist;
        public Presentatie(MindMap mindmap)
        {
            foreach(Knoop knoop in mindmap.knopenlist)
            {
                dialist.Add(new Dia(knoop));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinesLayer
{
    public class Dia
    {
        private IList<object> bullets;
        private IList<object> medialist;
        private IList<object> hyperlist;

        public Dia(Knoop knoop)
        {
            this.Knoop = knoop;
            foreach (Inhoud inhoud in knoop.inhoudlist)
            {
                if (inhoud is Hyperlink)
                {
                    hyperlist.Add(inhoud.content);
                }
                else if (inhoud is Text)
                {
                    bullets.Add(inhoud.content);
                }
                else if (inhoud is Media)
                {
                    medialist.Add(inhoud.content);
                }
            }
        }
        public Knoop Knoop;
        public Notitie Notitie;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BussinesLayer
{

    public class Knoop
    {
        #region attributen
        private Opmaak huidigeOpmaak;


        public Opmaak Opmaak
        {
            get { return huidigeOpmaak; }
            set { huidigeOpmaak = value; }
        }

        public IList<Inhoud> inhoudlist;
        public Point positie { get; set; }

        #endregion
    }
}

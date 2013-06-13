using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace BussinesLayer
{
    public class Relatie : Knoop
    {
        public  Point point1
        {
            get { return point1; }
        }
        private Point point2
        {
            get { return point2; }
        }
        public Knoop Knoop2
        {
            get { return Knoop2; }
        }

        public Knoop Knoop1
        {
            get { return Knoop1; }
        }

        public IList<Relatie> Relaties;
        }
    }


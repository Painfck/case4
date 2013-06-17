using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Mindmap
{
    public class MindMap
    {
        public IList<Knoop> knopenlist;
        public IList<Relatie> relatieslist;

        public MindMap()
        {

        }

        public void Teken(Graphics canvas)
        {
            foreach (Knoop knoop in knopenlist)
            {
                knoop.Teken(canvas);
            }
        }

    }
}

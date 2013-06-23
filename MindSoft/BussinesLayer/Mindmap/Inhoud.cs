using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BussinesLayer
{
    public abstract class Inhoud
    {
        public string content;

        public abstract void Draw(Graphics canvas);
        public abstract void Move(int posX, int posY);
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BussinesLayer
{
    public class Media : Inhoud
    {
        public string name;
        public Bitmap content;
        public override void Draw(Graphics canvas)
        {
            canvas.DrawImage(content, 0, 0);
        }

        public override void Move(int posX, int posY)
        {
            throw new NotImplementedException();
        }

        public string path { get; set; }
    }
}

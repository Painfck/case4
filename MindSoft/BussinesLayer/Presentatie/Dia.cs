using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace BussinesLayer
{
    public class Dia
    {
        #region attributen
        private IList<string> bullets;
        private IList<string> medialist;
        private IList<string> hyperlist;
        private Font diafont = new Font("Arial", 11);
        public Knoop Knoop;
        public Notitie Notitie;

        #endregion

        #region constructors
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
        #endregion 

        #region displaymethods
        public void Draw(Graphics graphics)
        {
            float x, y;
            x = 10;
            y = 10;

            foreach(string obj in bullets)
            {
                if (y < 600)
                {
                    graphics.DrawString(obj, diafont, new SolidBrush(Color.Black), new PointF(x, y));
                    y += 12;
                }
                else
                {
                    y = 10;
                    x += 100;
                    graphics.DrawString(obj, diafont, new SolidBrush(Color.Black), new PointF(x, y));
                }
            }
            foreach (string obj in medialist)
            {
                graphics.DrawImage(null/*obj.content*/, new Point(Convert.ToInt32(x), Convert.ToInt32(y)));
                y += 10 /* obj.content.length */;
            }

            foreach(string obj in hyperlist)
            {
                if (y < 600)
                {
                    graphics.DrawString(obj, diafont, new SolidBrush(Color.Black), new PointF(x, y));
                }
                else
                {
                    y = 10;
                    x += 100;
                    graphics.DrawString(obj, diafont, new SolidBrush(Color.Black), new PointF(x, y));
                }
            }
        }
        #endregion

    }
}

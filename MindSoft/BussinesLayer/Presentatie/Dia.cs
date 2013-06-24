﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace BussinesLayer
{
    public class Dia
    {
        #region attributen
        private IList<Text> bullets;
        private IList<Media> medialist;
        private IList<Hyperlink> hyperlist;
        private Font diafont = new Font("Arial", 11);
        public Knoop Knoop;
        public Notitie Notitie;
        public int diaid;
        #endregion

        #region constructors
        public Dia(Knoop knoop, int diaid)
        {
            this.Knoop = knoop;
            this.diaid = diaid;
            bullets = new List<Text>();
            foreach (Text text in knoop.inhoudlist)
            {
                bullets.Add(text);
            }
        }
        #endregion 

        #region displaymethods
        public void Draw(Graphics graphics)
        {
            float x, y;
            x = 10;
            y = 10;

            foreach(Text text in bullets)
            {
                if (y < 600)
                {
                    graphics.DrawString(text.textInhoud, text., new SolidBrush(Color.Black), new PointF(x, y));
                    y += 12;
                }
                else
                {
                    y = 10;
                    x += 100;
                    graphics.DrawString(text.textInhoud, diafont, new SolidBrush(Color.Black), new PointF(x, y));
                }
            }
            //foreach (string obj in medialist)
            //{
            //    graphics.DrawImage(null/*obj.content*/, new Point(Convert.ToInt32(x), Convert.ToInt32(y)));
            //    y += 10 /* obj.content.length */;
            //}

            //foreach(string obj in hyperlist)
            //{
            //    if (y < 600)
            //    {
            //        graphics.DrawString(obj, diafont, new SolidBrush(Color.Black), new PointF(x, y));
            //    }
            //    else
            //    {
            //        y = 10;
            //        x += 100;
            //        graphics.DrawString(obj, diafont, new SolidBrush(Color.Black), new PointF(x, y));
            //    }
            //}
        }
        #endregion

    }
}

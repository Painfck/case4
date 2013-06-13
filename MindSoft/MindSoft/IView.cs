using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSoft
{
    interface IView
    {
        Graphics paper;

        private void DrawKnoop()
        {
            switch (penColor)
            {
                case "Black":
                    Pen pen = new Pen(Color.Black);
                    break;
                case "Blue":
                    Pen pen = new Pen(color.Blue);
                    break;
                case "Red":
                    Pen pen = new Pen(color.Red);
                    break;
            }
        }
    }
}

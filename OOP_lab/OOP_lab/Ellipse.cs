using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Fgr;

namespace OOP_lab
{
    [Serializable]
    internal class Ellipse : Figure
    {
        private int x1;
        private int y1;
        private int x2;
        private int y2;
        public static string name = "Ellipse";

        override public string figure_name
        {
            get { return name; }
        }

        override public Color figure_color
        {
            get; set;
        }

        override public int X1
        {
            get { return x1; }
            set { x1 = value; }
        }

        override public int Y1
        {
            get { return y1; }
            set { y1 = value; }
        }

        override public int X2
        {
            get { return x2; }
            set { x2 = value; }
        }

        override public int Y2
        {
            get { return y2; }
            set { y2 = value; }
        }

        public override void figure_draw(Graphics figure_graphic)
        {
            int width = Math.Max(x1, x2) - Math.Min(x1, x2);
            int height = Math.Max(y1, y2) - Math.Min(y1, y2);
            figure_graphic.DrawEllipse(new Pen(figure_color), Math.Min(x1, x2), Math.Min(y1, y2), width, height);
        }

        public override Figure Clone()
        {
            return new Ellipse()
            {
                X1 = this.X1,
                Y1 = this.Y1,
                X2 = this.X2,
                Y2 = this.Y2,
                figure_color = this.figure_color
            };
        }
    }
}

/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP_lab
{
    [Serializable]
    internal class Adaptee
    {
        private Point[] Points = new Point[3];

        public Point A
        {
            get { return Points[0]; } //x1 y1
            set { Points[0] = value; }
        }
        public Point B
        {
            get { return Points[1]; } //x2, y2
            set { Points[1] = value; }
        }
        public Point C
        {
            get { return Points[2]; } //x3, y3
            set { Points[2] = value; }
        }

        public void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawPolygon(pen, this.Points);
        }
    }
}*/
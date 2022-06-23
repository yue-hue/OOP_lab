using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fgr;
using System.Drawing;
using AdapteeNS;

namespace OOP_lab
{
    [Serializable]
    internal class Adapter : Figure  
    {
        public static string name = "New triangle";

        Adaptee adaptee = new Adaptee();

        private readonly Adaptee _adaptee;

        public Adapter()
        {
            this._adaptee = adaptee;
        }

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
            get { return _adaptee.A.X; }
            set 
            {
                Point point = new Point();
                point.X = value;
                point.Y = Y2;
                _adaptee.A = point;
            }
        }

        override public int Y1
        {
            get { return _adaptee.A.Y; }
            set 
            {
                Point point = new Point();
                point.X = X1;
                point.Y = value;
                _adaptee.A = point;
                _adaptee.C = new Point(X1 < X2 ? X1 + (X2 - X1) / 2 : X1 - (X1 - X2) / 2, Y1);
            }
        }

        override public int X2
        {
            get { return _adaptee.B.X; }
            set 
            {
                Point point = new Point();
                point.X = value;
                point.Y = Y2;
                _adaptee.B = point;
            }
        }

        override public int Y2
        {
            get { return _adaptee.B.Y; }
            set 
            {
                Point point = new Point();
                point.X = X2;
                point.Y = value;
                _adaptee.B = point;
                _adaptee.C = new Point(X1 < X2 ? X1 + (X2 - X1) / 2 : X1 - (X1 - X2) / 2, Y1);
            }
        }

        public override void figure_draw(Graphics figure_graphic)
        {
            Pen pen = new Pen(figure_color);
            _adaptee.Draw(figure_graphic, pen);
        }

        public override Figure Clone()
        {
            return new Adapter
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

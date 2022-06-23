using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;
using System.IO;
using Fgr;

namespace OOP_lab
{
    public partial class Form1 : Form
    {
        bool can_draw = false;
        bool cancel = false;
        private static Image canvas;
        private static Image tempCanvas;
        private static Graphics painter;

        private BinaryFormatter formatter = new BinaryFormatter();
        private List<Figure> history = new List<Figure>();

        private Figure figure;
        private Figure_list figure_list = new Figure_list();

        public Form1()
        {
            InitializeComponent();

            color_btn.BackColor = colorDialog1.Color;

            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            tempCanvas = (Image)pictureBox1.Image.Clone();
            canvas = (Image)pictureBox1.Image.Clone();

            figure_list.add_figure(Line.name, typeof(Line));
            figure_list.add_figure(Triangle.name, typeof(Triangle));
            figure_list.add_figure(Rectangle.name, typeof(Rectangle));
            figure_list.add_figure(Square.name, typeof(Square));
            figure_list.add_figure(Ellipse.name, typeof(Ellipse));
            figure_list.add_figure(Circle.name, typeof(Circle));

            figure_list.add_figure(Adapter.name, typeof(Adapter));

            figure_list.refresh_plugins();

            foreach (string name in figure_list.figures)
            {
                comboBox1.Items.Add(name);
            }
            comboBox1.SelectedIndex = 0;
            figure = figure_list.create_figure(comboBox1.Text);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            figure.X1 = e.X;
            figure.Y1 = e.Y;           
            can_draw = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && can_draw)
            {
                tempCanvas.Dispose();
                tempCanvas = (Bitmap)canvas.Clone();
                painter = Graphics.FromImage(tempCanvas);
                figure.X2 = e.X;
                figure.Y2 = e.Y;
                figure.figure_color = colorDialog1.Color;
                figure.figure_draw(painter);
                painter.Dispose();
                pictureBox1.Image.Dispose();
                pictureBox1.Image = (Image)tempCanvas.Clone();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        { 
            canvas.Dispose();
            canvas = (Bitmap)pictureBox1.Image.Clone();
            if (can_draw)
            {
                history.Add(figure.Clone());
                figures_lb.Items.Add(figure.figure_name);
                figures_lb.SelectedIndex = figures_lb.Items.Count - 1;
                can_draw = false;
            }            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected_figure = comboBox1.SelectedIndex;
            figure = figure_list.create_figure(comboBox1.Text);            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            color_btn.BackColor = colorDialog1.Color;
            if (figures_lb.SelectedIndex > -1 || cancel)
            {
                history[figures_lb.SelectedIndex].figure_color = colorDialog1.Color;
                painter = Graphics.FromImage(canvas);
                painter.FillRectangle(new SolidBrush(Color.White), 0, 0, canvas.Width, canvas.Height);
                foreach (Figure figure in history)
                {
                    figure.figure_draw(painter);
                }
                painter.Dispose();
                pictureBox1.Image.Dispose();
                pictureBox1.Image = (Image)canvas.Clone();
            }
        }

        private void toolStripOpen_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\Users\mikyy\source\repos\OOP_lab\OOP_lab\bin\Debug\extract\figures.dat"))
            {
                File.Delete(@"C:\Users\mikyy\source\repos\OOP_lab\OOP_lab\bin\Debug\extract\figures.dat");
                ZipFile.ExtractToDirectory("result.zip", "extract");
            }
            else
            {
                ZipFile.ExtractToDirectory("result.zip", "extract");
            }

            using (FileStream fs = new FileStream(@"extract\figures.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    history.AddRange((List<Figure>)formatter.Deserialize(fs));

                    painter = Graphics.FromImage(canvas);
                    figures_lb.Items.Clear();
                    foreach (Figure figure in history)
                    {
                        figure.figure_draw(painter);
                        figures_lb.Items.Add(figure.figure_name);
                    }
                    painter.Dispose();
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = (Image)canvas.Clone();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something get wrong :c");
                }                
            }
        }

        private void toolStripSave_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream(@"start\figures.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, history);
            }

            if (File.Exists(@"C:\Users\mikyy\source\repos\OOP_lab\OOP_lab\bin\Debug\result.zip"))
            {
                File.Delete(@"C:\Users\mikyy\source\repos\OOP_lab\OOP_lab\bin\Debug\result.zip");
                ZipFile.CreateFromDirectory("start", "result.zip");
                MessageBox.Show("Data was successfully saved :3");
            }
            else
            {
                ZipFile.CreateFromDirectory("start", "result.zip");
                MessageBox.Show("Data was successfully saved :3");
            }
        }

        private void figures_lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (figures_lb.SelectedIndex > -1)
            {
                figure.figure_color = colorDialog1.Color;
                history[figures_lb.SelectedIndex].figure_color = colorDialog1.Color;
                color_btn.BackColor = history[figures_lb.SelectedIndex].figure_color;
            }
        }
    }
}

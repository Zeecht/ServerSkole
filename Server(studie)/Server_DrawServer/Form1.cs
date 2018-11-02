using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_DrawServer
{
    public partial class Form1 : Form
    {
        public bool isDrawing = true;
        public List<Point> drawPosition = new List<Point>();


        public Form1()
        {
            InitializeComponent();

            panel1.MouseDown += new MouseEventHandler(Mouse);
        }


        public void Mouse(object sender, MouseEventArgs me)
        {

            if (isDrawing)
            {
                drawPosition.Add(me.Location);
                panel1.Invalidate();
            }
        }


        public void Draw(object sender, PaintEventArgs pe)
        {

            //pe.Graphics.DrawLines(Pens.Black, drawingPosition);
            panel1.Invalidate();
        }


    }
}

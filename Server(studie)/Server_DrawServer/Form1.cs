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

        Graphics graphics;

        public Form1()
        {
            InitializeComponent();

            graphics = PicBox.CreateGraphics();
            PicBox.MouseDown += new MouseEventHandler(Mouse);
        }


        public void Mouse(object sender, MouseEventArgs me)
        {
            Pen p = new Pen(Color.Black);
            graphics.DrawLine(p, MousePosition, MousePosition);

        }


        public void Draw(object sender, PaintEventArgs pe)
        {
            
        }

        
    }
}

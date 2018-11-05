using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_DrawClientProjekt
{
    public partial class Form1 : Form
    {
        public bool isDrawing = false;
        Graphics graphics;
        SolidBrush brush = new SolidBrush(Color.Black);
        Server server;
        int x;
        int y;

        public Form1()
        {
            InitializeComponent();

            graphics = pictureBox2.CreateGraphics();
            pictureBox2.MouseDown += PictureBox2_Click;
            pictureBox2.MouseUp += PictureBox2_Release;
            
            server = new Server("127.0.0.1", 13000);
        }

        private void PictureBox2_Click(object sender, MouseEventArgs e)
        {
            Draw_Timer.Enabled = true;




        }
        
        private void PictureBox2_Release(object sender, MouseEventArgs e)
        {
            Draw_Timer.Enabled = false;
            while (server.KordinatListe.Count != 0)
            {
                server.Connect();
            }
        }

        private void Draw_Timer_Tick(object sender, EventArgs e)
        {
            graphics.FillEllipse(brush, Form1.MousePosition.X - 150, Form1.MousePosition.Y - 150, 10, 10);

            x = Form1.MousePosition.X - 150;
            y = Form1.MousePosition.Y - 150;
            
            string paintMark = x.ToString() + "," + y.ToString();
            server.KordinatListe.Add(paintMark);

            graphics.Flush();
        }
    }
}

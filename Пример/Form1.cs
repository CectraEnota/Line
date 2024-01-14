using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЭКЗ_Пример
{
    public partial class Form1 : Form
    {
        private bool[,] map = new bool[23, 20];
        private bool a = false, d = false, w = false, s = false;
        private int frameCounter = 0;
        private int speed = 10;
        private int FPS = 15;
        private (int, int) playerPos = (10, 20);

        public void Generate_Row()
        {
            Random r = new Random();
            for (int i = 21; i >= 0; i--)
                for (int j = 0; j < 20; j++)
                    map[i + 1, j] = map[i, j];

            for (int i = 0; i < 20; i++)
            {
                if (r.Next() % 9 == 0)
                    map[0, i] = true;
                else
                    map[0, i] = false;
            }

        }

        public bool Detect_collision()
        {
            return (map[playerPos.Item2, playerPos.Item1] == true);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) w = true;
            if (e.KeyCode == Keys.S) s = true;
            if (e.KeyCode == Keys.A) a = true;
            if (e.KeyCode == Keys.D) d = true;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) w = false;
            if (e.KeyCode == Keys.A) a = false;
            if (e.KeyCode == Keys.S) s = false;
            if (e.KeyCode == Keys.D) d = false;
        }

        public void SetPlayerPos()
        {
            if (s && playerPos.Item2 < 20) playerPos.Item2++;
            if (a && playerPos.Item1 > 0) playerPos.Item1--;
            if (d && playerPos.Item1 < 19) playerPos.Item1++;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            a = false;
            d = false;
            w = false;
            s = false;
            playerPos = (10, 20);
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                    map[i, j] = false;
            timer1.Start();
        }

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            timer1.Interval = 1000 / FPS;
            timer1.Start();

            pictureBox1.Focus();
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                    map[i, j] = false;
        }

        private void draw_Frame()
        {
            Bitmap buffer = new Bitmap(Math.Max(pictureBox1.Width, 10),
                Math.Max(pictureBox1.Height, 10));
            Graphics drawer = Graphics.FromImage(buffer);
            Pen pen = new Pen(Color.Black, 1);
            SolidBrush brushGr = new SolidBrush(Color.Gray);
            SolidBrush brushRed = new SolidBrush(Color.Red);
            //drawer.FillRectangle(brushRed, 230, 300, 22, 22);



            float delta = pictureBox1.Width / 20;
            drawer.FillRectangle(brushRed, playerPos.Item1 * delta + (float)0.5, playerPos.Item2 * delta + (float)0.5, delta - 1, delta - 1);

            for (int i = 0; i < 23; i++)
                for (int j = 0; j < 20; j++)
                {
                    if (map[i, j] == true)
                    {
                        drawer.FillRectangle(brushGr, j * delta + (float)0.5, i * delta + (float)0.5, delta - 1, delta - 1);
                    }
                }
            //drawer.FillRectangle(brushRed, playerPos.Item1 * delta + (float)0.5, playerPos.Item2 * delta + (float)0.5, delta - 1, delta - 1);
            pictureBox1.BackgroundImage = buffer;
            frameCounter++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetPlayerPos();
            if ((frameCounter % 10 == 0 || w) && s == false)
                Generate_Row();
            if (!Detect_collision())
                draw_Frame();
            else
            {
                timer1.Stop();
                MessageBox.Show("GAME OVER");

                for (int i = 21; i >= 0; i--)
                    for (int j = 0; j < 20; j++)
                        map[i + 1, j] = false;

                draw_Frame();
            }
        }
    }
}

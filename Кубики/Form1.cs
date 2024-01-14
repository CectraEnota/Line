using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace ЭКЗ_Тетрис
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[,] Matrix = new int[10, 10];//матрица
        int speed = 1;
        int one = 50;//ширина одного куба
        List<Kap> kaps = new List<Kap>();
        List<Case> cases = new List<Case>();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Width = 501;
            panel1.Height = 501;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.White);
            kaps.Clear();
            Random random = new Random();
            //Инициализация 
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Matrix[i, j] = 0;
                }
            }
            //прорисовка сетки 
            for (int i = 0; i <= 10; i++)
            {
                g.DrawLine(Pens.Black, 0, i * one, panel1.Width, i * one);
                g.DrawLine(Pens.Black, i * one, 0, i * one, panel1.Width);
            }
            //timer1.Interval = 700;
            timer1.Start();
        }
        bool flag = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Random rnd = new Random();
            SolidBrush brushKap = new SolidBrush(Color.FromArgb(255, (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
            for (int i = 0; i < kaps.Count; i++)
            {
                SolidBrush brush = new SolidBrush(kaps[i].color);
                g.FillRectangle(Brushes.White, kaps[i].x0, kaps[i].y0, one, one);
                for (int j = 0; j <= 10; j++)
                {
                    g.DrawLine(Pens.Black, 0, j * one, panel1.Width, j * one);
                    g.DrawLine(Pens.Black, j * one, 0, j * one, panel1.Width);
                }
                kaps[i].y0 += 50;
                if (kaps[i].y0 > panel1.Height - one || cases.Exists(x => x.x0 == kaps[i].x0 && x.y0 == kaps[i].y0))
                {
                    g.FillRectangle(brush, kaps[i].x0, kaps[i].y0 - one, one, one);
                    Case cas = new Case(kaps[i].x0, kaps[i].y0 - one);
                    cases.Add(cas);
                    if (kaps[i].y0 == one && cases.Exists(x => x.x0 == kaps[i].x0 && x.y0 == kaps[i].y0 + one))
                    {
                        timer1.Stop();
                        cases.Clear();
                        kaps.Clear();
                        MessageBox.Show("Конец игры");
                        flag = true;
                    }
                    if (flag == false)
                    {
                        kaps.RemoveAt(i);
                    }
                }
                else
                {
                    g.FillRectangle(brush, kaps[i].x0, kaps[i].y0, one, one);
                }
            }
            if (flag == false)
            {
                int NewKapCount = rnd.Next(2);
                for (int i = 0; i < NewKapCount; i++)
                {
                    Kap NewKap = new Kap(one * rnd.Next(10), one * rnd.Next(1), speed, brushKap.Color);
                    kaps.Add(NewKap);
                    g.FillRectangle(brushKap, NewKap.x0, NewKap.y0, one, one);
                }
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Rectangle rect = panel1.ClientRectangle;
                g.CopyFromScreen(panel1.PointToScreen(new Point(rect.X, rect.Y)), Point.Empty, rect.Size);
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "data.png";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(saveFileDialog.FileName);
            }
        }
    }
}

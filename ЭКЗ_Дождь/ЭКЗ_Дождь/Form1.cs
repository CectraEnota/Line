﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЭКЗ_Дождь
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SpeedMin.Text = "1";
            SpeedMax.Text = "5";
        }
        List<Kap> kaps = new List<Kap>();
        List<Tycha> tychs = new List<Tycha>();
        Brush brushKap = new SolidBrush(Color.Blue);
        Brush brushTych = new SolidBrush(Color.Gray);
        int MaxxSpeed = 5;
        int MinnSpeed = 1;
        bool start = false;

        private void btnStart_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            if (!start)
            {

                Random rand = new Random();
                int coiunt = rand.Next(7, 15);
                for (int i = 0; i < coiunt; i++)
                {
                    Tycha NewTycha = new Tycha(rand.Next(600), rand.Next(40));
                    tychs.Add(NewTycha);
                    g.FillEllipse(brushTych, NewTycha.x0, NewTycha.y0, 60, 30);
                }
                timer1.Start();
                SpeedMax.Enabled = false;
                SpeedMin.Enabled = false;
                start = true;
            }
            else
            {
                g.Clear(Color.White);
                SpeedMax.Enabled = true;
                SpeedMin.Enabled = true;
                kaps.Clear();
                tychs.Clear();
                timer1.Stop();
                start = false;
            }
        }

        int Radios = 20;//начальный радиус лужи
        int lyX = 300;//начальная координата x лужи
        bool SaveLy = false;//проверка на первую каплю

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Random rnd = new Random();
            for (int i = 0; i < kaps.Count; i++)
            {
                g.FillEllipse(Brushes.White, kaps[i].x0, kaps[i].y0, 20, 40);
                if (SaveLy)
                {
                    g.FillEllipse(brushKap, lyX - Radios, 400, Radios * 2, 50);
                }

                kaps[i].y0 += kaps[i].speed;
                if (kaps[i].y0 >= 450)
                {
                    kaps.RemoveAt(i);
                    Radios += 5;
                    g.FillEllipse(brushKap, lyX - Radios, 400, Radios * 2, 50);
                    SaveLy = true;
                }
                else
                    g.FillEllipse(brushKap, kaps[i].x0, kaps[i].y0, 20, 40);
            }
            int NewKapCount = rnd.Next(2);
            for (int i = 0; i < NewKapCount; i++)
            {
                Kap NewKap = new Kap(rnd.Next(600), rnd.Next(100, 150), rnd.Next(MinnSpeed, MaxxSpeed));
                kaps.Add(NewKap);
                g.FillEllipse(brushKap, NewKap.x0, NewKap.y0, 20, 40);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Width = 600;
            panel1.Height = 450;
            panel1.BackColor = Color.White;
        }

        private void ColorKap_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                brushKap = new SolidBrush(colorDialog1.Color);
            }
        }

        private void ColorTycha_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                brushTych = new SolidBrush(colorDialog1.Color);
            }
        }

        private void SpeedMin_TextChanged(object sender, EventArgs e)
        {
            Random rnd = new Random();
            if (int.TryParse(SpeedMin.Text, out MinnSpeed))
            {
                if (MinnSpeed < MaxxSpeed)
                {
                    for (int i = 0; i < kaps.Count; i++)
                    {
                        kaps[i].speed = rnd.Next(MinnSpeed, MaxxSpeed);
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка");
                    int MaxxSpeed = 5;
                    int MinnSpeed = 1;
                    SpeedMin.Text = "1";
                    SpeedMax.Text = "5";
                }
            }
        }

        private void SpeedMax_TextChanged(object sender, EventArgs e)
        {
            Random rnd = new Random();
            if (int.TryParse(SpeedMax.Text, out MaxxSpeed))
            {
                if (MinnSpeed < MaxxSpeed)
                {
                    for (int i = 0; i < kaps.Count; i++)
                    {
                        kaps[i].speed = rnd.Next(MinnSpeed, MaxxSpeed);
                    }

                }
                else
                {
                    MessageBox.Show("Ошибка");
                    int MaxxSpeed = 5;
                    int MinnSpeed = 1;
                    SpeedMin.Text = "1";
                    SpeedMax.Text = "5";
                }

            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Net.WebRequestMethods;

namespace ЭКЗ_Таблица
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Содание шапки
            table1.Columns.Add("Name", "Имя");
            table1.Columns.Add("Height", "Рост");
            table1.Columns.Add("Weight", "Вес");
            table1.Columns.Add("Group", "Группа крови");
        }
        bool flag = false;//отслеживает была ли нажата кнопка дважды. На второе нажатие останавливает таймер 
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                timer1.Start();
                flag = true;
            }
            else
            {
                timer1.Stop();
                flag = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            List<string> Name = new List<string>() { "Иван", "Мария", "Виктория", "Тимофей", "Никита", "Виолетта", "Андрей", "Максим" };
            List<string> GroupBload = new List<string>() { "A", "B", "AB" };
            //Закидываем рандомные значения 
            table1.Rows.Add(Name[random.Next(0, 8)], random.Next(130, 210), random.Next(30, 120), GroupBload[random.Next(0, 3)]);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "TXT Files|.txt";
            saveFileDialog.FileName = "data.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (TextWriter textWriter = new StreamWriter(saveFileDialog.FileName))
                {
                    for (int str = 0; str < table1.Rows.Count - 1; str++)
                    {
                        for (int col = 0; col < table1.Columns.Count; col++)
                        {
                            textWriter.Write(table1[col, str].Value);
                            if (col != table1.Columns.Count - 1)
                            {
                                textWriter.Write(";");
                            }
                        }
                        textWriter.WriteLine();
                    }
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)//Вызываем окно выбора файла, если нажали ОК то продолжаем
            {
                table1.Rows.Clear();//очищаем строки
                string[] str = System.IO.File.ReadAllLines(openFile.FileName);
                for (int i = 0; i < str.Length; i++)//пробигаем по всем считынным строкам
                {
                    //буферы в которые мы будем помещать значения Имен, Роста, Веса и группы крови для рассматриваемой строки
                    List<char> BufName = new List<char>();
                    List<char> BufHeight = new List<char>();
                    List<char> BufWight = new List<char>();
                    List<char> BufGroup = new List<char>();
                    int pole = 0;//Характеризуем какой элемент мы считываем посимвольно 
                    for (int c = 0; c < str[i].Length; c++)
                    {
                        char sim = str[i][c];
                        if (sim != ';')
                        {
                            if (pole == 0)
                                BufName.Add(sim);//Помещаем в бурферы
                            if (pole == 1)
                                BufHeight.Add(sim);
                            if (pole == 2)
                                BufWight.Add(sim);
                            if (pole == 3)
                                BufGroup.Add(sim);
                        }
                        else pole++;//Если вдруг попался символ ; то начит переходим к считыванию следующего элемента
                    }
                    //Buf.ToArray() возвращает массив типа char, с помощью String.Concat(...) вы склеиваем массив char в одну строку
                    table1.Rows.Add(String.Concat(BufName.ToArray()), String.Concat(BufHeight.ToArray()), String.Concat(BufWight.ToArray()), String.Concat(BufGroup.ToArray()));
                }
            }
        }
    }
}

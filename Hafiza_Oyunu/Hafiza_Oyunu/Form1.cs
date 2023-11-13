using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hafiza_Oyunu
{
    public partial class Form1 : Form
    {
        List<string> icons = new List<string>()
        {
            "!","A","@","*","7","?","(","5","p","<",
            "!","A","@","*","7","?","(","5","p","<"
        };

        Random rnd = new Random();
        int randomindex;
        Timer t = new Timer();
        Timer t2 = new Timer();
        Button first, second;
        public Form1()
        {
            InitializeComponent();
            t.Tick += T_Tick;
            t.Start();
            t.Interval = 5000;
            show();
            t2.Tick += T2_Tick;
        }

        private void T2_Tick(object sender, EventArgs e)
        {
            t2.Stop();
            first.ForeColor = first.BackColor;
            second.ForeColor = second.BackColor;
            first = null;
            second = null;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            t.Stop();
            foreach (Button item in Controls)
            {
                item.ForeColor = item.BackColor;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void show()
        {
            Button btn;
            foreach (Button item in Controls)
            {
                btn = item ;
                randomindex = rnd.Next(icons.Count);
                btn.Text = icons[randomindex];
                btn.ForeColor = Color.Black;
                icons.RemoveAt(randomindex);
            }

        }
        int sayac = 0;
        int dogru = 0;
        int yanlis=0;

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (first == null)
            {
                first = btn;
                first.ForeColor = Color.Black;
                yanlis++;
                return;
            }
            second = btn;
            second.ForeColor = Color.Black;
            if (first.Text == second.Text)
            {
                first.ForeColor = Color.Black;
                second.ForeColor = Color.Black;
                first = null;
                second = null;
                sayac++;
                dogru++;
                if (sayac == 10)
                {
                    MessageBox.Show("Doğru Sayisi=  " + dogru + "  Yanlış Sayısı=  " + yanlis);
                }
            }
            else
            {
                t2.Start();
                t2.Interval = 1000;
            }
        }
    }
}

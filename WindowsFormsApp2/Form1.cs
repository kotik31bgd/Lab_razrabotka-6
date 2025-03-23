using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int hour, minute, second;
         SoundPlayer sp = new SoundPlayer("D:\\C418_-_Key_30921622.wav");
        bool b = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int h = DateTime.Now.Hour;

            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;

            string time = "";

            // unnecessary
            if (h < 10)
                time += "0";
            time += h + ":";

            if (m < 10)
                time += "0";
            time += m + ":";

            if (s < 10)
                time += "0";
            time += s;

            toolStripStatusLabel2.Text = DateTime.Now.ToLongDateString();
            toolStripStatusLabel3.Text = time;
            label9.Text = time;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            hour = Convert.ToInt32(textBox1.Text);
            minute = Convert.ToInt32(textBox2.Text);
            second = Convert.ToInt32(textBox3.Text);

            if (hour == 0 && minute == 0 && second == 0)
                MessageBox.Show("Значение таймера не задано!");
            else
                timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            second--;
                if (second == -1)
            {
                minute--;
                second = 59;

            }
                if (minute == -1)
            {
                hour--;
                minute = 59;
            }

            string s_h = "", s_m = "", s_s = "";
            if (second < 10)
                s_s += "0";
            s_s += second;
            if (minute < 10)
                s_m += "0";
            s_m += minute;
            if ( hour < 10 )
                s_h += "0";
            s_h += hour;

            label1.Text = s_h;
            label3.Text = s_m;
            label5.Text = s_s;

            if (hour == 0 && minute == 0 && second == 0)
            {
                timer2.Stop();
                MessageBox.Show("Время вышло!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            textBox1.Text = Convert.ToString(hour);
            textBox2.Text = Convert.ToString(minute);
            textBox3.Text = Convert.ToString(second);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            label1.Text = "00";
            label3.Text = "00";
            label5.Text = "00";
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (b == false)
            {
                maskedTextBox1.Enabled = false;
                timer3.Start();
                button4.Text = "Убрать будильник";
                b = true;
            }
            else if (b == true)
            {
                maskedTextBox1.Text = "";
                timer2.Stop();
                maskedTextBox1.Enabled = true;
                button4.Text = "Завести будильник";
                b = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button5.Enabled = false;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            // Для совпадения установленного будильника и дефолтного
            if (label9.Text == maskedTextBox1.Text + ":00")
            {
                button5.Enabled = true;
                 sp.Play();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
             sp.Stop();
            button5.Enabled = false;
            maskedTextBox1.Enabled = true;
            button4.Text = "Завести будильник";
            b = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm
{
    public partial class Form1 : Form
    {
        private int Music = 0;

        private string NameFile = "";
        private string Hour = "";
        private string Minutes = "";
        private string Seconds = "";

        private string HourShot = "";
        private string MinutesShot = "";
        private string SecondsShot = "";

        private string HourNow = "";
        private string MinutesNow = "";
        private string SecondsNow = "";

        WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();

        public Form1()
        {
            InitializeComponent();
            timer2.Interval = 500;
            timer2.Tick += new EventHandler(timer2_Tick);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (Hour.Length == 1)
            {
                Hour = "0" + Hour;
            }

            if (Minutes.Length == 1)
            {
                Minutes = "0" + Minutes;
            }

            if (Seconds.Length == 1)
            {
                Seconds = "0" + Seconds;
            }

            textBox1.Text = Hour;
            textBox2.Text = Minutes;
            textBox3.Text = Seconds;

            if (HourShot.Length == 1)
            {
                HourShot = "0" + HourShot;
            }

            if (MinutesShot.Length == 1)
            {
                MinutesShot = "0" + MinutesShot;
            }

            if (SecondsShot.Length == 1)
            {
                SecondsShot = "0" + SecondsShot;
            }

            textBox4.Text = HourShot;
            textBox5.Text = MinutesShot;
            textBox6.Text = SecondsShot;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                if (textBox1.Text.Length >= 0 && textBox1.Text.Length <= 1)
                {
                    return;
                }
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
            }

            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                if (textBox2.Text.Length >= 0 && textBox2.Text.Length <= 1)
                {
                    return;
                }
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
            }

            e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                if (textBox3.Text.Length >= 0 && textBox3.Text.Length <= 1)
                {
                    return;
                }
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
            }

            e.Handled = true;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 1)
            {
                textBox1.Text = "0" + textBox1.Text;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 1)
            {
                textBox2.Text = "0" + textBox2.Text;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 1)
            {
                textBox3.Text = "0" + textBox3.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string extension = "";

            if (Music == 0)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    NameFile = openFileDialog1.FileName;
                    extension = Path.GetExtension(NameFile);

                    if (extension != ".mp3")
                    {
                        MessageBox.Show("Файл должен иметь расширение mp3");
                        return;
                    }

                    music.Text = NameFile.Substring(0, 14) + "...";
                }
            }

            else
            {
                WMP.controls.stop();
                music.Text = NameFile.Substring(0, 14) + "...";
                Music = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (start.Text == "Стоп")
            {
                if (Music == 1)
                {
                    WMP.controls.stop();
                    music.Text = NameFile.Substring(0, 14) + "...";
                    Music = 0;
                }

                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;

                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                textBox6.ReadOnly = false;

                timer2.Enabled = false;

                start.BackColor = Color.PaleGreen;
                start.Text = "Запустить";
            }

            else
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Поле часы пусто");
                    return;
                }

                if (textBox2.Text == "")
                {
                    MessageBox.Show("Поле минуты пусто");
                    return;
                }

                if (textBox3.Text == "")
                {
                    MessageBox.Show("Поле секунды пусто");
                    return;
                }

                if (!(Convert.ToInt32(textBox1.Text) >= 0 && Convert.ToInt32(textBox1.Text) <= 23))
                {
                    MessageBox.Show("Некорректно указаны часы");
                    return;
                }

                if (!(Convert.ToInt32(textBox2.Text) >= 0 && Convert.ToInt32(textBox2.Text) <= 59))
                {
                    MessageBox.Show("Некорректно указаны минуты");
                    return;
                }

                if (!(Convert.ToInt32(textBox3.Text) >= 0 && Convert.ToInt32(textBox3.Text) <= 59))
                {
                    MessageBox.Show("Некорректно указаны секунды");
                    return;
                }

                if (music.Text == "Выбрать музыку")
                {
                    MessageBox.Show("Выберете песню mp3");
                }
                else
                {
                    start.BackColor = Color.LavenderBlush;
                    start.Text = "Стоп";

                    Hour = textBox1.Text;
                    Minutes = textBox2.Text;
                    Seconds = textBox3.Text;

                    HourShot = textBox1.Text;
                    MinutesShot = textBox2.Text;
                    SecondsShot = textBox3.Text;

                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    textBox3.ReadOnly = true;

                    textBox4.ReadOnly = true;
                    textBox5.ReadOnly = true;
                    textBox6.ReadOnly = true;
                }

                timer2.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            HourNow = DateTime.Now.Hour.ToString();
            MinutesNow = DateTime.Now.Minute.ToString();
            SecondsNow = DateTime.Now.Second.ToString();

            if (HourNow.Length == 1)
            {
                HourNow = "0" + HourNow;
            }

            if (MinutesNow.Length == 1)
            {
                MinutesNow = "0" + MinutesNow;
            }

            if (SecondsNow.Length == 1)
            {
                SecondsNow = "0" + SecondsNow;
            }

            if (Hour == HourNow && Minutes == MinutesNow && Seconds == SecondsNow)
            {
                WMP.URL = NameFile;
                WMP.settings.volume = 100;
                WMP.controls.play();

                Music = 1;

                music.Text = "Выключить музыку";
            }

            if (HourShot == HourNow && MinutesShot == MinutesNow && SecondsShot == SecondsNow)
            {
                System.Diagnostics.Process.Start("shutdown", "/s /t 5");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                if (textBox4.Text.Length >= 0 && textBox4.Text.Length <= 1)
                {
                    return;
                }
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
            }

            e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                if (textBox5.Text.Length >= 0 && textBox5.Text.Length <= 1)
                {
                    return;
                }
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
            }

            e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                if (textBox6.Text.Length >= 0 && textBox6.Text.Length <= 1)
                {
                    return;
                }
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
            }

            e.Handled = true;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 1)
            {
                textBox4.Text = "0" + textBox4.Text;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 1)
            {
                textBox5.Text = "0" + textBox5.Text;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text.Length == 1)
            {
                textBox6.Text = "0" + textBox6.Text;
            }
        }
    }
}

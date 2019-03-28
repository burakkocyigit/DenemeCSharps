using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;

namespace DenemeInvoke
{
    public partial class Form1 : Form
    {
        Thread th;
        System.Timers.Timer timer1 = new System.Timers.Timer();
        private int a = 0;
        private int b = 0;
        private bool yap = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Elapsed += Timer1_Elapsed;
            timer1.Enabled = true;
            //th = new Thread(enabledTimer);
            //th.Start();
        }

        private void Timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            timer1.Enabled = false;
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new Action(() => textBox1.Text = a.ToString()));
            }
            //Thread.Sleep(10000);
            a++;
            if (yap)
                timer1.Enabled = true;
            stopwatch.Stop();
            Debug.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        private void enabledTimer()
        {
            timer1.Enabled = true;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            yap = false;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            yap = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = b.ToString();
            b++;
        }
    }
}

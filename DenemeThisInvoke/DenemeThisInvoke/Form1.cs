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

namespace DenemeThisInvoke
{
    public partial class Form1 : Form
    {
        Thread th;
        int a = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            th = new Thread(timerEnabled);
            th.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() => timer1.Enabled = false));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = a.ToString();
            a++;
        }
        public void timerEnabled()
        {
            this.Invoke(new Action(() => timer1.Enabled = true));
        }
    }
}

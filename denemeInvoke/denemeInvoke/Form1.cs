using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace denemeInvoke
{
    public partial class Form1 : Form
    {
        DenemeClass deneme;
        System.Timers.Timer timer1 = new System.Timers.Timer();
        int a = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            deneme = new DenemeClass(this);
            deneme.ControllerEvent += Deneme_ControllerEvent;
            timer1.Elapsed += Timer1_Elapsed;
            timer1.Enabled = true;

        }

        private void Deneme_ControllerEvent()
        {
            textBox1.Text = (deneme.degisken + 1).ToString();
            textBox2.Text = (deneme.degisken + 2).ToString();
        }

        private void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new Action(() => deneme.degistir(a)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(textBox3.Text);
        }
    }
}

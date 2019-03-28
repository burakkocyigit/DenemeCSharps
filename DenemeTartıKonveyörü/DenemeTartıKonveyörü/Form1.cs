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

namespace DenemeTartıKonveyörü
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //string b = "10.0  \n";
            string a = serialPort1.ReadLine();
            if (a[6] == ' ')
                textBox1.Text = a.Remove(0, 7).Remove(3);
            else if (a[5] == ' ')
                textBox1.Text = a.Remove(0, 6).Remove(4);
            else if (a[4] == ' ')
                textBox1.Text = a.Remove(0, 5).Remove(5);
            else if (a[3] == ' ')
                textBox1.Text = a.Remove(0, 4).Remove(6);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            serialPort1.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
        }
    }
}

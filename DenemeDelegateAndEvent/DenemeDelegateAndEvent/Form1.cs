using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DenemeDelegateAndEvent
{
    public partial class Form1 : Form
    {
        Form2 frm = new Form2();

        public Form1()
        {
            InitializeComponent();
        }

        public delegate void MenuBasi();
        public static event MenuBasi Sef;

        private void Form1_Load(object sender, EventArgs e)
        {
            frm.Show();
        }

        public ArrayList alinanlar { get; set; } = new ArrayList();
        
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Köfte");
            alinanlar.Add("Köfte");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Patates");
            alinanlar.Add("Patates");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Kola");
            alinanlar.Add("Kola");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm.fr = this;
            MessageBox.Show("Ödeme OK");
            Sef();
            listBox1.Items.Clear();
            alinanlar.Clear();
        }
    }
}

using System;
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
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1.Sef += Form1_Sef;
        }

        public Form1 fr { get; set; }
        
        private void Form1_Sef()
        {
            listBox1.Items.AddRange(fr.alinanlar.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            frm.fr = this.fr;
        }
    }
}

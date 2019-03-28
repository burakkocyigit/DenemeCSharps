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

namespace denemeDelegeAndEvents
{
    public partial class Form2 : Form
    {
        Form1 fr = new Form1();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1.Sef += Form1_Sef;
        }

        private void Form1_Sef()
        {
            listBox1.Items.AddRange(fr.alinanlar.ToArray());
        }
    }
}

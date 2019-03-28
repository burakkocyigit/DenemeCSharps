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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Form1.Sef += Form1_Sef;
        }

        public Form1 fr { get; set; }

        private void Form1_Sef()
        {
            listBox1.Items.AddRange(fr.alinanlar.ToArray());
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DenemeControlExsistingFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Lenovo\Desktop\CSV_TERMO\20180309");
            FileInfo[] TXTFiles = di.GetFiles("*.csv");

            foreach(FileInfo fi in TXTFiles)
            {
                listBox1.Items.Add(fi.Name);
            }
        }
    }
}

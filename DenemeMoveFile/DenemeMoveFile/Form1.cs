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

namespace DenemeMoveFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Lenovo\Desktop\burki burki\");
            FileInfo[] TXTFiles = di.GetFiles("*.csv");
            
            foreach (FileInfo fi in TXTFiles)
            {
                System.IO.File.Copy(@"C:\Users\Lenovo\Desktop\burki burki\" + fi.Name, @"C:\Users\Lenovo\Desktop\Yeni klasör (6)\" + fi.Name);
                System.IO.File.Delete(@"C:\Users\Lenovo\Desktop\burki burki\" + fi.Name);
            }
        }
    }
}

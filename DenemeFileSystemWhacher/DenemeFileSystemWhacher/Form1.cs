using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DenemeFileSystemWhacher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fileSystemWatcher1.EnableRaisingEvents = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            listBox1.Items.Add("file created>" + e.FullPath);
            listBox1.Items.Add(e.Name);
        }
    }
}

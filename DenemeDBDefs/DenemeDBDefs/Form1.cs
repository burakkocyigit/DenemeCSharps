using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DenemeDBDefs
{
    public partial class Form1 : Form
    {
        DBDefs _dBDefs = new DBDefs();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _dBDefs.ConnectToDBTrusted("BURAKKOCYIGIT", "DenemeDataBase");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = _dBDefs.ExecuteScalarStr("select ID from Students where Ad='Ali'");
        }
    }
}

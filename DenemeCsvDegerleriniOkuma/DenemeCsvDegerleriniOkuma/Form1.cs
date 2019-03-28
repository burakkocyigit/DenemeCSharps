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
using Microsoft.VisualBasic.FileIO;


namespace DenemeCsvDegerleriniOkuma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string TakeCsvValues(int a)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Lenovo\Desktop\burki burki\");
            FileInfo[] TXTFiles = di.GetFiles("*.csv");
            if(!(a < TXTFiles.Length))
                goto jmp;

            TextFieldParser csvReader = new TextFieldParser(@"C:\Users\Lenovo\Desktop\burki burki\" + TXTFiles[a].Name);
            csvReader.SetDelimiters(new string[] { ";" });
            string[] colFields = csvReader.ReadFields();
            for (int i = 0; i < colFields.Length; i++)
            {
                if (colFields[i] == "")
                {
                    colFields[i] = null;
                }
            }
            return colFields[a++];
            jmp:
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = TakeCsvValues(5);
            textBox2.Text = TakeCsvValues(1);
            textBox3.Text = TakeCsvValues(2);
            textBox4.Text = TakeCsvValues(3);
            textBox5.Text = TakeCsvValues(4);
            /*textBox6.Text = TakeCsvValues(5);
            textBox7.Text = TakeCsvValues(6);
            textBox8.Text = TakeCsvValues(7);
            textBox9.Text = TakeCsvValues(8);
            textBox10.Text = TakeCsvValues(9);
            textBox11.Text = TakeCsvValues(10);
            textBox12.Text = TakeCsvValues(11);
            textBox13.Text = TakeCsvValues(12);
            textBox14.Text = TakeCsvValues(13);
            textBox15.Text = TakeCsvValues(14);
            textBox16.Text = TakeCsvValues(15);*/
        }
    }
}

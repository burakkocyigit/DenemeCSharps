using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace denemeButtonColor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Lime;
            await Task.Delay(5000);
            button1.BackColor = Color.DarkGreen;


            //await awaiting();
            //button1.BackColor = Color.DarkGreen;


            //await Task.Run(() =>
            //{
            //    System.Threading.Thread.Sleep(5000);
            //    button1.BackColor = Color.DarkGreen;
            //});


            //Application.DoEvents();
            //Thread.Sleep(5000);
            //button1.BackColor = Color.DarkGreen;
        }
        //private async Task awaiting()
        //{
        //    await Task.Delay(5000);
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "tamam";
        }
    }
}

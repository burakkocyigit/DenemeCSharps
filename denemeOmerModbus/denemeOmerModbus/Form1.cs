using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyModbus;
using System.Threading;


namespace denemeOmerModbus
{
    public partial class Form1 : Form
    {
        Plc _plc = new Plc();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _plc.Register1Event += _plc_Register1Event;
            _plc.Register2Event += _plc_Register2Event;
            _plc.Register3Event += _plc_Register3Event;
            _plc.Register4Event += _plc_Register4Event;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            _plc.readPlc();
            timer1.Enabled = true;
        }
        private void _plc_Register1Event()
        {
            textBox1.Text = _plc.register1.ToString();
        }

        private void _plc_Register2Event()
        {
            textBox2.Text = _plc.register2.ToString();
        }

        private void _plc_Register3Event()
        {
            textBox3.Text = _plc.register3.ToString();
        }

        private void _plc_Register4Event()
        {
            textBox4.Text = _plc.register4.ToString();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            _plc.writePlc((int)numericUpDown1.Value, Convert.ToInt32(textBox5.Text));
            timer1.Enabled = true;
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}

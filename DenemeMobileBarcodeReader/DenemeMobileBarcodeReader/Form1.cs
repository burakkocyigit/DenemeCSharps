using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DenemeMobileBarcodeReader
{
    public partial class Form1 : Form
    {
        public string a { get; set; }
        MobileBarcodeReader _mobileBarcodeReader;
        public Form1()
        {
            InitializeComponent();
        }
        //private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        //{
        //    Thread.Sleep(20);
        //    a = serialPortMobileBarcodeReader.ReadExisting();
        //    textBox1.Text = a;
        //    //Thread.Sleep(500);
        //    //a = serialPort1.ReadExisting();
        //    //if (a.Length == 9)
        //    //{
        //    //    textBox1.Text = a;
        //    //    return;
        //    //}
        //    //else if (a.Length < 9)
        //    //    a = a + serialPort1.ReadExisting();
        //    //textBox1.Text = a;


        //    //a = Encoding.ASCII.
        //    //a = serialPort1.ReadExisting();
        //    //textBox1.Text = a;
        //    //if (a.Length == 9)
        //    //    textBox1.Text = a;
        //    //else
        //    //    a=a
        //    //button1_Click(button1, EventArgs.Empty);
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            _mobileBarcodeReader = new MobileBarcodeReader(serialPortMobileBarcodeReader);
            _mobileBarcodeReader.open();
            _mobileBarcodeReader.DataEvent += _mobileBarcodeReader_DataEvent;
            //serialPort1.Open();

        }

        private void _mobileBarcodeReader_DataEvent()
        {
            textBox1.Text = _mobileBarcodeReader._data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //a=serialPort1.ReadExisting();
            //textBox1.Text = a;
        }
    }
}

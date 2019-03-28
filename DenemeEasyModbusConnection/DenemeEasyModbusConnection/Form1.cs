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



namespace DenemeEasyModbusConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ModbusClient istemci = new ModbusClient("192.168.0.1", 502);

        private void button1_Click(object sender, EventArgs e)
        {
            istemci.Connect();
            istemci.WriteSingleCoil(0, true);
            //istemci.WriteSingleRegister(0, Convert.ToInt32(textBox1.Text));
            int[] a = new int[5];
            etiket:
            a = istemci.ReadHoldingRegisters(0, 1);
            if (a[0] == 5)
            {
                goto etiket2;
            }
            goto etiket;
            etiket2:
            textBox1.Text = a[0].ToString();
            istemci.ReceiveDataChanged += İstemci_ReceiveDataChanged;
            istemci.Disconnect();
        }

        private void İstemci_ReceiveDataChanged(object sender)
        {
            textBox1.Text = istemci.ReadHoldingRegisters(0, 1).ToString();
            //textBox1.Text = istemci.ReadHoldingRegisters()
        }
    }
}

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
using Modbus.Data;
using Modbus.Device;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO.Ports;
using System.Net.NetworkInformation;
using System.Data.SqlClient;



namespace DenemeNModbusConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ok;
            ushort adrx = 0;
            ushort adry = 1;
            ushort adrz = 2;
            ushort adrh = 3;
            ushort adrok = 0;
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("192.168.0.1", 502);
            ModbusIpMaster master = ModbusIpMaster.CreateIp(tcpClient);
            
            ushort x = (ushort)Convert.ToInt32(textBox1.Text);
            ushort y = (ushort)Convert.ToInt32(textBox2.Text);
            ushort z = (ushort)Convert.ToInt32(textBox3.Text);
            ushort h = (ushort)Convert.ToInt32(textBox4.Text);
            if (checkBox1.Checked)
                ok = true;
            else
                ok = false;
            master.WriteSingleRegister(adrx, x);
            master.WriteSingleRegister(adry, y);
            master.WriteSingleRegister(adrz, z);
            master.WriteSingleRegister(adrh, h);
            master.WriteSingleCoil(adrok, ok);

            ushort[] key = new ushort[4];
            key = master.ReadHoldingRegisters(0, 4);
            if (key[3] == 1)
            {
                textBox5.Text = "tamam";
            }
            tcpClient.Close();
            master.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modbus.Device;
using System.Net.Sockets;

namespace DenemeRobotHareket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            ushort adrx = 1;
            TcpClient tcpClient = new TcpClient();
            ModbusIpMaster master = ModbusIpMaster.CreateIp(tcpClient);
            tcpClient.Connect("192.168.0.100", 502);
            ushort x = (ushort)Convert.ToInt32(textBox1.Text);
            master.WriteSingleRegister(adrx, x);
            tcpClient.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ushort adrx0 = 0;
            TcpClient tcpClient = new TcpClient();
            ModbusIpMaster master = ModbusIpMaster.CreateIp(tcpClient);
            tcpClient.Connect("192.168.0.100", 502);
            ushort y = (ushort)Convert.ToInt32(textBox2.Text);
            master.WriteSingleRegister(adrx0, y);
            tcpClient.Close();
        }
    }
}

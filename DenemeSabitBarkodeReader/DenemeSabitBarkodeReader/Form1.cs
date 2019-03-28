using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace DenemeSabitBarkodeReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            readBarcode();
        }

        private void readBarcode()
        {
            byte[] a = new byte[1];
            byte[] b = new byte[1];
            byte[] received = new byte[30];
            a[0] = 43;
            b[0] = 45;
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            s.Connect(new IPEndPoint(IPAddress.Parse("192.168.0.5"), 10003));
            s.Send(a);
            s.ReceiveTimeout = 5000;
            int c = 0;
            try
            {
                c = s.Receive(received);
                textBox1.Text = System.Text.Encoding.UTF8.GetString(received);
                c = s.Receive(received);
                textBox2.Text = System.Text.Encoding.UTF8.GetString(received);
            }
            catch (Exception)
            {
                s.Send(b);
            }
            s.Disconnect(false);
        }
    }
}

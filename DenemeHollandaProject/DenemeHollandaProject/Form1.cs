using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Modbus.Device;
using System.Net.Sockets;

namespace DenemeHollandaProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fileSystemWatcher1.EnableRaisingEvents = true;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        string[] colFields;//solvedCsv
        List<string> csvFileNames = new List<string>();

        SqlConnection conn = new SqlConnection("Data Source=TEKNIK_DOKUMAN; Initial Catalog=DenemeHollanda; User Id=burak; password=12345;");
        Thread th;

        private void button1_Click(object sender, EventArgs e)
        {
            th = new Thread(startSystem);
            DirectoryInfo di = new DirectoryInfo(@fileSystemWatcher1.Path);
            FileInfo[] TXTFiles = di.GetFiles("*.csv");

            foreach (FileInfo fi in TXTFiles)
            {

                if (!csvFileNames.Contains(fi.Name))
                {
                    listBox1.Items.Add(fi.Name);
                    csvFileNames.Add(fi.Name);
                }
            }
            if (csvFileNames.Count != 0)
            {
                th.Start();
            }
        }

        private void startSystem()
        {
            for (int i = 0; i < csvFileNames.Count; i++)
            {
                readAndSendSql(@fileSystemWatcher1.Path + @"\" + csvFileNames[i], i);

                System.IO.File.Copy(@fileSystemWatcher1.Path + @"\" + csvFileNames[i], @"c:\users\lenovo\desktop\yeni klasör (2)\" + csvFileNames[i]);
                File.Delete(@fileSystemWatcher1.Path + @"\" + csvFileNames[i]);


                csvFileNames.RemoveAt(i);
                i--;
            }
        }

        public void readAndSendSql(string direction, int index)
        {
            TextFieldParser csvReader = new TextFieldParser(direction);
            csvReader.SetDelimiters(new string[] { ";" });
            colFields = csvReader.ReadFields();
            for (int i = 0; i < colFields.Length; i++)
            {
                if (colFields[i] == "")
                {
                    colFields[i] = null;
                }
            }
            //sendPlc();
            csvReader.Dispose();
            conn.Open();
            SqlCommand kmt = new SqlCommand("Insert into  tbl_csv VALUES  ('" + colFields[0] + "','" + colFields[1] + "','" + colFields[2] + "','" + colFields[3] + "','" + colFields[4] + "','" + colFields[5] + "','" + colFields[6] + "','" + colFields[7] + "','" + colFields[8] + "','" + colFields[9] + "','" + colFields[10] + "','" + colFields[11] + "','" + colFields[12] + "','" + colFields[13] + "','" + colFields[14] + "','" + colFields[15] + "')", conn);
            kmt.ExecuteNonQuery();
            conn.Close();
        }

        //public void sendPlc()
        //{
        //    if (colFields[2] == "")
        //    {
        //        ushort adres = 0;
        //        ushort value = 5;
        //        TcpClient tcpClient = new TcpClient();
        //        ModbusIpMaster master = ModbusIpMaster.CreateIp(tcpClient);
        //        tcpClient.Connect("192.168.0.1", 502);
        //        master.WriteSingleRegister(adres, value);
        //        tcpClient.Close();
        //    }
        //}

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            if (!csvFileNames.Contains(e.Name))
            {
                listBox1.Items.Add(e.Name);
                csvFileNames.Add(e.Name);
            }
            if (th.ThreadState != ThreadState.Running)
            {
                th = null;
                th = new Thread(startSystem);
                th.Start();
            }
        }
    }
}
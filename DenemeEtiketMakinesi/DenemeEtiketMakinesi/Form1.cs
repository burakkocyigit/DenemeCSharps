using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DenemeEtiketMakinesi
{
    public partial class Form1 : Form
    {
        string text;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            orderText();
            serialPort1.Write(text);
            serialPort1.Write(text);
        }

        public void orderText()
        {
            text =
            "#!A1#DC" +
            "#IMSR150.08/210.16" +
            "#RX0" +
            "#ERN/1//0" +
            "#R0/0" +

            "#T18.00 #J80.83" +
            "#YG/1///C:\\GRAPHICS\\kordsa_logo.gif#G" +

            "#T148.41 #J204.50 #YB13/2P2.0O/10.16/3///300096902#G" +
            "#T148.58 #J66.50 #YB13/2P2.0O/10.16/3///300096902#G" +
            "#T148.66 #J139.41 #YB13/2P2.0O/10.16/3///300096902#G" +
            "#T115.58 #J205.00 #YB13/2P2.0O/20.00/13///300096902#G" +
            "#T03.83 #J181.00 #YL0/0/01.00/116.33" +
            "#T122.16 #J04.16 #YL0/1/01.00/200.16" +
            "#T39.58 #J05.66 #YL0/1/01.00/176.50" +
            "#T65.41 #J05.66 #YL0/1/01.00/176.50" +
            "#T81.91 #J05.08 #YL0/1/01.00/176.41" +
            "#T97.25 #J05.66 #YL0/1/01.00/176.50" +
            "#T22.91 #J05.08 #YL0/1/01.00/176.41" +
            "#T122.41 #J69.83 #YL0/0/01.00/27.25" +
            "#T122.25 #J143.33 #YL0/0/01.00/26.91" +
            "#T44.66 #J12.16 #YN101/1B/59///PALLET NO#G" +
            "#T28.75 #J12.16 #YN101/1B/59///MATERIAL#G" +
            "#T36.16 #J12.16 #YN101/1B/85///100% POLYESTER YARN#G" +
            "#T50.08 #J136.83 #YN101/1B/59///MERGE#G" +
            "#T27.50 #J137.58 #YN101/1B/59///REF-PIN#G" +
            "#T37.66 #J137.00 #YN101/1B/119///KO900#G" +
            "#T19.41 #J82.91 #YN101/1B/55///Made in TURKEY#G" +
            "#T62.58 #J11.08 #YN101/1B/288///300096902#G" +
            "#T61.00 #J136.58 #YN101/1B/119///1P1421#G" +
            "#T71.50 #J11.25 #YN101/1B/59///TYPE#G" +
            "#T78.58 #J11.25 #YN101/1B/85///SA80#G" +
            "#T71.16 #J78.75 #YN101/1B/59///DTEX/DENIER#G" +
            "#T78.58 #J78.75 #YN101/1B/85///1440/1296#G" +
            "#T70.58 #J136.66 #YN101/1B/59///FILAMENTS#G" +
            "#T78.91 #J137.08 #YN101/1B/102///432#G" +
            "#T101.91 #J10.16 #YN101/1B/59///COMMERCIAL WEIGHT#G" +
            "#T110.50 #J10.25 #YN101/1B/85///0685,9 KG#G" +
            "#T119.00 #J10.25 #YN101/1B/85///1512,1 LB#G" +
            "#T87.00 #J10.41 #YN101/1B/59///PACK DATE#G" +
            "#T93.41 #J10.41 #YN101/1B/85///03-09-2018#G" +
            "#T86.50 #J78.08 #YN101/1B/59///## OF BOBBINS#G" +
            "#T93.50 #J78.16 #YN101/1B/85///80#G" +
            "#T86.66 #J136.50 #YN101/1B/59///ICN#G" +
            "#T95.58 #J136.16 #YN101/1B/102///700109957#G" +
            "#T101.91 #J77.58 #YN101/1B/59///GROSS WEIGHT#G" +
            "#T110.50 #J77.58 #YN101/1B/85///0767,5 KG#G" +
            "#T119.00 #J77.58 #YN101/1B/85///1692,0 LB#G" +
            "#T102.66 #J136.16 #YN101/1B/59///ERP CODE#G" +
            "#T130.66 #J10.50 #YN101/1B/85///300096902#G" +
            "#T130.91 #J76.33 #YN101/1B/85///300096902#G" +
            "#T136.41 #J10.91 #YN101/1B/42///1P1421-1440/SA80#G" +
            "#T113.75 #J135.33 #YN101/1B/102///1191191#G" +
            "#T142.41 #J11.25 #YN101/1B/59///1191191#G" +
            "#T136.75 #J76.75 #YN101/1B/42///1P1421-1440/SA80#G" +
            "#T146.58 #J11.75 #YN101/1B/42///03-09-2018#G" +
            "#T132.91 #J148.83 #YN101/1B/102///300096902#G" +
            "#T142.66 #J77.08 #YN101/1B/59///1191191#G" +
            "#T137.33 #J149.33 #YN101/1B/42///1P1421-1440/SA80#G" +
            "#T146.91 #J77.58 #YN101/1B/42///03-09-2018#G" +
            "#T143.33 #J149.66 #YN101/1B/59///1191191#G" +
            "#T147.50 #J150.08 #YN101/1B/42///03-09-2018#G" +
            "#Q1#G" +
            "#!P1";
        }
    }
}

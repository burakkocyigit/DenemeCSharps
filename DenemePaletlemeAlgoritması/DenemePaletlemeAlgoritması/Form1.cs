using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using Modbus.Device;

namespace DenemePaletlemeAlgoritması
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Paletleme(1000, 0, 0, 1200, 1200, 100, 300, 300, 100, 0);
        }

        public void Paletleme(int maxHight, int reference_x, int reference_y, int paletX, int paletY, int paletZ, int productX, int productY, int productZ, int tolerans)
        {
            ushort gripperAdress = 1;                            //GRİPPER REGISTER ADRESİ ATANMALI !!!
            ushort[] gripperOffsets = new ushort[3];             //OFFSET DEĞERLERİ ATANMALI !!!
            ushort gripperControl = 0;

            TcpClient Client = new TcpClient();
            ModbusIpMaster master = ModbusIpMaster.CreateIp(Client);

            int calculateX, calculateY, calculateZ, AdjustedReferenceX, AdjustedReferenceY, AdjustedReferenceZ, initialX, initialY, initialZ;
            calculateZ = maxHight / productZ;
            calculateY = paletY / productY;
            AdjustedReferenceY = (paletY - calculateY * productY) / 2 + reference_y;
            calculateX = paletY / productX;
            AdjustedReferenceX = (paletX - calculateX * productX) / 2 + reference_x;
            AdjustedReferenceZ = paletZ;
            initialX = AdjustedReferenceX;
            initialY = AdjustedReferenceY;
            initialZ = AdjustedReferenceZ;

            ushort offsetX, offsetY, offsetZ;
            Client.Connect("192.168.0.1", 502);
            for (int k = 0; k < calculateZ; k++)
            {
                for (int j = 0; j < calculateY; j++)
                {
                    for (int i = 0; i < calculateX; i++)
                    {
                        offsetX = (ushort)(AdjustedReferenceX + productX / 2 + i * productX);
                        offsetY = (ushort)(AdjustedReferenceY + productY / 2);
                        offsetZ = (ushort)(AdjustedReferenceZ + productZ);

                        ushort offsetAdress = 2;                       //OFFSET REGISTER ADRESİ ATANMALI !!!
                        ushort[] offsetValues = new ushort[3];
                        offsetValues[0] = offsetX;
                        offsetValues[1] = offsetY;
                        offsetValues[2] = offsetZ;
                        while (true)
                        {
                            master.ReadHoldingRegisters(gripperAdress, gripperControl);
                            if (gripperControl == 1)
                            {
                                master.WriteMultipleRegisters(offsetAdress, offsetValues);
                                break;
                            }
                        }
                        while (true)
                        {
                            master.ReadHoldingRegisters(gripperAdress, gripperControl);
                            if (gripperControl == 0)
                            {
                                master.WriteMultipleRegisters(offsetAdress, gripperOffsets);
                                break;
                            }
                        }
                    }
                    AdjustedReferenceX = initialX;
                    AdjustedReferenceY = AdjustedReferenceY + productY;
                }
                AdjustedReferenceX = initialX;
                AdjustedReferenceY = initialY;
                AdjustedReferenceZ = AdjustedReferenceZ + productZ;
            }
        }
    }
}

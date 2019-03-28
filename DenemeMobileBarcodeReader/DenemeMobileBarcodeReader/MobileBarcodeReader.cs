using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Ports;
using System.Windows.Forms;

namespace DenemeMobileBarcodeReader
{
    public delegate void DataController();
    class MobileBarcodeReader
    {
        public event DataController DataEvent;
        SerialPort _mobileBarcodeReader;
        public string _data;
        private bool connected;
        public string data {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                if (DataEvent != null)
                {
                    DataEvent();
                }
            }
        }
        public MobileBarcodeReader(SerialPort serialPort)
        {
            _mobileBarcodeReader = serialPort;
            _mobileBarcodeReader.DataReceived += _mobileBarcodeReader_DataReceived;
        }

        private void _mobileBarcodeReader_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(20);
            data = _mobileBarcodeReader.ReadExisting();
        }

        public bool open()
        {
            if (_mobileBarcodeReader.IsOpen!=true)
            {
                try
                {
                    _mobileBarcodeReader.Open();
                    bool r = (_mobileBarcodeReader.IsOpen == true);
                    connected = r;
                    return r;
                }
                catch (System.IO.IOException Ex)
                {
                    string ErrorMessage = "Mobil barkod okuyucuya bağlanırken hata ile karşılaşıldı.";
                    ErrorMessage += Environment.NewLine;
                    ErrorMessage += Environment.NewLine;
                    ErrorMessage += Ex.Message;
                    MessageBox.Show(ErrorMessage, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return false;
        }
        public void close()
        {
            if (_mobileBarcodeReader.IsOpen==true)
            {
                try
                {
                    _mobileBarcodeReader.Close();
                }
                catch (System.IO.IOException Ex)
                {
                    string ErrorMessage = "Mobil barkod okuyucuya bağlanırken hata ile karşılaşıldı.";
                    ErrorMessage += Environment.NewLine;
                    ErrorMessage += Environment.NewLine;
                    ErrorMessage += Ex.Message;
                    MessageBox.Show(ErrorMessage, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

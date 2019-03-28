using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyModbus;
using System.Threading;

namespace denemeOmerModbus
{
    public delegate void Register1Controller();
    public delegate void Register2Controller();
    public delegate void Register3Controller();
    public delegate void Register4Controller();
    class Plc
    {
        public event Register1Controller Register1Event;
        public event Register2Controller Register2Event;
        public event Register3Controller Register3Event;
        public event Register4Controller Register4Event;
        public int register1
        {
            get
            {
                return _register1;
            }
            set
            {
                _register1 = value;
                if (_register1 != __register1 && Register1Event != null)
                {
                    __register1 = _register1;
                    Register1Event();
                }
            }
        }
        public int register2
        {
            get
            {
                return _register2;
            }
            set
            {
                _register2 = value;
                if (_register2 != __register2 && Register2Event != null)
                {
                    __register2 = _register2;
                    Register2Event();
                }
            }
        }
        public int register3
        {
            get
            {
                return _register3;
            }
            set
            {
                _register3 = value;
                if (_register3 != __register3 && Register3Event != null)
                {
                    __register3 = _register3;
                    Register3Event();
                }
            }
        }
        public int register4
        {
            get
            {
                return _register4;
            }
            set
            {
                _register4 = value;
                if (_register4 != __register4 && Register4Event != null)
                {
                    __register4 = _register4;
                    Register4Event();
                }
            }
        }
        private int _register1;
        private int _register2;
        private int _register3;
        private int _register4;
        private int __register1;
        private int __register2;
        private int __register3;
        private int __register4;
        private int[] registers = new int[4];
        ModbusClient _client = new ModbusClient("192.168.0.1", 502);

        public void readPlc()
        {
            _client.Connect();
            //Thread.Sleep(100);
            registers = _client.ReadHoldingRegisters(0, 4);
            _client.Disconnect();
            register1 = registers[0];
            register2 = registers[1];
            register3 = registers[2];
            register4 = registers[3];
        }
        public void writePlc(int address, int value)
        {
            _client.Connect();
            _client.WriteSingleRegister(address, value);
            _client.Disconnect();
        }
    }
}

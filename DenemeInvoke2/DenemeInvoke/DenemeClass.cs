using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace denemeInvoke
{
    public delegate void Controller();
    class DenemeClass
    {
        public event Controller ControllerEvent;

        public int degisken
        {
            get
            {
                return _degisken;
            }
            set
            {
                _degisken = value;
                if (_degisken != __degisken && ControllerEvent != null)
                {
                    __degisken = degisken;
                    ControllerEvent();
                }
            }
        }
        private int _degisken = 0;
        private int __degisken = 0;

        Form1 copyForm = new Form1();
        public DenemeClass(Form1 form)
        {
            copyForm = form;
        }

        public void degistir(int a)
        {
            degisken = a;
        }
    }
}

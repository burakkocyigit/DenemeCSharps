using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;

namespace S7.Net_Example
{
    public partial class FormMain : Form
    {
        //Declare variables & constants.
        private Plc plc = null;
        private ErrorCode errorState = ErrorCode.NoError;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {  
            try
            {
                cboxCPUType.DataSource = Enum.GetNames(typeof(CpuType));
                cboxCPUType.SelectedIndex = 3;//default is S7 1200
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (plc != null)
                {
                    plc.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                CpuType cpuType = (CpuType)Enum.Parse(typeof(CpuType), cboxCPUType.SelectedValue.ToString());
                string ipAddress = txtIPAddress.Text;
                short rack = short.Parse(txtRack.Text);
                short slot = short.Parse(txtSlot.Text);
                plc = new Plc(cpuType, ipAddress, rack, slot);
                errorState = plc.Open();
                btnConnect.Enabled = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (plc != null)
                {
                    plc.Close();
                }
                btnConnect.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMRead_Click(object sender, EventArgs e)
        {
            try
            {
                if(plc != null)
                {
                    string variable = txtMAddress.Text;
                    object result = plc.Read(variable);
                    txtPV.Text = string.Format("{0}", result.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMWrite_Click(object sender, EventArgs e)
        {
            try
            {
                if (plc != null)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

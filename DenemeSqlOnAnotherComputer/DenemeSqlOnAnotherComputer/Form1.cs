using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DenemeSqlOnAnotherComputer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=192.168.1.2; Initial Catalog=SatınalmaExcel; User Id=BurakExcel; password=12345;");

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            DataTable tbl = new DataTable();
            SqlDataAdapter adptr = new SqlDataAdapter("Select Tedarikçi,Açıklama from tbl_takip ", conn);
            adptr.Fill(tbl);
            conn.Close();
            dataGridView1.DataSource = tbl;
            conn.Close();
        }
    }
}

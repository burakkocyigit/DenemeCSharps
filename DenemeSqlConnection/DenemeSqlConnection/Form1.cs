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

namespace DenemeSqlConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DatagridYenile();
        }

        SqlConnection conn = new SqlConnection("Data Source=TEKNIK_DOKUMAN; Initial Catalog=ders; User Id=burak; password=12345;");

        protected void DatagridYenile()
        {
            conn.Open();
            DataTable tbl = new DataTable();
            SqlDataAdapter adptr = new SqlDataAdapter("Select kullanici_id,adi,soyadi,kullaniciadi,parola from tbkullanicilar ", conn);
            adptr.Fill(tbl);
            conn.Close();
            dataGridView1.DataSource = tbl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("Insert into  tbkullanicilar VALUES  ('" + txbAdi.Text + "','" + txbSoyadi.Text + "','" + txbKullaniciadi.Text + "','" + txbParola.Text + "')", conn);
            kmt.ExecuteNonQuery();
            conn.Close();
            DatagridYenile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("DELETE  tbkullanicilar where kullanici_id=" + dataGridView1.CurrentRow.Cells["kullanici_id"].Value.ToString(), conn);
            kmt.ExecuteNonQuery();
            conn.Close();
            DatagridYenile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("update tbkullanicilar set adi='"+txbAdi.Text+"' ,soyadi='"+txbSoyadi.Text+"' ,kullaniciadi='"+txbKullaniciadi.Text+"' ,parola='"+txbParola.Text+"' where kullanici_id=" + dataGridView1.CurrentRow.Cells["kullanici_id"].Value.ToString(),conn);
            kmt.ExecuteNonQuery();
            conn.Close();
            DatagridYenile();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace DenemeCsvWriting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection("Data Source=TEKNIK_DOKUMAN; Initial Catalog=ders; User Id=burak; password=12345;");
            sqlCon.Open();

            SqlCommand sqlCmd = new SqlCommand("select * from tbkullanicilar", sqlCon);
            SqlDataReader reader = sqlCmd.ExecuteReader();

            string directory = @"C:\Users\Lenovo\Desktop\Yeni klasör (2)";
            string filename = "test.csv";
            string path = Path.Combine(directory, filename);
            StreamWriter sw = File.CreateText(path);
            object[] output = new object[reader.FieldCount];

            for (int i = 0; i < reader.FieldCount; i++)
            {
                output[i] = reader.GetName(i);
            }
            sw.WriteLine(string.Join(";", output));
            while (reader.Read())
            {
                reader.GetValues(output);
                sw.WriteLine(string.Join(";", output));
            }
            sw.Close();
            reader.Close();
            sqlCon.Close();
        }
    }
}

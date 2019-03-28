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
using Microsoft.VisualBasic.FileIO;

namespace DenemeHollandaProject2
{
    public partial class Form1 : Form
    {

        string[] colFields;
        SqlConnection conn = new SqlConnection("Data Source=TEKNIK_DOKUMAN; Initial Catalog=DenemeHollanda; User Id=burak; password=12345;");


        public Form1()
        {
            InitializeComponent();
        }

        public void csvParser()
        {
            TextFieldParser csvReader = new TextFieldParser(SapFolderDirection);
            csvReader.SetDelimiters(new string[] { ";" });
            colFields = csvReader.ReadFields();
            for (int i = 0; i < colFields.Length; i++)
            {
                if (colFields[i] == "")
                {
                    colFields[i] = null;
                }
            }
            csvReader.Dispose();
        }
        public void sendSql()//coFields lerin indexleri ve sql sorgularındaki tablolar yanlış en son düzeltilecek
        {
            conn.Open();
            if (colFields[1] == "paketli")
            {
                SqlCommand kmt = new SqlCommand("Insert into  tbl_csv VALUES  ('" + colFields[0] + "','" + colFields[1] + "','" + colFields[2] + "','" + colFields[3] + "','" + colFields[4] + "','" + colFields[5] + "','" + colFields[6] + "','" + colFields[7] + "','" + colFields[8] + "','" + colFields[9] + "','" + colFields[10] + "','" + colFields[11] + "','" + colFields[12] + "','" + colFields[13] + "','" + colFields[14] + "','" + colFields[15] + "')", conn);
                kmt.ExecuteNonQuery();
            }
            else if (colFields[2] == "boyalı")
            {

            }
        }
    }
}

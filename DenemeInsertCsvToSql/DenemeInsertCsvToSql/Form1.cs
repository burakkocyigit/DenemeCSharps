using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace DenemeInsertCsvToSql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { ";" });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return csvData;
        }

        static void InsertDataIntoSQLServerUsingSQLBulkCopy(DataTable csvFileData)
        {
            using (SqlConnection dbConnection = new SqlConnection("Data Source=TEKNIK_DOKUMAN; Initial Catalog=ders; User Id=burak; password=12345;"))
            {
                dbConnection.Open();
                using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
                {
                    s.DestinationTableName = "tbkullanicilar";
                    foreach (var column in csvFileData.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());
                    s.WriteToServer(csvFileData);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Lenovo\Desktop\burak\visual studio\DenemeCsvWriting\DenemeCsvWriting\bin\Debug");
            FileInfo[] TXTFiles = di.GetFiles("*.csv");

            foreach (FileInfo fi in TXTFiles)
            {
                listBox1.Items.Add(fi.Name);
            }
            foreach(FileInfo fil in TXTFiles)
            {
                InsertDataIntoSQLServerUsingSQLBulkCopy(GetDataTabletFromCSVFile(@"C:\Users\Lenovo\Desktop\Yeni klasör (2)\" + fil.Name));
            }
        }
    }
}

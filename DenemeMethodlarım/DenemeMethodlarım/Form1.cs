using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.Data.SqlClient;

namespace DenemeMethodlarım
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static DataTable GetDataTabletFromCSVFile(string csv_file_path) //insertCsvToSql methodu kullanıyor.
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

        static void InsertDataIntoSQLServerUsingSQLBulkCopy(DataTable csvFileData) //insertCsvToSql methodu kullanıyor.
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
        public void insertCsvToSql() //hedef klasörün içindeki csv dosyalarını sql'e gönderir.
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Lenovo\Desktop\burak\visual studio\DenemeCsvWriting\DenemeCsvWriting\bin\Debug");
            FileInfo[] TXTFiles = di.GetFiles("*.csv");

            foreach (FileInfo fil in TXTFiles)
            {
                InsertDataIntoSQLServerUsingSQLBulkCopy(GetDataTabletFromCSVFile(@"C:\Users\Lenovo\Desktop\burak\visual studio\DenemeCsvWriting\DenemeCsvWriting\bin\Debug\" + fil.Name));
            }
        }
        public void exportCsvFromSql() //Belirlenen hedefte bir csv doyası oluşturur ve sql den verileri alıp içine aktarır
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
        public void tasiSil() //kaynak dosya yolundaki dosyaları bulur hedef klasöre kopyalar ve kaynaktan siler.
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Lenovo\Desktop\burki burki\");
            FileInfo[] TXTFiles = di.GetFiles("*.csv");

            foreach (FileInfo fi in TXTFiles)
            {
                System.IO.File.Copy(@"C:\Users\Lenovo\Desktop\burki burki\" + fi.Name, @"C:\Users\Lenovo\Desktop\Yeni klasör (2)\" + fi.Name);
                System.IO.File.Delete(@"C:\Users\Lenovo\Desktop\burki burki\" + fi.Name);
            }
        }
        public string TakeCsvValues(int a) //csv dosyasının içini bir string arrayin içine alır ve bu stringin istenilen değerini döndürür
        {
            TextFieldParser csvReader = new TextFieldParser(@"C:\Users\Lenovo\Desktop\burki burki\0001992103.csv");
            csvReader.SetDelimiters(new string[] { ";" });
            string[] colFields = csvReader.ReadFields();
            for (int i = 0; i < colFields.Length; i++)
            {
                if (colFields[i] == "")
                {
                    colFields[i] = null;
                }
            }
            return colFields[a];
        }

    }
}

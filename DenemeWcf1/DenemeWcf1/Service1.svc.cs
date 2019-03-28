using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;

namespace DenemeWcf1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-E0NJGAQ5; Initial Catalog=DeneWebservice; User Id=sa; password=12345;");

       
        public void GetData(string txbAdi,string txbSoyadi,string txbTelefon)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("Insert into  tbl_kisiler VALUES  ('" + txbAdi + "','" + txbSoyadi + "','" + txbTelefon + "')", conn);
            kmt.ExecuteNonQuery();
            conn.Close();
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}

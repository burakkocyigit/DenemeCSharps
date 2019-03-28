using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDependency.SqlClient;

namespace DenemeSqlListener
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "data source=BURAKKOCYIGIT;initial catalog=DenemeListenerForSql;integrated security=True";
            using (var tableDependency = new SqlTableDependency<Customer>(connectionString, "Customers"))
            {
                tableDependency.OnChanged += TableDependency_OnChanged;
                tableDependency.OnError += TableDependency_OnError;

                tableDependency.Start();
                Console.WriteLine("Waiting for receiving notifications...");
                Console.WriteLine("Press a key to stop");
                Console.ReadKey();
                tableDependency.Stop();
            }
        }
        private static void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Customer> e)
        {
            Console.WriteLine(Environment.NewLine);

            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                var changedEntity = e.Entity;
                Console.WriteLine("DML operation: " + e.ChangeType);
                Console.WriteLine("ID: " + changedEntity.Id);
                Console.WriteLine("Name: " + changedEntity.Name);
                Console.WriteLine("Surname: " + changedEntity.Surname);
                Console.WriteLine(Environment.NewLine);
            }
        }

        private static void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Exception ex = e.Error;
            throw ex;
        }
    }
}

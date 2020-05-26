using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineInventorySystem.Data
{
    class DatabaseClass
    {
        public readonly string dbconnection;

       public DatabaseClass()
        {
            dbconnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OnlineInventorySystem;";
        }

       public DatabaseClass(string connection)
       {
           dbconnection = connection;
       }
    }
}

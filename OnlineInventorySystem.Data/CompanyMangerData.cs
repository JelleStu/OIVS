using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data.Sql;
using System.Data;

namespace OnlineInventorySystem.Data
{
    public class CompanyMangerData
    {
        private readonly DatabaseClass dbClass = new DatabaseClass();

        public int Login(string username, string psword)
        {
            using (SqlConnection connection = new SqlConnection(dbClass.dbconnection))
            {
                using (SqlCommand query =
                    new SqlCommand(
                        "select companyID, name, password FROM companies WHERE name =@username AND password =@psword",
                        connection))
                {
                    query.Parameters.AddWithValue("@username", username);
                    query.Parameters.AddWithValue("@psword", psword);
                    connection.Open();

                    SqlDataAdapter da = new SqlDataAdapter(query);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        int id = row.Field<int>("companyID");
                        return id;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
    }
}

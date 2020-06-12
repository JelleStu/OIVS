using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OnlineInventorySystem.Data
{
    public class SQLCompanyContext : ICompanyRepository<CompanyDTO>
    {
        private readonly string connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OnlineInventorySystem;";
        public CompanyDTO Login(string username, string psword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("select companyID, name, password FROM companies WHERE name =@username AND password =@psword",
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
                        CompanyDTO company = new CompanyDTO();
                        company.companyID = id;
                        return company;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public CompanyDTO GetCompanyByID(int id)
        {
            CompanyDTO company = new CompanyDTO();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("select companyID FROM companies WHERE companyID =@id",
                    connection))
                {
                    query.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        company.companyID = reader.GetInt32(0);
                    }
                }
            }
            return company;
        }
    }
}

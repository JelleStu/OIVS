using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventorySystem.Data
{
    class ProductRepository : IProductRepository, IDisposable
    {
        // Context
        public ProductRepository(IProductRepository context)
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetProducts(int companyID)
        {
            List<ProductDto> products = new List<ProductDto>();

            using (SqlConnection connection = new SqlConnection(dbClass.dbconnection))
            {
                using (SqlCommand query = new SqlCommand("select * FROM products WHERE companyID = @companyID", connection))
                {
                    query.Parameters.AddWithValue("@companyID", companyID);
                    connection.Open();
                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductDto product = new ProductDto
                        {
                            productId = reader.GetInt32(0),
                            productName = reader.GetString(1),
                            productDescription = reader.GetString(2),
                            quantity = reader.GetInt32(3),
                            productPrice = reader.GetDecimal(4),
                            companyID = reader.GetInt32(5),
                            productCategory = reader.GetString(6)
                        };
                        products.Add(product);
                    }
                    connection.Close();
                    return products;
                }

            }
        }

        public Task<ProductDto> GetProductByID(int studentID)
        {
            throw new NotImplementedException();
        }

        public void InsertProduct(ProductDto product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(ProductDto product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(ProductDto product)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save()
        {
            throw new NotImplementedException();
        }
    }
}

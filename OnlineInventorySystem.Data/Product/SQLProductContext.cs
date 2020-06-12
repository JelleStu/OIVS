using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineInventorySystem.Data.Product;

namespace OnlineInventorySystem.Data
{
    public class SQLProductContext : IProductContext<ProductDto>
    {
        private readonly string connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OnlineInventorySystem;";
        public List<ProductDto> GetProducts(int companyID)
        {
            List<ProductDto> products = new List<ProductDto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
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

        public ProductDto GetProductByID(int productID)
        {
            ProductDto product = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("select * from products where productID = @productID", connection))
                {
                    query.Parameters.AddWithValue("@productID", productID);
                    connection.Open();
                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        product = new ProductDto
                        {
                            productId = reader.GetInt32(0),
                            productName = reader.GetString(1),
                            productDescription = reader.GetString(2),
                            quantity = reader.GetInt32(3),
                            productPrice = reader.GetDecimal(4),
                            companyID = reader.GetInt32(5),
                            productCategory = reader.GetString(6)
                        };

                    }
                    connection.Close();
                    return product;
                }
            }
        }

        public void InsertProduct(string _name, string _description, int _quantity, decimal _price, int companyID, string productCategory)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("INSERT INTO products(productName, productDescription, quantity, productPrice, companyID, category) VALUES (@name, @description, @quantity, @price, @companyID, @category)", connection))
                {
                    query.Parameters.AddWithValue("@name", _name);
                    query.Parameters.AddWithValue("@description", _description);
                    query.Parameters.AddWithValue("@quantity", _quantity);
                    query.Parameters.AddWithValue("@price", _price);
                    query.Parameters.AddWithValue("@companyID", companyID);
                    query.Parameters.AddWithValue("@category", productCategory);

                    connection.Open();
                    query.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void DeleteProduct(int productID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("DELETE FROM products WHERE productID = @id", connection))
                {
                    query.Parameters.AddWithValue("@id", productID);

                    connection.Open();
                    query.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void UpdateProduct(int productid, string productname, string productdescription, int quantity,
            decimal price)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("UPDATE products SET productName = @name, productDescription = @description, quantity = @quantity, productPrice = @price WHERE productID = @id", connection))
                {
                    query.Parameters.AddWithValue("@id", productid);
                    query.Parameters.AddWithValue("@name", productname);
                    query.Parameters.AddWithValue("@description", productdescription);
                    query.Parameters.AddWithValue("@quantity", quantity);
                    query.Parameters.AddWithValue("@price", price);
                    
                    connection.Open();
                    query.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public List<ProductDto> GetProductsByCategory(string category, int companyID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand query =
                    new SqlCommand("SELECT * FROM products WHERE companyID = @companyID AND category = @category",
                        connection))
                {
                    query.Parameters.AddWithValue("@companyID", companyID);
                    query.Parameters.AddWithValue("@category", category);

                    connection.Open();

                    List<ProductDto> productsCategorized = new List<ProductDto>();
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
                        productsCategorized.Add(product);
                    }
                    return productsCategorized;
                }
            }
        }
    }
}

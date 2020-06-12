using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using OnlineInventorySystem.Data.Product;

namespace OnlineInventorySystem.Data
{
    public class ProductRepository : IProductRepository<ProductDto>
    {
        private IProductContext<ProductDto> context;

        public ProductRepository(IProductContext<ProductDto> _context)
        {
            context = _context;
        }

        public List<ProductDto> GetProducts(int companyID)
        {
          return context.GetProducts(companyID);
        }

        public ProductDto GetProductByID(int productID)
        {
            return context.GetProductByID(productID);
        }

        public void InsertProduct(string _name, string _description, int _quantity, decimal _price, int companyID, string productCategory)
        {
            context.InsertProduct(_name, _description, _quantity, _price, companyID, productCategory);
        }

        public void DeleteProduct(int productID)
        {
            context.DeleteProduct(productID);
        }

        public void UpdateProduct(int productid, string productname, string productdescription, int quantity,
            decimal price)
        {
            context.UpdateProduct(productid, productname, productdescription, quantity, price);
        }

        public List<ProductDto> GetProductsByCategory(string category, int companyID)
        {
            return context.GetProductsByCategory(category, companyID);
        }
    }
}

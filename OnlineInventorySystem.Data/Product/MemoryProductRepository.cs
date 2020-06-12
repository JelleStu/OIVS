using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineInventorySystem.Data.Product
{
    public class MemoryProductRepository : IProductContext<ProductDto>
    {
        private List<ProductDto> productList;
        private ProductDto newproduct;
        
        public MemoryProductRepository()
        {
            productList = new List<ProductDto>();
            
        }
        public List<ProductDto> GetProducts(int companyID)
        {
            return productList;
        }

        public ProductDto GetProductByID(int _productID)
        {
          ProductDto product = productList.SingleOrDefault(p => p.productId == _productID);
          return product;
        }

        public void InsertProduct(string _name, string _description, int _quantity, decimal _price, int _companyID,
            string _productCategory)
        {
            newproduct = new ProductDto()
            {
                productId = 1,
                productName = _name,
                productDescription = _description,
                quantity = _quantity,
                productPrice = _price,
                companyID = _companyID,
                productCategory = _productCategory
            };
            productList.Add(newproduct);
        }

        public void DeleteProduct(int productID)
        {
            ProductDto product = productList.SingleOrDefault(p => p.productId == productID);
            productList.Remove(product);
        }

        public void UpdateProduct(int _productid, string _productname, string _productdescription, int _quantity, decimal _price)
        {
            productList.SingleOrDefault(p => p.productId == _productid).productName = _productname;
            productList.SingleOrDefault(p => p.productId == _productid).productDescription = _productdescription;
            productList.SingleOrDefault(p => p.productId == _productid).quantity = _quantity;
            productList.SingleOrDefault(p => p.productId == _productid).productPrice = _price;
        }

        public List<ProductDto> GetProductsByCategory(string category, int companyID)
        {
            throw new NotImplementedException();
        }
    }
}

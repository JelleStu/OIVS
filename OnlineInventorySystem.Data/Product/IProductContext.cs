using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineInventorySystem.Data.Product
{
    public interface IProductContext<T> where T : ProductDto
    {
        List<T> GetProducts(int companyID);
        T GetProductByID(int productID);

        void InsertProduct(string _name, string _description, int _quantity, decimal _price, int companyID, string productCategory);
        void DeleteProduct(int productID);
        void UpdateProduct(int productid, string productname, string productdescription, int quantity,
            decimal price);

        List<T> GetProductsByCategory(string category, int companyID);
    }
}

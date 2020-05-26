using System;
using System.Collections.Generic;
using OnlineInventorySystem.Data;

namespace OnlineInventorySystem.Logic
{
    public class ProductManagerLogic
    {
        private readonly ProductDatabaseManager productDatabaseManager;

        public ProductManagerLogic()
        {
             productDatabaseManager = new ProductDatabaseManager();
        }
        public List<ProductLogic> GetAllProducts(int companyID)
        {
            List<ProductDto> productsDTO = productDatabaseManager.GetAllProducts(companyID);
            return ConvertToProductLogic(productsDTO);
        }

        public ProductLogic GetProductById(int id)
        {
            ProductDto productDTO = productDatabaseManager.GetProductById(id);
            if (productDTO == null) return null;
            ProductLogic productLogic = new ProductLogic
            {
                productId = productDTO.productId,
                productName = productDTO.productName,
                productDescription = productDTO.productDescription,
                quantity = productDTO.quantity,
                productPrice = productDTO.productPrice
            };
            return productLogic;
            }

        public void EditProduct(int productid, string productname, string productdescription, int quantity,
            decimal price)
        {
            productDatabaseManager.EditProduct(productid, productname, productdescription, quantity, price);
        }

        public void CreateProduct(string productname, string productdescription,int quantity, decimal price, int companyID, string productCategory)
        {
            productDatabaseManager.CreateProduct(productname, productdescription, quantity, price, companyID, productCategory);
        }

        public void DeleteProduct(int id)
        {
            productDatabaseManager.DeleteProduct(id);
        }

        public List<ProductLogic> GetCategoryProduct(string category, int companyID)
        {
           var productsDTO = productDatabaseManager.GetProductsCategory(category, companyID);
           return ConvertToProductLogic(productsDTO);

        }

        private List<ProductLogic> ConvertToProductLogic(List<ProductDto> productsDTO)
        {
            List<ProductLogic> productsLogic = new List<ProductLogic>();
            foreach (var productDTO in productsDTO)
            {
                ProductLogic productLogic = new ProductLogic();
                productLogic.productId = productDTO.productId;
                productLogic.productName = productDTO.productName;
                productLogic.productDescription = productDTO.productDescription;
                productLogic.quantity = productDTO.quantity;
                productLogic.productPrice = productDTO.productPrice;
                productLogic.companyID = productDTO.companyID;
                productLogic.productCategory = productDTO.productCategory;
                productsLogic.Add(productLogic);
            }
            return productsLogic;
        } 
    }
}
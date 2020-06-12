using System;
using System.Collections.Generic;
using OnlineInventorySystem.Data;
using OnlineInventorySystem.Data.Product;

namespace OnlineInventorySystem.Logic
{
    public class ProductManager
    {
        private ProductRepository productRepository;
        private SQLProductContext sqlProductContext;
        private Company company;

        public ProductManager(Company _copmany)
        {
            company = _copmany;
            sqlProductContext = new SQLProductContext();
            productRepository = new ProductRepository(sqlProductContext);
        }
        public ProductManager(Company _copmany, IProductContext<ProductDto> context)
        {
            company = _copmany;
            productRepository = new ProductRepository(context);
        }
        public List<ProductLogic> GetAllProducts(int companyID)
        {
           List<ProductDto> productsDTO = productRepository.GetProducts(companyID);
            return ConvertToProductLogic(productsDTO);
        }

        public ProductLogic GetProductById(int id)
        {
            ProductDto productDTO = productRepository.GetProductByID(id);
            if (productDTO == null) return null;
            ProductLogic productLogic = new ProductLogic
            {
                productId = productDTO.productId,
                productName = productDTO.productName,
                productDescription = productDTO.productDescription,
                quantity = productDTO.quantity,
                productPrice = productDTO.productPrice,
                company = company,
                productCategory = productDTO.productCategory
            };
            return productLogic;
            }

        public void EditProduct(int productid, string productname, string productdescription, int quantity,
            decimal price)
        {
            productRepository.UpdateProduct(productid, productname, productdescription, quantity, price);
        }

        public void CreateProduct(string productname, string productdescription,int quantity, decimal price, int companyID, string productCategory)
        {
            productRepository.InsertProduct(productname, productdescription, quantity, price, companyID, productCategory);
        }

        public void DeleteProduct(int id)
        {
            productRepository.DeleteProduct(id);
        }

        public List<ProductLogic> GetCategoryProduct(string category, int companyID)
        {
           var productsDTO = productRepository.GetProductsByCategory(category, companyID);
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
                productLogic.company = company;
                productLogic.productCategory = productDTO.productCategory;
                productsLogic.Add(productLogic);
            }
            return productsLogic;
        } 
    }
}
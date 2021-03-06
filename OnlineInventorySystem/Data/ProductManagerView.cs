﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineInventorySystem.Logic;

namespace OnlineInventorySystem.Data
{
    public class ProductManagerView
    {
        private ProductManager productManagerLogic;
        private Logic.Company company;

        public ProductManagerView(Logic.Company _company)
        {
            company = _company;
            productManagerLogic = new ProductManager(company);
        }
        public List<Productview> GetAllProducts(int companyID)
        {
            List<ProductLogic> productsLogic = productManagerLogic.GetAllProducts(companyID);
            return ConvertToProductview(productsLogic);


        }

        public Productview GetProductById(int id)
        {
            ProductLogic productLogic = productManagerLogic.GetProductById(id);
            if (productLogic == null) return null;
            Productview productView = new Productview
            {
                productId = productLogic.productId,
                productName = productLogic.productName,
                productDescription = productLogic.productDescription,
                quantity = productLogic.quantity,
                productPrice = productLogic.productPrice,
                productCategory = productLogic.productCategory
            };

            return productView;
        }

        public void EditProduct(int productid, string productname, string productdescription, int quantity,
            decimal price)
        {
            productManagerLogic.EditProduct(productid, productname, productdescription, quantity, price);
        }

        public void CreateProduct(string productname, string productdescription,  int quantity,
            decimal price, int companyID, string productCategory)
        {
            productManagerLogic.CreateProduct(productname, productdescription, quantity, price, companyID, productCategory);
        }

        public void DeleteProduct(int id)
        {
            productManagerLogic.DeleteProduct(id);
        }

        public List<Productview> GetCategoryProduct(string category, int _companyID)
        {
            var productLogics = productManagerLogic.GetCategoryProduct(category, _companyID);
            return ConvertToProductview(productLogics);
        }

        private List<Productview> ConvertToProductview(List<ProductLogic> productsLogic)
        {
            List<Productview> productsView = new List<Productview>();
            foreach (var productLogic in productsLogic)
            {
                Productview productview = new Productview
                {
                    productId = productLogic.productId,
                    productName = productLogic.productName,
                    productDescription = productLogic.productDescription,
                    quantity = productLogic.quantity,
                    productPrice = productLogic.productPrice,
                    companyID = company.companyID,
                    productCategory = productLogic.productCategory
                };
                productsView.Add(productview);
            }

            return productsView;
        }
    }
}

using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineInventorySystem.Data;
using OnlineInventorySystem.Data.Product;
using OnlineInventorySystem.Logic;

namespace OnlineInventorySystem.UnitTest
{
    [TestClass]
    public class ProductManagerTest
    {
        private ProductManager productManager;
        private IProductContext<ProductDto> testRepository;
        private Company companyTest;

        [TestInitialize]
        public void TestInitialize()
        {
            companyTest = new Company()
            {
                companyID = 1
            };
            testRepository = new MemoryProductRepository();
            productManager = new ProductManager(companyTest, testRepository);
        }
        [TestMethod]
        public void Test_Get_Product_1()
        {
            //Arrange
            ProductLogic productArrange = new ProductLogic()
            {
                productId = 1,
                productName = "Tuinstoel",
                productDescription = "Tuinstoel zwart",
                quantity = 1,
                productPrice = (decimal)25.00,
                productCategory = "Other",
                company = companyTest
            };
            //Act
            productManager.CreateProduct("Tuinstoel", "Tuinstoel zwart", 1, (decimal) 25.00, 1, "Other");
            ProductLogic product = productManager.GetProductById(1);
            //Assert
            Assert.AreEqual(productArrange.productId, product.productId);
            Assert.AreEqual(productArrange.productName, product.productName);
            Assert.AreEqual(productArrange.productCategory, product.productCategory);
            Assert.AreEqual(productArrange.productDescription, product.productDescription);
            Assert.AreEqual(productArrange.productPrice, product.productPrice);
            Assert.AreEqual(productArrange.quantity, product.quantity);
        }

        [TestMethod]
        public void Test_Edit_Product()
        {
            //Arrange
            //Create new product first
            productManager.CreateProduct("Tuinstoel", "Tuinstoel zwart", 1, (decimal)25.00, 1, "Other");

            //Act
            //Original product in database has description: Tuinstoel zwart.
            ProductLogic productEdit = productManager.GetProductById(1);
            productEdit.productDescription = "Tuinstoel wit";
            productManager.EditProduct(productEdit.productId, productEdit.productName, productEdit.productDescription, productEdit.quantity, productEdit.productPrice);
            productEdit = productManager.GetProductById(1);
           
            //Assert
            Assert.AreNotEqual("Tuinstoel zwart", productEdit.productDescription);

            //Cleaning up and resetting product in database, otherwise test 1 will fail.
            productEdit.productDescription = "Tuinstoel wit";
            productManager.EditProduct(productEdit.productId, productEdit.productName, productEdit.productDescription, productEdit.quantity, productEdit.productPrice);
        }
        
       
    }
}

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineInventorySystem.Logic;

namespace OnlineInventorySystem.UnitTest
{
    [TestClass]
    public class ProductManagerTest
    {
        private string TestConnectionString;
        private ProductManagerLogic productManager;

        [TestInitialize]
        public void TestInitialize()
        {
            TestConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OnlineInventorySystemTest";
            productManager = new ProductManagerLogic();
        }
        [TestMethod]
        public void Test_Get_Product()
        {
            //Arrange
            ProductLogic product = new ProductLogic()
            {
                productId = 1,
                productCategory = "Ohter",
                productName = "Tuinstoel",
                companyID = 1,
                productDescription = "tuinstoel zwart",
                productPrice = 25,
                quantity = 1
            };
            //Act

            //Assert
        }
    }
}

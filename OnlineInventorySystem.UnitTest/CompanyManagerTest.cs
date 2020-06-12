using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineInventorySystem.Data;
using OnlineInventorySystem.Data.Company;
using OnlineInventorySystem.Logic;

namespace OnlineInventorySystem.UnitTest
{
    [TestClass]
   public class CompanyManagerTest
    {
        private CompanyManager companyManager;
        private ICompanyRepository<CompanyDTO> testRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            testRepository = new MemoryCompanyRepository();
            companyManager = new CompanyManager(testRepository);
        }

        [TestMethod]
        public void Login()
        {
            //Arrange
            int companyIDArrange = 1;
            //Act
            int companyID = companyManager.CompanyLogin("test@test.nl", "test123");
            //Assert
            Assert.AreEqual(companyIDArrange, companyID);
        }

        [TestMethod]
        public void Get_Company_1()
        {
            //Arrange
            //I want to select a company with companyID 1
            int companyArrangeID = 1;

            //Act
            //Get company by id
            var intAct = companyManager.GetCompanyByID(1).companyID;

            //Assert
            Assert.AreEqual(companyArrangeID, intAct);
        }

        [TestMethod]
        public void Login_Fail()
        {
            //Arrange
            //I want 0 because the code should give me 0 back.
            int Arrange = 0;

            //Act
            int intAct = companyManager.CompanyLogin("fout", "fout");

            //Assert
            Assert.AreEqual(Arrange, intAct);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace OnlineInventorySystem.Data.Company
{
   public class MemoryCompanyRepository : ICompanyRepository<CompanyDTO>
   {
       private CompanyDTO newcompany;
       private List<CompanyDTO> companyList; 
       public MemoryCompanyRepository()
       {
           newcompany = new CompanyDTO()
           {
               companyID = 1,
               companyName = "test@test.nl",
               password = "test123"
           };
           companyList = new List<CompanyDTO>();
           companyList.Add(newcompany);
       }
       public CompanyDTO Login(string username, string psword)
       {
           var company = companyList.FirstOrDefault(c => c.companyName == username && c.password == psword);
           return company;
       }
       
       public CompanyDTO GetCompanyByID(int id)
       {
           var company = companyList.FirstOrDefault(c => c.companyID == id);
           return company;
       }
    }
}

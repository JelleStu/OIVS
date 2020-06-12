using System;
using System.Collections.Generic;
using System.Text;
using OnlineInventorySystem.Data;
using OnlineInventorySystem;
namespace OnlineInventorySystem.Logic
{
    public class CompanyManager
    {
        private readonly CompanyRepository companyRepository;

        public CompanyManager()
        {
            SQLCompanyContext sqlCompanyContext = new SQLCompanyContext();
            companyRepository = new CompanyRepository(sqlCompanyContext);
        } 
        public CompanyManager(ICompanyRepository<CompanyDTO> _context)
        {
            companyRepository = new CompanyRepository(_context);
        }

        public Company GetCompanyByID(int id)
        {
            CompanyDTO companyDto = companyRepository.GetCompanyByID(id);
            Company company = new Company()
            {
                companyID = companyDto.companyID
            };
            return company;
        }

        public int CompanyLogin(string username, string psword)
        { 

          CompanyDTO companyDTO =  companyRepository.Login(username, psword);
          if (companyDTO != null)
          {
              Company company = new Company
              {
                  companyID = companyDTO.companyID
              };
              return company.companyID;
          }
          else
          {
              return 0;
          }
        }
    }
}

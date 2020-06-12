using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineInventorySystem.Data
{
    public class CompanyRepository : ICompanyRepository<CompanyDTO>
    {
        private ICompanyRepository<CompanyDTO> context;

        public CompanyRepository(ICompanyRepository<CompanyDTO> _context)
        {
            context = _context;
        }
        public CompanyDTO  Login(string username, string psword)
        {
           return context.Login(username, psword);
        }

        public CompanyDTO GetCompanyByID(int id)
        {
            return context.GetCompanyByID(id);
        }
    }
}

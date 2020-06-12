using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineInventorySystem.Data
{
    public interface ICompanyRepository<T> where T : CompanyDTO
    { 
        T Login(string username, string psword);
        T GetCompanyByID(int id);
    }
}
